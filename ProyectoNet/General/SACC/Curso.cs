using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Curso
    {
        protected int _id;
        protected List<Alumno> _alumnos;
        protected Docente _docente;
        protected List<DayOfWeek> _diasDeCursada = new List<DayOfWeek>();
        protected Materia _materia;
        protected List<HorarioDeCursada> _horario = new List<HorarioDeCursada>();
        protected string _observaciones;

        protected EspacioFisico _espacioFisico;
        protected Dictionary<InstanciaDeEvaluacion, List<Evaluacion>> _evaluaciones_por_instancias;
        //protected List<InstanciaDeEvaluacion> _instanciasDeEvaluacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return this.Materia.Nombre + " (" + this.Materia.Modalidad.Descripcion + ")"; } set { } }
        public Docente Docente { get { return _docente; } set { _docente = value; } }
        public Materia Materia { get { return _materia; } set { _materia = value; } }
        public string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public EspacioFisico EspacioFisico { get { return _espacioFisico; } set { _espacioFisico = value; } }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<Alumno> Alumnos()
        {
            return _alumnos;
        }

        public Curso()
        {
        }

        public Dictionary<InstanciaDeEvaluacion, List<Evaluacion>> EvaluacionesPorInstancias()
        {
            return _evaluaciones_por_instancias;
        }

        protected void Asignar(Materia materia, Docente docente, EspacioFisico espacio, DateTime inicio, DateTime fin)
        {
            _materia = materia;
            _docente = docente;
            _espacioFisico = espacio;
            FechaInicio = inicio;
            FechaFin = fin;
            _alumnos = new List<Alumno>();
            _evaluaciones_por_instancias = new Dictionary<InstanciaDeEvaluacion, List<Evaluacion>>();
        }

        public Curso(Materia materia, Docente docente, EspacioFisico espacio, DateTime inicio, DateTime fin)
        {
            Asignar(materia, docente, espacio, inicio, fin);
        }

        public Curso(int id, Materia materia, Docente docente, EspacioFisico espacio, DateTime inicio, DateTime fin)
        {
            this._id = id;
            Asignar(materia, docente, espacio, inicio, fin);
        }

        public void AgregarDiaDeCursada(DayOfWeek diaDeLaSemana)
        {
            this._diasDeCursada.Add(diaDeLaSemana);
        }

        public void AgregarHorarioDeCursada(HorarioDeCursada horario)
        {
            this.AgregarDiaDeCursada(horario.Dia);
            this._horario.Add(horario);
        }

        public List<HorarioDeCursada> GetHorariosDeCursada()
        {
            return this._horario;
        }

        public List<DayOfWeek> diasDeCursada()
        {
            return this._diasDeCursada;
        }

        public void ActualizarAlumnosDelCurso(List<Alumno> lista_alumnos)
        {
            //var lista_auxiliar = _alumnos;
            AgregarAlumnos(lista_alumnos);
            //quiar los alumnos que no agregué en el método anterior (lista_alumnos - alumnos original)
            //QuitarAlumnos(lista_alumnos);
        }

        public void AgregarAlumnos(List<Alumno> lista_alumnos)
        {
            lista_alumnos.ForEach(a => this.AgregarAlumno(a));
        }

        public void AgregarAlumno(Alumno un_alumno)
        {
            if (!_alumnos.Contains(un_alumno))
                _alumnos.Add(un_alumno);

        }

        public void QuitarAlumnos(List<Alumno> lista_alumnos)
        {
            lista_alumnos.ForEach(a => this.QuitarAlumno(a));
        }

        public void QuitarAlumno(Alumno un_alumno)
        {
            if (_alumnos.Contains(un_alumno))
                _alumnos.Remove(un_alumno);
        }

        public EspacioFisico GetEspacioFisico()
        {
            return this._espacioFisico;
        }

        public void AgregarEspacioFisico(EspacioFisico espacioFisico)
        {
            this._espacioFisico = espacioFisico;
        }

        internal int esMayorAlfabeticamenteQue(Curso otrocurso)
        {
            return this.Nombre.CompareTo(otrocurso.Nombre);
        }

        public List<InstanciaDeEvaluacion> GetInstanciasDeEvaluacion()
        {
            return this.Materia.Modalidad.InstanciasDeEvaluacion;
        }

        //public void AgregarInstanciasEvaluaciones(List<InstanciaDeEvaluacion> instanciasEvaluaciones)
        //{
        //    instanciasEvaluaciones.ForEach(i => this.AgregarInstanciaEvaluacion(i));
        //}

        //public void AgregarInstanciaEvaluacion(InstanciaDeEvaluacion instanciaEvaluacion)
        //{
        //    this._instanciasDeEvaluacion.Add(instanciaEvaluacion);
        //}

        //public List<Evaluacion> GetInstanciasEvaluaciones()
        //{
        //    return this._instanciasEvaluaciones;
        //}

        //public Evaluacion ObtenerNotas(Evaluacion instancia_evaluacion)
        //{
        //    return  _instanciasEvaluaciones.Find(i => i.Equals(instancia_evaluacion));
        //}

        //public string ObtenerNotaDelAlumno(Alumno alumno, Evaluacion instancia_evaluacion)
        //{
        //    return _instanciasEvaluaciones.Find(i => i.IdAlumno == alumno.Id && i == instancia_evaluacion).Calificacion;
        //}

        //public string ObtenerNotaDelAlumnoEnLaFecha(Alumno alumno, DateTime fecha)
        //{
        //    return _instanciasEvaluaciones.Find(i => i.IdAlumno == alumno.Id && i.Fecha == fecha).Calificacion;
        //}

        //public void AgregarEvaluacion(Evaluacion evaluacion)
        //{
        //    if (!this._evaluaciones_por_instancias.ContainsKey(evaluacion.InstanciaEvaluacion))
        //    {
        //        this._evaluaciones_por_instancias.Add(evaluacion.InstanciaEvaluacion, new List<Evaluacion>());
        //    }
        //    this._evaluaciones_por_instancias[evaluacion.InstanciaEvaluacion].Add(evaluacion);
        //}

        //public void AgregarEvaluaciones(List<Evaluacion> lista_eavluaciones)
        //{
        //    foreach (var evaluacion in lista_eavluaciones)
        //    {
        //        this.AgregarEvaluacion(evaluacion);
        //    }
        //}

        //public List<Evaluacion> EvaluacionesDe(Alumno un_alumno)
        //{
        //    var todasLasEvaluaciones = new List<Evaluacion>();
        //    this._evaluaciones_por_instancias.Values.ToList().ForEach(evaluaciones => todasLasEvaluaciones.AddRange(evaluaciones));
        //    return todasLasEvaluaciones.FindAll(unaEvaluacion => unaEvaluacion.Alumno == un_alumno);
        //}

        //public List<Evaluacion> EvaluacionesDe(InstanciaDeEvaluacion instancia)
        //{
        //    if (!this._evaluaciones_por_instancias.ContainsKey(instancia))
        //        return new List<Evaluacion>();

        //    return this._evaluaciones_por_instancias[instancia];
        //}

        //public Evaluacion EvaluacionDeAlumnoEnUnaInstancia(Alumno un_alumno, InstanciaDeEvaluacion instancia)
        //{
        //    if (!this._evaluaciones_por_instancias.ContainsKey(instancia))
        //        return new EvaluacionNull();

        //    return this._evaluaciones_por_instancias[instancia].Find(e => e.Alumno.Equals(un_alumno));
        //}

        //public List<Evaluacion> GetEvaluaciones()
        //{
        //    var todasLasEvaluaciones = new List<Evaluacion>();
        //    this._evaluaciones_por_instancias.Values.ToList().ForEach(evaluaciones => todasLasEvaluaciones.AddRange(evaluaciones));
        //    return todasLasEvaluaciones;
        //}


        //está bien esto??
        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((Curso)obj).Id == this.Id) { return true; }
            return false;
        }
    }
}
