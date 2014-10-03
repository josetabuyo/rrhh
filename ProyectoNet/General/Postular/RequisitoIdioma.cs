using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class RequisitoIdioma:RequisitoPerfil
    {

        public string Idioma { get; protected set; }

        public RequisitoIdioma(string descripcion, string idioma)
        {
            this.Idioma = idioma;
            this.Descripcion = descripcion;
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
            return ((CvIdiomas)item_cv).Idioma.Equals(this.Idioma);
        }   
    }
}
