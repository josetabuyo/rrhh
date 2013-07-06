using System;
namespace General.Repositorios
{
    public interface IRepositorioDeModalidades
    {
        global::General.Modalidad GetModalidadById(int idModalidad);
        global::System.Collections.Generic.List<global::General.Modalidad> GetModalidades();
        global::General.ModalidadNull ModalidadNull();
    }
}
