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
        protected bool _enCurso;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return this.Materia.Nombre + " - " + this.Cuatrimestre() + " (" + this.Materia.Modalidad.Descripcion + ") - " + this.EspacioFisico.Edificio.Nombre; } set { } }
        public Docente Docente { get { return _docente; } set { _docente = value; } }
        public Materia Materia { get { return _materia; } set { _materia = value; } }
        public string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public EspacioFisico EspacioFisico { get { return _espacioFisico; } set { _espacioFisico = value; } }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EnCurso { get { return this._enCurso; } }        

        public List<Alumno> Alumnos()
        {
            return _alumnos;
        }

        public Curso()
        {
        }

        protected void Asignar(Materia materia, Docente docente, EspacioFisico espacio, DateTime inicio, DateTime fin, string observaciones)
        {
            _materia = materia;
            _docente = docente;
            _espacioFisico = espacio;
            FechaInicio = inicio;
            FechaFin = fin;
            _alumnos = new List<Alumno>();
            _observaciones = observaciones;
            _enCurso = this.EstaEnCurso();
        }

        public Curso(Materia materia, Docente docente, EspacioFisico espacio, DateTime inicio, DateTime fin, string observaciones)
        {
            Asignar(materia, docente, espacio, inicio, fin, observaciones);
        }

        public Curso(int id, Materia materia, Docente docente, EspacioFisico espacio, DateTime inicio, DateTime fin, string observaciones)
        {
            this._id = id;
            Asignar(materia, docente, espacio, inicio, fin, observaciones);
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


        public string Cuatrimestre()
        {
            var anio = this.FechaInicio.Year;
            var cuatrimestre = "";

            if (this.FechaInicio.Month <= 7)
            {
                cuatrimestre = "1°C";
            } else {
                cuatrimestre = "2°C";
            }

            return cuatrimestre + " " + anio;
        }

        public bool EstaEnCurso()
        {
            var fecha_hoy = DateTime.Today;
            var fecha_fin_curso = this.FechaFin;

            if (fecha_hoy > fecha_fin_curso)
                return false;
            return true;
        }
    }
}
