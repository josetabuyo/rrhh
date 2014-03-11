using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeDocentes : RepositorioLazy<List<Docente>>, General.Repositorios.IRepositorioDeDocentes
    {
        protected static List<Docente> docentes { get; set; }
        protected IRepositorioDeCursos repo_cursos;


        public RepositorioDeDocentes(IConexionBD conexion, IRepositorioDeCursos repo_cursos)
            :base(conexion)
        {
            this.repo_cursos = repo_cursos;
            this.cache = new CacheNoCargada<List<Docente>>();
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
            return cache.Ejecutar(ObtenerDocentesDesdeLaBase, this);
        }

        public List<Docente> ObtenerDocentesDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.SACC_Get_Docentes");
            docentes = new List<Docente>();

            tablaDatos.Rows.ForEach(row =>
            {

                Docente docente = new Docente
                {
                    Id = row.GetSmallintAsInt("Id"),
                    Dni = row.GetInt("Documento"),
                    Apellido = row.GetString("Apellido"),
                    Nombre = row.GetString("Nombre"),
                    Telefono = row.GetString("Telefono"),
                    Mail = row.GetString("Mail"),
                    Direccion = row.GetString("Direccion")
                };

                docentes.Add(docente);
            });

            docentes.Sort((docente1, docente2) => docente1.esMayorAlfabeticamenteQue(docente2));
            return docentes;
        }


        public void GuardarDocente(Docente un_docente, Usuario usuario)
        {
            var parametros = Parametros(un_docente, usuario, 0);

            try
            {
                conexion.EjecutarSinResultado("SACC_Ins_Docente", parametros);
            }
            catch (Exception)
            {

                conexion.EjecutarSinResultado("SACC_Upd_Del_Docente", parametros);
                BorrarBaja(un_docente);
            }        
            
            docentes.Add(un_docente);
        }

        private void BorrarBaja(Docente docente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@IdBaja", docente.Baja);

            conexion.EjecutarSinResultado("SACC_Del_Baja", parametros);
        }

        public void QuitarDocente(Docente un_docente, Usuario usuario)
        {
                var idBaja = CrearBaja(usuario);

                var parametros = Parametros(un_docente, usuario, idBaja);

                conexion.EjecutarSinResultado("SACC_Upd_Del_Docente", parametros);        
        }

        public bool DocenteAsignadoACurso(Docente un_docente)
        {
            List<Curso> cursos = repo_cursos.GetCursos();
            return cursos.Exists(c => c.Docente.Id == un_docente.Id);
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }


        private static Dictionary<string, object> Parametros(Docente un_docente, Usuario usuario, int id_baja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdDocente", un_docente.Id);
            //parametros.Add("@Documento", un_docente.Dni);
            //parametros.Add("@Apellido", un_docente.Apellido);
            //parametros.Add("@Nombre", un_docente.Nombre);
            //parametros.Add("@Baja", "baja");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            if (id_baja != 0)
                parametros.Add("@idBaja", id_baja); 

            return parametros;
        }
    }
}
