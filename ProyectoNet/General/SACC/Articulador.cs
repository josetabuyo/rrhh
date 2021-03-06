﻿using System;
using System.Collections.Generic;
using General.Repositorios;
using System.Linq;
using System.Text;

namespace General
{
    public class Articulador
    {

        public string condicion_del_alumno { get; set; }
        public float limite_de_regularidad_de_asistencias{ get; set; }
        public const string regular = "Regular";
        public const string libre = "Libre";
        public const float limite_de_regularidad_de_asistencias_en_porcentaje = 10; //por ciento

        public Articulador() 
        {    
        }

        public void EvaluarRegularidadPara(Alumno alumno, Curso curso, List<AcumuladorAsistencia> repo_asistencias)
        {

            int limite_maximo_de_ausencias = ObtenerLimiteDeAusencias(curso);

            int ausencias_computables = ObtenerLasAusenciasComputables(alumno, curso, repo_asistencias);

            CriterioDeRegularidad(ausencias_computables, limite_maximo_de_ausencias);
        }


        public int AusenciasDisponibles(Alumno alumno, Curso curso, List<AcumuladorAsistencia> repo_asistencias)
        {
            int limite_maximo_de_ausencias = ObtenerLimiteDeAusencias(curso);

            int ausencias_computables = ObtenerLasAusenciasComputables(alumno, curso, repo_asistencias);

            return (limite_maximo_de_ausencias - ausencias_computables);
        }

