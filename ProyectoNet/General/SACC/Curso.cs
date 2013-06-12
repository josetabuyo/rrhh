using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Curso
    {
        
        private int _id;
        private string _nombre;
        private List<Alumno> _alumnos;
        private Docente _docente;
        private List<DayOfWeek> _diasDeCursada = new List<DayOfWeek>();
        private Materia _materia;
        private List<HorarioDeCursada> _horario = new List<HorarioDeCursada>();
       
        private EspacioFisico _espacioFisico;
        private Dictionary<InstanciaDeEvaluacion, List<Evaluacion>> _evaluaciones_por_instancias; 
        //private List<InstanciaDeEvaluacion> _instanciasDeEvaluacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return this.Materia.Nombre + " (" + this.Materia.Modalidad.Descripcion + ")"; } set { } }
        public Docente Docente { get { return _docente; } set { _docente = value; } }
        public Materia Materia { get{ return _materia; } set{_materia = value;} }
       
        public EspacioFisico EspacioFisico { get { return _espacioFisico; } set { _espacioFisico = value; } }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<Alumno> Alumnos()
        {
            return _alumnos;
        }

        public Dictionary<InstanciaDeEvaluacion, List<Evaluacion>> EvaluacionesPorInstancias()
        {
            return _evaluaciones_por_instancias;
        }

        public Curso()
        {
            _alumnos = new List<Alumno>();
            _evaluaciones_por_instancias = new Dictionary<InstanciaDeEvaluacion, List<Evaluacion>>();
        }
  
        public Curso(int id, string nombre) 
        { 
            this._id = id;
            this._nombre = nombre;

            _alumnos = new List<Alumno>();
            _evaluaciones_por_instancias = new Dictionary<InstanciaDeEvaluacion, List<Evaluacion>>();

        }

        public Curso(int id, string nombre, Materia materia, Docente docente)
        {
            this._id = id;
            this._nombre = nombre;
            this._materia = materia;
            this._docente = docente;
            _alumnos = new List<Alumno>();
            _evaluaciones_por_instancias = new Dictionary<InstanciaDeEvaluacion, List<Evaluacion>>();
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
        
        public List<DayOfWeek> diasDeCursada(){ 
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

        public void AgregarEvaluacion(Evaluacion evaluacion)
        {
            if (!this._evaluaciones_por_instancias.ContainsKey(evaluacion.InstanciaEvaluacion))
            {
                this._evaluaciones_por_instancias.Add(evaluacion.InstanciaEvaluacion, new List<Evaluacion>());
            }
            this._evaluaciones_por_instancias[evaluacion.InstanciaEvaluacion].Add(evaluacion);
        }

        public List<InstanciaDeEvaluacion> Instancias()
        {
            return this._materia.Modalidad.EstructuraDeEvaluacion.Instancias();
        }

        public void AgregarEvaluaciones(List<Evaluacion> lista_eavluaciones)
        {
            foreach (var evaluacion in lista_eavluaciones)
            {
                this.AgregarEvaluacion(evaluacion);
            }
        }

        public List<Evaluacion> EvaluacionesDe(Alumno un_alumno)
        {
            var todasLasEvaluaciones = new List<Evaluacion>();
            this._evaluaciones_por_instancias.Values.ToList().ForEach(evaluaciones => todasLasEvaluaciones.AddRange(evaluaciones));
            return todasLasEvaluaciones.FindAll(unaEvaluacion => unaEvaluacion.Alumno == un_alumno);
        }

        public List<Evaluacion> EvaluacionesDe(InstanciaDeEvaluacion instancia)
        {
            if (!this._evaluaciones_por_instancias.ContainsKey(instancia))
                return new List<Evaluacion>();
           
            return this._evaluaciones_por_instancias[instancia];
        }

        public Evaluacion EvaluacionDeAlumnoEnUnaInstancia(Alumno un_alumno, InstanciaDeEvaluacion instancia)
        {
            if (!this._evaluaciones_por_instancias.ContainsKey(instancia))
                return new EvaluacionNull();

            return this._evaluaciones_por_instancias[instancia].Find(e => e.Alumno.Equals(un_alumno));
        }

        public List<Evaluacion> GetEvaluaciones()
        {
            var todasLasEvaluaciones = new List<Evaluacion>();
            this._evaluaciones_por_instancias.Values.ToList().ForEach(evaluaciones => todasLasEvaluaciones.AddRange(evaluaciones));
            return todasLasEvaluaciones;
        }
    }
}
