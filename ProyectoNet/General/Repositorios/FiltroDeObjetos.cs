using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class FiltroDeObjetos
    {
        private JObject criterio;

        public FiltroDeObjetos(string criterio)
        {
            this.criterio = (JObject)JsonConvert.DeserializeObject(criterio);
        }

        public Boolean Evaluar(object obj)
        {
            var pasa_todas_las_condiciones = true;
            foreach (var filtro_propiedad in criterio)
            {
                var propiedad_a_filtrar = obj.GetType().GetProperty(filtro_propiedad.Key);
                if (propiedad_a_filtrar != null)
                {
                    if (propiedad_a_filtrar.GetValue(obj, null).GetHashCode() != filtro_propiedad.Value.GetHashCode()) pasa_todas_las_condiciones = false;
                }
                else
                {
                    var campo_a_filtrar = obj.GetType().GetField(filtro_propiedad.Key);
                    if (campo_a_filtrar != null)
                    {
                        if (campo_a_filtrar.GetValue(obj).GetHashCode() != filtro_propiedad.Value.GetHashCode()) pasa_todas_las_condiciones = false;
                    }
                }
            }


            //bool filtrar_por_provincia = false;
            //int id_provincia = -1;

            //if (criterio["provincia"] != null)
            //{
            //    filtrar_por_provincia = true;
            //    id_provincia = (int)((JValue)criterio_deserializado["provincia"]);
            //}

            //var pasa_todas_las_condiciones = true;
            //if (filtrar_por_provincia)
            //{
            //    if (localidad.IdProvincia != id_provincia) pasa_todas_las_condiciones = false;
            //}

            //return pasa_todas_las_condiciones;
            return pasa_todas_las_condiciones;
        }
    }
}
