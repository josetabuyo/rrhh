using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class RequisitoPerfil
    {
        public string Descripcion { get; set; }
        public abstract ItemCv ItemCV();
    }
}
