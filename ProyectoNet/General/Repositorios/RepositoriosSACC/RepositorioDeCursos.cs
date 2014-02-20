using System;
using System.Linq;
using System.Collections.Generic;
using General.MAU;


namespace General.Repositorios
{
    public class RepositorioDeCursos : RepositorioLazy<List<Curso>>, General.Repositorios.IRepositorioDeCursos
    {

        IRepositorioDeDocentes repo_docentes;
        IRepositorioDeEspaciosFisicos repo_espacios_fisico;
        IRepositorioDeModalidades repo_modalidades;
        IRepositorioDeMaterias repo_materias;
        IRepositorioDeAlumnos repo_alumnos;
        ComparadorDeDiferencias comparador = new ComparadorDeDiferencias();

        public RepositorioDeCursos(IConexionBD conexion)
            :base(conexion)
        {
            this.cache = new CacheNoCargada<List<Curso>>();
            this.repo_docentes = new RepositorioDeDocentes(conexion, this);

            repo_espacios_fisico = new RepositorioDeEspaciosFisicos(conexion, this);
            repo_modalidades = new RepositorioDeModalidades(conexion);
            repo_materias = new RepositorioDeMaterias(conexion, this, repo_modalidades);
            repo_alumnos = new RepositorioDeAlumnos(conexion, this, repo_modalidades);
        }

        public void SetRepoDocuentes(IRepositorioDeDocentes new_repo_docentes)
        {
            this.repo_docentes = new_repo_docentes;
        }
        public void SetRepoEspaciosFisicos(IRepositorioDeEspaciosFisicos new_repo_espacios_fisicos)
        {
            this.repo_espacios_fisico = new_repo_espacios_fisicos;
        }

        public void SetRepoAlumnos(IRepositorioDeAlumnos new_repo_alumnos)
        {
            this.repo_alumnos = new_repo_alumnos;
        }
        public void SetRepoModalidades(IRepositorioDeModalidades new_repo_modalidades)
        {
            this.repo_modalidades = new_repo_modalidades;
        }

        public void SetRepoMaterias(IRepositorioDeMaterias new_repo_materias)
        {
            this.repo_materias = new_repo_materias;
        }


        public Curso GetCursoById(int id)
        {
            return GetCursos().Find(c => c.Id == id);
        }

        public List<Curso> GetCursos()
        {
            return this.cache.Ejecutar(GetCursosDesdeLaBase, this);
        }

        public List<Curso> GetCursosDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.SACC_Get_Cursos");
            var cursos = new List<Curso>();

            tablaDatos.Rows.ForEach(row =>
            {
                var docente = GetDocenteByIdCurso(row.GetSmallintAsInt("IdDocente"));

                var espacio_fisico = GetEspacioFisicoById(repo_espacios_fisico, row.GetSmallintAsInt("IdEspacioFisico"));

                Curso curso = new Curso
                    (row.GetSmallintAsInt("Id"),
                    repo_materias.GetMateriaById(row.GetSmallintAsInt("IdMateria")),
                    docente,
                    espacio_fisico,
                    row.GetObject("FechaInicio") is DBNull ? new DateTime(DateTime.Now.Year, 1, 1) : row.GetDateTime("FechaInicio"),
                    row.GetObject("FechaFin") is DBNull ? new DateTime(DateTime.Now.Year, 12, 1) : row.GetDateTime("FechaFin"),
                    row.GetString("Observaciones"));

                var horarios = GetHorariosByIdCurso(row.GetSmallintAsInt("Id"));
                foreach (var h in horarios)
                { curso.AgregarHorarioDeCursada(h); }

                var inscripciones = GetInscripcionesByIdCurso(row.GetSmallintAsInt("Id"));
                var alumnos = repo_alumnos.GetAlumnos();

                var alumnos_inscriptos = alumnos.FindAll(a =>
                { return inscripciones.Contains(a.Id); });

                curso.AgregarAlumnos(alumnos_inscriptos);
                cursos.Add(curso);
            });

            cursos.Sort((curso1, curso2) => curso1.esMayorAlfabeticamenteQue(curso2));
            return cursos;
        }

        private static EspacioFisico GetEspacioFisicoById(IRepositorioDeEspaciosFisicos repo_espacios_fisico, int id_espacio_fisico)
        {
            if (id_espacio_fisico == 0)
            { return new EspacioFisicoNull(); }
            else
            { return repo_espacios_fisico.GetEspacioFisicoById(id_espacio_fisico); }
        }


