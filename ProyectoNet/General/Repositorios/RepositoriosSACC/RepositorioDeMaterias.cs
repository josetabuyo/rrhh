using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeMaterias : RepositorioLazy<List<Materia>> , General.Repositorios.IRepositorioDeMaterias
    {
        protected IConexionBD conexion_bd { get; set; }
        protected static List<Materia> materias { get; set; }
        protected IRepositorioDeModalidades repo_modalidades;
        protected IRepositorioDeCursos repo_cursos;
        
        public RepositorioDeMaterias(IConexionBD conexion, IRepositorioDeCursos repo_cursos,IRepositorioDeModalidades repo_modalidades)
        {
            this.conexion_bd = conexion;
            this.repo_modalidades = repo_modalidades;
            this.repo_cursos = repo_cursos;
            this.cache = new CacheNoCargada<List<Materia>>();
        }

        public Materia GetMateriaById(int id)
        {
            var materias = GetMaterias().Find(m => m.Id.Equals(id));
            return materias;
        }

        public Materia GetMateriaByNombre(string nombre)
        {
            return GetMaterias().Find(m => m.Nombre.Equals(nombre));
        }

        public List<Materia> GetMaterias()
        {
            return cache.Ejecutar(ObtenerMateriasDesdeLaBase, this);
        }

        public List<Materia> ObtenerMateriasDesdeLaBase()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Materias");
            materias = new List<Materia>();

            tablaDatos.Rows.ForEach(row =>
            {
                Ciclo ciclo = new Ciclo(row.GetSmallintAsInt("idCiclo"), row.GetString("NombreCiclo"));                

                Materia materia = new Materia
                {
                    Id = row.GetSmallintAsInt("Id"),
                    Nombre = row.GetString("Nombre"),
                    Modalidad = repo_modalidades.GetModalidadById(row.GetInt("IdModalidad")), 
                    Ciclo = ciclo
                };

                materias.Add(materia);
            });

            materias.Sort((materia1, materia2) => materia1.esMayorAlfabeticamenteQue(materia2));
            return materias;
        }

        public Materia GuardarMaterias(Materia materia, Usuario usuario)
        {
            var parametros = Parametros(materia, usuario, 0);

            conexion_bd.EjecutarSinResultado("SACC_Ins_Materia", parametros);

            return materia;
        }

        public Materia ActualizarMaterias(Materia materia, Usuario usuario)
        {
            var parametros = Parametros(materia, usuario, 0);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Materia", parametros);

            return materia;
        }

        public void QuitarMateria(Materia materia, Usuario usuario)
        {           
            var idBaja = CrearBaja(usuario);

            var parametros = Parametros(materia, usuario, idBaja);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Materia", parametros);
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


        public bool MateriaAsignadaACurso(Materia una_materia)
        {
            List<Curso> cursos = repo_cursos.GetCursos();
            return cursos.Exists(c => c.Materia.Id == una_materia.Id);
        }

        private static Dictionary<string, object> Parametros(Materia materia, Usuario usuario,int id_baja)
        {
            var parametros = new Dictionary<string, object>();
            if (materia.Id != 0)
                parametros.Add("@IdMateria", materia.Id);
            
            parametros.Add("@Nombre", materia.Nombre);
            parametros.Add("@IdModalidad", materia.Modalidad.Id);
            parametros.Add("@Ciclo", materia.Ciclo.Id);
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            if (id_baja != 0)            
                parametros.Add("@IdBaja", id_baja); 
            
            return parametros;
        }

        public List<Ciclo> GetCiclos()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Ciclos");
            List<Ciclo> ciclos = new List<Ciclo>();

            tablaDatos.Rows.ForEach(row =>
            {
                Ciclo ciclo = new Ciclo(row.GetSmallintAsInt("idCiclo"), row.GetString("NombreCiclo"));

                ciclos.Add(ciclo);
            });

            return ciclos;
        }
    }
}
