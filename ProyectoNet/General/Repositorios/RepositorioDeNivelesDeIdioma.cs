using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeNivelesDeIdioma : RepositorioLazySingleton<NivelDeIdioma>
    {
        private static RepositorioDeNivelesDeIdioma _instancia;

        private RepositorioDeNivelesDeIdioma(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeNivelesDeIdioma Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeNivelesDeIdioma(conexion);
            return _instancia;
        }

        public List<NivelDeIdioma> All()
        {
            return this.Obtener();
        }

        public List<NivelDeIdioma> Find(string criterio)
        {
            var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
            bool filtrar_por_id = false;
            int id_nivel = -1;

            if (criterio_deserializado["Id"] != null)
            {
                filtrar_por_id = true;
                id_nivel = (int)((JValue)criterio_deserializado["Id"]);
            }

            return All().FindAll(nivel_de_idioma =>
            {
                var pasa_todas_las_condiciones = true;
                if (filtrar_por_id)
                {
                    if (nivel_de_idioma.Id != id_nivel) pasa_todas_las_condiciones = false;
                }
                return pasa_todas_las_condiciones;
            });
        }

        protected override List<NivelDeIdioma> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetNivelesDeIdioma");
            var nacionalidades = new List<NivelDeIdioma>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    nacionalidades.Add(new NivelDeIdioma(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return nacionalidades;
        }

        protected override void GuardarEnLaBase(NivelDeIdioma objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(NivelDeIdioma objeto)
        {
            throw new NotImplementedException();
        }
    }
}