        private Docente GetDocenteByIdCurso(int idCurso)
        {
            var docente = repo_docentes.GetDocenteById(idCurso);
            if (docente == null)
                docente = new DocenteNull();
            return docente;
        }

        protected List<HorarioDeCursada> cache_horarios;
        protected List<HorarioDeCursada> GetHorarios()
        {
            if (cache_horarios != null) return cache_horarios;

            var tablaDatos = conexion.Ejecutar("dbo.SACC_Get_Horarios");
            var horarios = new List<HorarioDeCursada>();
            tablaDatos.Rows.ForEach(row =>
            {
                var hora_desde = FormatHora(row.GetString("Desde"));
                var hora_hasta = FormatHora(row.GetString("Hasta"));
                var horas_catedra = row.GetSmallintAsInt("HorasCatedra");
                var nro_dia = (DayOfWeek)row.GetSmallintAsInt("NroDiaSemana");
                var curso_id = row.GetSmallintAsInt("idCurso");
                horarios.Add(new HorarioDeCursada(nro_dia, hora_desde, hora_hasta, horas_catedra, curso_id));


            });
            cache_horarios = horarios;
            return horarios;

        }

        protected List<HorarioDeCursada> GetHorariosByIdCurso(int id_curso)
        {
            return GetHorarios().FindAll(h => h.IdCurso == id_curso);
        }


        private string FormatHora(string hora)
        {
            if (hora.Length == 4)
            {
                return hora.Substring(0, 2) + ":" + hora.Substring(2, 2);
            }
            else if (hora.Length > 4)
            {
                return hora.Replace(":", "").Substring(0, 4);
            }
            else
            {
                return string.Empty;
            }

        }


        protected List<List<int>> cache_inscripciones;
        protected List<List<int>> GetInscripciones()
        {
            if (cache_inscripciones != null) return cache_inscripciones;

            var tablaDatos = conexion.Ejecutar("dbo.SACC_Get_Inscripciones");
            var inscripciones = new List<List<int>>();
            tablaDatos.Rows.ForEach(row =>
            {
                var inscripcion = new List<int>();
                inscripcion.Add(row.GetSmallintAsInt("IdCurso"));
                inscripcion.Add(row.GetInt("IdAlumno"));
                inscripciones.Add(inscripcion);
            });

            return inscripciones;
        }

        protected List<int> GetInscripcionesByIdCurso(int id_curso)
        {
            return (from inscripcion in GetInscripciones() where inscripcion.First() == id_curso select inscripcion.Last()).ToList();
        }

        public bool AgregarCurso(Curso curso)
        {

            var parametros = new Dictionary<string, object>();
            var horarios_nuevos = curso.GetHorariosDeCursada();


            parametros.Add("id_espacioFisico", curso.EspacioFisico.Id);
            parametros.Add("id_materia", curso.Materia.Id);
            parametros.Add("id_docente", curso.Docente.Id);
            parametros.Add("fecha_inicio", curso.FechaInicio);
            parametros.Add("fecha_fin", curso.FechaFin);
            parametros.Add("fecha", DateTime.Now);
            parametros.Add("Observaciones", curso.Observaciones);

            int id_curso = int.Parse(conexion.EjecutarEscalar("dbo.SACC_Ins_Curso", parametros).ToString());

            InsertarHorarios(id_curso, horarios_nuevos);
            return true;

        }

