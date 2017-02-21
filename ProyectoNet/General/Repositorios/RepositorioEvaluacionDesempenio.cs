using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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

        public string getFormularioDeEvaluacion(int nivel, int evaluado, int evaluacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_formulario", nivel);
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Formulario", parametros);
            var list_de_pregYRtas = new List<Object> { };

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_pregYRtas.Add(new
                    {
                        Orden = row.GetSmallintAsInt("Orden", 0),
                        idPregunta = row.GetSmallintAsInt("id_pregunta", 0),
                        idConcepto = row.GetSmallintAsInt("id_concepto", 0),
                        Enunciado = row.GetString("Enunciado", "Sin enunciado"),
                        Factor = row.GetString("Factor", "0"),
                        idNivel = row.GetSmallintAsInt("id_nivel", 0),
                        DescripcionNivel = row.GetString("descripcion_nivel", "Sin información"),
                        DetalleNivel = row.GetString("detalle_nivel", "Sin información"),
                        Rta1 = row.GetString("Rpta1", "Sin información"),
                        Rta2 = row.GetString("Rpta2", "Sin información"),
                        Rta3 = row.GetString("Rpta3", "Sin información"),
                        Rta4 = row.GetString("Rpta4", "Sin información"),
                        Rta5 = row.GetString("Rpta5", "Sin información"),
                        Concepto = row.GetString("concepto", "Sin información"),

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_pregYRtas);
        }

        public string GetAgentesEvaluablesPor(MAU.Usuario usuario)
        {
            return JsonConvert.SerializeObject("hola");
        }

        public int insertarEvaluacion(int idEvaluado, int idEvaluador, int idFormulario, int periodo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", 0);
            parametros.Add("@id_evaluador", idEvaluador);
            parametros.Add("@id_evaluado", idEvaluado);
            parametros.Add("@id_formulario", idFormulario);
            parametros.Add("@id_periodo", periodo);
            parametros.Add("@estado", 0);
            parametros.Add("@baja", 0);
            //parametros.Add("@fecha", DateTime());
            

            return (int)_conexion.EjecutarEscalar("dbo.EVAL_INS_Evaluacion", parametros);
            
        }

        public string insertarEvaluacionDetalle(int idEvaluacion, int idPregunta, int opcion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEvaluacion);
            parametros.Add("@id_pregunta", idPregunta);
            parametros.Add("@opcion_elegida", opcion);


            return _conexion.EjecutarEscalar("dbo.EVAL_INS_Evaluacion_Detalle", parametros).ToString();

        }
    }
 
}
