using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public interface IRepositorioDeAccesosAURL
    {
        List<AccesoAURL> TodosLosAccesos();
        void Refresh();
    }
}
