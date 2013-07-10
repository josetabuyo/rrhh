using System;
using General;

namespace General
{
    public class Evaluacion
    {
        private  InstanciaDeEvaluacion _instanciaEvaluacion;
        private Alumno _alumno;
        private Curso _curso;
        private Calificacion _calificacion;
        private DateTime _fecha;


        public InstanciaDeEvaluacion InstanciaEvaluacion { get { return _instanciaEvaluacion; } set { _instanciaEvaluacion = value; } }
        public Calificacion Calificacion { get { return _calificacion; } set { _calificacion = value; } }
        public Alumno Alumno { get { return _alumno; } set { _alumno = value; } }
        public Curso Curso { get { return _curso; } set { _curso = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        public Evaluacion() { }

        public Evaluacion(InstanciaDeEvaluacion instancia_evaluacion, Alumno alumno, Curso curso, Calificacion calificacion, DateTime fecha)
        {
            this._instanciaEvaluacion = instancia_evaluacion;
            this._calificacion = calificacion;
            this._alumno = alumno;
            this._curso = curso;
            this._fecha = fecha;
        }

         public void CambiarCalificacionPor(int nota)
         {
             Calificacion calificacion_nueva = new CalificacionNumerica(nota);
             this._calificacion = calificacion_nueva; 
         }
    }
}
