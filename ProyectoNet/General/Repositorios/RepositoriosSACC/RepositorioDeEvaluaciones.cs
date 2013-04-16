using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeEvaluaciones
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeEvaluaciones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public Dictionary<Dictionary<Alumno,InstanciasDeEvaluacion>,string> GetEvaluacionesPorCursoYAlumno(int id_curso, int id_alumno)
        {

            return new Dictionary<Dictionary<Alumno, InstanciasDeEvaluacion>, string>();
        
        }

    }
}
