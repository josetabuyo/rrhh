using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
   public class UnidadDeTiempo
    {
       
        public int Id;
        public string Descripcion;

        public UnidadDeTiempo()
        {

        }
        
        
        public UnidadDeTiempo(int id, string descripcion)
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

            return this.Id == ((UnidadDeTiempo)obj).Id;
        }
        
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Id;
        }






    }
}
