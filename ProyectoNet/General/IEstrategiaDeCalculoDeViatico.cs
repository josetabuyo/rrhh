using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General
{
    public interface IEstrategiaDeCalculoDeViatico
    {
        float CalcularViatico(Zona unaZona, Persona unaPersona);

        float CalcularViatico(ComisionDeServicio comision);

        float CalcularViatico(Estadia estadia);
    }
}
