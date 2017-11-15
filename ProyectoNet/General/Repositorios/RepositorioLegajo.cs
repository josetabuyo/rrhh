using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using Newtonsoft.Json;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioLegajo : RepositorioLazySingleton<Legajo>
    {

        private static RepositorioLegajo _instancia;

        private RepositorioLegajo(IConexionBD conexion)
            : base(conexion, 10)
        {

        }

        public string getAreaDeLaPersona(int documento)
        {
            var area = new Area();
            var datos_adicionales = new List<Area>();
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Documento", documento);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GetAreaDeLaPersona", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                var linea = tablaDatos.Rows.First();
                area.Id = linea.GetInt("IdArea", 0);
                area.Nombre = linea.GetString("Descripcion", "");
            }
            if (area.Id > 0)
            {
                parametros.Clear();

                parametros.Add("@id_area", area.Id);
                var tablaDatos2 = conexion.Ejecutar("dbo.VIA_GetAreasCompletas", parametros);
                datos_adicionales = RepositorioDeAreas.GetAreasDeTablaDeDatos(tablaDatos2);
                area = datos_adicionales.First();
            }

            //PERMISOS PARA GESTIONAR LICENCIAS
            if (area.Asistentes != null)
            {
                area.Asistentes.Clear();
            }
            else
            {
                area.Asistentes = new List<Asistente>();
            }
            parametros.Add("@FechaVigencia", DateTime.Today);
            parametros.Add("@Muestra_Depto", true);
            parametros.Add("@Muestra_Lugares_de_Trabajo", true);
            parametros.Add("@Muestra_Lugares_Sin_Trabajadores", true);

            var tablaDatos3 = conexion.Ejecutar("dbo.VIA_Get_Areas_y_RespAsist", parametros);
            if (tablaDatos3.Rows.Count > 0)
            {
                tablaDatos3.Rows.ForEach(row =>
                {
                    area.Asistentes.Add(new Asistente(row.GetString("Nombre", ""), row.GetString("Apellido", ""), "", 0, "", "", ""));
                });

            }
            //var repo_permisos = RepositorioDePermisosSobreAreas.NuevoRepositorioDePermisosSobreAreas(conexion, RepositorioDeAreas.NuevoRepositorioDeAreas(conexion));
            //var repo_usuario = new RepositorioDeUsuarios(conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(conexion));
            //var usuarios = repo_usuario.GetUsuariosQueAdministranLaFuncionalidadDelArea(4, area);
            //if (area.Asistentes != null)
            //{
            //    area.Asistentes.Clear();
            //}
            //else {
            //    area.Asistentes = new List<Asistente>();
            //}

            //List<Asistente> asistentes_confuncionalidades = new List<Asistente>();
            //usuarios.ForEach(u =>
            //{
            //    if (u.Owner != null)
            //    {
            //        var asistente_nuevo = new Asistente(u.Owner.Nombre, u.Owner.Apellido, "", 0, "", "", "");
            //        area.Asistentes.Add(asistente_nuevo);
            //    }

            //});

            return JsonConvert.SerializeObject(area);
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
                    Dictionary<string, int> dicUniInst = traerMasDatosDelEstudio(row.GetInt("id"));
                    string nombre_universidad = traerNombre(dicUniInst);

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

        private Dictionary<string, int> traerMasDatosDelEstudio(int idEstudio)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdEstudio", idEstudio);
            parametros.Add("@Tipo", 1);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Estudio_Realizado_ID", parametros);
            Dictionary<string, int> univNivel = new Dictionary<string, int>();


            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    univNivel.Add("Nivel", row.GetSmallintAsInt("Id_Nivel"));
                    univNivel.Add("IdInstitucion", row.GetSmallintAsInt("Id_Institucion"));
                    univNivel.Add("IdUniversidad", row.GetSmallintAsInt("Id_Universidad"));

                });

            }

            return univNivel;
        }

        private string traerNombre(Dictionary<string, int> dicUniIns)
        {
            string nombre = "Sin datos";


            if (dicUniIns["Nivel"] == 5)
            {

                var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Universidades");

                if (tablaDatos.Rows.Count > 0)
                {
                    tablaDatos.Rows.ForEach(row =>
                    {
                        if (dicUniIns["IdUniversidad"] == row.GetSmallintAsInt("id", 0))
                        {
                            nombre = row.GetString("Universidad", "Sin datos");
                        }


                    });

                }

            }
            else
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@Nivel", dicUniIns["Nivel"]);
                var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Instituciones_X_Nivel", parametros);

                if (tablaDatos.Rows.Count > 0)
                {
                    tablaDatos.Rows.ForEach(row =>
                    {
                        if (dicUniIns["IdInstitucion"] == row.GetSmallintAsInt("id", 0))
                        {
                            nombre = row.GetString("Nombre", "Sin datos");
                        }


                    });

                }
            }

            return nombre;
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
                        FechaHasta = row.GetDateTime("Fecha_Hasta", DateTime.MinValue),
                        // FechaHasta = row.g.GetDateTime("Fecha_Hasta", DateTime.Today),
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


        public  List<Selector> GetSubclasificacionesDeConsultas()
        {
            List<Selector> selectores = new List<Selector>();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GetSubTiposDeConsultaDePortal");
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                   Selector subtipo = new Selector(row.GetInt("Id"),  row.GetString("descripcion"));
                    selectores.Add(subtipo);
                });
            }
            return selectores;
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

        public bool SolicitarRenovacionCredencial(Usuario usuario_solicitante, string id_motivo, string id_organismo, int id_lugar_entrega)
        {
            RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
            var id_ticket = repo.crearTicket("solicitud_credencial", usuario_solicitante.Id);

         //   var id_motivo = GetMotivosBajaCredencial().Find(x => x.Descripcion.Trim().ToUpper() == motivo.Trim().ToUpper()).Id;
          //  List<MotivoBaja> motivos = GetMotivosBajaCredencial();
                                 
            var parametros = new Dictionary<string, object>();

            parametros.Add("@IdPersona", usuario_solicitante.Owner.Id);
            parametros.Add("@IdTipoCredencial", 2); //2 Definitiva - 1 provisoria
            parametros.Add("@IdOrganismo", int.Parse(id_organismo));
            parametros.Add("@IdMotivo", int.Parse(id_motivo));
            parametros.Add("@IdLugarEntrega", id_lugar_entrega);
            parametros.Add("@IdTicketAprobacion", id_ticket);
            
            var tablaDatos = conexion.Ejecutar("dbo.Acre_InsSolicitudCredencial", parametros);

            return true;
        }

        public bool AprobarSolicitudCredencial(SolicitudCredencial solicitud, Usuario usuario_aprobador)
        {
            RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
            var id_ticket_impresion = repo.crearTicket("impresion_credencial", usuario_aprobador.Id);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPersona", usuario_aprobador.Owner.Id);
            parametros.Add("@IdSolicitud ", solicitud.Id);
            parametros.Add("@IdTicketImpresion ", id_ticket_impresion); 

            var tablaDatos = conexion.Ejecutar("dbo.Acre_AprobarSolicitudCredencial", parametros);

            var repo_usuarios = new RepositorioDeUsuarios(this.conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(this.conexion));

            var usuario_solicitante = repo_usuarios.GetUsuarioPorIdPersona(solicitud.IdPersona);
            new RepositorioDeAlertasPortal(this.conexion)
                .crearAlerta("Solicitud de Credencial", "Tu solicitud ha sido aprobada, se le avisará cuando esté impresa", usuario_solicitante.Id, usuario_aprobador.Id);
            return true;
        }

        public bool RechazarSolicitudCredencial(SolicitudCredencial solicitud, string motivo, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPersona", usuario.Owner.Id);
            parametros.Add("@IdSolicitud ", solicitud.Id);
            parametros.Add("@Motivo ", motivo);

            var tablaDatos = conexion.Ejecutar("dbo.Acre_RechazarSolicitudCredencial", parametros);

            var repo_usuarios = new RepositorioDeUsuarios(this.conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(this.conexion));

            var usuario_solicitante = repo_usuarios.GetUsuarioPorIdPersona(solicitud.IdPersona);
            new RepositorioDeAlertasPortal(this.conexion)
                .crearAlerta("Solicitud de Credencial", "Tu solicitud ha sido rechazada por:" + motivo, usuario_solicitante.Id, usuario.Id);
            return true;
        }

        public List<MotivoBaja> GetMotivosBajaCredencial()
        {
           
            List<MotivoBaja> motivosbaja = new List<MotivoBaja>();
            getMotivosBajaCredencial(motivosbaja);

            return motivosbaja;
        }

        private List<MotivoBaja> getMotivosBajaCredencial(List<MotivoBaja> motivosbaja)
        {
            MotivoBaja motivo = new MotivoBaja();
            var tablaDatos = conexion.Ejecutar("dbo.Acre_GetMotivosBajaCredencial");

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    motivosbaja.Add(new MotivoBaja(row.GetInt("Id"), row.GetString("Descripcion")));

                });
            }
            else
            {
                motivosbaja.Add(new MotivoBaja(0, "-"));
            }

            return motivosbaja;
        }




        public List<Credencial> GetCredencialesTodasDePortal(int idPersona)
        {
            var parametros = new Dictionary<string, object>();
            if (idPersona != 0)
            {
                parametros.Add("@IdPersona", idPersona);
            }

            List<Credencial> credenciales = new List<Credencial>();
            getCredencialesPorCriterio(parametros, credenciales);

            return credenciales;
        }

        private List<Credencial> getCredencialesPorCriterio(Dictionary<string, object> parametros, List<Credencial> credenciales)
        {
            Area area = new Area();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GETCredencialesDePortal", parametros);
                                
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    credenciales.Add(new Credencial(row.GetInt("IdCredencial"), row.GetString("TipoCredencial"), row.GetDateTime("FechaAlta"), row.GetString("UsuarioAlta"), row.GetString("Organismo"), row.GetInt("IdFoto", 0), row.GetString("CodigoMagnetico"), row.GetString("Estado")));                                

                });    

            }
            else
            {
                credenciales.Add(new Credencial(0, "", DateTime.MinValue, " ", " ", 0, "", "INACTIVA")); 
            }


            return credenciales;
        }


        public List<SolicitudCredencial> GetSolicitudesDeCredencialPorPersona(int id_persona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPersona", id_persona);

            var tablaDatos = conexion.Ejecutar("dbo.Acre_GetSolicitudesCredencialPorIdPersona", parametros);

            List<SolicitudCredencial> solicitudes = new List<SolicitudCredencial>();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    solicitudes.Add(new SolicitudCredencial(row.GetInt("Id"), row.GetInt("IdPersona"), row.GetString("TipoCredencial"), row.GetString("Motivo"), row.GetString("Organismo"), row.GetString("Estado"), row.GetInt("IdTicketAprobacion", 0), row.GetInt("IdTicketimpresion", 0), row.GetDateTime("Fecha")));

                });
            }
            else
            {
                solicitudes.Add(new SolicitudCredencial(0,0,"","","","",0,0 ,DateTime.MinValue));
            }
            return solicitudes;
        }



        public List<LugarEntrega> GetLugaresEntregaCredencial()
        {
           // var parametros = new Dictionary<string, object>();
           // parametros.Add("@IdPersona", id_persona);

            var tablaDatos = conexion.Ejecutar("dbo.Acre_GetLugaresEntregaCredencial");

            List<LugarEntrega> lugares_entrega = new List<LugarEntrega>();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    lugares_entrega.Add(new LugarEntrega(row.GetInt("Id"), row.GetInt("Id_Lugar"), row.GetDateTime("Desde"), false, row.GetString("Descripcion")));

                });
            }
            else
            {
                lugares_entrega.Add(new LugarEntrega(0, 0, DateTime.MinValue, false, "-"));
            }
            return lugares_entrega;
        }




        public SolicitudCredencial GetSolicitudDeCredencialPorIdTicketAprobacion(int id_ticket)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_ticket", id_ticket);
            
            var tablaDatos = conexion.Ejecutar("dbo.Acre_GetSolicitudDeCredencialPorIdTicketAprobacion", parametros);

            if (tablaDatos.Rows.Count == 0) throw new Exception("No existe una solicitud con ese nro de ticket");
            if (tablaDatos.Rows.Count > 1) throw new Exception("Hay mas de una solicitud con ese nro de ticket");

            var row = tablaDatos.Rows[0];
            var solicitud = new SolicitudCredencial();
            solicitud.Id = row.GetInt("Id");
            solicitud.IdPersona = row.GetInt("IdPersona");
            solicitud.Motivo = row.GetString("Motivo");
            solicitud.Organismo = row.GetString("Organismo");
            return solicitud;             
        }

        public SolicitudCredencial GetSolicitudDeCredencialPorIdTicketImpresion(int id_ticket)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_ticket", id_ticket);

            var tablaDatos = conexion.Ejecutar("dbo.Acre_GetSolicitudDeCredencialPorIdTicketImpresion", parametros);

            if (tablaDatos.Rows.Count == 0) throw new Exception("No existe una solicitud con ese nro de ticket");
            if (tablaDatos.Rows.Count > 1) throw new Exception("Hay mas de una solicitud con ese nro de ticket");

            var row = tablaDatos.Rows[0];
            var solicitud = new SolicitudCredencial();
            solicitud.Id = row.GetInt("Id");
            solicitud.IdPersona = row.GetInt("IdPersona");
            solicitud.Motivo = row.GetString("Motivo");
            solicitud.Organismo = row.GetString("Organismo");
            solicitud.Credencial = new Credencial();
            solicitud.Credencial.Id = row.GetInt("idCredencial");
            solicitud.Credencial.IdFoto = row.GetInt("idFoto");
            solicitud.Credencial.Impresa = row.GetBoolean("impresa");
            solicitud.Credencial.CodigoMagnetico = row.GetString("CodigoMagnetico", "");
            return solicitud;
        }

        public bool MarcarCredencialComoImpresa(int idCredencial, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_credencial", idCredencial);

            var tablaDatos = conexion.Ejecutar("dbo.Acre_MarcarCredencialComoImpresa", parametros);
            return true;
        }

        public bool AsociarCodigoMagneticoACredencial(int idCredencial, string codigo_magnetico, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_credencial", idCredencial);
            parametros.Add("@codigo_magnetico", codigo_magnetico);

            var tablaDatos = conexion.Ejecutar("dbo.Acre_AsociarCodigoMagneticoACredencial", parametros);
            return true;
        }

        public bool CerrarTicketImpresion(SolicitudCredencial solicitud, string instrucciones_de_retiro, Usuario usuario)
        {
            var repo_usuarios = new RepositorioDeUsuarios(this.conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(this.conexion));

            var usuario_solicitante = repo_usuarios.GetUsuarioPorIdPersona(solicitud.IdPersona);
            new RepositorioDeTickets(this.conexion)
                .MarcarEstadoTicket(solicitud.IdTicketImpresion, usuario.Id);
            new RepositorioDeAlertasPortal(this.conexion)
                .crearAlerta("Solicitud de Credencial", "Su credencial está impresa. Para retirarla: " + instrucciones_de_retiro, usuario_solicitante.Id, usuario.Id);
            return true;
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



        public void ResponderConsulta(int id, string respuesta, Usuario usuario)
        {
            var resumen = respuesta;
            if (respuesta.Length > 100) resumen = respuesta.Substring(0, 100);
            var id_estado = 7;
            var leido = true;
            var calificacion = 0;
            UpdateConsulta(id, respuesta, usuario, resumen, id_estado, leido, calificacion, false);
        }
        public void RepreguntarConsulta(int id, string respuesta, Usuario usuario)
        {
            var resumen = respuesta;
            if (respuesta.Length > 100) resumen = respuesta.Substring(0, 100);
            var id_estado = 6;
            var leido = false;
            var calificacion = 0;
            UpdateConsulta(id, respuesta, usuario, resumen, id_estado, leido, calificacion, true);
        }
        public void CerrarConsulta(int id, int calificacion, Usuario usuario)
        {
            var respuesta = "";
            var resumen = "CONSULTA CERRADA";
            var id_estado = 9;
            var leido = false;
            UpdateConsulta(id, respuesta, usuario, resumen, id_estado, leido, calificacion, false);
        }
        public void EliminarConsulta(int id, Usuario usuario)
        {
            var resumen = "";
            var respuesta = "";
            var id_estado = 8;
            var leido = false;
            var calificacion = 0;
            UpdateConsulta(id, respuesta, usuario, resumen, id_estado, leido, calificacion, false);
        }

        private void UpdateConsulta(int id, string respuesta, Usuario usuario, string resumen, int id_estado, bool leido, int calificacion, bool ticket)
        {
            var id_ticket = 0;
            if (ticket)
            {
                RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
                id_ticket = repo.crearTicket("consulta", usuario.Id);
            }
            else
            {

            }

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id", id);
            parametros.Add("@Respuesta", respuesta);
            parametros.Add("@Id_Usuario", usuario.Owner.Id);
            parametros.Add("@resumen", resumen);
            parametros.Add("@id_estado", id_estado);
            parametros.Add("@leido", leido);
            parametros.Add("@calificacion", calificacion);
            parametros.Add("@idTicket", id_ticket);
            conexion.EjecutarSinResultado("dbo.LEG_UPDConsultasDePortal2", parametros);
            parametros.Clear();
            parametros.Add("@Id", id);
            var creador = conexion.EjecutarEscalar("dbo.LEG_GETConsultasCreador", parametros);

            if (!ticket)
            {
                RepositorioDeAlertasPortal repoAlerta = new RepositorioDeAlertasPortal(this.conexion);
                repoAlerta.crearAlerta("Respuesta a su consulta", resumen, (int)(short)creador, usuario.Id);
            }
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

        public Consulta GetConsultaPorIdTicket(int id_ticket)
        {
            Consulta consulta = new Consulta();
            List<Respuesta> respuestas = new List<Respuesta>();
            Area area = new Area();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_ticket", id_ticket);

            var tablaDatos_Cabecera = conexion.Ejecutar("dbo.LEG_GetConsultaPorIdTicket", parametros);

            if (tablaDatos_Cabecera.Rows.Count > 0)
            {
                tablaDatos_Cabecera.Rows.ForEach(row =>
                {
                    Persona creador = new Persona(row.GetInt("id_usuario"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Persona responsable = new Persona(row.GetInt("id_responsable", 0), row.GetInt("NroDocumentoResponsable", 0), row.GetString("nombreResponsable", ""), row.GetString("apellidoResponsable", ""), area);
                    List<Respuesta> respuestas_vacias = new List<Respuesta>();
                    consulta = new Consulta(
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
                        respuestas_vacias);
                });

            }
            parametros.Clear();
            parametros.Add("@Id_consulta", consulta.Id);
            var tablaDatos_Detalle = conexion.Ejecutar("dbo.LEG_GetDetalleDeConsultaDePortal", parametros);
            if (tablaDatos_Detalle.Rows.Count > 0)
            {
                tablaDatos_Detalle.Rows.ForEach(row =>
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

            consulta.respuestas = respuestas;
            return consulta;

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

        public int NuevaConsultaDePortal(Usuario usuario, int id_tipo_consulta, string motivo)
        {
            RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
            var id_ticket = repo.crearTicket("consulta", usuario.Id);

            var parametros = new Dictionary<string, object>();
            var resumen = motivo;
            if (motivo.Length > 100) resumen = motivo.Substring(0, 100);
            parametros.Add("@id_usuario_creador", usuario.Owner.Id);
            parametros.Add("@id_tipo_consulta", id_tipo_consulta);
            parametros.Add("@motivo", motivo);
            parametros.Add("@resumen", resumen);
            parametros.Add("@idTicket", id_ticket);

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


        public string GetConsultasDePortalNoLeidas(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_usuario", id_usuario);
            parametros.Add("@Leido", 1);
            List<Consulta> consultas = new List<Consulta>();
            getConsultasPorCriterio(parametros, consultas);

            return JsonConvert.SerializeObject(consultas);

        }

        public string VerificarCambioDomicilio(int idTarea, int documento, string folio, int idUsuarioDestinatario, int idUsuarioVerificador)
        {

            using (var tran = conexion.BeginTransaction())
            {
                try
                {
                    var parametros = new Dictionary<string, object>();

                    //parametros.Add("@idDomicilio", idDomicilio);
                    CvDomicilio domicilio = JsonConvert.DeserializeObject<CvDomicilio>(this.GetDomicilioPendientePorAlerta(idTarea));

                    parametros.Add("@idAlerta", idTarea);
                    //parametros.Add("@idUsuarioVerificador", idUsuarioVerificador);

                    //var tablaDatos = conexion.Ejecutar("dbo.LEG_UPD_DomicilioPendiente", parametros);
                    //var tablaDatos = conexion.Ejecutar("dbo.LEG_DEL_DomicilioPendiente", parametros);

                    parametros = new Dictionary<string, object>();
                    parametros.Add("@Fecha_Comunicacion", DateTime.Today);
                    parametros.Add("@Calle", domicilio.Calle);
                    parametros.Add("@Número", domicilio.Numero);
                    parametros.Add("@Piso", domicilio.Piso);
                    parametros.Add("@Dpto", domicilio.Depto);
                    parametros.Add("@Casa", domicilio.Casa);
                    parametros.Add("@Manzana", domicilio.Manzana);
                    parametros.Add("@Barrio", domicilio.Barrio);
                    parametros.Add("@Torre", domicilio.Torre);
                    parametros.Add("@UF", domicilio.Uf);
                    parametros.Add("@Localidad", domicilio.Localidad);
                    parametros.Add("@Codigo_Postal", domicilio.Cp);
                    parametros.Add("@Partido_Dpto", domicilio.Partido);
                    parametros.Add("@Provincia", domicilio.Provincia);
                    parametros.Add("@Folio", folio);
                    parametros.Add("@Id_Interna", "");
                    parametros.Add("@Nro_Doc", documento);
                    parametros.Add("@Baja", false);
                    parametros.Add("@usuario", idUsuarioVerificador);
                    parametros.Add("@Telefono", "");
                    parametros.Add("@Correo_Electronico", "");

                    var tablaDatos = conexion.Ejecutar("dbo.Alta_DomicilioPersonal", parametros);

                    this.borrarDomicilioPendiente(idTarea, idUsuarioVerificador);

                    RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
                    repo.MarcarEstadoTicket(idTarea, idUsuarioVerificador);

                    RepositorioDeAlertasPortal repoAlerta = new RepositorioDeAlertasPortal(this.conexion);
                    repoAlerta.crearAlerta("Confirmación de cambio de Domicilio", "Su domicilio ha sido modificado.", idUsuarioDestinatario, idUsuarioVerificador);

                    tran.Commit();
                    return JsonConvert.SerializeObject("Se ha cambiado el domicilio con exito.");

                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception(e.Message);
                }
            }




        }

        public bool borrarDomicilioPendiente(int idTarea, int idUsuario)
        {
            //try
            // {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idAlerta", idTarea);
            parametros.Add("@idUsuarioVerificador", idUsuario);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_UPD_DomicilioPendiente", parametros);

            return true;
            // }
            // catch (Exception e)
            //  {
            //      throw new Exception(e.Message);
            //  }

        }

        public string GetDomicilioPendientePorPersona(int idPersona)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@idPersona", idPersona);

            //List<CvDomicilio> listaDomicilios = new List<CvDomicilio>();
            CvDomicilio unDomicilio = new CvDomicilio();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_DomicilioPendiente", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>

                    //listaDomicilios.Add(new CvDomicilio(row.GetInt("id"), row.GetString("calle", ""), row.GetSmallintAsInt("nro", 0), row.GetString("piso", ""), row.GetString("dpto", ""), row.GetInt("localidad", 0), row.GetInt("cp", 0), row.GetInt("provincia", 0)))
                    unDomicilio = new CvDomicilio(row.GetInt("id"), row.GetString("calle", ""), row.GetSmallintAsInt("nro", 0), row.GetString("piso", ""), row.GetString("dpto", ""), new Localidad(row.GetInt("idLocalidad"), row.GetString("nombreLocalidad")), row.GetInt("cp", 0), new Provincia(row.GetSmallintAsInt("idProvincia", 0), row.GetString("nombreProvincia", "")), row.GetString("manzana", ""), row.GetString("casa", ""), row.GetString("barrio", ""), row.GetString("torre", ""), row.GetString("uf", ""))

                    );
            }

            return JsonConvert.SerializeObject(unDomicilio);

        }

        public bool GuardarDomicilioPendiente(CvDomicilio domicilio, Usuario usuario)
        {

            try
            {

                RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
                var id_ticket = repo.crearTicket("cambio_domicilio", usuario.Id);

                var parametros = new Dictionary<string, object>();

                parametros.Add("@calle", domicilio.Calle);
                parametros.Add("@numero", domicilio.Numero);
                parametros.Add("@piso", domicilio.Piso);
                parametros.Add("@depto", domicilio.Depto);
                parametros.Add("@cp", domicilio.Cp);
                parametros.Add("@localidad", domicilio.Localidad);
                parametros.Add("@provincia", domicilio.Provincia);
                parametros.Add("@torre", domicilio.Torre);
                parametros.Add("@manzana", domicilio.Manzana);
                parametros.Add("@barrio", domicilio.Barrio);
                parametros.Add("@uf", domicilio.Uf);
                parametros.Add("@casa", domicilio.Casa);
                parametros.Add("@idPersona", usuario.Owner.Id);
                parametros.Add("@idAlerta", id_ticket);


                conexion.Ejecutar("dbo.LEG_Ins_Domicilios_Pendientes", parametros);

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public string GetDomicilioPendientePorAlerta(int idAlerta)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@idAlerta", idAlerta);

            //List<CvDomicilio> listaDomicilios = new List<CvDomicilio>();
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_DomicilioPendientePorAlerta", parametros);

            CvDomicilio dom = new CvDomicilio();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>

                    dom = new CvDomicilio(row.GetInt("id"), row.GetString("calle", ""), row.GetSmallintAsInt("nro", 0), row.GetString("piso", ""), row.GetString("dpto", ""), new Localidad(row.GetInt("idLocalidad"), row.GetString("nombreLocalidad")), row.GetInt("cp", 0), new Provincia(row.GetSmallintAsInt("idProvincia", 0), row.GetString("nombreProvincia", "")), row.GetString("manzana", ""), row.GetString("casa", ""), row.GetString("barrio", ""), row.GetString("torre", ""), row.GetString("uf", ""))
                    //dom = new CvDomicilio(row.GetInt("id"), row.GetString("calle", ""), row.GetSmallintAsInt("nro", 0), row.GetString("piso", ""), row.GetString("dpto", ""), row.GetInt("localidad", 0), row.GetInt("cp", 0), row.GetInt("provincia", 0))
                );
            }

            return JsonConvert.SerializeObject(dom);
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
