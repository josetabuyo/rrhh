using System;
using System.Collections.Generic;

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
        private int _horasCatedra;
        private EspacioFisico _espacioFisico;
        private List<InstanciaDeEvaluacion> _instanciasDeEvaluacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return this.Materia.Nombre + " (" + this.Materia.Modalidad.Descripcion + ")"; } set { } }
        public Docente Docente { get { return _docente; } set { _docente = value; } }
        public Materia Materia { get{ return _materia; } set{_materia = value;} }
        public int HorasCatedra { get { return _horasCatedra; } set { _horasCatedra = value; } }
        public EspacioFisico EspacioFisico { get { return _espacioFisico; } set { _espacioFisico = value; } }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<Alumno> Alumnos()
        {
            return _alumnos;
        }

        public List<InstanciaDeEvaluacion> InstanciasDeEvaluacion()
        {
            return _instanciasDeEvaluacion;
        }

        public Curso()
        {
            _alumnos = new List<Alumno>();
            _instanciasDeEvaluacion = new List<InstanciaDeEvaluacion>();
        }
  
        public Curso(int id, string nombre) 
        { 
            this._id = id;
            this._nombre = nombre;

            _alumnos = new List<Alumno>();
            _instanciasDeEvaluacion = new List<InstanciaDeEvaluacion>();

        }

        public Curso(int id, string nombre, Materia materia, Docente docente)
        {
            this._id = id;
            this._nombre = nombre;
            this._materia = materia;
            this._docente = docente;
            _alumnos = new List<Alumno>();
            _instanciasDeEvaluacion = new List<InstanciaDeEvaluacion>();
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

        public void AgregarInstanciasEvaluaciones(List<InstanciaDeEvaluacion> instanciasEvaluaciones)
        {
            instanciasEvaluaciones.ForEach(i => this.AgregarInstanciaEvaluacion(i));
        }

        public void AgregarInstanciaEvaluacion(InstanciaDeEvaluacion instanciaEvaluacion)
        {
            this._instanciasDeEvaluacion.Add(instanciaEvaluacion);
        }

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

        public void AgregarEvaluacion(Evaluacion evaluacion_historia_primer_parcial_bel)
        {

        }
    }
}
