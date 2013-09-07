using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace General
{
    public class PlanillaMensual
    {
        private Curso _un_curso;
        private DateTime _fechaDesde;
        private DateTime _fechaHasta;
        private Dictionary<Alumno, List<Asistencia>> _asistencias_e_inasistencias;
        private CalendarioDeCurso _un_calendario;

        public Curso Curso { get { return _un_curso; } }
        public DateTime FechaDesde { get { return _fechaDesde; } }
        public DateTime FechaHasta { get { return _fechaHasta; } }

        public Dictionary<Alumno, List<Asistencia>> Asistencias { get { return _asistencias_e_inasistencias; } }
        public CalendarioDeCurso Calendario { get { return _un_calendario; } }

        public PlanillaMensual() { }

        public PlanillaMensual(Curso un_curso, DateTime fecha_desde, DateTime fecha_hasta)
        {
            // TODO: Complete member initialization
            this._un_curso = un_curso;
            this._fechaDesde = fecha_desde;
            this._fechaHasta = fecha_hasta;

            this._asistencias_e_inasistencias = new Dictionary<Alumno, List<Asistencia>>();
        }

        public PlanillaMensual(Curso un_curso, DateTime fecha_desde, DateTime fecha_hasta, CalendarioDeCurso un_calendario)
        {
            // TODO: Complete member initialization
            this._un_curso = un_curso;
            this._fechaDesde = fecha_desde;
            this._fechaHasta = fecha_hasta;
            this._un_calendario = un_calendario;
            this._asistencias_e_inasistencias = new Dictionary<Alumno, List<Asistencia>>();
        }


       
        private void AgregarAlAlumnoSiNoEsta(Alumno un_alumno)
        {
            if (!this._asistencias_e_inasistencias.ContainsKey(un_alumno))
                this._asistencias_e_inasistencias.Add(un_alumno, new List<Asistencia>());	            
        }

        private Validador Validador()
        {
            return new Validador();
        }

        private bool AlumnoPerteneceAlcurso(Alumno un_alumno)
        {
            return _un_curso.Alumnos().Contains(un_alumno);
        }

        public List<DateTime> GetDiasDeCursadaEntre(DateTime fecha_desde, DateTime fecha_hasta)
        {
            return this._un_calendario.DiasACursarSinIncluirFeriadosEntre(fecha_desde, fecha_hasta).Select(dia => dia.Dia()).ToList(); // Se cambia momentáneamente por sin feriados pero hay que revisar!!! aaaaaaaaaaaaaaaa
        }

    }
}