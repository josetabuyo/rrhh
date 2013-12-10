using System;
using System.Collections.Generic;
using System.Linq;
using General;

namespace General.Repositorios
{
    public class RepositorioDeAlumnos : RepositorioLazy<List<Alumno>>, General.Repositorios.IRepositorioDeAlumnos
    {
        protected IConexionBD conexion_bd { get; set; }

        protected IRepositorioDeModalidades repo_modalidades;
        protected IRepositorioDeCursos repo_cursos;
        //protected Articulador articulador;

        public RepositorioDeAlumnos(IConexionBD conexion, IRepositorioDeCursos repo_cursos, IRepositorioDeModalidades repo_modalidades)
        {
            this.conexion_bd = conexion;
            this.repo_modalidades = repo_modalidades;
            this.repo_cursos = repo_cursos;
            this.cache = new CacheNoCargada<List<Alumno>>();
        }

        public List<Alumno> GetAlumnos()
        {
            return cache.Ejecutar(ObtenerAlumnosDesdeLaBase, this);
        }

        public List<Alumno> ObtenerAlumnosDesdeLaBase()
        {

            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Alumnos");
            var alumnos = new List<Alumno>();


            tablaDatos.Rows.ForEach(row =>
            {
                var baja = 0;
                if (!(row.GetObject("IdBaja") is DBNull))
                    baja = (int)row.GetObject("IdBaja");

                var lugar_de_trabajo = "";
                if (!(row.GetObject("LugarTrabajo") is DBNull))
                    lugar_de_trabajo = (string)row.GetObject("LugarTrabajo");

                Area area = ConstruirAreaDeAlumno(row);

                Organismo organismo = new Organismo(0, "Sin Organismo Asignado");
                if (!(row.GetObject("IdOrganismo") is DBNull))
                {
                    organismo.Id = row.GetSmallintAsInt("IdOrganismo");
                    organismo.Descripcion = row.GetString("DescripcionOrganismo");
                }


                List<Area> areas_alumno = new List<Area>();
                areas_alumno.Add(area);
                Alumno alumno = new Alumno
                {
                    Id = row.GetInt("Id"),
                    Nombre = row.GetString("Nombre"),
                    Apellido = row.GetString("Apellido"),
                    Documento = row.GetInt("Documento"),
                    Telefono = row.GetString("Telefono"),
                    Mail = row.GetString("Mail"),
                    Direccion = row.GetString("Direccion"),
                    LugarDeTrabajo = lugar_de_trabajo,
                    FechaDeNacimiento = ObtenerFechaDeNacimiento(row),
                    //EstadoDeCursada = articulador.EstadoDelAlumno(
                    //CicloCursado
                    Organismo = organismo,
                    Areas = areas_alumno,
                    Modalidad = repo_modalidades.GetModalidadById(row.GetInt("IdModalidad")),
                    Baja = baja
                };


                alumnos = CorteDeControlAreasDeAlumno(alumnos, alumno);
            });

            //ordeno por modalidad, apellido, nombre
            alumnos.Sort((alumno1, alumno2) => alumno1.esMayorAlfabeticamenteQue(alumno2));
            return alumnos;
        }

        private DateTime ObtenerFechaDeNacimiento(RowDeDatos row)
        {
            if (row.GetObject("FechaNacimiento") is DBNull)
            {
                return DateTime.Today;
            }
            return row.GetDateTime("FechaNacimiento");
        }

        private DateTime ObtenerFechaDeIngreso(RowDeDatos row)
        {
            if (row.GetObject("FechaIngresoMDS") is DBNull)
            {
                return DateTime.Today;
            }
            return row.GetDateTime("FechaIngresoMDS");
        }


        private static List<Alumno> CorteDeControlAreasDeAlumno(List<Alumno> alumnos, Alumno alumno)
        {
            if (alumnos.Exists(a => a.Documento == alumno.Documento))
            {
                alumnos.Find(a => a.Documento == alumno.Documento).Areas.AddRange(alumno.Areas);

            }
            else
            {
                alumnos.Add(alumno);
            }

            return alumnos;
        }

        private static Area ConstruirAreaDeAlumno(RowDeDatos row)
        {
            Area area = new Area(1, "Ministerio de Desarrollo Social - Externo"); //Se moquean los que no son del Ministerio
            if (!(row.GetObject("IdArea") is DBNull))
            {
                area = new Area(row.GetSmallintAsInt("IdArea"), row.GetString("NombreArea"));
            }
            return area;
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
                BorrarBaja(un_alumno);
                conexion_bd.EjecutarSinResultado("SACC_Upd_Del_Alumno", parametros);
            }

        }

