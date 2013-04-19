using System.Collections.Generic;
using System;


namespace General.Repositorios
{
    public class RepositorioDeEvaluacion
    {
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeEvaluacion(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Evaluacion> GetEvaluaciones()
        {
            var tablaEvaluaciones = conexion_bd.Ejecutar("dbo.SACC_Get_Evaluaciones");
            this.evaluaciones = GetEvaluacionesFromTabla(tablaEvaluaciones);
            return evaluaciones;
        }

        public List<Evaluacion> GetEvaluacionesPorCursoYAlumno(int id_curso, int id_alumno)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Id.Equals(id_curso) && evaluaciones.Alumno.Id.Equals(id_alumno));
        }

        public void GuardarEvaluaciones(Evaluacion evaluacion, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("id_alumno", evaluacion.Alumno.Id);
            parametros.Add("id_curso", evaluacion.Curso.Id);
            parametros.Add("fecha_evaluacion", evaluacion.Fecha);
            parametros.Add("calificacion", evaluacion.Calificacion);
            parametros.Add("id_usuario", usuario.Id);
            parametros.Add("fecha", DateTime.Now);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Ins_Evaluacion", parametros);

        }

        public List<Evaluacion> GetEvaluacionesFromTabla(TablaDeDatos tablaEvaluaciones)
        {
            List<Evaluacion> evaluaciones = new List<Evaluacion>();

            if (tablaEvaluaciones.Rows.Count > 0)
            {
                tablaEvaluaciones.Rows.ForEach(row =>
                {
                    
                    
                    
                    //Asistencia asistencia;
                    //switch (row.GetString("calificacion"))
                    //{
                    //    case 0:
                    //        asistencia = new AsistenciaIndeterminada(row.GetDateTime("FechaEvaluacion"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //    case 1:
                    //        asistencia = new AsistenciaHoraUno(row.GetDateTime("FechaEvaluacion"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //    case 2:
                    //        asistencia = new AsistenciaHoraDos(row.GetDateTime("FechaEvaluacion"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //    case 3:
                    //        asistencia = new AsistenciaHoraTres(row.GetDateTime("FechaEvaluacion"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //    case 4:
                    //        asistencia = new InasistenciaNormal(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //    case 5:
                    //        asistencia = new AsistenciaClaseSuspendida(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //    default:
                    //        asistencia = new AsistenciaIndeterminada(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                    //        break;
                    //}
                    //evaluaciones.Add(asistencia);
                   

                });
            }
            return evaluaciones;
        }

        public void GuardarEvaluaciones(List<Evaluacion> evaluaciones_a_guardar, Usuario usuario)
        {
            foreach (var e in evaluaciones_a_guardar)
            {
                BorrarEvaluaciones(e);
            }
            foreach (var e in evaluaciones_a_guardar)
            {
                //if (e.Calificacion != 0)
                GuardarEvaluaciones(e, usuario);
            }
        }

        private void BorrarEvaluaciones(Evaluacion evaluacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("id_alumno", evaluacion.Alumno.Id);
            parametros.Add("id_curso", evaluacion.Curso.Id);
            parametros.Add("fecha_evaluacion", evaluacion.Fecha);
            conexion_bd.EjecutarSinResultado("dbo.SACC_Del_Evaluaciones", parametros);

        }
    }
}