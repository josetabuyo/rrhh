using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeNivelesDeDocencia : RepositorioLazySingleton<NivelDeDocencia>
    {
        private static RepositorioDeNivelesDeDocencia _instancia;

        private RepositorioDeNivelesDeDocencia(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeNivelesDeDocencia Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeNivelesDeDocencia(conexion);
            return _instancia;
        }

        public List<NivelDeDocencia> All()
        {
            return this.Obtener();
        }

        public List<NivelDeDocencia> Find(string criterio)
        {
            var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
            bool filtrar_por_id = false;
            int id_nivel = -1;

            if (criterio_deserializado["Id"] != null)
            {
                filtrar_por_id = true;
                id_nivel = (int)((JValue)criterio_deserializado["Id"]);
            }

            return All().FindAll(nivel_de_docencia =>
            {
                var pasa_todas_las_condiciones = true;
                if (filtrar_por_id)
                {
                    if (nivel_de_docencia.Id != id_nivel) pasa_todas_las_condiciones = false;
                }
                return pasa_todas_las_condiciones;
            });
        }

        protected override List<NivelDeDocencia> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetNivelesDeDocencia");
            var niveles = new List<NivelDeDocencia>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new NivelDeDocencia(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return niveles;
        }
    
        protected override void  GuardarEnLaBase(NivelDeDocencia objeto)
        {
 	        throw new NotImplementedException();
        }

        protected override void  QuitarDeLaBase(NivelDeDocencia objeto)
        {
 	        throw new NotImplementedException();
        }
    }
}
