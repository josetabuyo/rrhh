using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General.Repositorios
{
    public class RepositorioDePasajes
    {

        #region IRepositorioPasajes Members

        private IConexionBD conexion_bd;

        public RepositorioDePasajes(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public void AltaDePasajes(List<Pasaje> Pasajes)
        {
            foreach (Pasaje un_pasaje in Pasajes)
            {
                AltaDeUnPasaje(un_pasaje);
            }
        }

        public void AltaDeUnPasaje(Pasaje un_pasaje)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdComisionDeServicio", un_pasaje.ComisionDeServicio.Id);
            parametros.Add("@Fecha", un_pasaje.FechaDeViaje);
            parametros.Add("@Origen", un_pasaje.Origen.Id);
            parametros.Add("@Destino", un_pasaje.Destino.Id);
            parametros.Add("@Precio", un_pasaje.Precio);
            parametros.Add("@MedioDeTransporte", un_pasaje.MedioDeTransporte.Id);
            parametros.Add("@MedioDePago", un_pasaje.MedioDePago.Id);
            parametros.Add("@Baja", un_pasaje.Baja);
            parametros.Add("@usuario", un_pasaje.Baja);
            var id = conexion_bd.EjecutarEscalar("dbo.VIA_AltaPasaje", parametros);
            un_pasaje.Id = (int)((Decimal)id);
        }

        public void BajaDePasajes(List<Pasaje> Pasajes)
        {
            foreach (Pasaje un_pasaje in Pasajes)
            {
                BajaDeUnPasaje(un_pasaje);
            }
        }

        private void BajaDeUnPasaje(Pasaje un_pasaje)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPasaje", un_pasaje.Id);
            conexion_bd.EjecutarSinResultado("dbo.VIA_BajaPasaje", parametros);
        }

        #endregion
    }
}
