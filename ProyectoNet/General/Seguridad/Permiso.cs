using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Seguridad
{
    public class Permiso
    {
        public Features Feature { get; set; }

        public string Descripcion
        {
            get {
                return this.Feature.ToString();
            }
        }
    }
}
