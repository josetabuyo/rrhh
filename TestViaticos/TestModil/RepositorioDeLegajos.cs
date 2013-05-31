using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestViaticos.TestModil
{
    public class RepositorioDeLegajos
    {
        private List<LegajoModil> legajos { get; set; }
        public RepositorioDeLegajos()
        {
            legajos = new List<LegajoModil>();
            legajos.Add(new LegajoModil(123));
        }

        public LegajoModil getLegajo(int numero_de_legajo)
        {
            var leg = legajos.Find(l=>l.numero == numero_de_legajo);
            if (leg == null) throw new ExcepcionDeLegajoInexistente();
            return leg;
        }       
    }
}
