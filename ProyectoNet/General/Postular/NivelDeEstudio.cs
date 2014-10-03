using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class NivelDeEstudio:RequisitoPerfil
    {
        public int Id;
        public string Descripcion;

        public NivelDeEstudio()
        {

        }

        public NivelDeEstudio(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Id == ((NivelDeEstudio)obj).Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return  this.Id;
        }

        public override ItemCv ItemCV()
        {
            throw new NotImplementedException();
        }

        public override bool EsCumlidoPor(ItemCv item_cv)
        {
            throw new NotImplementedException();
        }
    }
}
