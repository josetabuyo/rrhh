using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AnalisisDeLicenciaOrdinaria
    {
        public List<LogCalculoVacaciones> lineas { get; set; }

        public AnalisisDeLicenciaOrdinaria()
        {
            this.lineas = new List<LogCalculoVacaciones>();
        }

        public void Add(SolicitudesDeVacaciones aprobadas, VacacionesPermitidas primera_permitida_aplicable)
        {
            var linea = lineas.Find(l => l.PeriodoAutorizado.Equals(primera_permitida_aplicable.Periodo));
            if (LineaCompleta(linea))
            {
                linea = new LogCalculoVacaciones();
                this.lineas.Add(linea);
            }

            linea.CantidadDiasDescontados = aprobadas.CantidadDeDias();
            linea.LicenciaDesde = aprobadas.Desde();
            linea.LicenciaHasta = aprobadas.Hasta();

        }

        /// <summary>
        /// Agrega un registro a la tabla del analisis para las vacaciones permitidas consumibles
        /// </summary>
        /// <param name="analisis">la coleccion de registros del analisis en curso</param>
        /// <param name="permitidas_consumibles">la cantidad de dias consumibles con su periodo</param>
        public void Add(VacacionesPermitidas permitidas_consumibles)
        {
            lineas.Add(new LogCalculoVacaciones() { PeriodoAutorizado = permitidas_consumibles.Periodo, CantidadDiasAutorizados = permitidas_consumibles.CantidadDeDias() });
        }

        protected bool LineaCompleta(LogCalculoVacaciones linea)
        {
            return !linea.LicenciaDesde.Equals(DateTime.MinValue);
        }

        public void Add(LogCalculoVacaciones logCalculoVacaciones)
        {
            lineas.Add(logCalculoVacaciones);
        }

        public LogCalculoVacaciones First()
        {
            return lineas.First();
        }

        public LogCalculoVacaciones Last()
        {
            return lineas.Last();
        }

        public int Count()
        {
            return lineas.Count();
        }

    }
}
