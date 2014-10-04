using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class RequisitoIdioma:RequisitoPerfil
    {
        protected List<string> idiomas_requeridos;

        public RequisitoIdioma(string descripcion, List<string> idiomas_requeridos)
        {
            // TODO: Complete member initialization
            this.Descripcion = descripcion;
            this.idiomas_requeridos = idiomas_requeridos;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }
        //    return idiomas_requeridos.Equals(((RequisitoIdioma)obj).idiomas_requeridos)));
        //}

        //public override int GetHashCode()
        //{
        //    return this.Idioma.GetHashCode();
        //}


        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            return this.idiomas_requeridos.Any(i => i.Equals(((CvIdiomas)item_cv).Idioma));
        }   
    }
}
