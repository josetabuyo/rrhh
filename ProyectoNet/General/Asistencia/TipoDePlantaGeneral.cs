using System;
using System.Collections.Generic;
using System.Text;
using General.Repositorios;
using System.Configuration;

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

        protected static int anios = 0;

        public override ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            var prorroga = new ProrrogaLicenciaOrdinaria();
            if (anios == 0)
            {
                RepositorioLicencias repo = new RepositorioLicencias(Conexion());
                anios = repo.GetProrrogaPlantaGeneral(fecha_calculo.Year);
            }          

            if (fecha_calculo.Month == 12)
            {
                prorroga.UsufructoDesde = fecha_calculo.Year - anios;
                prorroga.UsufructoHasta = fecha_calculo.Year;
            }
            else
            {
                prorroga.UsufructoDesde = fecha_calculo.Year + 1 - anios;
                prorroga.UsufructoHasta = fecha_calculo.Year + 1;
            }

            return prorroga;
        }

        public ConexionBDSQL Conexion()
        {
            return new ConexionBDSQL(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
        }
    }
}
