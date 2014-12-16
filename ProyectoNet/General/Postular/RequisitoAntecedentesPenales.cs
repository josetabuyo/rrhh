using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class RequisitoAntecedentesPenales:RequisitoPerfil
    {

        protected AntecedentePenal antecedentePenal;

        public RequisitoAntecedentesPenales(string descripcion, int parametro)
        {
            this.Descripcion = descripcion;
        }


        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            if (item_cv.GetType() != typeof(AntecedentePenal))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
