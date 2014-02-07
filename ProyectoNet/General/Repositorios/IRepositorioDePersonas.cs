using System;
namespace General.Repositorios
{
    public interface IRepositorioDePersonas
    {
        System.Collections.Generic.List<General.Persona> BuscarPersonas(string criterio);
        System.Collections.Generic.List<General.Persona> BuscarPersonasConLegajo(string criterio);
        IConexionBD conexion_bd { get; set; }
        System.Collections.Generic.List<General.Persona> GetPersonas();
        General.TipoDePlanta GetTipoDePlantaActualDe(General.Persona unaPersona);
        System.Collections.Generic.List<General.Persona> ObtenerPersonasDesdeLaBase();
    }
}
