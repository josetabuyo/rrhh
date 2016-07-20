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

        protected int anios = 0;
        protected static int anio_anterior = 0;

        public override ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            var prorroga = new ProrrogaLicenciaOrdinaria();
            RepositorioLicencias repo = new RepositorioLicencias(Conexion());
            int anio_calculo = fecha_calculo.Year;
            if (anio_anterior != anio_calculo)
            {
                anios = 0;
                anio_anterior = anio_calculo;
            }
            
           
            if (anios == 0)
            {
                if (fecha_calculo.Month != 12)
                {
                    //Si no es diciembre, el año de cálculo es el anterior
                    anio_calculo = anio_calculo - 1;
                    anios = repo.GetProrrogaPlantaGeneral(anio_calculo);
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
