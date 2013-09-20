using System;
using System.Collections.Generic;
using System.Linq;



namespace General.Repositorios
{
    public class Reportes
    {
        public IConexionBD conexion { get; set; }

        public Reportes() 
        {
        }


        public List<Alumno> ObtenerAlumnosQueEstanCursandoConModalidad(Modalidad modalidad, IRepositorioDeCursos repo_curso)
        {
            List<Alumno> alumnos_de_la_modaldiad = new List<Alumno>();
             List<Curso> cursos_con_modalidad = new List<Curso>();
            if (modalidad.Id > 0)
            {
                cursos_con_modalidad = repo_curso.GetCursos().FindAll(c => c.Materia.Modalidad.Id == modalidad.Id && c.FechaInicio <= DateTime.Today && DateTime.Today <= c.FechaFin);
            }
            else 
            {
                cursos_con_modalidad = repo_curso.GetCursos().FindAll(c => c.FechaInicio <= DateTime.Today && DateTime.Today <= c.FechaFin);
            }

            foreach (Curso curso in cursos_con_modalidad)
            {
                alumnos_de_la_modaldiad.AddRange(curso.Alumnos());
            }

           return  alumnos_de_la_modaldiad.Distinct().ToList();
        }

        public List<Alumno> ObtenerAlumnosDelOrganismo(Organismo organismo, IRepositorioDeAlumnos repo_alumno)
        {
            List<Alumno> alumnos_del_organismo = repo_alumno.GetAlumnos();

            return alumnos_del_organismo.FindAll(a => a.Organismo.Id == organismo.Id);
        }

        public List<Materia> ObtenerMateriasNoCursadasDe(Alumno alumno, List<Materia> todas_las_materias, List<Curso> todos_los_cursos, List<Asistencia> asistencias_del_alumno)
        {
            List<Materia> materias_sin_cursar = new List<Materia>();
            List<Curso> cursos_aprobados = new List<Curso>();
            List<Curso> cursos_cursados = new List<Curso>();
            Modalidad modalidad = alumno.Modalidad;
            //RepositorioDeAsistencias repo_asistencia = new RepositorioDeAsistencias(conexion);
            List<Materia> materias_de_la_modalidad = todas_las_materias.FindAll(m => m.Modalidad.Id == modalidad.Id);
            Articulador articulador = new Articulador();

            //Busco todos los cursos en que se dictaron las materias y asistió el Alumno
            foreach (Materia materia in materias_de_la_modalidad)
	        {
                cursos_cursados.AddRange(todos_los_cursos.FindAll(c => c.Alumnos().Exists(a => a.Id == alumno.Id) && c.Materia.Id == materia.Id));
	        }
            //De esos Cursos, tomo sólo los que terminó con condición de Alumno Regular (y falta APROBADO!) 
            foreach (Curso curso in cursos_cursados)
            {
                List<Asistencia> asistencias_por_curso_y_alumno = asistencias_del_alumno.FindAll(a => a.IdCurso == curso.Id);
                
                if (articulador.EsRegular(alumno, curso, asistencias_por_curso_y_alumno)) //&& aprobó!
                {
                    cursos_aprobados.Add(curso);
                }
            }

            //Me quedo con todas las Materias que no aprobó
            foreach (Materia materia in materias_de_la_modalidad)
	        {
		        if(!cursos_aprobados.Exists( c => c.Materia.Id == materia.Id))
                {
                    materias_sin_cursar.Add(materia);
                }
	        }

            return materias_sin_cursar;
        }

        public List<Alumno> ObtenerAlumnosQueNoCursaron(Materia materia, List<Alumno> alumnos, List<Curso> todos_los_cursos, List<Asistencia> asistencias_de_los_alumnos)
        {
            List<Alumno> alumnos_que_no_cursaron = new List<Alumno>();
            List<Materia> materia_to_list = new List<Materia> { materia };
            
            foreach (Alumno alumno in alumnos)
            {
                if(ObtenerMateriasNoCursadasDe(alumno, materia_to_list, todos_los_cursos, asistencias_de_los_alumnos).Count > 0)
                {
                    alumnos_que_no_cursaron.Add(alumno);
                }
            }
            
            return alumnos_que_no_cursaron;
        }

        public List<Alumno> ObtenerAlumnosQueEstanCursandoConModalidadYCiclo(Modalidad modalidad, Ciclo ciclo, IRepositorioDeCursos repo_curso)
        {
            List<Alumno> alumnos_de_la_modaldiad_y_ciclo = new List<Alumno>();

            List<Curso> cursos_con_modalidad = repo_curso.GetCursos().FindAll(c => c.Materia.Modalidad.Id == modalidad.Id && c.Materia.Ciclo.Id == ciclo.Id && c.FechaInicio <= DateTime.Today && DateTime.Today <= c.FechaFin);

            foreach (Curso curso in cursos_con_modalidad)
            {
                alumnos_de_la_modaldiad_y_ciclo.AddRange(curso.Alumnos());
            }

            return alumnos_de_la_modaldiad_y_ciclo.Distinct().ToList();
        }
    }
}
