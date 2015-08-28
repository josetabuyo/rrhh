using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class NivelDeDocencia
    {
        public int Id;
        public string Descripcion;

        public NivelDeDocencia()
        {

        }

        public NivelDeDocencia(int id, string descripcion)
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

            return this.Id == ((NivelDeDocencia) obj).Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return  this.Id;
        }
    }
}
