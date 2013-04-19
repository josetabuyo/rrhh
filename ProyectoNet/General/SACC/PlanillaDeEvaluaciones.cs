using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.SACC;


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

        public void AgregarEvaluacion(Evaluacion evaluacion)
        {             
            this._evaluaciones_por_instancias[evaluacion.InstanciaEvaluacion].Add(evaluacion);
        }

        //private void AgregarInasistencia(Alumno un_alumno, DateTime fecha)
        //{
        //    this._evaluaciones_por_instancias[un_alumno].Add(new InasistenciaNormal(fecha));
        //}

        //private void AgregarAsistencia(Alumno un_alumno, DateTime fecha)
        //{
        //    this._evaluaciones_por_instancias[un_alumno].Add(new AsistenciaIndeterminada(fecha));
        //}

        //private void AgregarAlAlumnoSiNoEsta(Alumno un_alumno)
        //{
        //    if (!this._evaluaciones_por_instancias.ContainsKey(un_alumno))
        //        this._evaluaciones_por_instancias.Add(un_alumno, new List<Asistencia>());	            
        //}

        //private Validador Validador()
        //{
        //    return new Validador();
        //}

        //public void AgregarAsistenciaPara(Alumno un_alumno, DateTime fecha)
        //{
        //    List<DateTime> diasCursable = this.GetDiasDeCursadaEntre(this.FechaDesde, this.FechaHasta);

        //    Validador().EstaEnLaColeccion(_un_curso.Alumnos(), un_alumno, "Alumnos");
        //    Validador().EstaEnLaColeccion(diasCursable, fecha, "Dias de Cursada");

        //    AgregarAlAlumnoSiNoEsta(un_alumno);
        //    AgregarAsistencia(un_alumno, fecha);        
        //}

        private bool AlumnoPerteneceAlcurso(Alumno un_alumno)
        {
            return _un_curso.Alumnos().Contains(un_alumno);
        }

        public List<Evaluacion> GetEvaluacionesPorAlumno(Alumno un_alumno)
        {
            var todasLasEvaluaciones = new List<Evaluacion>();
            this._evaluaciones_por_instancias.Values.ToList().ForEach(evaluaciones => todasLasEvaluaciones.AddRange(evaluaciones));
            return todasLasEvaluaciones.FindAll(unaEvaluacion => unaEvaluacion.Alumno == un_alumno);
        }

        public List<InstanciaDeEvaluacion> GetInstanciasDeEvaluacion()
        {
            return this._evaluaciones_por_instancias.Keys.ToList();
        }


        public Evaluacion GetEvaluacionPorAlumnoEInstancia(Alumno un_alumno_del_curso, InstanciaDeEvaluacion primer_parcial)
        {
            var evaluaciones = this._evaluaciones_por_instancias[primer_parcial];
            return evaluaciones.Find(unaEvaluacion => unaEvaluacion.Alumno == un_alumno_del_curso);
        }
    }
}