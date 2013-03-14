using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeProvincias
    {

        #region IRepositorioProvincias Members

        public List<Provincia> GetProvinciasDeLaZona(Zona zona)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.VIA_GetProvinciasDeLaZona");
            cn.AsignarParametro("@idZona", zona.Id);

            dr = cn.EjecutarConsulta();
            Provincia unaProvincia;
            List<Provincia> provincias = new List<Provincia>();
            RepositorioLocalidades repositorio = new RepositorioLocalidades();

            while (dr.Read())
            {
                unaProvincia = new Provincia { Id = dr.GetInt16(0), Nombre = dr.GetString(1), CodigoAFIP = dr.GetInt16(0) };
                provincias.Add(unaProvincia);
                unaProvincia.Localidades = repositorio.GetLocalidadesDeLaProvincia(unaProvincia);
            }
            return provincias;
        }
        #endregion
    }
}
