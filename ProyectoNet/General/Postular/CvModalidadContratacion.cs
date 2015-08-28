using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvModalidadContratacion
    {
        public int Id;
        public string Descripcion;

        public CvModalidadContratacion() { }


        public CvModalidadContratacion(int id, string descripcion)
        {
            // TODO: Complete member initialization
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
