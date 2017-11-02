using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
   public class MotivoBaja
    {
        public int Id;
        public string Descripcion;
       
        public MotivoBaja() { }
       
        public MotivoBaja(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }


    }
}
