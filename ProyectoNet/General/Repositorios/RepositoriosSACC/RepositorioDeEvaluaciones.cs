using System.Collections.Generic;
using System;


namespace General.Repositorios
{
    public class RepositorioDeEvaluacion : RepositorioLazy<List<Evaluacion>> 
    {
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        public IConexionBD conexion_bd { get; set; }
        IRepositorioDeAlumnos repo_alumnos;
        IRepositorioDeCursos repo_cursos;
        ComparadorDeDiferencias comparador_de_evalauciones = new ComparadorDeDiferencias();


        public RepositorioDeEvaluacion(IConexionBD conexion, IRepositorioDeCursos repo_cursos, IRepositorioDeAlumnos repo_alumnos)
        {
            this.conexion_bd = conexion;
            this.repo_alumnos = repo_alumnos;
            this.repo_cursos = repo_cursos;
            this.cache = new CacheNoCargada<List<Evaluacion>>();

        }

        public List<Evaluacion> GetEvaluaciones()
        {
            return cache.Ejecutar(ObtenerEvaluacionesDesdeLaBase, this);
        }

        public List<Evaluacion> ObtenerEvaluacionesDesdeLaBase()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Evaluaciones");
            var alumnos = repo_alumnos.GetAlumnos();
            var cursos = repo_cursos.GetCursos();
            tablaDatos.Rows.ForEach(row =>
                {
                    
                    Evaluacion evaluacion = new Evaluacion{
                        Id = row.GetInt("id"),
                        InstanciaEvaluacion = new InstanciaDeEvaluacion(row.GetSmallintAsInt("idInstanciaEvaluacion"), row.GetString("DescripcionInstanciaEvaluacion")),
                        Alumno = alumnos.Find(a => a.Id == row.GetSmallintAsInt("idAlumno")),
                        Curso = cursos.Find(c => c.Id == row.GetSmallintAsInt("idCurso")),
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
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Id.Equals(curso.Id) && evaluaciones.Alumno.Id.Equals(alumno.Id));
        }

        public List<Evaluacion> GetEvaluacionesPorCurso(Curso curso)
        {
            GetEvaluaciones();
            return  this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Id.Equals(curso.Id));
        }