        public AlumnoPerfil GetAlumnoPerfilById(int id)
        {

            return GetAlumnosPerfil().Find(ap => ap.IdAlumno == id);
        }

        public List<AlumnoPerfil> GetAlumnosPerfil()
        {
            var perfiles = new List<AlumnoPerfil>();
            var parametros = new Dictionary<string, object>();
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_AlumnosPerfil");
            tablaDatos.Rows.ForEach(row =>
            {
                var perfil = new AlumnoPerfil()
                {
                    Id = row.GetInt("Id"),
                    IdAlumno = row.GetInt("IdPersona"),
                    Asistencia = row.GetString("Asistencia"),
                    Puntualidad = row.GetString("Puntualidad"),
                    Compromiso = row.GetString("NivelCompromiso"),
                    Participacion = row.GetString("Participacion"),
                    Cumplimiento = row.GetString("CumplimientoTareas"),
                    Integracion = row.GetString("IntegracionGrupo"),
                    Respeto = row.GetString("RespetoNormas"),
                    Responsabilidad = row.GetString("Responsabilidad"),
                    Otro1 = row.GetString("Otro1"),
                    Otro2 = row.GetString("Otro2")
                };
            });

            return perfiles;
        }

        public Alumno GetAlumnoByDNI(int dni)
        {
            var parametros = new Dictionary<string, object>();
            var articulador = new Articulador();
            List<Alumno> alumnos_dni = new List<Alumno>();
            parametros.Add("@DocumentoPersona", dni);

            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_DatosPersonales", parametros);

            List<Curso> cursos = repo_cursos.GetCursos();

            tablaDatos.Rows.ForEach(row =>
            {
                var modaldidad = new Modalidad();
                var baja = 0;
                if (!(row.GetObject("IdModalidad") is DBNull))
                    modaldidad = repo_modalidades.GetModalidadById(row.GetInt("IdModalidad"));

                if (!(row.GetObject("BajaAlumno") is DBNull))
                {
                    baja = row.GetInt("BajaAlumno");
                    modaldidad = repo_modalidades.ModalidadNull();
                }

                if (!(row.GetObject("BajaDocente") is DBNull))
                    baja = row.GetInt("BajaDocente");

                Area area = ConstruirAreaDeAlumno(row);
                List<Area> areas_alumno = new List<Area>();
                areas_alumno.Add(area);

                Alumno alumno = new Alumno
                {
                     Id = row.GetInt("Id"),
                     Nombre = row.GetString("Nombre"),
                     Apellido = row.GetString("Apellido"),
                     Documento = row.GetInt("Documento"),
                     Telefono = row.GetString("Telefono"),
                     Mail = row.GetString("Email_Personal"),
                     Direccion = row.GetString("Direccion"),
                     FechaDeNacimiento = ObtenerFechaDeNacimiento(row),
                     FechaDeIngreso = ObtenerFechaDeIngreso(row),
                     Areas = areas_alumno,
                     Modalidad = modaldidad,
                     Baja = baja
                };



                alumnos_dni = CorteDeControlAreasDeAlumno(alumnos_dni, alumno);

            });


            alumnos_dni.First().EstadoDeAlumno = articulador.EstadoDelAlumno(alumnos_dni.First(), repo_cursos, cursos);
            alumnos_dni.First().CicloCursado = articulador.CicloDelAlumno(alumnos_dni.First(), repo_cursos, cursos);

            return alumnos_dni.First();
        }

        public Alumno ActualizarAlumno(Alumno alumno, Usuario usuario)
        {
            var parametros = Parametros(alumno, usuario, 0);

            //deberia borrar la baja asociada
            BorrarBaja(alumno);

            conexion_bd.EjecutarSinResultado("SACC_Upd_Del_Alumno", parametros);

            return alumno;
        }

        private void BorrarBaja(Alumno alumno)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@IdBaja", alumno.Baja);

            conexion_bd.EjecutarSinResultado("SACC_Del_Baja", parametros);
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

        public bool AlumnoAsignadoACurso(Alumno un_alumno)
        {
            List<Curso> cursos = repo_cursos.GetCursos();
            return cursos.Exists(c => c.Alumnos().Contains(un_alumno));
        }


        public List<Organismo> GetOrganismos()
        {

            var tablaDatos = conexion_bd.Ejecutar("dbo.CRED_Get_Organismos");
            List<Organismo> organismos = new List<Organismo>();

            tablaDatos.Rows.ForEach(row =>
            {
                Organismo organismo = new Organismo
               {
                   Id = row.GetSmallintAsInt("Id"),
                   Descripcion = row.GetString("Descripcion")
               };

                organismos.Add(organismo);
            });

            return organismos;
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
