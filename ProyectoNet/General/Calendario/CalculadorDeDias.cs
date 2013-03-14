namespace General.Calendario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CalculadorDeDias
    {
        public CalculadorDeDias()
        { }

        public float CalcularDiasDe(Estadia estadia)
        {
            DateTime desde = estadia.Desde;
            DateTime hasta = estadia.Hasta;
            TimeSpan periodo = hasta - desde;
            TimeSpan totalHorasDesde = desde.TimeOfDay;
            TimeSpan totalHorasHasta = hasta.TimeOfDay;

            Double minutos = periodo.TotalMinutes;
            int dias = int.Parse((hasta.Date - desde.Date).TotalDays.ToString());

            TimeSpan horaDeComparacion = new TimeSpan(12, 00, 00);     

            if (desde.Date == hasta.Date)
            {
                return 0.5F;
            }
            else if (totalHorasDesde <= horaDeComparacion & totalHorasHasta <= horaDeComparacion)
            {
                return float.Parse((dias + 0.5).ToString());
            }
            else if (totalHorasDesde <= horaDeComparacion & totalHorasHasta > horaDeComparacion)
            {
                return float.Parse((dias + 1).ToString());
            }
            else if (totalHorasDesde > horaDeComparacion & totalHorasHasta <= horaDeComparacion)
            {
                return float.Parse((dias).ToString());
            }
            else if (totalHorasDesde > horaDeComparacion & totalHorasHasta > horaDeComparacion)
            {
                return float.Parse((dias + 0.5).ToString());
            }

            return float.Parse(periodo.Days.ToString());
        
        }

    }
}
