using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General
{
    public interface IRepositorioProvincias
    {
        List<Provincia> GetProvinciasDeLaZona(Zona zona);
    }
}
