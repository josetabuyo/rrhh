using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
    public class IntegranteComite
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public bool EsTitular { get; set; }

        public IntegranteComite()
        {

        }
    }
}
