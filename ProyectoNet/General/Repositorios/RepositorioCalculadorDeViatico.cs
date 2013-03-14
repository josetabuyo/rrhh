using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioCalculadorDeViatico
    {

        #region RepositorioCalculadorDeViatico Members

        public Decimal GetValorDeViatico(Estadia estadia, Persona persona)
        {
            ConexionDB cn = new ConexionDB("dbo.VIA_GetValorDelViatico");

            cn.AsignarParametro("@idTipoViatico", persona.TipoDeViatico.Id );
            cn.AsignarParametro("@idZona", estadia.Provincia.Zona.Id);

            SqlDataReader rto = cn.EjecutarConsulta();

            if (rto.Read())
            {
                return rto.GetDecimal(3);
            }

            //No creo que deberia volver 0
            return 0;
        }


        #endregion

    }
}
