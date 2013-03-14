using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalendarioDeFeriados
    {
        private List<DateTime> listaDeFeriados = new List<DateTime>(); 

        public CalendarioDeFeriados()
        {

        }

        public void AgregarFeriado(DateTime feriado)
        {
            listaDeFeriados.Add(feriado);
        }

        internal bool NoEsFeriado(DateTime dia)
        {
            return !listaDeFeriados.Contains(dia);
        }
    }
}
