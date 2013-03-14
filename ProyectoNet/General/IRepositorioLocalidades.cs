using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General
{
    public interface IRepositorioLocalidades
    {
        List<Localidad> GetLocalidadesDeLaProvincia(Provincia zona);
    }
}
