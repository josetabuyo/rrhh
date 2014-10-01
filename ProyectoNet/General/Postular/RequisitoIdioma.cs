using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class RequisitoIdioma
    {

        public string Idioma { get; protected set; }

        public RequisitoIdioma(string idioma)
        {
            this.Idioma = idioma;
        }

        public override bool Equals(object obj)
        {
            return Idioma.Equals(((RequisitoIdioma)obj).Idioma);
        }
    }
}
