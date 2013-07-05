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
                        Alumno = repo_alumnos.GetAlumnoByDNI(row.GetSmallintAsInt("idAlumno")),
                        Curso = repo_cursos.GetCursoById(row.GetSmallintAsInt("idCurso")),
                        Calificacion = new CalificacionNoNumerica(row.GetString("Calificacion")),
                        Fecha = row.GetDateTime("FechaEvaluacion")
                    };
                    evaluaciones.Add(evaluacion);
                 });  

            return evaluaciones;
        }

        public List<Evaluacion> GetEvaluacionesPorCursoYAlumno(int id_curso, int id_alumno)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Id.Equals(id_curso) && evaluaciones.Alumno.Id.Equals(id_alumno));
        }

        public Evaluacion GetEvaluacionPorAlumnoEInstancia(Alumno un_alumno_del_curso, InstanciaDeEvaluacion una_instancia_del_curso)
        {
            GetEvaluaciones();
            return evaluaciones.Find(unaEvaluacion => unaEvaluacion.Alumno.Equals(un_alumno_del_curso) && unaEvaluacion.InstanciaEvaluacion.Equals(una_instancia_del_curso));
                
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



        //---------------Bel-------------

        // public void AgregarEvaluacion(Evaluacion evaluacion)
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
    }
}