using System;
using System.Collections.Generic;

namespace General
{
    public class EspacioFisico
    {
        public string Aula { get; set; }

        public string Edificio { get; set; }

        public EspacioFisico()
        {

        }

        internal int esMayorAlfabeticamenteQue(EspacioFisico otroespaciofisico)
        {
            return this.Aula.CompareTo(otroespaciofisico.Aula);
        }
    }
}
