using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General
{
    public interface IRepositorioComisionesDeServicio
    {
        void AltaDeComisionesDeServicio(List<ComisionDeServicio> ComisionesDeServicio);
        void CompletarDatosDelCalculoDeViaticosDe(Persona documento);
    }
}
