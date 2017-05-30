﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using General.MAU;
using System.Reflection;
using General.MED;

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

        public static void Reset()
        {
            _instancia = null;
        }

        public static RepositorioEvaluacionDesempenio NuevoRepositorioEvaluacion(IConexionBD conexion)
        {
            if (!(_instancia != null)) _instancia = new RepositorioEvaluacionDesempenio(conexion);
            return _instancia;
        }

        public List<DetallePreguntas> getFormularioDeEvaluacion(int nivel, int evaluado, int evaluacion)
        {
            var parametros = new Dictionary<string, object>();
            var list_de_pregYRtas = new List<FormEvaluacion> { };
            var list_de_pregYRtasRespondidas = new List<DetallePreguntas> { };
            var tablaDatos = new TablaDeDatos();

            if (evaluacion != 0)
            {
                parametros.Add("@id_evaluacion", evaluacion);
            }

            parametros.Add("@id_nivel", nivel);
            tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Evaluacion", parametros);
            FormularioFromTabla(list_de_pregYRtasRespondidas, tablaDatos);

            return list_de_pregYRtasRespondidas;
        }

        private static void FormularioFromTabla(List<DetallePreguntas> list_de_pregYRtasRespondidas, TablaDeDatos tablaDatos)
        {
            tablaDatos.Rows.ForEach(row =>
            {
                list_de_pregYRtasRespondidas.Add(new DetallePreguntas(
                    row.GetSmallintAsInt("id_pregunta", 0), 0,
                    row.GetSmallintAsInt("opcion_elegida", 0),
                    row.GetString("Enunciado", "Sin enunciado"),
                    row.GetString("Rpta1", "Sin información"),
                    row.GetString("Rpta2", "Sin información"),
                    row.GetString("Rpta3", "Sin información"),
                    row.GetString("Rpta4", "Sin información"),
                    row.GetString("Rpta5", "Sin información")));
            });
        }

        public string GetNivelesFormulario(string id_nivel)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_nivel", int.Parse(id_nivel));
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_CATEGORIAS_NIVEL", parametros);
            object respuesta;

            respuesta = new
            {
                id_nivel = tablaDatos.Rows[0].GetSmallintAsInt("id_nivel"),
                deficiente = tablaDatos.Rows[0].GetSmallintAsInt("deficiente"),
                regular = tablaDatos.Rows[0].GetSmallintAsInt("regular"),
                bueno = tablaDatos.Rows[0].GetSmallintAsInt("bueno"),
                destacado = tablaDatos.Rows[0].GetSmallintAsInt("destacado"),
                descripcion_nivel = tablaDatos.Rows[0].GetString("descripcion")
            };
            return JsonConvert.SerializeObject(respuesta);
        }

        public DescripcionAreaEvaluacion GetDescripcionAreaEvaluacion(int idArea, Dictionary<int, DescripcionAreaEvaluacion> cache, string codigo)
        {
            if (!cache.ContainsKey(idArea))  {

                var parametros = new Dictionary<string, object>();
                parametros.Add("@idArea", idArea);
                var tablaDatos = _conexion.Ejecutar("[dbo].[EVAL_GET_DATA_ESTR_pc_dotaciones]", parametros);

                tablaDatos.Rows.ForEach(row =>
                    cache.Add(idArea, new DescripcionAreaEvaluacion(row.GetString("Organismo", ""), row.GetString("Secretaria", ""), row.GetString("Subsecretaria", ""), row.GetString("DireccionNacional", ""), row.GetString("Area_Coordinacion", ""), codigo))
                );
            }
             
            return cache[idArea];
        }

        public List<EvaluacionDesempenio> GetAgentesEvaluablesPor(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            var id_evaluador = usuario.Owner.Id;
            parametros.Add("@id_evaluador", id_evaluador);
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Evaluados_Evaluador", parametros);

            var evaluaciones = new List<EvaluacionDesempenio> { };
            var detalle_preguntas = new List<DetallePreguntas> { };
            var cache_areas = new Dictionary<int, DescripcionAreaEvaluacion>();
            var primer_row = true;
            var evaluador = GetAgenteEvaluadorEvaluacionDesempenio(id_evaluador);
            EvaluacionDesempenio evaluacion = new EvaluacionDesempenio();

            if (tablaDatos.Rows.Count > 0)
            {
                var id_evaluacion_anterior = 0;
                tablaDatos.Rows.ForEach(row =>
                {
                    if (primer_row == true)
                    {
                        primer_row = false;
                        id_evaluacion_anterior = row.GetSmallintAsInt("id_evaluacion", 0);
                        var id_evaluado = row.GetSmallintAsInt("id_evaluado", 0);
                        evaluacion = newEvaluadoFromRow(row, detalle_preguntas, id_evaluado, cache_areas, evaluador);
                    }

                    if (row.GetSmallintAsInt("id_evaluacion", 0) != id_evaluacion_anterior || id_evaluacion_anterior == 0)
                    {
                        evaluaciones.Add(evaluacion);
                        id_evaluacion_anterior = row.GetSmallintAsInt("id_evaluacion", 0);
                        detalle_preguntas = new List<DetallePreguntas>();
                        var id_evaluado = row.GetSmallintAsInt("id_evaluado", 0);
                        evaluacion = newEvaluadoFromRow(row, detalle_preguntas, id_evaluado, cache_areas, evaluador);
                        AddDetallePreguntasA(detalle_preguntas, row);
                    }
                    else
                    {
                        AddDetallePreguntasA(detalle_preguntas, row);
                    }
                });
            }
            evaluaciones.Add(evaluacion);
            return evaluaciones;
        }

        protected AgenteEvaluacionDesempenio GetAgenteEvaluadorEvaluacionDesempenio(int id_evaluador)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_evaluador", id_evaluador);
            var tablaDatos = _conexion.Ejecutar("[dbo].[EVAL_GET_DATOS_Evaluador]", parametros);
            var evaluador = new AgenteEvaluacionDesempenio();
            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];
                evaluador = new AgenteEvaluacionDesempenio(id_evaluador, row.GetString("apellido"), row.GetString("nombre"),
                                                    row.GetInt("NroDocumento"), row.GetString("escalafon"), row.GetString("nivel"), row.GetString("grado"), row.GetString("agrupamiento"), row.GetString("puesto"), string.Empty);
            }
            return evaluador;

        }

        protected AgenteEvaluacionDesempenio GetAgenteEvaluadoEvaluacionDesempenio(int id_evaluador)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_evaluado", id_evaluador);
            var tablaDatos = _conexion.Ejecutar("[dbo].[EVAL_GET_DATOS_Evaluado]", parametros);
            var evaluador = new AgenteEvaluacionDesempenio();
            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];
                evaluador = new AgenteEvaluacionDesempenio(id_evaluador, row.GetString("apellido"), row.GetString("nombre"),
                                                    row.GetInt("NroDocumento"), "SINEP", row.GetString("nivel"), row.GetString("grado"), "agrupamiento-hard", string.Empty, row.GetString("Nivel_Estudios", ""));
            }
            return evaluador;
        }

        protected void AddDetallePreguntasA(List<DetallePreguntas> detalle_preguntas, RowDeDatos row)
        {
            detalle_preguntas.Add(new DetallePreguntas(row.GetSmallintAsInt("id_pregunta", 0), row.GetSmallintAsInt("orden_pregunta", 0),
                row.GetSmallintAsInt("opcion_elegida", 0), row.GetString("enunciado", ""),
                row.GetString("rpta1", ""), row.GetString("rpta2", ""), row.GetString("rpta3", ""),
                row.GetString("rpta4", ""), row.GetString("rpta5", "")));
        }

        protected EvaluacionDesempenio newEvaluadoFromRow(RowDeDatos row, List<DetallePreguntas> detalle_preguntas, int id_evaluado, Dictionary<int, DescripcionAreaEvaluacion> cache_areas, AgenteEvaluacionDesempenio evaluador)
        {
            //metodo hardcodeado, cambiar
            var area = GetDescripcionAreaEvaluacion(row.GetSmallintAsInt("id_area_evaluado", 0), cache_areas, row.GetString("codigo_unidad_eval", ""));
            return new EvaluacionDesempenio(GetAgenteEvaluadoEvaluacionDesempenio(id_evaluado),
                            evaluador, row.GetInt("id_evaluacion", 0), row.GetSmallintAsInt("estado_evaluacion", 0), new PeriodoEvaluacion(row.GetInt("id_periodo", 0),
                            row.GetString("descripcion_periodo", ""), row.GetDateTime("periodo_desde"), row.GetDateTime("periodo_hasta")), new NivelEvaluacionDesempenio(row.GetSmallintAsInt("id_nivel", 0),
                            row.GetString("descripcion_nivel", ""), row.GetString("detalle_nivel", ""), row.GetSmallintAsInt("deficiente", 0), row.GetSmallintAsInt("regular", 0), 
                            row.GetSmallintAsInt("bueno", 0), row.GetSmallintAsInt("destacado", 0)), detalle_preguntas,
                            area, row.GetString("codigo_gde",""));
        }

        public int insertarEvaluacion(int idEvaluado, int idEvaluador, int idFormulario, int periodo, int estado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", 0);
            parametros.Add("@id_evaluador", idEvaluador);
            parametros.Add("@id_evaluado", idEvaluado);
            parametros.Add("@id_formulario", idFormulario);
            parametros.Add("@id_periodo", periodo);
            parametros.Add("@estado", estado);
            parametros.Add("@baja", 0);
            //parametros.Add("@fecha", DateTime());
            return (int)_conexion.EjecutarEscalar("dbo.EVAL_INS_Evaluacion", parametros);
        }

        public void updateEvaluacion(int idEval, int idEvaluado, int idEvaluador, int idFormulario, int periodo, int estado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEval);
            parametros.Add("@id_evaluador", idEvaluador);
            parametros.Add("@id_evaluado", idEvaluado);
            parametros.Add("@id_formulario", idFormulario);
            parametros.Add("@id_periodo", periodo);
            parametros.Add("@estado", estado);
            parametros.Add("@baja", 0);
            parametros.Add("@fecha", DateTime.Today);

            _conexion.Ejecutar("dbo.EVAL_UPD_Evaluacion", parametros);

        }

        public void insertarEvaluacionDetalle(int idEvaluacion, int idPregunta, int opcion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEvaluacion);
            parametros.Add("@id_pregunta", idPregunta);
            parametros.Add("@opcion_elegida", opcion);

            _conexion.Ejecutar("dbo.EVAL_INS_Evaluacion_Detalle", parametros);

        }

        public void deleteEvaluacionDetalle(int idEval)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", idEval);

            _conexion.Ejecutar("dbo.EVAL_DEL_Evaluacion_Detalle", parametros);
        }

        public void EvalGuardarCodigoGDE(int id, string codigo_gde)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_evaluacion", id);
            parametros.Add("@codigo_gde", codigo_gde);

            _conexion.Ejecutar("dbo.EVAL_UPD_CodigoGdeEvaluacion", parametros);
        }
    }

}
