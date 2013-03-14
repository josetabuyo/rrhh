using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioMediosDeTransporte
    {

        #region IRepositorioMediosDeTransporte Members

        public List<MedioDeTransporte> GetTodosLosMediosDeTransporte()
        {
            List<MedioDeTransporte> medios = new List<MedioDeTransporte>();
            ConexionDB cn = new ConexionDB("dbo.VIA_GetMediosDeTransporte");
            SqlDataReader dr = cn.EjecutarConsulta();
            MedioDeTransporte medio;

            while (dr.Read())
            {
                medio = new MedioDeTransporte(dr.GetInt16(0),dr.GetString(1));
                medios.Add(medio);
            }
            return medios;

        }

        #endregion
    }
}
