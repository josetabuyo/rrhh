using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General.Repositorios
{
    public interface IRepositorioDePersonas
    {
        List<Persona> BuscarPersonas(string criterio);
        List<Persona> BuscarPersonasConLegajo(string criterio);
        TipoDePlanta GetTipoDePlantaActualDe(Persona unaPersona);
		List<Persona> TodasLasPersonas();
		Persona GetPersonaPorId(int id_persona);
    }
}
