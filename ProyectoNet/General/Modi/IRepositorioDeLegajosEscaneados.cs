using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public interface  IRepositorioDeLegajosEscaneados
    {
        List<ImagenModi> getImagenesParaUnLegajo(int legajo);
    }
}