        public bool EsRegular(Alumno alumno, Curso curso, List<AcumuladorAsistencia> asistencias_por_curso_y_alumno)
        {
            this.EvaluarRegularidadPara(alumno, curso, asistencias_por_curso_y_alumno);
            if (condicion_del_alumno == regular)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Este método es el que hay que cambiar en caso de que se modifique el criterio de Regularidad que actualmente es el 10% de Ausencias como máximo
        private int LimiteMaximoDeAusenciasParaAlumnosRegulares(int total_horas_catedra)
        {
            return 10 * total_horas_catedra / 100;
        }

        private int ObtenerLasAusenciasComputables(Alumno alumno, Curso curso, List<AcumuladorAsistencia> repo_asistencias)
        {
            List<HorarioDeCursada> horarios_del_curso = curso.GetHorariosDeCursada();

            List<AcumuladorAsistencia> lista_de_asistencias_tomadas = new List<AcumuladorAsistencia>(); //repo_asistencias.GetAsistenciasPorCursoYAlumno(curso.Id, alumno.Id);

            int ausencias_computables = 0;

            lista_de_asistencias_tomadas.ForEach(asistencia =>
            {

                ausencias_computables = AusenciasComputables(horarios_del_curso, ausencias_computables, asistencia);

            });
            return ausencias_computables;
        }

        private int ObtenerLimiteDeAusencias(Curso curso)
        {
            CalendarioDeCurso calendario = CalendarioDelCurso(curso);

            List<DateTime> dias_de_cursada = GetDiasDeCursadaEntre(curso.FechaInicio, curso.FechaFin, calendario);

            int total_horas_catedra = TotalDeHorasCatedra(curso, dias_de_cursada);

            return LimiteMaximoDeAusenciasParaAlumnosRegulares(total_horas_catedra);
        }

        private int AusenciasComputables(List<HorarioDeCursada> horarios_del_curso, int ausencias_computables, AcumuladorAsistencia asistencia)
        {
            HorarioDeCursada dia_y_horario = horarios_del_curso.Find(d => d.Dia == asistencia.Fecha.DayOfWeek);
            ausencias_computables += dia_y_horario.HorasCatedra - int.Parse(asistencia.Valor);
            
            return ausencias_computables;
        }

        public int TotalDeHorasCatedra(Curso curso, List<DateTime> dias_de_cursada)
        {
            var total_horas_catedra = 0;
            var horarios_de_cursada = curso.GetHorariosDeCursada();
            dias_de_cursada.ForEach(d =>
            {
                var horario = horarios_de_cursada.Find(h => h.Dia == d.DayOfWeek);
                if (horario  != null)
                {
                    total_horas_catedra += horario.HorasCatedra;
                }
               
            });
            return total_horas_catedra;
        }

        public List<DateTime> GetDiasDeCursadaEntre(DateTime fecha_desde, DateTime fecha_hasta, CalendarioDeCurso calendario)
        {
            return calendario.DiasACursarSinIncluirFeriadosEntre(fecha_desde, fecha_hasta).Select(dia => dia.Dia()).ToList();
        }

        public CalendarioDeCurso CalendarioDelCurso(Curso curso)
        {
            ManagerDeCalendarios manager_de_calendarios = new ManagerDeCalendarios(new CalendarioDeFeriados());
            manager_de_calendarios.AgregarCalendarioPara(curso);
            CalendarioDeCurso calendario = manager_de_calendarios.CalendarioPara(curso);
            return calendario;
        }

        private void CriterioDeRegularidad(int ausencias, int limite_maximo_de_ausencias)
        {
            if (ausencias > limite_maximo_de_ausencias)
            {
                condicion_del_alumno = libre;
            }else{
                 condicion_del_alumno = regular;
            }
        }

        public bool DecimeSiAprobo(Alumno alumno, Curso curso, RepositorioDeEvaluacion repo_evaluacion)
        {
            var evaluaciones = repo_evaluacion.GetEvaluacionesPorCursoYAlumno(curso, alumno);
            //FC: uso la instancia de id 6 xq es la calificacion final en ambas modalidades
            var eval = evaluaciones.Find(e => e.InstanciaEvaluacion.Id == 6);

            if (eval == null)
                eval = new EvaluacionNull();

            return eval.Aprobado();
        }

        public EstadoDeAlumno EstadoDelAlumno(Alumno alumno, IRepositorioDeCursos repo_cursos, List<Curso> cursos)
        {
            var cursos_del_alumno = repo_cursos.GetCursosParaElAlumno(alumno, cursos);
            var fecha_hoy = new DateTime(2013,10,01);

            var cursos_ordenados = OrdenarCursosPorFecha(cursos_del_alumno);

            if (cursos_ordenados.Count == 0)
            {
                return new EstadoAlumnoSinCursar();
            }
            else if (cursos_ordenados.First().FechaFin <= fecha_hoy)
            {
                return new EstadoAlumnoFinalizado();
            }
                return new EstadoAlumnoCursando();
            
        }

        public Ciclo CicloDelAlumno(Alumno alumno, IRepositorioDeCursos repo_cursos, List<Curso> cursos)
        {
            var cursos_del_alumno = repo_cursos.GetCursosParaElAlumno(alumno, cursos);

            var cursos_ordenados = OrdenarCursosPorCiclo(cursos_del_alumno);

            if (cursos_ordenados.Count == 0)
            {
                return new Ciclo();
            }
            return cursos_ordenados.First().Materia.Ciclo;
        }

        private List<Curso> OrdenarCursosPorFecha(List<Curso> cursos_del_alumno)
        {
            IEnumerable<Curso> sortedCursos =
                                             from curso in cursos_del_alumno
                                             orderby curso.FechaFin descending
                                             select curso;

            var cursos_ordenados = sortedCursos.ToList();
            return cursos_ordenados;
        }

        private List<Curso> OrdenarCursosPorCiclo(List<Curso> cursos_del_alumno)
        {
            IEnumerable<Curso> sortedCursos =
                                             from curso in cursos_del_alumno
                                             orderby curso.Materia.Ciclo.Id descending
                                             select curso;

            var cursos_ordenados = sortedCursos.ToList();
            return cursos_ordenados;
        }

        public string EstadoDelAlumnoParaElCurso(Curso curso, List<Evaluacion> evaluaciones)
        {
            if (curso.EstaEnCurso() && CalificacionDelCurso(curso, evaluaciones) == "Adeuda Final")
            {
                return "Adeuda";
            }
            else if (curso.EstaEnCurso() && CalificacionDelCurso(curso, evaluaciones) != "Adeuda Final")
            {
                return "En Curso";
            }
            else if (!curso.EstaEnCurso() && CalificacionDelCurso(curso, evaluaciones) == "Adeuda Final")
            {
                return "Adeuda";
            }
            else
            {
                return "Aprobada";
            }
        }

        public string CalificacionDelCurso(Curso curso, List<Evaluacion> evaluaciones)
        {
            //FC: por ahora pregunto si un determinado curso tiene una instancia con id 6 (que es la calificacion final), si no la tiene es que la adeuda
            var evaluacion_final = evaluaciones.Find(e => e.Curso.Id.Equals(curso.Id) && e.InstanciaEvaluacion.Id == 6);
            if (evaluacion_final != null)
            {
               return evaluacion_final.Calificacion.Descripcion;
            }

            return "Adeuda Final";
        }

        public List<AcumuladorAsistencia> AsistenciasParaUnAlumnoYCurso(Alumno alumno, Curso curso, IRepositorioDeAsistencias repo_asistencias)
        {
            var asistencias = repo_asistencias.GetAsistencias();
            return asistencias.FindAll(asistencia => asistencia.IdCurso.Equals(curso.Id) && asistencia.IdAlumno.Equals(alumno.Id));
        }

       
    }
}
