using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class RequisitoIdioma:RequisitoPerfil
    {

        public string Idioma { get; protected set; }

        public RequisitoIdioma(string idioma)
        {
            this.Idioma = idioma;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Idioma.Equals(((RequisitoIdioma)obj).Idioma);
        }

        public override int GetHashCode()
        {
            return this.Idioma.GetHashCode();
        }

        public override ItemCv ItemCV()
        {
            return new ItemCv(this.Idioma);
        }

        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            return item_cv.Descripcion.Equals(this.Idioma);
        }   
    }
}
