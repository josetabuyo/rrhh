using System.Collections.Generic;
using System;


namespace General.Repositorios
{
    public class RepositorioDeEvaluacion
    {
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        public IConexionBD conexion_bd { get; set; }
        IRepositorioDeAlumnos repo_alumnos;
        IRepositorioDeCursos repo_cursos;


        public RepositorioDeEvaluacion(IConexionBD conexion, IRepositorioDeCursos repo_cursos, IRepositorioDeAlumnos repo_alumnos)
        {
            this.conexion_bd = conexion;
            this.repo_alumnos = repo_alumnos;
            this.repo_cursos = repo_cursos;
        }

        public List<Evaluacion> GetEvaluaciones()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Evaluaciones");
            
            tablaDatos.Rows.ForEach(row =>
                {
                    
                    Evaluacion evaluacion = new Evaluacion{

                        InstanciaEvaluacion = new InstanciaDeEvaluacion(row.GetSmallintAsInt("idInstanciaEvaluacion"), row.GetString("DescripcionInstanciaEvaluacion")),
                        Alumno = repo_alumnos.GetAlumnos().Find(a => a.Id == row.GetSmallintAsInt("idAlumno")),
                        Curso = repo_cursos.GetCursoById(row.GetSmallintAsInt("idCurso")),
                        Calificacion = new CalificacionNoNumerica(row.GetString("Calificacion")),
                        Fecha = row.GetDateTime("FechaEvaluacion")
                    };
                    evaluaciones.Add(evaluacion);
                 });  

            return evaluaciones;
        }

        public List<Evaluacion> GetEvaluacionesPorCursoYAlumno(Curso curso, Alumno alumno)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Equals(curso) && evaluaciones.Alumno.Equals(alumno));
        }

        public List<Evaluacion> GetEvaluacionesPorCurso(Curso curso)
        {
            GetEvaluaciones();
            return  this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Id.Equals(curso.Id));
        }

        public List<Evaluacion> GetEvaluacionesPorCursoEInstancia(Curso un_curso, InstanciaDeEvaluacion una_instancia_del_curso)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Equals(un_curso) && evaluaciones.InstanciaEvaluacion.Equals(una_instancia_del_curso));
        }

        public Evaluacion GetEvaluacionPorCursoAlumnoEInstancia(Curso un_curso, Alumno un_alumno_del_curso, InstanciaDeEvaluacion una_instancia_del_curso)
        {
            GetEvaluaciones();
            var hola =  evaluaciones.Find(unaEvaluacion => unaEvaluacion.Curso.Equals(un_curso) && unaEvaluacion.Alumno.Equals(un_alumno_del_curso) && unaEvaluacion.InstanciaEvaluacion.Equals(una_instancia_del_curso));
            return hola;
        }

        public List<Evaluacion> GetEvaluacionesAlumno(Alumno alumno)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Alumno.Equals(alumno));
        }

        public List<Evaluacion> GetEvaluacionesPorInstancia(InstanciaDeEvaluacion instancia)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.InstanciaEvaluacion.Equals(instancia));
        }

        public void GuardarEvaluacion(Evaluacion evaluacion, Usuario usuario)
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


        public void GuardarEvaluaciones(List<Evaluacion> evaluaciones_a_guardar, Usuario usuario)
        {
            foreach (var e in evaluaciones_a_guardar)
            {
                BorrarEvaluacion(e);
            }
            foreach (var e in evaluaciones_a_guardar)
            {
                //if (e.Calificacion != 0)
                GuardarEvaluacion(e, usuario);
            }
        }

        private void BorrarEvaluacion(Evaluacion evaluacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("id_alumno", evaluacion.Alumno.Id);
            parametros.Add("id_curso", evaluacion.Curso.Id);
            parametros.Add("fecha_evaluacion", evaluacion.Fecha);
            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Evaluacion", parametros);
        }


        public void GetInstanciasDeEvaluacionPorCurso()
        {
            
        }
    }
}