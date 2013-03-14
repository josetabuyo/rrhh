using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioMediosDePago
    {

        #region IRepositorioMediosDePago Members

        public List<MedioDePago> GetTodosLosMediosDePago()
        {
            List<MedioDePago> medios = new List<MedioDePago>();
            ConexionDB cn = new ConexionDB("dbo.VIA_GetMediosDePago");
            SqlDataReader dr = cn.EjecutarConsulta();
            MedioDePago medio;

            while (dr.Read())
            {
                medio = new MedioDePago(dr.GetInt16(0),dr.GetString(1));
                medios.Add(medio);
            }
            return medios;
        }

        #endregion
    }
}
