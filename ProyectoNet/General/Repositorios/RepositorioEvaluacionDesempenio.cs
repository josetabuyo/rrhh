using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioEvaluacionDesempenio
    {
        private static RepositorioEvaluacionDesempenio _instancia;

        IConexionBD _conexion;
        private RepositorioEvaluacionDesempenio(IConexionBD conexion)
        {
            _conexion = conexion;
        }

        public static RepositorioEvaluacionDesempenio NuevoRepositorioEvaluacion(IConexionBD conexion)
        {
            if (!(_instancia != null)) _instancia = new RepositorioEvaluacionDesempenio(conexion);
            return _instancia;
        }

        public string getEvaluaciones(int doc)
        {
            return JsonConvert.SerializeObject("hola");
        }

        public string GetAgentesEvaluablesPor(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluador", usuario.Owner.Id);
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Evaluados_Evaluador", parametros);
            

            var tipos_consultas = new List<Object> { };

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                tipos_consultas.Add(new
                {

                    id_evaluado = row.GetSmallintAsInt("id_evaluado"),
                    apellido = row.GetString("apellido"),
                    nombre = row.GetString("nombre"),
                    nro_documento = row.GetInt("NroDocumento"),
                    id_evaluacion = row.GetString("id_evaluacion", ""),
                    estado = row.GetString("estado_evaluacion",""),
                    id_periodo = row.GetString("id_periodo", ""),
                    descripcion_periodo = row.GetString("descripcion_periodo", ""),
                    id_nivel = row.GetString("id_nivel", ""),
                    id_pregunta = row.GetString("id_pregunta", ""),
                    orden_pregunta = row.GetString("orden_pregunta", ""),
                    enunciado = row.GetString("enunciado", ""),
                    rpta1 = row.GetString("rpta1", ""),
                    rpta2 = row.GetString("rpta2", ""),
                    rpta3 = row.GetString("rpta3", ""),
                    rpta4 = row.GetString("rpta4", ""),
                    rpta5 = row.GetString("rpta5", "")

                })
                );
            }

            return JsonConvert.SerializeObject(tipos_consultas);
        }
    }
 
}
