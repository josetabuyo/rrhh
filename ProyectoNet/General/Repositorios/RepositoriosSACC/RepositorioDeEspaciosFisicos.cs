using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeEspaciosFisicos
    {
        private IConexionBD conexion_bd { get; set; }
        public static List<EspacioFisico> espacios_fisicos { get; set; }
        
        public RepositorioDeEspaciosFisicos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        //public Materia GetMateriaById(int id)
        //{
        //    return GetMaterias().Find(m => m.Id.Equals(id));
        //}

        //public Materia GetMateriaByNombre(string nombre)
        //{
        //    return GetMaterias().Find(m => m.Nombre.Equals(nombre));
        //}

        //public List<Materia> GetMaterias()
        //{
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Materias");
        //    materias = new List<Materia>();

        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        Ciclo ciclo = new Ciclo(row.GetSmallintAsInt("idCiclo"), row.GetString("NombreCiclo"));                
        //        Modalidad modeliadad_aux = new Modalidad(row.GetInt("IdModalidad"), row.GetString("ModalidadDescripcion"));
                
        //        Materia materia = new Materia
        //        {
        //            Id = row.GetSmallintAsInt("Id"),
        //            Nombre = row.GetString("Nombre"),
        //            Modalidad = modeliadad_aux,
        //            Ciclo = ciclo
        //        };

        //        materias.Add(materia);
        //    });

        //    materias.Sort((materia1, materia2) => materia1.esMayorAlfabeticamenteQue(materia2));
        //    return materias;
        //}

        //public Materia GuardarMaterias(Materia materia, Usuario usuario)
        //{
        //    var parametros = Parametros(materia, usuario, 0);

        //    conexion_bd.EjecutarSinResultado("SACC_Ins_Materia", parametros);

        //    return materia;
        //}

        //public Materia ActualizarMaterias(Materia materia, Usuario usuario)
        //{
        //    var parametros = Parametros(materia, usuario, 0);

        //    conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Materia", parametros);

        //    return materia;
        //}

        //public void QuitarMateria(Materia materia, Usuario usuario)
        //{           
        //    var idBaja = CrearBaja(usuario);

        //    var parametros = Parametros(materia, usuario, idBaja);

        //    conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Materia", parametros);
        //}

        //private int CrearBaja(Usuario usuario)
        //{
        //    var parametros = new Dictionary<string, object>();

        //    parametros.Add("@Motivo", ""); 
        //    parametros.Add("@IdUsuario", usuario.Id);
        //    parametros.Add("@Fecha", "");

        //    int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

        //    return id;
        //}


        //public bool MateriaAsignadaACurso(Materia una_materia)
        //{
        //    List<Curso> cursos = new RepositorioDeCursos(conexion_bd).GetCursos();
        //    return cursos.Exists(c => c.Materia.Id == una_materia.Id);
        //}

        //private static Dictionary<string, object> Parametros(Materia materia, Usuario usuario,int id_baja)
        //{
        //    var parametros = new Dictionary<string, object>();
        //    if (materia.Id != 0)
        //        parametros.Add("@IdMateria", materia.Id);
            
        //    parametros.Add("@Nombre", materia.Nombre);
        //    parametros.Add("@IdModalidad", materia.Modalidad.Id);
        //    parametros.Add("@Ciclo", materia.Ciclo.Id);
        //    parametros.Add("@IdUsuario", usuario.Id);
        //    parametros.Add("@Fecha", "");
        //    if (id_baja != 0)            
        //        parametros.Add("@IdBaja", id_baja); 
            
        //    return parametros;
        //}

        //public List<Ciclo> GetCiclos()
        //{
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Ciclos");
        //    List<Ciclo> ciclos = new List<Ciclo>();

        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        Ciclo ciclo = new Ciclo(row.GetSmallintAsInt("idCiclo"), row.GetString("NombreCiclo"));

        //        ciclos.Add(ciclo);
        //    });

        //    return ciclos;
        //}


        public List<Edificio> GetEdificios()
        {
           return new List<Edificio>();
        }
    }
}
