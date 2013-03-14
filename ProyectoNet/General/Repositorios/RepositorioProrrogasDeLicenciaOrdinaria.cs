using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioProrrogasDeLicenciaOrdinaria

    {

        #region IRepositorioProrrogasDeLicenciaOrdinaria Members

        public ProrrogaLicenciaOrdinaria CargarDatos(ProrrogaLicenciaOrdinaria unaProrroga)
        {
            unaProrroga.Periodo = DateTime.Today.Year;

            ConexionDB cn = new ConexionDB("dbo.WEB_GetProrrogaOrdinaria");
            cn.AsignarParametro("@periodo", unaProrroga.Periodo);

            SqlDataReader dr;
            dr = cn.EjecutarConsulta();

            if (dr.Read())
            {
                unaProrroga.UsufructoDesde = dr.GetInt16(dr.GetOrdinal("Prorroga_Desde"));
                unaProrroga.UsufructoHasta = dr.GetInt16(dr.GetOrdinal("Prorroga_Hasta"));
            }
            else
            {
                unaProrroga = null;
            }
            return unaProrroga;
        }

        #endregion
    }
}
