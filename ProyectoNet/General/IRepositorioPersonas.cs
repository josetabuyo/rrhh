using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public interface IRepositorioPersonas
    {
        List<Persona> GetPersonasDelArea(Area unArea);
        TipoDePlanta GetTipoDePlantaActualDe(Persona unaPersona);
        void EliminarInasistenciaActual(Persona unaPersona);
    }
}
