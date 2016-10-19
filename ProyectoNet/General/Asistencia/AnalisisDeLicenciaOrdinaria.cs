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

            int index_of_primer_linea_proximo_periodo = IndexOfPrimerLineaProximoPeriodo(primera_permitida_aplicable.Periodo);


            if (LineaCompleta(linea))
            {
                if (lineaConAcarreoDeLineaAnterior(linea))
                {
                    index_of_primer_linea_proximo_periodo++;
                }
                linea = new LogCalculoVacaciones();
                
                this.lineas.Insert(index_of_primer_linea_proximo_periodo, linea);
                //this.lineas.Add(linea);
            }

            linea.CantidadDiasDescontados = aprobadas.CantidadDeDias();
            if (!lineas.Any(l => l.LicenciaDesde.Equals(aprobadas.Desde())))
            {
                linea.LicenciaDesde = aprobadas.Desde();
                linea.LicenciaHasta = aprobadas.Hasta();
            }


        }

        private static bool lineaConAcarreoDeLineaAnterior(LogCalculoVacaciones linea)
        {
            return linea.LicenciaDesde.Equals(DateTime.MinValue) && linea.CantidadDiasDescontados != 0;
        }

        private int IndexOfPrimerLineaProximoPeriodo(int periodo)
        {
            var primer_linea_proximo_periodo = lineas.Find(l => l.PeriodoAutorizado.Equals(periodo + 1));
            int index_of_primer_linea_proximo_periodo;
            if (primer_linea_proximo_periodo != null)
            {
                index_of_primer_linea_proximo_periodo = this.lineas.IndexOf(primer_linea_proximo_periodo);
            }
            else
            {
                if (this.lineas.Count() == 1)
                {
                    index_of_primer_linea_proximo_periodo = 1;
                }
                else
                {
                    index_of_primer_linea_proximo_periodo = this.lineas.Count() - 1;
                }

            }
            return index_of_primer_linea_proximo_periodo;
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

        public void Add(VacacionesPermitidas permitidas_consumibles, SolicitudesDeVacaciones solicitud, AnalisisDeLicenciaOrdinaria analisis)
        {
            var log = this.lineas.Find(l => l.PeriodoAutorizado == permitidas_consumibles.Periodo);
            if (analisis.LineaCompleta(log))
            {
                log = new LogCalculoVacaciones() { PeriodoAutorizado = 0, CantidadDiasAutorizados = 0, CantidadDiasDescontados = solicitud.DiasYaImputados(), LicenciaDesde = solicitud.Desde(), LicenciaHasta = solicitud.Hasta() };
                analisis.AddALaAuthorizacionDelPeriodo(log, permitidas_consumibles.Periodo);
            }
            else
            {
                log.CantidadDiasDescontados = solicitud.DiasYaImputados();
                log.LicenciaDesde = solicitud.Desde();
                log.LicenciaHasta = solicitud.Hasta();
            }
            //var log = new LogCalculoVacaciones() { PeriodoAutorizado = 0, CantidadDiasAutorizados = 0, CantidadDiasDescontados = solicitud.DiasYaImputados(), LicenciaDesde = solicitud.Desde(), LicenciaHasta = solicitud.Hasta() };
            //lineas.Add(log);
        }

        protected bool LineaCompleta(LogCalculoVacaciones linea)
        {
            return !(linea.LicenciaDesde.Equals(DateTime.MinValue) && linea.CantidadDiasDescontados == 0);
        }

        public void Add(LogCalculoVacaciones logCalculoVacaciones)
        {
            lineas.Add(logCalculoVacaciones);
        }

        public void AddALaAuthorizacionDelPeriodo(LogCalculoVacaciones log, int periodo)
        {
            var lineas_del_periodo = lineas.FindAll(l => l.PeriodoAutorizado == periodo);
            var index_of_primer_linea_proximo_periodo = IndexOfPrimerLineaProximoPeriodo(periodo);
            lineas.Insert(index_of_primer_linea_proximo_periodo, log);
            //throw new NotImplementedException();
        }

        public LogCalculoVacaciones At(int i)
        {
            return lineas[i];
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

        public void SetCalculoSinDescuento(List<VacacionesPermitidas> permitidas_calculadas)
        {

        }

        public void LasAutorizadasSinDescontarSon(List<VacacionesPermitidas> vacas_perdidas, List<VacacionesPermitidas> permitidas)
        {
            List<LogCalculoVacaciones> perdidas = new List<LogCalculoVacaciones>();
            permitidas.ForEach(perm =>
            {
                var linea_del_periodo = lineas.Find(l => l.PeriodoAutorizado == perm.Periodo);
                if (linea_del_periodo != null)
                {
                    if (linea_del_periodo.CantidadDiasAutorizados != perm.CantidadDeDias())
                    {
                        var dias_perdidos = perm.CantidadDeDias() - linea_del_periodo.CantidadDiasAutorizados;
                        linea_del_periodo.CantidadDiasAutorizados = perm.CantidadDeDias();
                        var per = new LogCalculoVacaciones();
                        per.PeriodoAutorizado = perm.Periodo;
                        per.CantidadDiasDescontados = dias_perdidos;
                        per.PerdidaExplicitamente = true;

                        var vp = vacas_perdidas.Find(v => v.Periodo == perm.Periodo);
                        if (vp != null)
                        {
                            per.Observacion = vp.Observacion;
                        }

                        perdidas.Add(per);
                    }
                }
            });

            perdidas.ForEach(p =>
                {
                    var index = 0;
                    var found = false;
                    var primera = lineas.Find(l => l.PeriodoAutorizado == p.PeriodoAutorizado);
                    index = lineas.IndexOf(primera) + 1;
                    for (int i = lineas.IndexOf(primera) + 1; i < lineas.Count; i++)
                    {
                        if (lineas[i].PeriodoAutorizado == 0 && ! found)
                        {
                            index = i;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    p.PeriodoAutorizado = 0;
                    lineas.Insert(index, p);
                });
        }

        public void CompletarLicenciasPerdidasPorVencimiento()
        {
            var periodo = 0;
            var suma = 0;
            var suma_esperada = 0;

            for (int i = 0; i < this.lineas.Count; i++)
            {
                if (lineas[i].PeriodoAutorizado != 0)
                {
                    if (suma_esperada != suma && HaySolicitudPosteriorA(lineas[i]))
                    {
                        lineas.Insert(i, new LogCalculoVacaciones() { PerdidaPorVencimiento = true, CantidadDiasDescontados = suma_esperada - suma });
                        i++;
                    }

                    periodo = lineas[i].PeriodoAutorizado;
                    suma_esperada = lineas[i].CantidadDiasAutorizados;
                    suma = 0;
                }

                suma += lineas[i].CantidadDiasDescontados;
            }
        }

        protected bool HaySolicitudPosteriorA(LogCalculoVacaciones logCalculoVacaciones)
        {
            var lineas_posteriores = lineas.GetRange(this.lineas.IndexOf(logCalculoVacaciones), lineas.Count - this.lineas.IndexOf(logCalculoVacaciones));
            return lineas_posteriores.Any(l => !l.LicenciaDesde.Equals(DateTime.MinValue));
        }
    }
}
