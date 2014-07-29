using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeLocalidades : RepositorioLazySingleton<Localidad>
    {

        private static RepositorioDeLocalidades _instancia;

        private RepositorioDeLocalidades(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeLocalidades Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeLocalidades(conexion);
            return _instancia;
        }

        public List<Localidad> All()
        {
            return this.Obtener();
        }

        public List<Localidad> Find(string criterio)
        {
            var criterio_deserializado = (JObject) JsonConvert.DeserializeObject(criterio);
            bool filtrar_por_provincia = false;
            int id_provincia = -1;

            if (criterio_deserializado["provincia"]!= null) {
                filtrar_por_provincia = true;
                id_provincia = (int)((JValue)criterio_deserializado["provincia"]);
            }



            List<Localidad> localidades = new List<Localidad>();

            localidades = All().FindAll(localidad =>
            {
                var pasa_todas_las_condiciones = true;
                if (filtrar_por_provincia)
                {
                    if (localidad.IdProvincia != id_provincia) pasa_todas_las_condiciones = false;
                }     
          

                return pasa_todas_las_condiciones;
                                
            });


            if (id_provincia==0)
            {
                Localidad caba = new Localidad();
                caba = localidades.Find(x => x.IdProvincia == 0);
                localidades.Clear();
                localidades.Add(caba);
                return localidades;

            }

            return localidades;
          


        }

        protected override List<Localidad> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetLocalidades");
            var localidades = new List<Localidad>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    localidades.Add(new Localidad(row.GetSmallintAsInt("Id"), row.GetString("Descripcion"), row.GetSmallintAsInt("IdProvincia")));
                });
            }

            return localidades;
        }

        protected override void GuardarEnLaBase(Localidad objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Localidad objeto)
        {
            throw new NotImplementedException();
        }


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

      
    }
}
