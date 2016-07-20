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
            int anio_calculo = fecha_calculo.Year;
            var prorroga = new ProrrogaLicenciaOrdinaria();
            RepositorioLicencias repo = new RepositorioLicencias(Conexion());
            if (anios == 0)
            {
                if (fecha_calculo.Month != 12)
                {
                    //Si no es diciembre, el año de cálculo es el anterior
                    anios = repo.GetProrrogaPlantaGeneral(anio_calculo - 1);
                }
                else
                {
                    anios = repo.GetProrrogaPlantaGeneral(anio_calculo);
                }

            }

            prorroga.UsufructoDesde = anio_calculo - anios;
            prorroga.UsufructoHasta = anio_calculo;

            return prorroga;
        }

        public ConexionBDSQL Conexion()
        {
            return new ConexionBDSQL(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
        }
    }
}
