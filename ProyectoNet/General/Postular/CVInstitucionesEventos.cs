using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
   public class CVInstitucionesEventos
    {

       public int Id;
       public string Descripcion;

       public CVInstitucionesEventos()
        {

        }

       public CVInstitucionesEventos(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }



    }
}
