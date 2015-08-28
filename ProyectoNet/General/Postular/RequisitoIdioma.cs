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
            this.Descripcion = descripcion;
            this.idiomas_requeridos = idiomas_requeridos;
        }

        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            if (item_cv.GetType() != typeof(CvIdiomas))
            {
                return false;
            }
            else
            {
                return this.idiomas_requeridos.Any(i => i.Equals(((CvIdiomas)item_cv).Idioma));
            }
        }   
    }
}
