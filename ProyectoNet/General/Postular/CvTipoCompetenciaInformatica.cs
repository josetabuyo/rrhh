﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
   public class CvTipoCompetenciaInformatica
    {
        public int Id;
        public string Descripcion;

        public CvTipoCompetenciaInformatica()
        {

        }

        public CvTipoCompetenciaInformatica(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }



    }
}
