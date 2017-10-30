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

        protected override List<Localidad> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetLocalidades");
            var localidades = new List<Localidad>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    localidades.Add(new Localidad(row.GetSmallintAsInt("Id"), row.GetString("Descripcion"), row.GetSmallintAsInt("IdProvincia"), row.GetSmallintAsInt("IdPartido")));
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

        public List<Localidad> Find(string criterio)
        {
            var localidades = this.ObtenerDesdeLaBase();

            
            var criterio_deserializado = (JObject) JsonConvert.DeserializeObject(criterio);

            if (criterio_deserializado["IdProvincia"] != null)
            {

                int id_provincia = (int)((JValue)criterio_deserializado["IdProvincia"]);
                //atada con alambre para cuando la localidad es CABA
                if (id_provincia == 0)
                {
                    Localidad caba = new Localidad();
                    caba = localidades.Find(localidad => localidad.IdProvincia == 0);
                    localidades.Clear();
                    localidades.Add(caba);
                }
            }
            else if (criterio_deserializado["IdPartido"] != null)
            {
                int id_partido = (int)((JValue)criterio_deserializado["IdPartido"]);

                List<Localidad> locs = localidades.FindAll(localidad => localidad.IdPartido == id_partido);
                localidades.Clear();
                //si es partido CABA, como me trae muchas localidades de CABA, fuerzo que sea una
                if (id_partido == 1)
                {
                    localidades.Add(locs.Find(l => l.IdProvincia == 0));
                } else {
                    localidades = locs;
                }
                

            }
            return localidades;
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
