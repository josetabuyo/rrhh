using System;
using System.Collections.Generic;
using System.Linq;



namespace General.Repositorios
{
    public class Reportes
    {

        public Reportes() 
        {
        }



        public List<Alumno> ObtenerAlumnosConModalidad(Modalidad modalidad, IRepositorioDeCursos repo_curso)
        {
            List<Alumno> alumnos_de_la_modaldiad = new List<Alumno>();

            List<Curso> cursos_con_modalidad = repo_curso.GetCursos().FindAll(c => c.Materia.Modalidad.Id == modalidad.Id);

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

        //public List<Alumno> ObtenerAlumnosConModalidad(Modalidad modalidad, Ciclo ciclo, IRepositorioDeCursos repo_curso)
        //{
        //    List<Alumno> alumnos_de_la_modaldiad = new List<Alumno>();

        //    List<Curso> cursos_con_modalidad = repo_curso.GetCursos().FindAll(c => (c.Materia.Modalidad.Id == modalidad.Id));

        //    foreach (Curso curso in cursos_con_modalidad)
        //    {
        //        if (curso.Materia.Ciclo.Id == ciclo.Id)
        //        {
        //            alumnos_de_la_modaldiad.AddRange(curso.Alumnos());
        //        }
        //    }

        //   return  alumnos_de_la_modaldiad.Distinct().ToList();
        //}
    }
}
