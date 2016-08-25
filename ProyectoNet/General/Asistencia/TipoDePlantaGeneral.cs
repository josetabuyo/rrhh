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
        protected IRepositorioLicencia _repoLicencias { get; set; }


        public TipoDePlantaGeneral(int id, string descripcion, IRepositorioLicencia repo)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._repoLicencias = repo;
        }

        protected int anios = 0;


        public override ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            var prorroga = new ProrrogaLicenciaOrdinaria();
            //RepositorioLicencias _repoLicencias = new RepositorioLicencias(Conexion());
            int anio_calculo = fecha_calculo.Year;

            if (fecha_calculo.Month != 12)
            {

                anio_calculo = anio_calculo - 1;
                anios = _repoLicencias.GetProrrogaPlantaGeneral(anio_calculo);
            }
            else
            {
                anios = _repoLicencias.GetProrrogaPlantaGeneral(anio_calculo);
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