        public List<Evaluacion> GetEvaluacionesPorCursoEInstancia(Curso un_curso, InstanciaDeEvaluacion una_instancia_del_curso)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Curso.Id.Equals(un_curso.Id) && evaluaciones.InstanciaEvaluacion.Id.Equals(una_instancia_del_curso.Id));
        }

        public Evaluacion GetEvaluacionPorCursoAlumnoEInstancia(Curso un_curso, Alumno un_alumno_del_curso, InstanciaDeEvaluacion una_instancia_del_curso)
        {
            GetEvaluaciones();
            return evaluaciones.Find(unaEvaluacion => unaEvaluacion.Curso.Id.Equals(un_curso.Id) && unaEvaluacion.Alumno.Id.Equals(un_alumno_del_curso.Id) && unaEvaluacion.InstanciaEvaluacion.Id.Equals(una_instancia_del_curso.Id));
            
        }

        public List<Evaluacion> GetEvaluacionesAlumno(Alumno alumno)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.Alumno.Id.Equals(alumno.Id));
        }

        public List<Evaluacion> GetEvaluacionesPorInstancia(InstanciaDeEvaluacion instancia)
        {
            GetEvaluaciones();
            return this.evaluaciones.FindAll(evaluaciones => evaluaciones.InstanciaEvaluacion.Id.Equals(instancia.Id));
        }

        public int GuardarEvaluacion(Evaluacion evaluacion, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_alumno", evaluacion.Alumno.Id);
            parametros.Add("@id_curso", evaluacion.Curso.Id);
            parametros.Add("@id_instancia_evaluacion", evaluacion.InstanciaEvaluacion.Id);
            parametros.Add("@calificacion", evaluacion.Calificacion.Descripcion);
            parametros.Add("@fecha_evaluacion", evaluacion.Fecha);
            parametros.Add("@fecha", DateTime.Today);
            parametros.Add("@id_usuario", usuario.Id);
           

            return (int)conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Evaluacion", parametros);
        }


        //public void GuardarEvaluaciones(List<Evaluacion> evaluaciones_a_guardar, Usuario usuario)
        //{
        //    foreach (var e in evaluaciones_a_guardar)
        //    {
        //        BorrarEvaluacion(e);
        //    }
        //    foreach (var e in evaluaciones_a_guardar)
        //    {
        //        //if (e.Calificacion != 0)
        //        GuardarEvaluacion(e, usuario);
        //    }
        //}

        public void GetInstanciasDeEvaluacionPorCurso()
        {
            
        }

        public List<Evaluacion> GuardarEvaluaciones(List<Evaluacion> evaluaciones_antiguas, List<Evaluacion> evaluaciones_nuevas, Usuario usuario)
        {
            var registros_no_procesados = new List<Evaluacion>();
            //FC: tengo que incluir para update a las que borre y ya estaban
            var evaluaciones_a_updatear = comparador_de_evalauciones.EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas);
            //FC: estas no tengo que insertarlas mas en el historico
            var evaluaciones_para_dar_de_baja = comparador_de_evalauciones.EvaluacionesParaDarDeBaja(evaluaciones_antiguas, evaluaciones_nuevas);
            var evaluaciones_a_insertar = comparador_de_evalauciones.EvaluacionesParaGuardar(evaluaciones_antiguas, evaluaciones_nuevas);
            //FC:estas no tengo que borrarlas mas
            var evaluaciones_a_borrar = comparador_de_evalauciones.EvaluacionesParaDarDeBajaSinInsertarOtra(evaluaciones_antiguas, evaluaciones_nuevas);
            
            foreach (var e in evaluaciones_a_insertar)
            {
                if (GuardarEvaluacion(e, usuario).Equals(0))
                    registros_no_procesados.Add(e);
            }
            foreach (var e in evaluaciones_a_updatear)
            {
                if (GuardarEvaluacion(e, usuario).Equals(0))
                    registros_no_procesados.Add(e);
            }
            foreach (var e in evaluaciones_para_dar_de_baja)
            {
                var idBaja = CrearBaja(usuario);
                ActualizarEvaluacion(e, usuario, idBaja);
            }
            foreach (var e in evaluaciones_a_borrar)
            {
                var idBaja = CrearBaja(usuario);
                if (ActualizarEvaluacion(e, usuario, idBaja).Equals(0))
                    registros_no_procesados.Add(e);
            }
            return registros_no_procesados;
        }

        private int ActualizarEvaluacion(Evaluacion evaluacion, Usuario usuario, int idBaja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", evaluacion.Id);
            parametros.Add("@id_alumno", evaluacion.Alumno.Id);
            parametros.Add("@id_curso", evaluacion.Curso.Id);
            parametros.Add("@id_instancia_evaluacion", evaluacion.InstanciaEvaluacion.Id);
            parametros.Add("@calificacion", evaluacion.Calificacion.Descripcion);
            parametros.Add("@fecha_evaluacion", evaluacion.Fecha);
            parametros.Add("@fecha", DateTime.Today);
            parametros.Add("@id_usuario", usuario.Id);
            if (idBaja != 0)
                parametros.Add("@id_baja", idBaja);

            return (int)conexion_bd.EjecutarEscalar("dbo.SACC_Upd_Del_Evaluacion", parametros);
        }

        //private void BorrarEvaluacion(Evaluacion evaluacion, Usuario usuario)
        //{
        //    var idBaja = CrearBaja(usuario);

        //    //var parametros = new Dictionary<string, object>();
        //    //parametros.Add("@id_alumno", evaluacion.Alumno.Id);
        //    //parametros.Add("@id_curso", evaluacion.Curso.Id);
        //    //parametros.Add("@id_instancia_evaluacion", evaluacion.InstanciaEvaluacion.Id);

        //    //conexion_bd.EjecutarSinResultado("dbo.SACC_Del_Evaluaciones", parametros);
        //}

        //private void GuardarHistorico(Evaluacion evaluacion, Usuario usuario)
        //{
        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@id_alumno", evaluacion.Alumno.Id);
        //    parametros.Add("@id_curso", evaluacion.Curso.Id);
        //    parametros.Add("@id_instancia_evaluacion", evaluacion.InstanciaEvaluacion.Id);
        //    parametros.Add("@calificacion", evaluacion.Calificacion.Descripcion);
        //    parametros.Add("@fecha_evaluacion", evaluacion.Fecha);
        //    parametros.Add("@fecha", DateTime.Today);
        //    parametros.Add("@id_usuario", usuario.Id);
                                                                          
        //    conexion_bd.EjecutarSinResultado("dbo.SACC_Ins_HistoricoEvaluaciones", parametros);
        //}

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }

    }
}