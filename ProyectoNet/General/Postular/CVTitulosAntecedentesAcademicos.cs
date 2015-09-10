using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
   public class CVTitulosAntecedentesAcademicos
    {

       public int Id;
       public string Descripcion;
       public int SoloVisiblePara { get; set; }

       public CVTitulosAntecedentesAcademicos()
        {

        }

       public CVTitulosAntecedentesAcademicos(int id, string descripcion, int solo_visible_para)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.SoloVisiblePara = solo_visible_para;
        }
    }
}
