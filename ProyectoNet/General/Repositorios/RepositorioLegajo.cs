using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioLegajo : RepositorioLazySingleton<Legajo>
    {

        private static RepositorioLegajo _instancia;

        private RepositorioLegajo(IConexionBD conexion)
            : base(conexion, 10)
        {

        }

        public static RepositorioLegajo NuevoRepositorioDeLegajos(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioLegajo(conexion);
            return _instancia;
        }

        public string getEstudios(int doc)
        {
            List<Estudio> lista_estudios = new List<Estudio>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@NroDocumento", doc);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Estudios_Realizados", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    int idUniversidad = traerMasDatosDelEstudio(row.GetInt("id"));
                    string nombre_universidad = traerNombre(idUniversidad);

                    lista_estudios.Add(new Estudio
                    {
                        nombreDeNivel = row.GetString("Nivel", "Sin información"),
                        titulo = row.GetString("Titulo", "Sin información"),
                        fechaEgreso = row.GetDateTime("Fecha_Egreso", new DateTime(1900, 1, 1)),
                        nombreUniversidad = nombre_universidad
                    });
                });

            }

            lista_estudios.Sort((estudio1, estudio2) => estudio2.fechaEgreso.CompareTo(estudio1.fechaEgreso));

            return JsonConvert.SerializeObject(lista_estudios.ToArray());

        }

        private int traerMasDatosDelEstudio(int idEstudio)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdEstudio", idEstudio);
            parametros.Add("@Tipo", 1);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Estudio_Realizado_ID", parametros);
            int idUniversidad = 0;

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    idUniversidad = row.GetSmallintAsInt("Id_Universidad", 0);

                });

            }

            return idUniversidad;
        }

        private string traerNombre(int idUniversidad)
        {
            string nombreUniversidad = "Sin datos";
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Universidades");

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    if (idUniversidad == row.GetSmallintAsInt("id", 0))
                    {
                        nombreUniversidad = row.GetString("Universidad", "Sin datos");
                    }


                });

            }

            return nombreUniversidad;
        }


        public string getFamiliares(int doc)
        {
            List<Persona> lista_personas = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc_Titular", doc);
            parametros.Add("@Id_Interna", 0);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_DDJJ_Familiares", parametros);
            var list_de_familiares = new List<Object> { };


            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_familiares.Add(new
                    {
                        Nombre = row.GetString("Nombre", "Sin información"),
                        Apellido = row.GetString("Apellido", "Sin información"),
                        Parentesco = row.GetString("Parentesco", "Sin información"),
                        Documento = row.GetInt("Nro_Doc", 0),
                        TipoDNI = row.GetString("Tipo_Doc", "Sin información"),

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_familiares);

        }

        public string getPsicofisicos(int doc)
        {
            //List<Persona> lista_personas = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Legajo", doc);
            parametros.Add("@id", 0);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Psicofisicos", parametros);
            var list_de_examenes = new List<Object> { };


            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_examenes.Add(new
                    {
                        Folio = row.GetString("Folio_Nro", "Sin información"),
                        Motivo = row.GetString("Motivo", "Sin información"),
                        Resultado = row.GetString("Resultado", "Sin información"),
                        Organismo = row.GetString("Org_Expidió", "Sin información")

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_examenes);

        }
        public void EnviarNotificacion(string notificacion, List<int> documentos, string titulo, int usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@notificacion", notificacion);
            parametros.Add("@titulo", titulo);
            parametros.Add("@id_creador", usuario);
            var id_notificacion = conexion.EjecutarEscalar("dbo.LEG_INSNotificacionTexto", parametros);

            documentos.ForEach(d =>
            {
                parametros.Clear();
                parametros.Add("@documento", d);
                parametros.Add("@id_notificacion", id_notificacion);
                conexion.EjecutarSinResultado("dbo.LEG_INSNotificacionUsuario", parametros);
            });
        }

        public string GetLiquidaciones(int anio, int mes, string cuil)
        {

            if (mes == 0)
            {
                mes = 12;
                anio = anio - 1;
            }

            var parametros = new Dictionary<string, object>();
            parametros.Add("@anio", anio);
            parametros.Add("@mes", mes);
            parametros.Add("@cuil", cuil);

            var liquidacion = new object();
            var listaLiquidaciones = new List<object>();

            var tablaDatos = conexion.Ejecutar("dbo.PLA_GET_Liquidaciones_Por_Persona_y_Periodo", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    liquidacion = new
                    {
                        Id = row.GetInt("liquidacion", 0),
                        Descripcion = row.GetString("Descripcion", "Sin nombre")
                    };

                    listaLiquidaciones.Add(liquidacion);
                });

            }

            return JsonConvert.SerializeObject(listaLiquidaciones);

        }

        public string GetReciboDeSueldo(int documento, int liq)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Documento", documento);
            parametros.Add("@liquidacion", liq);

            var recibo = new object();
            var listaReciboDetalle = new List<object>();
            var cabeceraRecibo = new object();

            var tablaDatos = conexion.Ejecutar("dbo.PLA_GET_Impresion_Recibos_Haberes", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                int idRecibo = tablaDatos.Rows.Last().GetInt("Id_Recibo");

                cabeceraRecibo = traerCabeceraRecibo(idRecibo);

                listaReciboDetalle = traerDetalleRecibo(idRecibo);

                recibo = new
                {
                    Cabecera = cabeceraRecibo,
                    Detalle = listaReciboDetalle
                };

            }

            return JsonConvert.SerializeObject(recibo);

        }

        private List<object> traerDetalleRecibo(int idRecibo)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Recibo", idRecibo);
            var listaDetalleRecibo = new List<object>();
            var un_detalle = new object();

            var tablaDatos = conexion.Ejecutar("dbo.RPT_PLA_Recibos_Haberes_Detalle", parametros);

            tablaDatos.Rows.ForEach(row =>
            {
                un_detalle = new
                {
                    //Nombre = row.GetString("Nombre", ""),
                    Concepto = row.GetString("Concepto", ""),
                    Aporte = row.GetDecimal("Aporte", 0),
                    Descuento = row.GetDecimal("Descuento", 0),
                    Descripcion = row.GetString("Descripcion", "")
                };

                listaDetalleRecibo.Add(un_detalle);
            });

            return listaDetalleRecibo;
        }

        private object traerCabeceraRecibo(int idRecibo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_recibo", idRecibo);
            var cabeceraRecibo = new object();

            var tablaDatos = conexion.Ejecutar("dbo.RPT_PLA_Recibo_Haberes_Header", parametros);

            if (tablaDatos.Rows.Count > 0)
            {

                cabeceraRecibo = new
                {
                    //Nombre = row.GetString("Nombre", ""),
                    Legajo = tablaDatos.Rows.First().GetInt("Legajo", 0),
                    Agente = tablaDatos.Rows.First().GetString("Agente", ""),
                    CUIL = tablaDatos.Rows.First().GetString("CUIL", ""),
                    Oficina = tablaDatos.Rows.First().GetSmallintAsInt("Oficina", 0),
                    Orden = tablaDatos.Rows.First().GetSmallintAsInt("Orden", 0),
                    Bruto = tablaDatos.Rows.First().GetString("SBruto", ""),
                    Neto = tablaDatos.Rows.First().GetString("SNeto", ""),
                    Descuentos = tablaDatos.Rows.First().GetString("SDescuentos", ""),
                    NivelGrado = tablaDatos.Rows.First().GetString("NivelGrado", ""),
                    Area = tablaDatos.Rows.First().GetString("area", ""),
                    Domicilio = tablaDatos.Rows.First().GetString("Domicilio", ""),
                    FechaLiquidacion = tablaDatos.Rows.First().GetString("F_Liquidacion", "")

                };

            }

            return cabeceraRecibo;
        }


        public string getDocumentosLegajo(string legajo)
        {
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id", legajo);
                parametros.Add("@legajo", legajo);
                var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Indice_Documentos", parametros);
                var list_de_documentos = new List<Object> { };

                if (tablaDatos.Rows.Count > 0)
                {
                    tablaDatos.Rows.ForEach(row =>
                    {
                        list_de_documentos.Add(new
                        {
                            Id = row.GetInt("id", 0),
                            Nombre = row.GetString("TIPO", "Sin información"),
                            Folio = row.GetString("FOLIO", "Sin información")

                        });
                    });

                }

                return JsonConvert.SerializeObject(list_de_documentos);
            }
        }


        public string getDesignaciones(int doc)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc", doc);
            parametros.Add("@id", 0);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Designaciones", parametros);
            var list_de_designaciones = new List<Object> { };

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_designaciones.Add(new
                    {
                        TipoActo = row.GetString("acto_tipo", "Sin información"),
                        NroActo = row.GetSmallintAsInt("acto_nro", 0),
                        FechActo = row.GetDateTime("acto_fecha"),
                        Motivo = row.GetString("motivoDesc", "Sin información"),
                        SituacionRevista = row.GetString("SR", "Sin información"),
                        Folio = row.GetString("folio", "Sin información"),

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_designaciones);

        }

        public string getCarreraAdminstrativa(int doc)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@doc", doc);
            parametros.Add("@id", 0);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Carreras_Admistrativas", parametros);
            var carrera_adm = new List<Object> { };

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    carrera_adm.Add(new
                    {
                        Organismo = row.GetString("Organismo", "Sin información"),
                        Regimen = row.GetString("regimen", "Sin información"),
                        Agrupamiento = row.GetString("AGRUPAMIENTO", "Sin información"),
                        Nivel = row.GetString("Nivel", "Sin información"),
                        Grado = row.GetString("Grado", "Sin información"),
                        Cargo = row.GetString("CARGO", "Sin información"),
                        FechaDesde = row.GetDateTime("Fecha_Desde"),
                        FechaHasta = row.GetDateTime("Fecha_Hasta", DateTime.Today),
                        DescCausa = row.GetString("DescCausa", "Sin información"),
                        Folio = row.GetString("Folio", "Sin información")

                    });
                });

            }

            return JsonConvert.SerializeObject(carrera_adm);

        }

        public string GetNotificacionesDePortal(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@documento", id_usuario);
            List<Notificacion> consultas = new List<Notificacion>();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GETNotificaciones", parametros);
            var area = new Area();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    Persona creador = new Persona(row.GetInt("id_usuario_creador"), 0, "", "", area);
                    List<Destinatario> destinatarios = new List<Destinatario>();
                    Notificacion notificaciones = new Notificacion(
                        row.GetInt("Id"),
                        creador,
                        row.GetDateTime("fecha_creacion"),
                        row.GetString("titulo"),
                        row.GetString("texto"),
                        destinatarios,
                        row.GetBoolean("leido"));

                    consultas.Add(notificaciones);

                });

            }

            return JsonConvert.SerializeObject(consultas);

        }

        public string GetConsultasDePortal(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_usuario", id_usuario);
            List<Consulta> consultas = new List<Consulta>();
            getConsultasPorCriterio(parametros, consultas);

            return JsonConvert.SerializeObject(consultas);

        }

        public string GetNotificacionesTodasDePortal()
        {

            List<Notificacion> notificaciones = new List<Notificacion>();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GETNotificacionesTodas");
            var area = new Area();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    Persona creador = new Persona(row.GetInt("id_usuario_creador"), 0, "", "", area);
                    List<Destinatario> destinatarios = new List<Destinatario>();
                    Notificacion notificacion = new Notificacion(
                        row.GetInt("Id"),
                        creador,
                        row.GetDateTime("fecha_creacion"),
                        row.GetString("titulo"),
                        row.GetString("texto"),
                        destinatarios,
                        false);
                    notificaciones.Add(notificacion);
                });
            }
            return JsonConvert.SerializeObject(notificaciones);
        }

        public string MostrarDestinatariosDeLaNotificacion(int id_notificacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdNotificacion", id_notificacion);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GETDestinatariosDeLaNotificacion", parametros);
            List<Destinatario> destinatarios = new List<Destinatario>();
            var area = new Area();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    Persona creador = new Persona(0, row.GetInt("documento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Destinatario destinatario = new Destinatario(id_notificacion, creador, row.GetDateTime("fecha_lectura", new DateTime(1900, 1, 1)), row.GetBoolean("leido"));
                    destinatarios.Add(destinatario);
                });
            }
            return JsonConvert.SerializeObject(destinatarios);
        }

        public string GetConsultasTodasDePortal(int estado)
        {
            var parametros = new Dictionary<string, object>();
            if (estado != 0)
            {
                parametros.Add("@Estado", estado);
            }

            List<Consulta> consultas = new List<Consulta>();
            getConsultasPorCriterio(parametros, consultas);

            return JsonConvert.SerializeObject(consultas);

        }

        private void getConsultasPorCriterio(Dictionary<string, object> parametros, List<Consulta> consultas)
        {
            Area area = new Area();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GETConsultasDePortal2", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    Persona creador = new Persona(row.GetInt("id_usuario"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Persona responsable = new Persona(row.GetInt("id_responsable", 0), row.GetInt("NroDocumentoResponsable", 0), row.GetString("nombreResponsable", ""), row.GetString("apellidoResponsable", ""), area);
                    List<Respuesta> respuestas = new List<Respuesta>();
                    Consulta consulta = new Consulta(
                        row.GetLong("Id"),
                        creador,
                        row.GetDateTime("fecha_creacion"),
                        row.GetDateTime(("fecha_respuesta"), new DateTime(9999, 12, 31)),
                        responsable,
                        row.GetSmallintAsInt("id_tipo_consulta"),
                        row.GetString("tipo_consulta"),
                        row.GetString("resumen"),
                        row.GetSmallintAsInt("id_estado"),
                        row.GetString("estado"),
                        row.GetSmallintAsInt(("calificacion"), 0),
                        row.GetBoolean("leido", false),
                        respuestas);

                    consultas.Add(consulta);

                });

            }
        }

        public void ResponderConsulta(int id, string respuesta, int id_usuario)
        {
            var resumen = respuesta;
            if (respuesta.Length > 100) resumen = respuesta.Substring(0, 100);
            var id_estado = 7;
            var leido = true;
            var calificacion = 0;
            UpdateConsulta(id, respuesta, id_usuario, resumen, id_estado, leido, calificacion);
        }
        public void RepreguntarConsulta(int id, string respuesta, int id_usuario)
        {
            var resumen = respuesta;
            if (respuesta.Length > 100) resumen = respuesta.Substring(0, 100);
            var id_estado = 6;
            var leido = false;
            var calificacion = 0;
            UpdateConsulta(id, respuesta, id_usuario, resumen, id_estado, leido, calificacion);
        }
        public void CerrarConsulta(int id, int calificacion, int id_usuario)
        {
            var respuesta = "";
            var resumen = "CONSULTA CERRADA";
            var id_estado = 9;
            var leido = false;
            UpdateConsulta(id, respuesta, id_usuario, resumen, id_estado, leido, calificacion);
        }
        public void EliminarConsulta(int id, int id_usuario)
        {
            var resumen = "";
            var respuesta = "";
            var id_estado = 8;
            var leido = false;
            var calificacion = 0;
            UpdateConsulta(id, respuesta, id_usuario, resumen, id_estado, leido, calificacion);
        }

        private void UpdateConsulta(int id, string respuesta, int id_usuario, string resumen, int id_estado, bool leido, int calificacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id", id);
            parametros.Add("@Respuesta", respuesta);
            parametros.Add("@Id_Usuario", id_usuario);
            parametros.Add("@resumen", resumen);
            parametros.Add("@id_estado", id_estado);
            parametros.Add("@leido", leido);
            parametros.Add("@calificacion", calificacion);
            conexion.EjecutarSinResultado("dbo.LEG_UPDConsultasDePortal2", parametros);
        }

        public void MarcarConsultaComoLeida(int id_consulta)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_consulta", id_consulta);
            conexion.EjecutarSinResultado("dbo.LEG_UPDConsultaLeida2", parametros);
        }
        public void MarcarNotificacionComoLeida(int id, int documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id);
            parametros.Add("@documento", documento);
            conexion.EjecutarSinResultado("dbo.LEG_UPDNotificacionLeida", parametros);
        }

        public string GetDetalleDeConsulta(int id_consulta)
        {
            List<Respuesta> respuestas = new List<Respuesta>();
            Area area = new Area();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_consulta", id_consulta);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GetDetalleDeConsultaDePortal", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    Persona persona = new Persona(row.GetInt("id_usuario"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Respuesta respuesta = new Respuesta(
                        row.GetInt("id_orden"),
                        persona,
                        row.GetDateTime("fecha_creacion"),
                        row.GetString("texto"));
                    respuestas.Add(respuesta);
                });
            }
            return JsonConvert.SerializeObject(respuestas);
        }


        public string GetTiposDeConsultaDePortal()
        {

            var tipos_consultas = new List<Object> { };

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GetTiposDeConsultaDePortal");

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                tipos_consultas.Add(new
                    {

                        id = row.GetSmallintAsInt("id"),
                        descripcion = row.GetString("descripcion"),
                        placeholder = row.GetString("placeholder")
                    })
                );
            }

            return JsonConvert.SerializeObject(tipos_consultas);

        }

        public int NuevaConsultaDePortal(int id_usuario, int id_tipo_consulta, string motivo)
        {
            var parametros = new Dictionary<string, object>();
            var resumen = motivo;
            if (motivo.Length > 100) resumen = motivo.Substring(0, 100);
            parametros.Add("@id_usuario_creador", id_usuario);
            parametros.Add("@id_tipo_consulta", id_tipo_consulta);
            parametros.Add("@motivo", motivo);
            parametros.Add("@resumen", resumen);

            var resultado = conexion.EjecutarEscalar("dbo.LEG_NuevaConsultaDePortal2", parametros);
            return (int)(long)resultado;
        }

        public int GetConsultasNoLeidas(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario_creador", id_usuario);

            var resultado = conexion.EjecutarEscalar("dbo.LEG_GetConsultasPortalNoLeidas2", parametros);
            return (int)resultado;
        }


        protected override List<Legajo> ObtenerDesdeLaBase()
        {
            throw new NotImplementedException();
        }

        protected override void GuardarEnLaBase(Legajo legajo)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Legajo legajo)
        {
            throw new NotImplementedException();
        }
    }
}
