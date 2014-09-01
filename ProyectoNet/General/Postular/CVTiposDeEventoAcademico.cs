using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
  public  class CVTiposDeEventoAcademico
    {

       public int Id;
       public string Descripcion;

       public CVTiposDeEventoAcademico()
        {

        }

       public CVTiposDeEventoAcademico(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }



    }
}
