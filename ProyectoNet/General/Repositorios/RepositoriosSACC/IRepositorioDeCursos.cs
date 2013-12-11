using System;
using System.Collections.Generic;
using AdministracionDeUsuarios;
namespace General.Repositorios
{
    public interface IRepositorioDeCursos
    {
        void ActualizarInscripcionesACurso(System.Collections.Generic.List<General.Alumno> alumnos_a_inscribir, General.Curso curso, Usuario usuario);
        bool AgregarCurso(General.Curso curso);
        General.Curso GetCursoById(int id);
        System.Collections.Generic.List<General.Curso> GetCursos();
        bool ModificarCurso(General.Curso curso);
        bool QuitarCurso(General.Curso curso, Usuario usuario);
        bool TieneAsignadoAlumnos(General.Curso un_curso);
        bool TieneAsignadoDocente(General.Curso un_curso);
        List<General.Curso> GetCursosParaElAlumno(General.Alumno alumno, List<General.Curso> cursos);
    }
}
