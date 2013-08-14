using System;
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

        public void EvaluarRegularidadPara(Alumno alumno, Curso curso, RepositorioDeAsistencias repo_asistencias)
        {

            int limite_maximo_de_ausencias = ObtenerLimiteDeAusencias(curso);

            int ausencias_computables = ObtenerLasAusenciasComputables(alumno, curso, repo_asistencias);

            CriterioDeRegularidad(ausencias_computables, limite_maximo_de_ausencias);
        }


        public int AusenciasDisponibles(Alumno alumno, Curso curso, RepositorioDeAsistencias repo_asistencias)
        {
            int limite_maximo_de_ausencias = ObtenerLimiteDeAusencias(curso);

            int ausencias_computables = ObtenerLasAusenciasComputables(alumno, curso, repo_asistencias);

            return (limite_maximo_de_ausencias - ausencias_computables);
        }


        //Este método es el que hay que cambiar en caso de que se modifique el criterio de Regularidad que actualmente es el 10% de Ausencias como máximo
        private int LimiteMaximoDeAusenciasParaAlumnosRegulares(int total_horas_catedra)
        {
            return 10 * total_horas_catedra / 100;
        }

        private int ObtenerLasAusenciasComputables(Alumno alumno, Curso curso, RepositorioDeAsistencias repo_asistencias)
        {
            List<HorarioDeCursada> horarios_del_curso = curso.GetHorariosDeCursada();

            List<Asistencia> lista_de_asistencias_tomadas = repo_asistencias.GetAsistenciasPorCursoYAlumno(curso.Id, alumno.Id);

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

        private int AusenciasComputables(List<HorarioDeCursada> horarios_del_curso, int ausencias_computables, Asistencia asistencia)
        {
            HorarioDeCursada dia_y_horario = horarios_del_curso.Find(d => d.Dia == asistencia.Fecha.DayOfWeek);

            if (0 < asistencia.Valor && asistencia.Valor < 4)
            {
                ausencias_computables += dia_y_horario.HorasCatedra - asistencia.Valor;
            }

            if (asistencia.Valor == 4)
            {
                ausencias_computables += dia_y_horario.HorasCatedra;
            }
            return ausencias_computables;
        }

        private int TotalDeHorasCatedra(Curso curso, List<DateTime> dias_de_cursada)
        {
            var total_horas_catedra = 0;
            dias_de_cursada.ForEach(d =>
            {
                total_horas_catedra += curso.GetHorariosDeCursada().Find(h => h.Dia == d.DayOfWeek).HorasCatedra;
            });
            return total_horas_catedra;
        }

        private List<DateTime> GetDiasDeCursadaEntre(DateTime fecha_desde, DateTime fecha_hasta, CalendarioDeCurso calendario)
        {
            return calendario.DiasACursarSinIncluirFeriadosEntre(fecha_desde, fecha_hasta).Select(dia => dia.Dia()).ToList();
        }

        private static CalendarioDeCurso CalendarioDelCurso(Curso curso)
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
    }
}
