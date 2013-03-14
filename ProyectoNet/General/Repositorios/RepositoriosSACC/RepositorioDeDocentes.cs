using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeDocentes
    {
        private IConexionBD conexion_bd { get; set; }
        public static List<Docente> docentes { get; set; }

        public RepositorioDeDocentes(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
            //if (docentes == null)
            //{
            //    docentes = new List<Docente>()
            //    {
            //        new Docente(0, 23425655, "Jose","Mujica"),
            //        new Docente(1, 17546899, "Profe de Literatura",""),
            //        new Docente(2, 17562845, "Newton",""),
            //        new Docente(3, 13457774, "Pedro Picapiedras",""),
            //        new Docente(4, 20454632, "Curie","")
            //    };
            //}
        }

        public Docente GetDocenteById(int id)
        {
            return GetDocentes().Find(d => d.Id.Equals(id));
        }

        public Docente GetDocenteByNombre(string nombre)
        {
            return GetDocentes().Find(m => m.Nombre.Equals(nombre));
        }

        public Docente GetDocenteByDNI(int dni)
        {
            return GetDocentes().Find(d => d.Dni.Equals(dni));
        }

        public List<Docente> GetDocentes()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Docentes");
            docentes = new List<Docente>();

            tablaDatos.Rows.ForEach(row =>
            {

                Docente docente = new Docente
                {
                    Id = row.GetSmallintAsInt("Id"),
                    Dni = row.GetInt("Documento"),
                    Apellido = row.GetString("Apellido"),
                    Nombre = row.GetString("Nombre")
                };

                docentes.Add(docente);
            });

            return docentes;
        }


        public void GuardarDocente(Docente un_docente, Usuario usuario)
        {
            var parametros = Parametros(un_docente, usuario, 0);

            conexion_bd.EjecutarSinResultado("SACC_Ins_Docente", parametros);
            
            docentes.Add(un_docente);
        }

        public void QuitarDocente(Docente un_docente, Usuario usuario)
        {
            var idBaja = CrearBaja(usuario);

            var parametros = Parametros(un_docente, usuario, idBaja);

            conexion_bd.EjecutarSinResultado("SACC_Upd_Del_Docente", parametros);
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


        private static Dictionary<string, object> Parametros(Docente un_docente, Usuario usuario, int id_baja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdDocente", un_docente.Id);
            //parametros.Add("@NroDocumento", un_docente.Dni);
            //parametros.Add("@Apellido", un_docente.Apellido);
            //parametros.Add("@Nombre", un_docente.Nombre);
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            if (id_baja != 0)
                parametros.Add("@idBaja", id_baja); 

            return parametros;
        }
    }
}
