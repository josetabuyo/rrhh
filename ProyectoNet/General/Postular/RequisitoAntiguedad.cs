using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class RequisitoAntiguedad:RequisitoPerfil
    {
        protected AmbitoLaboral ambitoLaboral;

        public RequisitoAntiguedad(string descripcion, AmbitoLaboral ambitoLaboral)
        {
            this.Descripcion = descripcion;
            this.ambitoLaboral = ambitoLaboral;
        }

        public RequisitoAntiguedad(string descripcion, int id_ambito_laboral)
        {
            this.Descripcion = descripcion;
            this.ambitoLaboral = new AmbitoLaboral(id_ambito_laboral,"");
        }

        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            if (item_cv.GetType() != typeof(CvExperienciaLaboral))
            {
                return false;
            }
            else
            {
                return ((CvExperienciaLaboral)item_cv).AmbitoLaboral.Equals(this.ambitoLaboral.Id);
            }
        }
    }
}
