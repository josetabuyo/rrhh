using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General.Repositorios
{
    public class RepositorioDeEstadias
    {

        #region IRepositorioEstadias Members

        private IConexionBD conexion_bd;

        public RepositorioDeEstadias(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public void AltaDeEstadias(List<Estadia> estadias)
        {
            foreach (Estadia una_estadia in estadias)
            {
                AltaDeUnaEstadia(una_estadia);
            }
        }

        public void AltaDeUnaEstadia(Estadia una_estadia)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdComisionDeServicio", una_estadia.ComisionDeServicio.Id);
            parametros.Add("@Desde", una_estadia.Desde);
            parametros.Add("@Hasta", una_estadia.Hasta);
            parametros.Add("@Motivo", una_estadia.Motivo);
            parametros.Add("@Eventuales", una_estadia.Eventuales);
            parametros.Add("@CalculadoPorCategoria", una_estadia.CalculadoPorCategoria);
            parametros.Add("@AdicionalParaPasajes", una_estadia.AdicionalParaPasajes);
            parametros.Add("@IdProvincia", una_estadia.Provincia.Id);
            parametros.Add("@baja", false);
            parametros.Add("@usuario", 1);
            var id = conexion_bd.EjecutarEscalar("dbo.VIA_AltaEstadia", parametros);
            una_estadia.Id = (int)((Decimal)id);
        }

        public void BajaDeEstadias(List<Estadia> estadias)
        {
            foreach (Estadia una_estadia in estadias)
            {
                BajaDeUnaEstadia(una_estadia);
            }
        }

        private void BajaDeUnaEstadia(Estadia una_estadia)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdEstadia", una_estadia.Id);
            conexion_bd.EjecutarSinResultado("dbo.VIA_BajaEstadia", parametros);
        }


        public List<Estadia> GetEstadiasPorPersona(int documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Documento", documento);
            var tabla_de_estadias = conexion_bd.Ejecutar("dbo.Via_GetEstadiasPorPersona",parametros);

            return GetEstadiasFromTabla(tabla_de_estadias);
        }

        private List<Estadia> GetEstadiasFromTabla(TablaDeDatos tabla_estadias)
        {
            List<Estadia> estadias = new List<Estadia>();
            var una_estadia = new Estadia();
            var una_provincia = new Provincia();
            tabla_estadias.Rows.ForEach(row =>
                {
                    una_estadia.Desde = row.GetDateTime("FechaDesde");
                    una_estadia.Hasta = row.GetDateTime("Fechahasta");
                    una_provincia.Id = row.GetSmallintAsInt("IdProvincia");
                    una_provincia.Nombre = row.GetString("NombreProvincia");
                    una_estadia.Provincia = una_provincia;
                    una_estadia.Eventuales = (Decimal)row.GetObject("Eventual");
                    una_estadia.AdicionalParaPasajes = (Decimal)row.GetObject("AdicionalParaPasajes");
                    una_estadia.CalculadoPorCategoria = (Decimal)row.GetObject("CalculadoPorCategoria");
                    una_estadia.Motivo = row.GetString("Motivo");
                    estadias.Add(una_estadia);

                });
            return estadias;
        }



        #endregion
    }
}
