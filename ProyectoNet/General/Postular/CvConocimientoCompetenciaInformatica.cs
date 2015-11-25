using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General.Postular
{
    public class CvConocimientoCompetenciaInformatica
    {
        public string Descripcion;
        public int Tipo;
        public int Id;
        public int SoloVisiblePara;
        public CvConocimientoCompetenciaInformatica()
        {

        }

        public CvConocimientoCompetenciaInformatica(int id, string descripcion, int tipo, int solo_visible_para)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Tipo = tipo;
            this.SoloVisiblePara = solo_visible_para;
        }
    }
}
