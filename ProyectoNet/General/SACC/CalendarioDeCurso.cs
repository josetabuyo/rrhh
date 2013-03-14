using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class CalendarioDeCurso
    {

        private List<DayOfWeek> _diasDeCursada;
        private CalendarioDeFeriados _calendarioDeFeriados;
        public CalendarioDeCurso()
        {

        }
        public CalendarioDeCurso(List<DayOfWeek> diasDeCursada, CalendarioDeFeriados unCalendarioDeFeriados)
        {
            this._diasDeCursada = diasDeCursada;
            this._calendarioDeFeriados = unCalendarioDeFeriados;
        }

        public List<DiaDeCursada> DiasACursarSinIncluirFeriadosEntre(DateTime fechaDesde, DateTime fechaHasta)
        {
            var diasACursarConFeriados = this.DiasDeCursadaConFeriadosEntre(fechaDesde, fechaHasta);
            var diasACursarSinFeriados = diasACursarConFeriados.FindAll(dia => _calendarioDeFeriados.NoEsFeriado(dia));
            var diasDeCursadaNoFeriados = diasACursarSinFeriados.Select(unDia => new DiaDeCursada(unDia, false));
            return diasDeCursadaNoFeriados.ToList();
        }

        public List<DiaDeCursada> DiasACursarIncluyendoFeriadosEntre(DateTime fechaDesde, DateTime fechaHasta)
        {
            var diasACursarConFeriados = this.DiasDeCursadaConFeriadosEntre(fechaDesde, fechaHasta);
            var diasACursarSinFeriados = diasACursarConFeriados.FindAll(dia => _calendarioDeFeriados.NoEsFeriado(dia));

            var diasFeriadosCursables = diasACursarConFeriados.FindAll(dia => !_calendarioDeFeriados.NoEsFeriado(dia));

            var diasDeCursadaNoFeriados = diasACursarSinFeriados.Select(unDia => new DiaDeCursada(unDia, false));
            var diasDeCursadaFeriados = diasFeriadosCursables.Select(unDia => new DiaDeCursada(unDia, true));

            return diasDeCursadaNoFeriados.Concat(diasDeCursadaFeriados).ToList();
        }

        private List<DateTime> DiasDeCursadaConFeriadosEntre(DateTime fechaDesde, DateTime fechaHasta)
        {
            var diasACursar = new List<DateTime>();
            var fechaCandidata = fechaDesde;

            while (fechaCandidata.CompareTo(fechaHasta) < 1)
            {
                if (this.validarSiEsCursable(fechaCandidata))
                {
                    diasACursar.Add(fechaCandidata);
                };
                fechaCandidata = fechaCandidata.AddDays(1);
            }
            return diasACursar;
        }

        private bool validarSiEsCursable(DateTime fechaCandidata)
        {
            var diasDeSemanaDeCursada = _diasDeCursada;
            var estaIncluido = diasDeSemanaDeCursada.Contains(fechaCandidata.DayOfWeek);
            return estaIncluido;
        }
    }
}



