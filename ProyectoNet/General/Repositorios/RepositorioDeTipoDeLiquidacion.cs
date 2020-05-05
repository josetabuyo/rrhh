using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeTipoDeLiquidacion : RepositorioLazySingleton<TipoLiquidacion>
    {

        private static RepositorioDeTipoDeLiquidacion _instancia;

        private RepositorioDeTipoDeLiquidacion(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeTipoDeLiquidacion Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeTipoDeLiquidacion(conexion);
            return _instancia;
        }

        public List<TipoLiquidacion> All()
        {
            return this.Obtener();
        }
        //
        protected override List<TipoLiquidacion> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.PLA_GET_Tipo_Liquidacion");
            var tiposLiquidacion = new List<TipoLiquidacion>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    tiposLiquidacion.Add(new TipoLiquidacion(row.GetInt("Id"), row.GetString("Descripcion"),row.GetInt("Meses_Retraso")));
                });
            }

            return tiposLiquidacion;
        }

        protected override void GuardarEnLaBase(TipoLiquidacion objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(TipoLiquidacion objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

       /* public List<Localidad> Find(string criterio)
        {
            var localidades = base.Find(criterio);

            //atada con alambre para cuando la localidad es CABA
            var criterio_deserializado = (JObject) JsonConvert.DeserializeObject(criterio);
            if (criterio_deserializado["IdProvincia"] == null) return localidades;

            int id_provincia = (int)((JValue)criterio_deserializado["IdProvincia"]);            
            if (id_provincia == 0)
            {
                Localidad caba = new Localidad();
                caba = localidades.Find(localidad => localidad.IdProvincia == 0);
                localidades.Clear();
                localidades.Add(caba);
            }
            return localidades;
        }*/

       

      
    }
}
