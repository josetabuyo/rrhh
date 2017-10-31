using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class LugarEntrega
    {

        public int Id;
        public int IdLugar;
        public DateTime Desde;
        public bool Baja;
        public string Descripcion;

        
        public LugarEntrega(){ }


        public LugarEntrega(int id, int idlugar, DateTime desde, bool baja, string descripcion)
        {
            this.Id = id;
            this.IdLugar = idlugar;
            this.Desde = desde;
            this.Baja = baja;
            this.Descripcion = descripcion;        
        }

    }
}
