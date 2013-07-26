using System;
namespace General.Repositorios
{
    public interface IRepositorioDeDocentes
    {
        bool DocenteAsignadoACurso(General.Docente un_docente);
        General.Docente GetDocenteByDNI(int dni);
        General.Docente GetDocenteById(int id);
        General.Docente GetDocenteByNombre(string nombre);
        System.Collections.Generic.List<General.Docente> GetDocentes();
        void GuardarDocente(General.Docente un_docente, General.Usuario usuario);
        void QuitarDocente(General.Docente un_docente, General.Usuario usuario);
    }
}
