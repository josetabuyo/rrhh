using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioLocalidades
    {
        #region IRepositorioLocalidades Members

        public List<Localidad> GetLocalidadesDeLaProvincia(Provincia provincia)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.VIA_GetLocalidadesDeLaProvincia");
            cn.AsignarParametro("@idProvincia", provincia.CodigoAFIP);

            dr = cn.EjecutarConsulta();
            Localidad unaLocalidad;
            List<Localidad> localidades = new List<Localidad>();


            while (dr.Read())
            {
                unaLocalidad = new Localidad { Id = dr.GetInt32(0), Nombre = dr.GetString(1) };

                if (provincia.Id == 0) //Si es Capital Federal
                {
                    if (unaLocalidad.Id == 11319) //Solo se agrega la Localidad del Ministerio CP: 1332
                    {
                        localidades.Add(unaLocalidad);
                    }
                }
                else {
                    localidades.Add(unaLocalidad);
                }

                
            }
            return localidades;

        }

        #endregion
    }
}
