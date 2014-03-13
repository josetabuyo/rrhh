using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    
    public class TipoDePlantaContratado : TipoDePlanta
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; } }

        public TipoDePlantaContratado()
        {
            this._id = 22;
            this._descripcion = "Contratado";
        }

        public override ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            var prorroga = new ProrrogaLicenciaOrdinaria();

            if (fecha_calculo.Month == 12)
                {
                    prorroga.UsufructoDesde = fecha_calculo.Year - 1;
                    prorroga.UsufructoHasta = fecha_calculo.Year;
                } else {
                    prorroga.UsufructoDesde = fecha_calculo.Year - 2;
                    prorroga.UsufructoHasta = fecha_calculo.Year - 1;
                }

            return prorroga;
        }


    }
}
