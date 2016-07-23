using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class LogCalculoVacaciones
    {
        public int PeriodoAutorizado { get; set; }
        public int CantidadDiasAutorizados { get; set; }
        public int CantidadDiasDescontados { get; set; }
        public bool YaFueAprobada { get; set; }
        public DateTime LicenciaDesde { get; set; }
        public DateTime LicenciaHasta { get; set; }
    }
}
