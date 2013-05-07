using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace General.Repositorios
{
    public class RepositorioDeCursos
    {

        public IConexionBD conexion_bd { get; set; }
        public static List<Curso> cursos { get; set; }

        public RepositorioDeCursos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public Curso GetCursoById(int id)
        {
            return GetCursos().Find(c => c.Id == id);
        }

        public List<Curso> GetCursos()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Cursos");
            cursos = new List<Curso>();
            EspacioFisico espacio_fisico;

            tablaDatos.Rows.ForEach(row =>
            {
                var docente = GetDocenteByIdCurso(row.GetSmallintAsInt("IdDocente"));
                var espacio_fisico_id = row.GetSmallintAsInt("IdEspacioFisico"); 

                if (espacio_fisico_id == 0)
                {
                    espacio_fisico = new EspacioFisicoNull();
                }
                else
                {
                    espacio_fisico =
                        new RepositorioDeEspaciosFisicos(conexion_bd).GetEspacioFisicoById(espacio_fisico_id);
                }

                Curso curso = new Curso
                {
                    Id = row.GetSmallintAsInt("Id"),
                    Docente = docente,
                    Materia = new RepositorioDeMaterias(conexion_bd).GetMateriaById(row.GetSmallintAsInt("IdMateria")),
                    EspacioFisico = espacio_fisico,
                    FechaInicio = row.GetObject("FechaInicio") is DBNull ? new DateTime(DateTime.Now.Year, 1,1) : row.GetDateTime("FechaInicio"),
                    FechaFin = row.GetObject("FechaFin") is DBNull ? new DateTime(DateTime.Now.Year, 12, 1) : row.GetDateTime("FechaFin")
                };
                var horarios = GetHorariosByIdCurso(row.GetSmallintAsInt("Id"));
                foreach (var h in horarios)
                {
                    curso.AgregarHorarioDeCursada(h);
                }
                var inscripciones = GetInscripcionesByIdCurso(row.GetSmallintAsInt("Id"));
                var alumnos = new RepositorioDeAlumnos(conexion_bd).GetAlumnos();

                var alumnos_inscriptos = alumnos.FindAll(a =>
                {
                    return inscripciones.Contains(a.Id);
                });

                curso.AgregarAlumnos(alumnos_inscriptos);

                cursos.Add(curso);
            });
            cursos.Sort((curso1, curso2) => curso1.esMayorAlfabeticamenteQue(curso2));
            return cursos;
        }

        private Docente GetDocenteByIdCurso(int idCurso)
        {
            var docente = new RepositorioDeDocentes(conexion_bd).GetDocenteById(idCurso);
            if (docente == null)
                docente = new DocenteNull();
            return docente;
        }

        private List<HorarioDeCursada> GetHorariosByIdCurso(int id_curso)
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Horarios");
            var horarios = new List<HorarioDeCursada>();
            tablaDatos.Rows.ForEach(row =>
            {
                var hora_desde = FormatHora(row.GetString("Desde"));
                var hora_hasta = FormatHora(row.GetString("Hasta"));
                var horas_catedra = row.GetSmallintAsInt("HorasCatedra");
                var nro_dia = (DayOfWeek)row.GetSmallintAsInt("NroDiaSemana");
                HorarioDeCursada horario = new HorarioDeCursada(nro_dia, hora_desde, hora_hasta, horas_catedra);
                if (row.GetSmallintAsInt("idCurso") == id_curso)
                    horarios.Add(horario);
            });
            return horarios;
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

        private List<int> GetInscripcionesByIdCurso(int id_curso)
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Inscripciones");
            var inscripciones = new List<int>();
            tablaDatos.Rows.ForEach(row =>
            {
                if (row.GetSmallintAsInt("IdCurso") == id_curso)
                {
                    inscripciones.Add(row.GetInt("IdAlumno"));
                }
            });
            return inscripciones;
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

            int id_curso = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Curso", parametros).ToString());

            InsertarHorarios(id_curso, horarios_nuevos);
            return true;

        }

        public bool QuitarCurso(Curso curso, Usuario usuario)
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
            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Curso", parametros);
            return true;
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }

        public bool ModificarCurso(Curso curso)
        {
            var curso_a_modificar = cursos.Find(c => c.Id == curso.Id);
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

                conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Curso", parametros);
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
                conexion_bd.EjecutarSinResultado("dbo.SACC_Ins_Horario", parametros);
            }
        }

        private void BorrarHorarios(int id_curso)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_curso", id_curso);
            conexion_bd.EjecutarSinResultado("dbo.SACC_Del_Horarios", parametros);
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

        private List<Alumno> ObtenerAlumnosDelCurso(Curso curso)
        {
            var id_alumnos_de_la_base = GetInscripcionesByIdCurso(curso.Id);
            var alumnos = new RepositorioDeAlumnos(conexion_bd).GetAlumnos();
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

            conexion_bd.EjecutarSinResultado("dbo.SACC_Ins_Inscripcion", parametros);
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
            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Inscripcion", parametros);

        }

        private bool TieneAsistenciasEnHorarios(Curso un_curso, List<HorarioDeCursada> horarios_nuevos)
        {
            var horarios_originales = un_curso.GetHorariosDeCursada();
            var asistencias = new RepositorioDeAsistencias(this.conexion_bd).GetAsistencias();

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
    }
}