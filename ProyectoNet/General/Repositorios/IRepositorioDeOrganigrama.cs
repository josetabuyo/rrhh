using System;
namespace General.Repositorios
{
    public interface IRepositorioDeOrganigrama
    {
        System.Collections.Generic.List<System.Collections.Generic.List<int>> ExcepcionesDeCircuitoViaticos();
        General.Area GetAreaById(int id);
        General.Organigrama GetOrganigrama();
        System.Collections.Generic.List<General.Alias> ObtenerTodosLosAliasDeAreas();
    }
}
