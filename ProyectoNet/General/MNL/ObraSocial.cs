using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MNL
{
    public class ObraSocial
    {
        public ObraSocial() {}
        public ObraSocial(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}
