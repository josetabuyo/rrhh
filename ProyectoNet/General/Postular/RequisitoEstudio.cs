using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class RequisitoEstudio: RequisitoPerfil
    {
        protected NivelDeEstudio nivel_de_estudio;
        //protected string descripcion_requisito;

        public RequisitoEstudio(NivelDeEstudio nivelDeEstudio)
        {
            this.nivel_de_estudio = nivelDeEstudio;
        }

        public RequisitoEstudio(string descripcion_requisito, NivelDeEstudio nivelDeEstudio)
        {
            this.Descripcion = descripcion_requisito;
            this.nivel_de_estudio = nivelDeEstudio;
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((RequisitoEstudio)obj).nivel_de_estudio.Equals(this.nivel_de_estudio);
        }

        public override int GetHashCode()
        {
            return this.nivel_de_estudio.GetHashCode();
        }

        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            if (item_cv.GetType() != typeof(CvEstudios))
            {
                return false;
            }
            else
            {
                return ((CvEstudios)item_cv).Nivel.Equals(this.nivel_de_estudio.Id);
            }

        }
    }
}
