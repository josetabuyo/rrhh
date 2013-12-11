using System;
using AdministracionDeUsuarios;
namespace General.Repositorios
{
    public interface IRepositorioDeAlumnos
    {
        global::General.Alumno ActualizarAlumno(global::General.Alumno alumno, global::AdministracionDeUsuarios.Usuario usuario);
        bool AlumnoAsignadoACurso(global::General.Alumno un_alumno);
        global::General.Alumno GetAlumnoByDNI(int dni);
        global::System.Collections.Generic.List<global::General.Alumno> GetAlumnos();
        void GuardarAlumno(global::General.Alumno un_alumno, global::AdministracionDeUsuarios.Usuario usuario);
        void QuitarAlumno(global::General.Alumno un_alumno, global::AdministracionDeUsuarios.Usuario usuario);
    }
}
