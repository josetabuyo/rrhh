using System;
using AdministracionDeUsuarios;
using General.MAU;
namespace General.Repositorios
{
    public interface IRepositorioDeMaterias
    {
        General.Materia ActualizarMaterias(General.Materia materia, Usuario usuario);
        System.Collections.Generic.List<General.Ciclo> GetCiclos();
        General.Materia GetMateriaById(int id);
        General.Materia GetMateriaByNombre(string nombre);
        System.Collections.Generic.List<General.Materia> GetMaterias();
        General.Materia GuardarMaterias(General.Materia materia, Usuario usuario);
        bool MateriaAsignadaACurso(General.Materia una_materia);
        void QuitarMateria(General.Materia materia, Usuario usuario);
    }
}
