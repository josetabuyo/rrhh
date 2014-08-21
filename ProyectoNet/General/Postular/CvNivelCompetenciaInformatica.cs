using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
   public class CvNivelCompetenciaInformatica
    {

        public int Id;
        public string Descripcion;

        public CvNivelCompetenciaInformatica()
        {

        }

        public CvNivelCompetenciaInformatica(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }



    }
}
