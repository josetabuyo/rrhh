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
                String valor_propiedad = "";
                String valor_filtro = filtro_propiedad.Value.ToString().ToLower();

                var propiedad_a_filtrar = obj.GetType().GetProperty(filtro_propiedad.Key);
                if (propiedad_a_filtrar != null)
                {
                    valor_propiedad = propiedad_a_filtrar.GetValue(obj, null).ToString().ToLower();
                }
                else
                {
                    var campo_a_filtrar = obj.GetType().GetField(filtro_propiedad.Key);
                    if (campo_a_filtrar != null)
                    {
                        valor_propiedad = campo_a_filtrar.GetValue(obj).ToString().ToLower();
                    }
                }
                if (valor_filtro.Contains("*"))
                {
                    if (!valor_propiedad.Contains(valor_filtro.Replace("*", ""))) pasa_todas_las_condiciones = false;
                }
                else
                {
                    if (valor_propiedad != valor_filtro) pasa_todas_las_condiciones = false;
                }            
            }

            return pasa_todas_las_condiciones;
        }
    }
}
