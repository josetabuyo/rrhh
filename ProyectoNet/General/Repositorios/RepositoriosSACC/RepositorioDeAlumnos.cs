using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeAlumnos
    {

         public IConexionBD conexion_bd { get; set; }
        public static List<Alumno> alumnos { get; set; }

        public RepositorioDeAlumnos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;    
        }

        public List<Alumno> GetAlumnos()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Alumnos");
            alumnos = new List<Alumno>();

            tablaDatos.Rows.ForEach(row =>
            {               
                Modalidad modeliadad_aux = new Modalidad(row.GetInt("IdModalidad"), row.GetString("ModalidadDescripcion"));
                Alumno alumno =  new Alumno
                {
                    Id = row.GetInt("Id"),
                    Nombre = row.GetString("Nombre"),
                    Apellido = row.GetString("Apellido"),
                    Documento = row.GetInt("Documento"),
                    Telefono = row.GetString("Telefono"),
                    Mail = row.GetString("Mail"),
                    Direccion = row.GetString("Direccion"),
                //    Area = new Area(1, row.GetString("Area")),
                    Modalidad = modeliadad_aux
                };

                alumnos.Add(alumno);
            });

            alumnos.Sort((alumno1, alumno2) => alumno1.esMayorAlfabeticamenteQue(alumno2));

            return alumnos;
        }

        public void GuardarAlumno(Alumno un_alumno, Usuario usuario)
        {
            var parametros = Parametros(un_alumno, usuario, 0);

            try
            {
                conexion_bd.EjecutarSinResultado("SACC_Ins_Alumno", parametros);
            }
            catch (Exception)
            {

                conexion_bd.EjecutarSinResultado("SACC_Upd_Del_Alumno", parametros);
            }
            
        }


        public Alumno GetAlumnoByDNI(int dni)
        {
            var parametros = new Dictionary<string, object>();
            List<Alumno> alumnos_dni = new List<Alumno>();
            parametros.Add("@DocumentoPersona", dni);

            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_DatosPersonales", parametros);
        
            tablaDatos.Rows.ForEach(row =>
            {
                alumnos_dni.Add(new Alumno
                {
                     Id = row.GetInt("Id"),
                     Nombre = row.GetString("Nombre"),
                     Apellido = row.GetString("Apellido"),
                     Documento = row.GetInt("Documento"),
                     Telefono = row.GetString("Telefono"),
                     Mail = row.GetString("Email_Personal"),
                     Direccion = row.GetString("Direccion"),
                   //  Area = new Area(1),
                     Modalidad = new Modalidad(1, "FINES Puro") });
            });
            return alumnos_dni.First();
        }

        public Alumno ActualizarAlumno(Alumno alumno, Usuario usuario)
        {
            var parametros = Parametros(alumno, usuario, 0);

            conexion_bd.EjecutarSinResultado("SACC_Upd_Del_Alumno", parametros);

            return alumno;
        }

        public void QuitarAlumno(Alumno un_alumno, Usuario usuario)
        {
            var idBaja = CrearBaja(usuario);

            var parametros = Parametros(un_alumno, usuario, idBaja);

            conexion_bd.EjecutarSinResultado("SACC_Upd_Del_Alumno", parametros);
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }

        public List<Modalidad> GetModalidades()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_GetModalidades");
            List<Modalidad> modalidades = new List<Modalidad>();

            tablaDatos.Rows.ForEach(row =>
            {
                Modalidad modalidad = new Modalidad(row.GetInt("IdModalidad"), row.GetString("ModalidadDescripcion"));

                modalidades.Add(modalidad);
            });

            return modalidades;
        }

        public bool AlumnoAsignadoACurso(Alumno un_alumno)
        {
            List<Curso> cursos = new RepositorioDeCursos(conexion_bd).GetCursos();
            return cursos.Exists(c => c.Alumnos().Contains(un_alumno));
        }

        private static Dictionary<string, object> Parametros(Alumno un_alumno, Usuario usuario, int id_baja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPersona", un_alumno.Id);
            parametros.Add("@IdModalidad", un_alumno.Modalidad.Id);
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            if (id_baja != 0)
                parametros.Add("@idBaja", id_baja);

            return parametros;
        }

    }
}
