using System;
using System.Collections.Generic;
using General.Repositorios;

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



        public void EvaluarCondicionPara(List<Asistencia> asistencias_del_alumno_y_del_curso)
        {
            //var aaa = curso.Alumnos().Find(a => a.Id == alumno.Id);

            //RepositorioDeAsistencias repo_asistencias = new RepositorioDeAsistencias(this.conexion_bd);

            //var asistencias_del_alumno = repo_asistencias.GetAsistenciasPorCursoYAlumno(curso.Id, alumno.Id);

            var asistencias_presenciales = asistencias_del_alumno_y_del_curso.FindAll(a => 0 < a.Valor && a.Valor < 4);

             CriterioDeRegularidad(asistencias_presenciales.Count, asistencias_del_alumno_y_del_curso.Count);

            //var horarios_de_cursada = curso.GetHorariosDeCursada();

            //var fecha_inicio_curso = curso.FechaInicio;
            //var fecha_fin_curso = curso.FechaFin;

            //CalendarioDeCurso calendario = new CalendarioDeCurso(

        }

        private void CriterioDeRegularidad(int asistio, int asistencias_tomadas)
        {
            if ((asistio / asistencias_tomadas * 100) < limite_de_regularidad_de_asistencias_en_porcentaje)
            {
                condicion_del_alumno = regular;
            }else{
                 condicion_del_alumno = libre;
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

    }
}
