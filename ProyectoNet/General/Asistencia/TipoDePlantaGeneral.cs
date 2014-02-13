using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    
    public class TipoDePlantaGeneral : TipoDePlanta
    {
        private int _id;
        public int Id { get { return _id; }  }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; }  }


        public TipoDePlantaGeneral(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
        }

        public override ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {

            var prorroga = new ProrrogaLicenciaOrdinaria();

            if (fecha_calculo.Month == 12)
            {
                prorroga.UsufructoDesde = fecha_calculo.Year - 8;
                prorroga.UsufructoHasta = fecha_calculo.Year;
            }
            else
            {
                prorroga.UsufructoDesde = fecha_calculo.Year - 9;
                prorroga.UsufructoHasta = fecha_calculo.Year - 1;
            }

            return prorroga;
        }

    }
}
