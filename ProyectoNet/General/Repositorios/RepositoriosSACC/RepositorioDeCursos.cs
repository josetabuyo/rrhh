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

            tablaDatos.Rows.ForEach(row =>
            {
                Curso curso = new Curso
                {
                    Id = row.GetSmallintAsInt("Id"),
                    Docente = new RepositorioDeDocentes(conexion_bd).GetDocenteById(row.GetSmallintAsInt("IdDocente")),
                    Materia = new RepositorioDeMaterias(conexion_bd).GetMateriaById(row.GetSmallintAsInt("IdMateria"))                        
                };
                var horarios = GetHorariosByIdCurso(row.GetSmallintAsInt("Id"));
                foreach (var h in horarios)
                {
                    curso.AgregarHorarioDeCursada(h.Key, h.Value);
                    curso.AgregarDiaDeCursada(h.Key);
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

            return cursos;
        }

        private Dictionary<DayOfWeek, HorarioDeCursada> GetHorariosByIdCurso(int id_curso)
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Horarios");
            var horarios = new Dictionary<DayOfWeek, HorarioDeCursada>();
            tablaDatos.Rows.ForEach(row =>
            {
                var hora_desde = row.GetString("Desde").Substring(0, 2) + ":" + row.GetString("Desde").Substring(2, 2);
                var hora_hasta = row.GetString("Hasta").Substring(0, 2) + ":" + row.GetString("Hasta").Substring(2, 2);
                HorarioDeCursada horario = new HorarioDeCursada(hora_desde, hora_hasta);
                horarios.Add((DayOfWeek)row.GetSmallintAsInt("NroDiaSemana"), horario);
            });
            return horarios;
        }

        private List<int> GetInscripcionesByIdCurso(int id_curso)
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Inscripciones");
            var inscripciones = new List<int>();
            tablaDatos.Rows.ForEach(row =>
            {
                inscripciones.Add(row.GetInt("IdAlumno"));
            });
            return inscripciones;
        }


        public bool AgregarCurso(Curso curso)
        {
            int proximo_id = 0;
            if (cursos.Count > 0)
            {
                proximo_id = cursos.Max(c => c.Id)+1;
            }
            curso.Id = proximo_id;
            cursos.Add(curso);
            return true;
        }

        public bool QuitarCurso(int id)
        {
            try
            {
                var curso_a_eliminar = this.GetCursoById(id);
                cursos.Remove(curso_a_eliminar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarCurso(Curso curso)
        {
            var curso_a_modificar = cursos.Find(c => c.Id == curso.Id);
            if (curso_a_modificar != null)
            {
                var indice = cursos.FindIndex(c => c.Id == curso.Id);
                cursos[indice] = curso;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
