using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class Articulador
    {
        public Articulador() { }

        public bool DecimeSiAprobo(Alumno alumno, Curso curso, RepositorioDeEvaluacion repo_evaluacion)
        {
            var evaluaciones =  repo_evaluacion.GetEvaluacionesPorCursoYAlumno(curso, alumno);
            var eval = evaluaciones.Find(e => e.InstanciaEvaluacion.Id == 6);

            if (eval == null)
                eval = new EvaluacionNull();

            return eval.Aprobado();            
        }
    }
}
