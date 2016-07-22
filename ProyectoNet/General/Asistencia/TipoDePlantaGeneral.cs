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


        public override ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            var prorroga = new ProrrogaLicenciaOrdinaria();
            RepositorioLicencias repo = new RepositorioLicencias(Conexion());
            int anio_calculo = fecha_calculo.Year;

            if (fecha_calculo.Month != 12)
            {

                anio_calculo = anio_calculo - 1;
                anios = repo.GetProrrogaPlantaGeneral(anio_calculo);
            }
            else
            {
                anios = repo.GetProrrogaPlantaGeneral(anio_calculo);
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
