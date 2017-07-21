using System;
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

        protected void FormularioFromTabla(List<DetallePreguntas> list_de_pregYRtasRespondidas, TablaDeDatos tablaDatos)
        {
            tablaDatos.Rows.ForEach(row =>
            {
                AddDetallePreguntasA(list_de_pregYRtasRespondidas, row);
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
            if (!cache.ContainsKey(idArea))
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idArea", idArea);
                var tablaDatos = _conexion.Ejecutar("[dbo].[EVAL_GET_DATA_ESTR_pc_dotaciones]", parametros);

                tablaDatos.Rows.ForEach(row =>
                {
                    if (!cache.ContainsKey(idArea))
                    {
                        cache.Add(idArea, new DescripcionAreaEvaluacion(row.GetString("Organismo", ""), row.GetString("Secretaria", ""), row.GetString("Subsecretaria", ""), row.GetString("DireccionNacional", ""), row.GetString("Area_Coordinacion", ""), codigo));
                    }
                }
                );
            }

            return cache[idArea];
        }

        public bool EsAgenteVerificador(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            var id_persona_evaluadora = usuario.Owner.Id;
            parametros.Add("@id_persona", id_persona_evaluadora);

            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Verificador_Evaluacion", parametros);

            return tablaDatos.Rows.Count > 0;
        }

        public RespuestaGetAgentesEvaluablesPor GetAgentesEvaluablesPor(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            var id_persona_evaluadora = usuario.Owner.Id;
            var es_agente_verificador = true;
            if (!EsAgenteVerificador(usuario))
            {
                parametros.Add("@id_persona_evaluadora", id_persona_evaluadora);
                es_agente_verificador = false;
            }
            
            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_Evaluados_Evaluador", parametros);

            var asignaciones = new List<AsignacionEvaluadoAEvaluador> { };
            var detalle_preguntas = new List<DetallePreguntas> { };
            var cache_areas = new Dictionary<int, DescripcionAreaEvaluacion>();
            var primer_row = true;
            var evaluador = GetAgenteEvaluadorEvaluacionDesempenio(id_persona_evaluadora);
            AsignacionEvaluadoAEvaluador asignacion_evaluado_a_evaluador = new AsignacionEvaluadoAEvaluador();

            if (tablaDatos.Rows.Count > 0)
            {
                var id_evaluacion_anterior = 0;
                var id_evaluado_anterior = 0;
                tablaDatos.Rows.ForEach(row =>
                {
                    if (primer_row == true)
                    {
                        primer_row = false;
                        id_evaluacion_anterior = row.GetSmallintAsInt("id_evaluacion", 0);
                        id_evaluado_anterior = row.GetSmallintAsInt("id_evaluado", 0);
                        var id_evaluado = row.GetSmallintAsInt("id_evaluado", 0);
                        asignacion_evaluado_a_evaluador = newAsignacionEvaluadoAEvaluadorFromRow(row, detalle_preguntas, id_evaluado, cache_areas, evaluador);
                    }

                    if (row.GetSmallintAsInt("id_evaluado", 0) != id_evaluado_anterior || row.GetSmallintAsInt("id_evaluacion", 0) != id_evaluacion_anterior)
                    {
                        asignaciones.Add(asignacion_evaluado_a_evaluador);
                        id_evaluacion_anterior = row.GetSmallintAsInt("id_evaluacion", 0);
                        id_evaluado_anterior = row.GetSmallintAsInt("id_evaluado", 0);
                        detalle_preguntas = new List<DetallePreguntas>();
                        var id_evaluado = row.GetSmallintAsInt("id_evaluado", 0);
                        asignacion_evaluado_a_evaluador = newAsignacionEvaluadoAEvaluadorFromRow(row, detalle_preguntas, id_evaluado, cache_areas, evaluador);
                        AddDetallePreguntasA(detalle_preguntas, row);
                    }
                    else
                    {
                        AddDetallePreguntasA(detalle_preguntas, row);
                    }
                });
            }
            if (tablaDatos.Rows.Count > 0)
            {
                asignaciones.Add(asignacion_evaluado_a_evaluador);
            }
            return new RespuestaGetAgentesEvaluablesPor(asignaciones, es_agente_verificador);
            
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
                                                    row.GetInt("NroDocumento"), row.GetString("escalafon"), row.GetString("nivel"), row.GetString("grado"), row.GetString("agrupamiento"), row.GetString("puesto"), string.Empty, DescripcionAreaEvaluacion.Nula(), row.GetInt("NroDocumento"));
            }
            return evaluador;

        }

        protected AgenteEvaluacionDesempenio GetAgenteEvaluadoEvaluacionDesempenio(int id_evaluador, DescripcionAreaEvaluacion area)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_evaluado", id_evaluador);
            var tablaDatos = _conexion.Ejecutar("[dbo].[EVAL_GET_DATOS_Evaluado]", parametros);
            var evaluador = new AgenteEvaluacionDesempenio();
            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];
                evaluador = new AgenteEvaluacionDesempenio(id_evaluador, row.GetString("apellido"), row.GetString("nombre"),
                                                    row.GetInt("NroDocumento"), "SINEP", row.GetString("nivel"), row.GetString("grado"), row.GetString("agrupamiento_evaluado", "No Especificado"), string.Empty, row.GetString("Nivel_Estudios", ""), area, row.GetInt("legajo"));
            }
            return evaluador;
        }

        protected void AddDetallePreguntasA(List<DetallePreguntas> detalle_preguntas, RowDeDatos row)
        {
            detalle_preguntas.Add(new DetallePreguntas(row.GetSmallintAsInt("id_pregunta", 0), row.GetSmallintAsInt("orden_pregunta", 0),
                row.GetSmallintAsInt("opcion_elegida", 0), row.GetString("enunciado", ""),
                row.GetString("rpta1", ""), row.GetString("rpta2", ""), row.GetString("rpta3", ""),
                row.GetString("rpta4", ""), row.GetString("rpta5", ""), row.GetString("factor", "")));
        }

        protected AsignacionEvaluadoAEvaluador newAsignacionEvaluadoAEvaluadorFromRow(RowDeDatos row, List<DetallePreguntas> detalle_preguntas, int id_evaluado, Dictionary<int, DescripcionAreaEvaluacion> cache_areas, AgenteEvaluacionDesempenio evaluador)
        {

            var area_evaluado = GetDescripcionAreaEvaluacion(row.GetSmallintAsInt("id_area_evaluado", 0), cache_areas, row.GetString("codigo_unidad_eval", ""));

            var nivel = new NivelEvaluacionDesempenio(row.GetSmallintAsInt("id_nivel", 0),
                                                        row.GetString("descripcion_nivel", ""),
                                                        row.GetString("detalle_nivel", ""),
                                                        row.GetSmallintAsInt("deficiente", 0),
                                                        row.GetSmallintAsInt("regular", 0),
                                                        row.GetSmallintAsInt("bueno", 0),
                                                        row.GetSmallintAsInt("destacado", 0));

            var periodo = this.PeridoFrom(row);

            var evaluacion = EvaluacionDesempenio.Nula();

            if (row.GetInt("id_evaluacion", 0) != 0)
            {
                evaluacion = new EvaluacionDesempenio(row.GetInt("id_evaluacion", 0),
                                            row.GetSmallintAsInt("estado_evaluacion", 0),
                                            nivel,
                                            detalle_preguntas,
                                            row.GetString("codigo_gde", ""));
            }

            var unidad_evaluacion = UnidadDeEvaluacion.Nulio();
            if (row.GetInt("id_unidad_eval", 0) != 0)
            {
                unidad_evaluacion = new UnidadDeEvaluacion(row.GetInt("id_unidad_eval"), row.GetString("codigo_unidad_eval"));
            }

            return new AsignacionEvaluadoAEvaluador(
                GetAgenteEvaluadoEvaluacionDesempenio(id_evaluado, area_evaluado),
                evaluador,
                evaluacion,
                periodo,
                nivel,
                unidad_evaluacion);

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

        public int GetIdEvaluadorDelUsuario(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_persona_responsable", usuario.Owner.Id);

            var tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_IdEvaluadorResponsableUnidadEval", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                return tablaDatos.Rows[0].GetSmallintAsInt("id");
            }
            else
            {
                parametros = new Dictionary<string, object>();
                parametros.Add("@id_persona", usuario.Owner.Id);

                tablaDatos = _conexion.Ejecutar("dbo.EVAL_GET_IdEvaluador_Persona", parametros);
                if (tablaDatos.Rows.Count > 0)
                {
                    return tablaDatos.Rows[0].GetSmallintAsInt("id");
                }
                else
                {
                    throw new Exception("No existe un id de evaluador para la persona solicitada");
                }
            }
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

        public PeriodoEvaluacion GetUltimoPeriodoEvaluacion()
        {
            var tabla = _conexion.Ejecutar("dbo.EVAL_GET_UltimoPeriodoEvaluacion");
            if (tabla.Rows.Count != 1)
            {
                throw new Exception("No se pudo determinar un periodo actual de evaluacion");
            }
            return PeridoFrom(tabla.Rows[0]);
        }

        protected PeriodoEvaluacion PeridoFrom(RowDeDatos row)
        {
            return new PeriodoEvaluacion(row.GetInt("id_periodo", 0),
                            row.GetString("descripcion_periodo", ""), row.GetDateTime("periodo_desde"), row.GetDateTime("periodo_hasta"));
        }

    }

}
