using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class RequisitoAntecedentesPenales:RequisitoPerfil
    {

        public RequisitoAntecedentesPenales(string descripcion, int parametro)
        {
            this.Descripcion = descripcion;
        }


        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            throw new NotImplementedException();
        }
    }
}
