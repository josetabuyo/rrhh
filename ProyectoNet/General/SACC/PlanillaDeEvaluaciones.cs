using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;


namespace General
{
    public class PlanillaDeEvaluaciones
    {
        private Curso _un_curso;
        
        //private DateTime _fechaDesde;
        //private DateTime _fechaHasta;
        private Dictionary<InstanciaDeEvaluacion, List<Evaluacion>> _evaluaciones_por_instancias;
        //private CalendarioDeCurso _un_calendario;

        public Curso Curso { get { return _un_curso; } }
        //public DateTime FechaDesde { get { return _fechaDesde; } }
        //public DateTime FechaHasta { get { return _fechaHasta; } }

        public Dictionary<InstanciaDeEvaluacion, List<Evaluacion>> Evaluaciones { get { return _evaluaciones_por_instancias; } }
        //public CalendarioDeCurso Calendario { get { return _un_calendario; } }

        public PlanillaDeEvaluaciones() { }

        public PlanillaDeEvaluaciones(Curso un_curso, List<InstanciaDeEvaluacion> instanciasDeEvaluaciones)
        {
            this._un_curso = un_curso;
            this._evaluaciones_por_instancias = new Dictionary<InstanciaDeEvaluacion, List<Evaluacion>>();

            instanciasDeEvaluaciones.ForEach( instancia => _evaluaciones_por_instancias.Add(instancia, new List<Evaluacion>()));
        }

        //public void AgregarEvaluacion(Evaluacion evaluacion)
        //{             
        //    this._evaluaciones_por_instancias[evaluacion.InstanciaEvaluacion].Add(evaluacion);
        //}

        private bool AlumnoPerteneceAlcurso(Alumno un_alumno)
        {
            return _un_curso.Alumnos().Contains(un_alumno);
        }

        //public List<Evaluacion> GetEvaluacionesPorAlumno(Alumno un_alumno)
        //{
        //    var todasLasEvaluaciones = new List<Evaluacion>();
        //    this._evaluaciones_por_instancias.Values.ToList().ForEach(evaluaciones => todasLasEvaluaciones.AddRange(evaluaciones));
        //    return todasLasEvaluaciones.FindAll(unaEvaluacion => unaEvaluacion.Alumno == un_alumno);
        //}

        //public List<InstanciaDeEvaluacion> GetInstanciasDeEvaluacion()
        //{
        //    return this._evaluaciones_por_instancias.Keys.ToList();
        //}


        public Evaluacion GetEvaluacionPorAlumnoEInstancia(Alumno un_alumno_del_curso, InstanciaDeEvaluacion primer_parcial)
        {
            var evaluaciones = this._evaluaciones_por_instancias[primer_parcial];
            return evaluaciones.Find(unaEvaluacion => unaEvaluacion.Alumno == un_alumno_del_curso);
        }
    }
}