        public bool QuitarCurso(Curso curso, Usuario usuario)
        {
            if (!this.TieneAsignadoAlumnos(curso))
            {
                var idBaja = CrearBaja(usuario);
                var parametros = new Dictionary<string, object>();

                parametros.Add("id_curso", curso.Id);
                parametros.Add("id_espacioFisico", curso.EspacioFisico.Id);
                parametros.Add("id_materia", curso.Materia.Id);
                parametros.Add("id_docente", curso.Docente.Id);
                parametros.Add("fecha_inicio", curso.FechaInicio);
                parametros.Add("fecha_fin", curso.FechaFin);
                parametros.Add("fecha", DateTime.Now);
                parametros.Add("Baja", idBaja);
                parametros.Add("Observaciones", curso.Observaciones);
                conexion.EjecutarSinResultado("dbo.SACC_Upd_Del_Curso", parametros);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }

        public bool ModificarCurso(Curso curso)
        {
            var curso_a_modificar = this.GetCursoById(curso.Id);
            if (curso_a_modificar != null)
            {
                var parametros = new Dictionary<string, object>();
                var horarios_nuevos = curso.GetHorariosDeCursada();
                if (!this.TieneAsistenciasEnHorarios(curso_a_modificar, horarios_nuevos) &&
                    !this.TieneAsignadoAlumnos(curso_a_modificar) &&
                    !this.TieneAsignadoDocente(curso_a_modificar))
                {
                    BorrarHorarios(curso.Id);
                    InsertarHorarios(curso.Id, horarios_nuevos);
                }
                parametros.Add("id_curso", curso.Id);
                parametros.Add("id_espacioFisico", curso.EspacioFisico.Id);
                parametros.Add("id_materia", curso.Materia.Id);
                parametros.Add("id_docente", curso.Docente.Id);
                parametros.Add("fecha_inicio", curso.FechaInicio);
                parametros.Add("fecha_fin", curso.FechaFin);
                parametros.Add("fecha", DateTime.Now);
                parametros.Add("Observaciones", curso.Observaciones);

                conexion.EjecutarSinResultado("dbo.SACC_Upd_Del_Curso", parametros);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InsertarHorarios(int id_curso, List<HorarioDeCursada> horarios_nuevos)
        {
            foreach (var h in horarios_nuevos)
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("id_curso", id_curso);
                parametros.Add("nro_dia_semana", (int)h.Dia);
                parametros.Add("desde", FormatHora(h.HoraDeInicio.ToString()));
                parametros.Add("hasta", FormatHora(h.HoraDeFin.ToString()));
                parametros.Add("horas_catedra", h.HorasCatedra);
                conexion.EjecutarSinResultado("dbo.SACC_Ins_Horario", parametros);
            }
        }

        private void BorrarHorarios(int id_curso)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", id_curso);
            conexion.EjecutarSinResultado("dbo.SACC_Del_Horarios", parametros);
        }

        public void ActualizarInscripcionesACurso(List<Alumno> alumnos_a_inscribir, Curso curso, Usuario usuario)
        {
            //primero de to do hay que elimar los que no van de la BD
            EliminarAlumnosDelCurso(alumnos_a_inscribir, curso, usuario);
            //limpiar la lista cursoalumno e inscribir
            var nuevos_alumnos = ObtenerAlumnosNoInscriptos(alumnos_a_inscribir, curso, usuario);
            nuevos_alumnos.ForEach(alumno => InscribirAlumno(alumno, curso, usuario));

            curso.Alumnos().Clear();
            curso.Alumnos().AddRange(ObtenerAlumnosDelCurso(curso));

        }

        private void EliminarAlumnosDelCurso(List<Alumno> alumnos_a_inscribir, Curso curso, Usuario usuario)
        {
            var alumnos_en_la_base = ObtenerAlumnosDelCurso(curso);

            List<Alumno> alumnosAEliminar = alumnos_en_la_base.FindAll(a => !alumnos_a_inscribir.Contains(a));
            alumnosAEliminar.ForEach(alumno => EliminarAlumnoDelCurso(alumno, curso, usuario));
        }

        public List<Alumno> ObtenerAlumnosDelCurso(Curso curso)
        {
            var id_alumnos_de_la_base = GetInscripcionesByIdCurso(curso.Id);
            var alumnos = new RepositorioDeAlumnos(conexion, this, new RepositorioDeModalidades(conexion)).GetAlumnos();
            var alumnos_en_la_base = alumnos.FindAll(a => id_alumnos_de_la_base.Contains(a.Id));
            return alumnos_en_la_base;
        }

        private List<Alumno> ObtenerAlumnosNoInscriptos(List<Alumno> alumnos_a_inscribir, Curso curso, Usuario usuario)
        {
            var alumnos_en_la_base = ObtenerAlumnosDelCurso(curso);
            return alumnos_a_inscribir.FindAll(alumno => !alumnos_en_la_base.Contains(alumno));
        }

        private void InscribirAlumno(Alumno alumno, Curso curso, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idCurso", curso.Id);
            parametros.Add("@idAlumno", alumno.Id);
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            parametros.Add("@idBaja", null);

            conexion.EjecutarSinResultado("dbo.SACC_Ins_Inscripcion", parametros);
        }

        private void EliminarAlumnoDelCurso(Alumno alumno, Curso curso, Usuario usuario)
        {
            //Verificar que no se elimine el alumno si tiene asistencias
            var idBaja = CrearBaja(usuario);
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idCurso", curso.Id);
            parametros.Add("@idAlumno", alumno.Id);
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            parametros.Add("@idBaja", idBaja);
            conexion.EjecutarSinResultado("dbo.SACC_Upd_Del_Inscripcion", parametros);

        }

        private bool TieneAsistenciasEnHorarios(Curso un_curso, List<HorarioDeCursada> horarios_nuevos)
        {
            var horarios_originales = un_curso.GetHorariosDeCursada();
            var asistencias = new RepositorioDeAsistencias(this.conexion).GetAsistencias();

            var horarios_inamovibles = horarios_originales.FindAll(h => asistencias.Exists(a => a.Fecha.DayOfWeek == h.Dia));
            var horarios_con_horas_catedra_cambiadas = horarios_originales.FindAll(h => horarios_nuevos.Exists(hn => h.Dia == hn.Dia && h.HorasCatedra != hn.HorasCatedra));
            if (horarios_nuevos.FindAll(h => horarios_inamovibles.Contains(h)).Count > 0 && horarios_con_horas_catedra_cambiadas.Count > 0)
                return true;
            else
                return false;
        }

        public bool TieneAsignadoAlumnos(Curso un_curso)
        {
            return un_curso.Alumnos().Count > 0;
        }

        public bool TieneAsignadoDocente(Curso un_curso)
        {
            return un_curso.Docente != null;
        }

        public List<InstanciaDeEvaluacion> GetInstanciasDeEvaluacion(int id_curso)
        {
            return GetCursoById(id_curso).Materia.Modalidad.InstanciasDeEvaluacion;
        }


        public List<Curso> GetCursosParaElAlumno(Alumno alumno, List<Curso> total_de_cursos)
        {
            var cursos_del_alumno = total_de_cursos.FindAll(c => c.Alumnos().Contains(alumno));

            return cursos_del_alumno;
        }

        public int GetMaxHorasCatedraCurso()
        {
            //Verificar que no se elimine el alumno si tiene asistencias

            return int.Parse(conexion.EjecutarEscalar("dbo.SACC_Get_MaxHorasCatedraCurso").ToString());
        }

        //public List<Observacion> GetObservaciones()
        //{

        //    List<Observacion> observaciones = new List<Observacion>();
        //    observaciones.Add(new Observacion(1, new DateTime(2013, 09, 06), "Fines CENS", "Mariano", "MDS", "Cursada", "Mariano", "Entre los alumnos agarraron al profesor para golpearle la cabeza", "Los echamos a todos", new DateTime(2013, 09, 15), "Elena"));
        //    observaciones.Add(new Observacion(2, new DateTime(2013, 09, 06), "Fines Puro", "Leonardo", "MDS", "Cursada", "Mariano", "Necesito los certificados de los días que faltó a cursar", "MARIANO, por favor pedile los certificados y avisales a todos los de acá que cada vez que faltan a cursar justifiquen", new DateTime(2013, 09, 15), "Elena"));
        //    observaciones.Add(new Observacion(3, new DateTime(2013, 09, 06), "Fines Puro", "Cholo", "MDS", "Libre", "Mariano", "Esta por quedar libre", "Se lo llamo para motivarlo a venir y terminar el ciclo", new DateTime(2013, 09, 15), "Elena"));
        //    observaciones.Add(new Observacion(4, new DateTime(2013, 09, 06), "Fines CENS", "Stefania", "MDS", "Expulsion", "Mariano", "Saco un arma en clase y amenazo con matar a todos", "Llamamos a la policia y se lo llevaron a comer una pizza para calmarlo", new DateTime(2013, 09, 15), "Elena"));

        //    return observaciones;
        //}

        //public List<Observacion> GetObservaciones()
        //{
        //    return this.cache.Ejecutar(GetObservacionesDesdeLaBase, this);
        //}

        public List<Observacion> GetObservaciones()
        {
            var tablaDatos = conexion.Ejecutar("dbo.SACC_Get_Observaciones");
            var observaciones = new List<Observacion>();

            tablaDatos.Rows.ForEach(row =>
            {
               
                Observacion observacion = new Observacion
                    (
                    row.GetInt("id"),
                    row.GetObject("FechaCarga") is DBNull ? new DateTime(DateTime.Now.Year, 1, 1) : row.GetDateTime("FechaCarga"),
                    row.GetString("Relacion"),
                    row.GetString("PersonaCarga"),
                    row.GetString("Pertenece"),
                    row.GetString("Asunto"),
                    row.GetString("ReferenteMDS"),
                    row.GetString("Seguimiento"),
                    row.GetString("Resultado"),
                    row.GetObject("FechaDelResultado") is DBNull ? new DateTime(DateTime.Now.Year, 1, 1) : row.GetDateTime("FechaDelResultado"),
                    row.GetString("ReferenteRtaMDS"));

                //observacion.Id = row.GetInt("id");
                    //row.GetString("idBaja"));

                observaciones.Add(observacion);
            });

            //observaciones.Sort((curso1, curso2) => curso1.esMayorAlfabeticamenteQue(curso2));
            return observaciones;
        }

        public List<Observacion> GuardarObservaciones(List<Observacion> observaciones_antiguas, List<Observacion> observaciones_nuevas, Usuario usuario)
        {
            var registros_no_procesados = new List<Observacion>();
            //FC: tengo que incluir para update a las que borre y ya estaban
            var observaciones_a_updatear = comparador.ObservacionesParaActualizar(observaciones_antiguas, observaciones_nuevas);
            //FC: estas no tengo que insertarlas mas en el historico
            var observaciones_para_dar_de_baja = comparador.ObservacionesParaDarDeBaja(observaciones_antiguas, observaciones_nuevas);
            var observaciones_a_insertar = comparador.ObservacionesParaGuardar(observaciones_antiguas, observaciones_nuevas);
            //FC:estas no tengo que borrarlas mas
            var observaciones_a_borrar = comparador.ObservacionesParaDarDeBajaSinInsertarOtra(observaciones_antiguas, observaciones_nuevas);

            foreach (var e in observaciones_a_insertar)
            {
                if (GuardarObservacion(e, usuario).Equals(0))
                    registros_no_procesados.Add(e);
            }
            foreach (var e in observaciones_a_updatear)
            {
                if (GuardarObservacion(e, usuario).Equals(0))
                    registros_no_procesados.Add(e);
            }
            foreach (var e in observaciones_para_dar_de_baja)
            {
                var idBaja = CrearBaja(usuario);
                ActualizarObservacion(e, usuario, idBaja);
            }
            foreach (var e in observaciones_a_borrar)
            {
                var idBaja = CrearBaja(usuario);
                if (ActualizarObservacion(e, usuario, idBaja).Equals(0))
                    registros_no_procesados.Add(e);
            }
            return registros_no_procesados;
        }

        public int GuardarObservacion(Observacion observacion, Usuario usuario)
        {

            var parametros = new Dictionary<string, object>();

            parametros.Add("@FechaCarga", observacion.FechaCarga);
            parametros.Add("@Relacion", observacion.Relacion);
            parametros.Add("@PersonaCarga", observacion.PersonaCarga);
            parametros.Add("@Pertenece", observacion.Pertenece);
            parametros.Add("@Asunto", observacion.Asunto);
            parametros.Add("@ReferenteMDS", observacion.ReferenteMDS);
            parametros.Add("@Seguimiento", observacion.Seguimiento);
            parametros.Add("@Resultado", observacion.Resultado);
            parametros.Add("@FechaDelResultado", observacion.FechaResultado);
            parametros.Add("@ReferenteRtaMDS", observacion.ReferenteRespuestaMDS);
            parametros.Add("@idUsuario", usuario.Id);

            return (int)conexion.EjecutarEscalar("dbo.SACC_Ins_Observacion", parametros);

        }

        private int ActualizarObservacion(Observacion observacion, Usuario usuario, int idBaja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", observacion.Id);
            parametros.Add("@FechaCarga", observacion.FechaCarga);
            parametros.Add("@Relacion", observacion.Relacion);
            parametros.Add("@PersonaCarga", observacion.PersonaCarga);
            parametros.Add("@Pertenece", observacion.Pertenece);
            parametros.Add("@Asunto", observacion.Asunto);
            parametros.Add("@ReferenteMDS", observacion.ReferenteMDS);
            parametros.Add("@Seguimiento", observacion.Seguimiento);
            parametros.Add("@Resultado", observacion.Resultado);
            parametros.Add("@FechaDelResultado", observacion.FechaResultado);
            parametros.Add("@ReferenteRtaMDS", observacion.ReferenteRespuestaMDS);
            parametros.Add("@idUsuario", usuario.Id);
            if (idBaja != 0)
                parametros.Add("@id_baja", idBaja);
                                                     
            return (int)conexion.EjecutarEscalar("dbo.SACC_Upd_Del_Observaciones", parametros);
        }


    }
}