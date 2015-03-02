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
        public CvConocimientoCompetenciaInformatica()
        {

        }

        public CvConocimientoCompetenciaInformatica(int id, string descripcion, int tipo)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Tipo = tipo;
        }
    }
}
