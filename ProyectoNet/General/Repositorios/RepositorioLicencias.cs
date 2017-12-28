using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using System.Data.SqlClient;
using System.Data;

namespace General.Repositorios
{
    public class RepositorioLicencias : RepositorioLazy<List<VacacionesPermitidas>>, IRepositorioLicencia
    {

        public RepositorioLicencias(IConexionBD conexion)
            : base(conexion)
        {
        }

        #region IRepositorioLicencias Members


        public string Guardar(Licencia unaLicencia)
        {
            if (this.GetLicenciasQueSePisanCon(unaLicencia))
            {
                return "Error, ya existe una licencia cargada en ese periodo.";
            }

            if (this.GetSolicitudesQueSePisanCon(unaLicencia))
            {
                return "Error, ya existe una solicitud cargada en ese periodo.";
            }

            if (!this.PoseeSaldosPara14FoH(unaLicencia))
            {
                return "Error, No cuenta con los días suficientes para solicitar esta licencia. <br/> Seleccione en el Calendario el mes correspondiente para visualizar los días disponibles";
            }

            ConexionDB cn = new ConexionDB("dbo.WEB_AltaSolicitudLicencia");
            cn.AsignarParametro("@documento", unaLicencia.Persona.Documento);
            cn.AsignarParametro("@idConcepto", unaLicencia.Concepto.Id);
            cn.AsignarParametro("@desde", unaLicencia.Desde.ToShortDateString());
            cn.AsignarParametro("@hasta", unaLicencia.Hasta.ToShortDateString());
            cn.AsignarParametro("@idUsuario", unaLicencia.Auditoria.UsuarioDeCarga.Id);
            cn.AsignarParametro("@idArea", unaLicencia.Persona.Area.Id);

            cn.EjecutarSinResultado();
            cn.Desconestar();
            return null;
        }

        private bool PoseeSaldosPara14FoH(Licencia unaLicencia)
        {
            if (unaLicencia.Concepto.Id == 32)
            {
                SaldoLicencia saldo = CargarSaldoLicencia14FoHDe(unaLicencia.Concepto, unaLicencia.Persona, unaLicencia.Desde);
                if (saldo.SaldoAnual <= 0 || saldo.SaldoMensual <= 0)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public bool GetLicenciasQueSePisanCon(Licencia unaLicencia)
        {
            SqlDataReader dr;
            bool retu = false;
            ConexionDB cn = new ConexionDB("dbo.Web_GetPisaLicencia");
            cn.AsignarParametro("@nro_documento", unaLicencia.Persona.Documento);
            cn.AsignarParametro("@desde", unaLicencia.Desde.ToShortDateString());
            cn.AsignarParametro("@hasta", unaLicencia.Hasta.ToShortDateString());

            dr = cn.EjecutarConsulta();
            while (dr.Read())
            {
                if (dr.GetString(dr.GetOrdinal("Aprobada")) == "Aprobada")
                {
                    retu = true;
                }
            }
            cn.Desconestar();
            return retu;
        }

        public bool GetSolicitudesQueSePisanCon(Licencia unaLicencia)
        {
            SqlDataReader dr;
            bool retu = false;
            ConexionDB cn = new ConexionDB("dbo.Web_GetPisaLicencia");
            cn.AsignarParametro("@nro_documento", unaLicencia.Persona.Documento);
            cn.AsignarParametro("@desde", unaLicencia.Desde.ToShortDateString());
            cn.AsignarParametro("@hasta", unaLicencia.Hasta.ToShortDateString());

            dr = cn.EjecutarConsulta();
            while (dr.Read())
            {
                if (dr.GetString(dr.GetOrdinal("Aprobada")) == "Solicitada")
                {
                    retu = true;
                }
            }
            cn.Desconestar();
            return retu;
        }


        public SaldoLicencia CargarSaldoLicenciaGeneralDe(ConceptoDeLicencia concepto, Persona unaPersona)
        {
            SaldoLicencia saldo = new SaldoLicencia();
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("[dbo].[Web_GetSaldoSegunConceptoDeLicencia]");
            cn.AsignarParametro("@idConcepto", concepto.Id);

            dr = cn.EjecutarConsulta();

            if (dr.Read())
            {
                saldo.SaldoAnual = dr.GetInt16(dr.GetOrdinal("SaldoAnual"));
                saldo.SaldoMensual = dr.GetInt16(dr.GetOrdinal("SaldoMensual"));
            }

            cn.Desconestar();

            cn = new ConexionDB("[dbo].[Web_GetLicenciasTomadasEnElAnio]");
            cn.AsignarParametro("@idConcepto", concepto.Id);
            cn.AsignarParametro("@documento", unaPersona.Documento);
            cn.AsignarParametro("@periodo", DateTime.Today.Year);

            dr = cn.EjecutarConsulta();

            int RestarDiasAnual = 0;
            int RestarDiasMensual = 0;
            while (dr.Read())
            {
                RestarDiasAnual = ((TimeSpan)(DateTime.Parse(dr.GetValue(dr.GetOrdinal("hasta")).ToString()) - DateTime.Parse(dr.GetValue(dr.GetOrdinal("desde")).ToString()))).Days;
                if (DateTime.Today.Month == DateTime.Parse(dr.GetValue(dr.GetOrdinal("desde")).ToString()).Month)
                {
                    RestarDiasMensual++;
                }
                if (DateTime.Today.Month == DateTime.Parse(dr.GetValue(dr.GetOrdinal("hasta")).ToString()).Month && DateTime.Parse(dr.GetValue(dr.GetOrdinal("desde")).ToString()) != DateTime.Parse(dr.GetValue(dr.GetOrdinal("hasta")).ToString()))
                {
                    RestarDiasMensual++;
                }
            }
            cn.Desconestar();
            saldo.SaldoAnual -= RestarDiasAnual;
            saldo.SaldoMensual -= RestarDiasMensual;
            return saldo;
        }


        public SaldoLicencia CargarSaldoLicencia14FoHDe(ConceptoDeLicencia concepto, Persona unaPersona, DateTime fecha)
        {
            SaldoLicencia licencias_tomadas = CargarSaldoLicenciaTomada14FoHDe(concepto, unaPersona, fecha);
            SaldoLicencia licencia_en_tramite = GetLicenciasPendientes14FoHPara(concepto, unaPersona, fecha);

            SaldoLicencia restadas = licencias_tomadas.Restar(licencia_en_tramite);

            if (restadas.SaldoAnual <= 0)
            {
                restadas.SaldoMensual = 0;
            }

            return restadas;
        }

        public SaldoLicencia CargarSaldoLicenciaTomada14FoHDe(ConceptoDeLicencia concepto, Persona unaPersona, DateTime fecha)
        {
            SaldoLicencia saldo = new SaldoLicencia();
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("[dbo].[Web_GetSaldoSegunConceptoDeLicencia]");
            cn.AsignarParametro("@idConcepto", concepto.Id);

            dr = cn.EjecutarConsulta();

            if (dr.Read())
            {
                saldo.SaldoAnual = dr.GetInt16(dr.GetOrdinal("SaldoAnual"));
                saldo.SaldoMensual = dr.GetInt16(dr.GetOrdinal("SaldoMensual"));
            }

            cn.Desconestar();

            cn = new ConexionDB("[dbo].[Web_GetLicenciasTomadasEnElAnio]");
            cn.AsignarParametro("@idConcepto", concepto.Id);
            cn.AsignarParametro("@documento", unaPersona.Documento);
            cn.AsignarParametro("@periodo", fecha.Year);

            dr = cn.EjecutarConsulta();

            int RestarDiasAnual = 0;
            int RestarDiasMensual = 0;
            while (dr.Read())
            {
                RestarDiasAnual = ((TimeSpan)(DateTime.Parse(dr.GetValue(dr.GetOrdinal("hasta")).ToString()) - DateTime.Parse(dr.GetValue(dr.GetOrdinal("desde")).ToString()))).Days + 1 + RestarDiasAnual;

                if (fecha.Month == DateTime.Parse(dr.GetValue(dr.GetOrdinal("desde")).ToString()).Month)
                {
                    RestarDiasMensual = ((TimeSpan)(DateTime.Parse(dr.GetValue(dr.GetOrdinal("hasta")).ToString()) - DateTime.Parse(dr.GetValue(dr.GetOrdinal("desde")).ToString()))).Days + 1 + RestarDiasMensual;
                }
            }
            cn.Desconestar();
            saldo.SaldoAnual -= RestarDiasAnual;
            saldo.SaldoMensual -= RestarDiasMensual;
            return saldo;
        }

        public SaldoLicencia GetLicenciasPendientes14FoHPara(ConceptoDeLicencia concepto, Persona persona, DateTime fecha)
        {
            var parametros = new Dictionary<string, object>();

            SaldoLicencia saldo = new SaldoLicencia();
            parametros.Add("@nro_documento", persona.Documento);
            parametros.Add("@id_concepto_licencia", concepto.Id);


            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPendientesDeAprobacion", parametros);

            int RestarDiasAnual = 0;
            int RestarDiasMensual = 0;
            tablaDatos.Rows.ForEach(dr =>
            {
                if (dr.GetDateTime("desde").Year == fecha.Year)
                {
                    RestarDiasAnual = ((TimeSpan)(DateTime.Parse(dr.GetDateTime("hasta").ToString()) - DateTime.Parse(dr.GetDateTime("desde").ToString()))).Days + 1 + RestarDiasAnual; ;
                    if (fecha.Month == DateTime.Parse(dr.GetDateTime("desde").ToString()).Month)
                    {
                        RestarDiasMensual++;
                    }
                }
            });

            saldo.SaldoAnual -= RestarDiasAnual;
            saldo.SaldoMensual -= RestarDiasMensual;
            return saldo;

        }


        public SaldoLicencia CargarSaldoLicenciaOrdinariaDe(ConceptoDeLicencia concepto, ProrrogaLicenciaOrdinaria prorroga, Persona unaPersona)
        {
            SaldoLicencia saldo = new SaldoLicencia();
            saldo.Detalle = new List<SaldoLicenciaDetalle>();
            SaldoLicenciaDetalle detalle;

            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("[dbo].[Web_GetSaldoLicencia]");
            cn.AsignarParametro("@nroDocumento", unaPersona.Documento);
            cn.AsignarParametro("@idConcepto", concepto.Id);

            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                detalle = new SaldoLicenciaDetalle();
                detalle.Periodo = dr.GetInt16(dr.GetOrdinal("periodo"));
                detalle.Disponible = dr.GetInt16(dr.GetOrdinal("saldo"));

                if (prorroga == null)
                {
                    //si la prorroga esta vacía solo se puede tomar las de este año, o el año pasado

                    //TODO: GER: Solo funciona bien para el mes de Diciembre.
                    if (DateTime.Today.Month == 12)
                    {
                        if (detalle.Periodo == DateTime.Today.Year || detalle.Periodo == DateTime.Today.Year - 1)
                        {
                            saldo.Detalle.Add(detalle);
                        }
                    }
                    else
                    {
                        if (detalle.Periodo == DateTime.Today.Year - 1 || detalle.Periodo == DateTime.Today.Year - 2)
                        {
                            saldo.Detalle.Add(detalle);
                        }
                    }
                }
                else
                {
                    if (prorroga.UsufructoDesde <= detalle.Periodo && detalle.Periodo <= prorroga.UsufructoHasta)
                    {
                        saldo.Detalle.Add(detalle);
                    }
                }
            }

            cn.Desconestar();
            return saldo;

        }
        #endregion

        public List<VacacionesPermitidas> GetVacacionesPermitidas()
        {
            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPermitidos");
            return ConstruirVacacionesPermitidas(tablaDatos);
        }

        public void EliminarLicenciaPendienteAprobacion(int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id);
            this.conexion.EjecutarSinResultado("LIC_GEN_DelDiasPendientesDeAprobacion", parametros);
        }

        public List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_documento", persona.Documento);

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasAprobados", parametros);

            return ConstruirVacacionesAprobadas(tablaDatos);
        }

        public void Cachear<T>(string nros_documento, string sp, Dictionary<string, object> parametros, Dictionary<int, List<T>> cache, Func<RowDeDatos, IConPersona> constructor) where T : IConPersona
        {
            
            var tablaDatos = this.conexion.Ejecutar(sp, parametros, 3000);

            List<T> items = new List<T>();
            tablaDatos.Rows.ForEach(row =>
            {
                var it = (T)constructor(row);
                AddToCache<T>(it.Persona.Documento, cache, it);
            });

            nros_documento.Split(',').ToList().ForEach(doc =>
            {
                if (doc != string.Empty)
                {
                    var numeric_doc = int.Parse(doc);
                    if (!cache.ContainsKey(numeric_doc))
                    {
                        cache.Add(numeric_doc, new List<T>());
                    }
                }
            });
        }

        public void CachearGetVacacionesPendientesAprobacion(string nros_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nros_documento", nros_documento);
            parametros.Add("@id_concepto_licencia", 1);
            this.CacheVacacionesPendientesAprobacion = new Dictionary<int, List<VacacionesPendientesDeAprobacion>>();
            this.Cachear<VacacionesPendientesDeAprobacion>(nros_documento, "dbo.LIC_GEN_GetDiasPendientesDeAprobacionVarios", 
                parametros, this.CacheVacacionesPendientesAprobacion, 
                (RowDeDatos row) => {
                    Persona persona = new Persona();
                    persona.Documento = row.GetInt("NroDocumento");
                    persona.Apellido = row.GetString("Apellido");
                    persona.Nombre = row.GetString("Nombre");

                    DateTime fecha_desde = row.GetDateTime("Desde");
                    DateTime fecha_hasta = row.GetDateTime("Hasta");
                    return new VacacionesPendientesDeAprobacion(persona, fecha_desde, fecha_hasta);
                });
        }

        public void CachearVacacionesPermitidasPara(string nros_documento, ConceptoDeLicencia concepto)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nros_documento", nros_documento);
            parametros.Add("@id_concepto_licencia", concepto.Id);
            this.CacheDiasPermitidos = new Dictionary<int, List<VacacionesPermitidas>>();
            Cachear<VacacionesPermitidas>(nros_documento, "dbo.LIC_GEN_GetDiasPermitidosVarios", parametros, this.CacheDiasPermitidos,
                (RowDeDatos row) => {
                    Persona persona = new Persona();
                    persona.Documento = row.GetInt("NroDocumento");
                    persona.Apellido = row.GetString("Apellido");
                    persona.Nombre = row.GetString("Nombre");

                    int periodo = row.GetSmallintAsInt("Periodo");
                    int dias = row.GetSmallintAsInt("Dias_Autorizados");

                    return new VacacionesPermitidas(persona, periodo, dias);
                });
        }

        Dictionary<int, List<VacacionesAprobadas>> CacheVacacionesAprobadas;
        public void CachearVacacionesAprobadasPara(string nros_documento, ConceptoDeLicencia concepto)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nros_documento", nros_documento);
            parametros.Add("@id_concepto_licencia", concepto.Id);
            this.CacheVacacionesAprobadas = new Dictionary<int, List<VacacionesAprobadas>>();
            Cachear<VacacionesAprobadas>(nros_documento, "dbo.LIC_GEN_GetVariosDiasAprobados", parametros, this.CacheVacacionesAprobadas,
                (RowDeDatos row) =>
                {
                    Persona persona = new Persona();
                    persona.Documento = row.GetInt("NroDocumento");
                    persona.Apellido = row.GetString("Apellido");
                    persona.Nombre = row.GetString("Nombre");

                    DateTime fecha_desde = row.GetDateTime("Desde");
                    DateTime fecha_hasta = row.GetDateTime("Hasta");

                    return new VacacionesAprobadas(persona, fecha_desde, fecha_hasta);
                });
        }

        Dictionary<int, List<VacacionesPermitidas>> CacheDiasPerdidos;
        public void CachearVacacionesPerdidas(string nros_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nros_documento", nros_documento);
            this.CacheDiasPerdidos = new Dictionary<int, List<VacacionesPermitidas>>();
            Cachear<VacacionesPermitidas>(nros_documento, "dbo.LIC_GEN_GetDiasPerdidosVarios", parametros, this.CacheDiasPerdidos,
                (RowDeDatos row) => {
                    Persona persona = new Persona();
                    persona.Documento = row.GetInt("NroDocumento");
                    persona.Apellido = row.GetString("Apellido");
                    persona.Nombre = row.GetString("Nombre");

                    int periodo = row.GetSmallintAsInt("Periodo");

                    int dias = row.GetSmallintAsInt("Dias_Perdidos");

                    VacacionesPermitidas vacaciones = new VacacionesPermitidas(persona, periodo, dias);
                    vacaciones.Observacion = row.GetString("Observacion");

                    return vacaciones;
                });
        }

        public List<VacacionesPermitidas> GetVacasPermitidasPara(Persona persona, ConceptoDeLicencia concepto)
        {
            if (EstaCacheado<VacacionesPermitidas>(this.CacheDiasPermitidos, persona.Documento))
            {
                var result = new List<VacacionesPermitidas>();
                CacheDiasPermitidos[persona.Documento].ForEach(v =>
                {
                    result.Add(v.Clonar());
                });
                return result;
            }
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_documento", persona.Documento);
            parametros.Add("@id_concepto_licencia", concepto.Id);
            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPermitidos", parametros);
            var vaca_permitidas = ConstruirVacacionesPermitidas(tablaDatos);
            return vaca_permitidas;
        }

        protected void AddToCache<T>(int dni, Dictionary<int, List<T>> cache, T item)
        {
            if (!cache.ContainsKey(dni))
            {
                cache.Add(dni, new List<T>());
            }
            cache[dni].Add(item);
        }

        public bool EstaCacheado<T>(Dictionary<int, List<T>> cache, int documento)
        {
            if (cache == null) return false;
            return cache.ContainsKey(documento);
        }

        public List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona, ConceptoDeLicencia concepto)
        {
            if (EstaCacheado<VacacionesAprobadas>(this.CacheVacacionesAprobadas, persona.Documento))
            {
                return CacheVacacionesAprobadas[persona.Documento];
            }

            var parametros = new Dictionary<string, object>();

            parametros.Add("@nro_documento", persona.Documento);
            parametros.Add("@id_concepto_licencia", concepto.Id);

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasAprobados", parametros);

            return ConstruirVacacionesAprobadas(tablaDatos);
        }

        protected List<VacacionesAprobadas> ConstruirVacacionesAprobadas(TablaDeDatos tablaDatos)
        {
            List<VacacionesAprobadas> vacaciones_aprobadas = new List<VacacionesAprobadas>();

            tablaDatos.Rows.ForEach(row =>
            {
                Persona persona = new Persona();
                persona.Documento = row.GetInt("NroDocumento");
                persona.Apellido = row.GetString("Apellido");
                persona.Nombre = row.GetString("Nombre");

                //int periodo = row.GetSmallintAsInt("Periodo");

                DateTime fecha_desde = row.GetDateTime("Desde");
                DateTime fecha_hasta = row.GetDateTime("Hasta");
                //int concepto = row.GetSmallintAsInt("Id_Concepto_Licencia");

                VacacionesAprobadas vacaciones = new VacacionesAprobadas(persona, fecha_desde, fecha_hasta);

                vacaciones_aprobadas.Add(vacaciones);
            });

            List<VacacionesAprobadas> vacaciones_aprobadas_ordenadas = (from vacacion in vacaciones_aprobadas orderby vacacion.Desde() select vacacion).ToList();

            return vacaciones_aprobadas_ordenadas;
        }

        protected List<VacacionesPermitidas> ConstruirVacacionesPermitidas(TablaDeDatos tablaDatos)
        {
            List<VacacionesPermitidas> vacaciones_permitidas = new List<VacacionesPermitidas>();

            tablaDatos.Rows.ForEach(row =>
            {
                Persona persona = new Persona();
                persona.Documento = row.GetInt("NroDocumento");
                persona.Apellido = row.GetString("Apellido");
                persona.Nombre = row.GetString("Nombre");

                int periodo = row.GetSmallintAsInt("Periodo");

                int dias = row.GetSmallintAsInt("Dias_Autorizados");
                int concepto = row.GetSmallintAsInt("Id_Concepto_Licencia");

                VacacionesPermitidas vacaciones = new VacacionesPermitidas(persona, periodo, dias);

                vacaciones_permitidas.Add(vacaciones);
            });

            List<VacacionesPermitidas> vacaciones_permitidas_ordenadas = (from vacacion in vacaciones_permitidas orderby vacacion.Periodo select vacacion).ToList();
            return vacaciones_permitidas_ordenadas;
        }

        protected List<VacacionesPermitidas> ConstruirVacacionesPerdidas(TablaDeDatos tablaDatos)
        {
            List<VacacionesPermitidas> vacaciones_perdidas = new List<VacacionesPermitidas>();

            tablaDatos.Rows.ForEach(row =>
            {
                Persona persona = new Persona();
                persona.Documento = row.GetInt("NroDocumento");
                persona.Apellido = row.GetString("Apellido");
                persona.Nombre = row.GetString("Nombre");

                int periodo = row.GetSmallintAsInt("Periodo");

                int dias = row.GetSmallintAsInt("Dias_Perdidos");
                int concepto = 1;

                VacacionesPermitidas vacaciones = new VacacionesPermitidas(persona, periodo, dias);
                vacaciones.Observacion = row.GetString("Observacion");
                vacaciones_perdidas.Add(vacaciones);
            });

            List<VacacionesPermitidas> vacaciones_permitidas_ordenadas = (from vacacion in vacaciones_perdidas orderby vacacion.Periodo select vacacion).ToList();
            return vacaciones_permitidas_ordenadas;
        }

        public List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_documento", persona.Documento);
            parametros.Add("@periodo", periodo.anio);
            parametros.Add("@id_concepto_licencia", licencia.Concepto.Id);

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPermitidos", parametros);

            return ConstruirVacacionesPermitidas(tablaDatos);
        }

        Dictionary<int, List<VacacionesPermitidas>> CacheDiasPermitidos;
        public List<VacacionesPermitidas> VacacionesPerdidasDe(int dni_persona)
        {
            if (EstaCacheado<VacacionesPermitidas>(this.CacheDiasPermitidos, dni_persona)) {
                return CacheDePerdidasDe(dni_persona);
            }
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_documento", dni_persona);
            var tablaDatosPerdidas = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPerdidos", parametros);

            return ConstruirVacacionesPerdidas(tablaDatosPerdidas);
        }

        protected List<VacacionesPermitidas> CacheDePerdidasDe(int dni_persona)
        {
            if (!CacheDiasPerdidos.ContainsKey(dni_persona)) {
                return new List<VacacionesPermitidas>();
            }
            return CacheDiasPerdidos[dni_persona];
        }

        public List<VacacionesPermitidas> GetVacacionPermitidaDescontandoPerdidasPara(Persona persona, ConceptoDeLicencia concepto, List<VacacionesPermitidas> vaca_perdidas)
        {
            List<VacacionesPermitidas> vaca_permitidas = GetVacasPermitidasPara(persona, concepto);
            vaca_perdidas.AddRange(VacacionesPerdidasDe(persona.Documento));

            return CalcularVacacionesPermitidasNoPerdidas(vaca_permitidas, vaca_perdidas);
        }

        private List<VacacionesPermitidas> CalcularVacacionesPermitidasNoPerdidas(List<VacacionesPermitidas> vaca_permitidas, List<VacacionesPermitidas> vaca_perdidas)
        {
            List<VacacionesPermitidas> vacaciones_reales = new List<VacacionesPermitidas>();
            vaca_permitidas.ForEach(permitida =>
            {

                if (vaca_perdidas.Exists(perdida => perdida.Periodo == permitida.Periodo && perdida.CantidadDeDias() <= permitida.CantidadDeDias()))
                {
                    var perdido = vaca_perdidas.Find(perdida => perdida.Periodo == permitida.Periodo && perdida.CantidadDeDias() <= permitida.CantidadDeDias());
                    permitida.RestarDias(perdido.CantidadDeDias());
                }
                vacaciones_reales.Add(permitida);

            });
            return vacaciones_reales;
        }

        public List<VacacionesPermitidas> GetVacacionPermitidaPara(Periodo periodo, Licencia licencia)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@periodo", periodo.anio);
            parametros.Add("@id_concepto_licencia", licencia.Concepto.Id);

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasAprobados", parametros);

            return ConstruirVacacionesPermitidas(tablaDatos);
        }

        public List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_documento", persona.Documento);

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPendientesDeAprobacion", parametros);

            return ConstruirVacacionesPendientes(tablaDatos);
        }



        Dictionary<int, List<VacacionesPendientesDeAprobacion>> CacheVacacionesPendientesAprobacion;
        //public void CachearGetVacacionesPendientesAprobacion(string nros_documento, ConceptoDeLicencia concepto)
        //{
        //    CacheVacacionesPendientesAprobacion = new Dictionary<int, List<VacacionesPendientesDeAprobacion>>();
        //    var parametros = new Dictionary<string, object>();

        //    parametros.Add("@nros_documento", nros_documento);
        //    parametros.Add("@id_concepto_licencia", concepto.Id);

        //    var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPendientesDeAprobacionVarios", parametros);

        //    var pendientes = ConstruirVacacionesPendientes(tablaDatos);
        //    pendientes.ForEach(pend =>
        //    {
        //        AddToCache<VacacionesPendientesDeAprobacion>(pend.Persona.Documento, CacheVacacionesPendientesAprobacion, pend);
        //    });
        //}

        public List<VacacionesPendientesDeAprobacion> VacasPendientesDeAprobacionCacheadasPara(Persona persona)
        {
            if (!CacheVacacionesPendientesAprobacion.ContainsKey(persona.Documento))
            {
                return new List<VacacionesPendientesDeAprobacion>();
            }
            return CacheVacacionesPendientesAprobacion[persona.Documento];
        }

        public List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona, ConceptoDeLicencia concepto)
        {
            if (EstaCacheado<VacacionesPendientesDeAprobacion>(this.CacheVacacionesPendientesAprobacion, persona.Documento))
            {
                return VacasPendientesDeAprobacionCacheadasPara(persona);

            }

            var parametros = new Dictionary<string, object>();

            parametros.Add("@nro_documento", persona.Documento);
            parametros.Add("@id_concepto_licencia", concepto.Id);

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPendientesDeAprobacion", parametros);

            return ConstruirVacacionesPendientes(tablaDatos);
        }

        public List<Persona> GetAusentesEntreFechasPara(List<Persona> personas, DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<Inasistencia> inasistencias = new List<Inasistencia>();
            List<Persona> personas_con_inasistencias = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@fecha_desde", fecha_desde);
            parametros.Add("@fecha_hasta", fecha_hasta);

            //Licencias Aprobadas por RRHH
            var tablaDatos1 = this.conexion.Ejecutar("dbo.LIC_GEN_GetAusenciasEntreFechas", parametros);


            foreach (var persona in personas)
            {
                if (tablaDatos1.Rows.Exists(row => row.GetInt("NroDocumento") == persona.Documento))
                {
                    tablaDatos1.Rows.FindAll(row => row.GetInt("NroDocumento") == persona.Documento).ForEach(row =>
                    {
                        Inasistencia inasistencia = new Inasistencia();
                        Persona persona_con_inasistencia = new Persona();
                        inasistencia.Aprobada = true;
                        inasistencia.Descripcion = row.GetSmallintAsInt("Concepto") + " - " + row.GetString("Descripcion");
                        inasistencia.Desde = row.GetDateTime("Desde");
                        inasistencia.Hasta = row.GetDateTime("Hasta");
                        inasistencia.Estado = "Recepcionada en DGRHyO";
                        persona_con_inasistencia.Apellido = persona.Apellido;
                        persona_con_inasistencia.Nombre = persona.Nombre;
                        persona_con_inasistencia.Documento = persona.Documento;
                        persona_con_inasistencia.PasePendiente = persona.PasePendiente;
                        persona_con_inasistencia.AgregarInasistencia(inasistencia);
                        personas_con_inasistencias.Add(persona_con_inasistencia);
                    });
                }
            }

            //Licencias pendientes de Aprobación por RRHH (solicitadas por la Web)
            var tablaDatos2 = this.conexion.Ejecutar("dbo.LIC_GEN_GetAusenciasPendientesEntreFechas", parametros);


            foreach (var persona in personas)
            {
                if (tablaDatos2.Rows.Exists(row => row.GetInt("NroDocumento") == persona.Documento))
                {
                    tablaDatos2.Rows.FindAll(row => row.GetInt("NroDocumento") == persona.Documento).ForEach(row =>
                    {
                        Inasistencia inasistencia = new Inasistencia();
                        Persona persona_con_inasistencia = new Persona();
                        inasistencia.Aprobada = true;
                        inasistencia.Id = row.GetInt("Id");
                        inasistencia.Descripcion = row.GetSmallintAsInt("Concepto") + " - " + row.GetString("Descripcion");
                        inasistencia.Desde = row.GetDateTime("Desde");
                        inasistencia.Hasta = row.GetDateTime("Hasta");
                        inasistencia.Estado = "En Trámite";
                        persona_con_inasistencia.Apellido = persona.Apellido;
                        persona_con_inasistencia.Nombre = persona.Nombre;
                        persona_con_inasistencia.Documento = persona.Documento;
                        persona_con_inasistencia.AgregarInasistencia(inasistencia);
                        personas_con_inasistencias.Add(persona_con_inasistencia);
                    });
                }
            }

            return personas_con_inasistencias;
        }




        public List<Persona> GetPasesEntreFechasPara(List<Persona> personas, DateTime fecha_desde, DateTime fecha_hasta)
        {
            List<PaseDeArea> pases = new List<PaseDeArea>();
            List<Persona> personas_con_pases = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@fecha_desde", fecha_desde);
            parametros.Add("@fecha_hasta", fecha_hasta);


            var tablaDatos1 = this.conexion.Ejecutar("dbo.LIC_GEN_GetPasesEntreFechas", parametros);

            foreach (var persona in personas)
            {
                if (tablaDatos1.Rows.Exists(row => row.GetInt("NroDocumento") == persona.Documento))
                {
                    tablaDatos1.Rows.FindAll(row => row.GetInt("NroDocumento") == persona.Documento).ForEach(row =>
                    {
                        PaseDeArea pase = new PaseDeArea();
                        Area areaDestino = new Area();
                        Area areaOrigen = new Area();
                        Persona persona_con_pase = new Persona();
                        persona_con_pase.Apellido = persona.Apellido;
                        persona_con_pase.Nombre = persona.Nombre;
                        persona_con_pase.Documento = persona.Documento;
                        areaDestino.Nombre = row.GetString("area_destino");
                        areaOrigen.Nombre = row.GetString("area_origen");
                        pase.Id = row.GetInt("Id");
                        pase.Fecha = row.GetDateTime("fecha_solicitud");
                        pase.Estado = determinarEstado(row.GetSmallintAsInt("estado"));
                        pase.AreaDestino = areaDestino;
                        pase.AreaOrigen = areaOrigen;
                        persona_con_pase.PasePendiente = pase;
                        personas_con_pases.Add(persona_con_pase);
                    });
                }
            }

            return personas_con_pases;
        }

        private string determinarEstado(int estado)
        {
            if (estado == 0) { return "Pendiente"; } else if (estado == 1) { return "Aprobado"; } else { return "Rechazado"; }
        }


        public bool DiasHabilitadosEntreFechas(DateTime desde, DateTime hasta, int idconcepto)
        {
            int dias_pedidos = 0;
            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetConceptosDeLicencia");
            var parametro = tablaDatos.Rows.Find(row => row.GetSmallintAsInt("id_Concepto") == idconcepto);

            int dias_autorizados = parametro.GetSmallintAsInt("Dias_Autorizados");
            bool solo_habiles = parametro.GetBoolean("Dias_Habiles");

            if (solo_habiles)
            {
                dias_pedidos = DiasHabilesEntreFechas(desde, hasta);
            }
            else
            {
                TimeSpan diff = hasta - desde;
                dias_pedidos = diff.Days + 1;
            }

            if (dias_pedidos > dias_autorizados)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int DiasHabilesEntreFechas(DateTime desde, DateTime hasta)
        {
            if (desde <= hasta)
            {

                int dias_habiles = 0;
                if (desde.Year == hasta.Year)
                {
                    List<DateTime> Feriados = ObtenerFeriados(desde.Year);
                    TimeSpan diff = hasta - desde;
                    int total = diff.Days + 1;

                    DateTime fecha_a_evaluar = desde;
                    for (int i = 0; i < total; i++)
                    {
                        if (!Feriados.Contains(fecha_a_evaluar))
                        {
                            if (!EsFinDeSemana(fecha_a_evaluar))
                            {
                                dias_habiles = dias_habiles + 1;
                            }
                        }
                        fecha_a_evaluar = fecha_a_evaluar.AddDays(1);
                    }
                }
                else
                {
                    int dias_habiles_anio_vigente = DiasHabilesEntreFechas(desde, new DateTime(desde.Year, 12, 31));
                    int dias_habiles_anio_siguiente = DiasHabilesEntreFechas(new DateTime(desde.Year + 1, 01, 01), hasta);
                    dias_habiles = dias_habiles_anio_vigente + dias_habiles_anio_siguiente;
                }
                return dias_habiles;
            }
            else
            {
                Exception e = new Exception("la fecha desde no puede ser menor a la fecha hasta");
                throw e;
            }

        }

        public List<DateTime> ObtenerFeriados(int anio)
        {
            List<DateTime> Feriados = new List<DateTime>();
            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasFeraidos");

            tablaDatos.Rows.ForEach(row =>
            {
                DateTime dia = new DateTime();
                dia = row.GetDateTime("fecha");
                if (row.GetBoolean("periodico"))
                {
                    Feriados.Add(new DateTime(anio, dia.Month, dia.Day));
                }
                else
                {
                    if (anio == dia.Year)
                    {
                        Feriados.Add(dia);
                    }
                }

            });
            return Feriados;
        }

        public bool EsFinDeSemana(DateTime fecha)
        {
            if (fecha.DayOfWeek.Equals(DayOfWeek.Saturday) || fecha.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                return true;
            }
            return false;
        }

        

        protected List<VacacionesPendientesDeAprobacion> ConstruirVacacionesPendientes(TablaDeDatos tablaDatos)
        {
            List<VacacionesPendientesDeAprobacion> vacaciones_pendientes = new List<VacacionesPendientesDeAprobacion>();

            tablaDatos.Rows.ForEach(row =>
            {
                Persona persona = new Persona();
                persona.Documento = row.GetInt("NroDocumento");
                persona.Apellido = row.GetString("Apellido");
                persona.Nombre = row.GetString("Nombre");

                //int periodo = row.GetSmallintAsInt("Periodo");

                DateTime fecha_desde = row.GetDateTime("Desde");
                DateTime fecha_hasta = row.GetDateTime("Hasta");
                //int concepto = row.GetSmallintAsInt("Id_Concepto_Licencia");

                VacacionesPendientesDeAprobacion vacaciones = new VacacionesPendientesDeAprobacion(persona, fecha_desde, fecha_hasta);

                vacaciones_pendientes.Add(vacaciones);
            });

            List<VacacionesPendientesDeAprobacion> vacaciones_pendientes_ordenadas = (from vacacion in vacaciones_pendientes orderby vacacion.Desde() select vacacion).ToList();

            return vacaciones_pendientes_ordenadas;
        }

        public ProrrogaLicenciaOrdinaria CargarDatos(ProrrogaLicenciaOrdinaria prorroga)
        {
            return TodasLasProrrogas().Find(p => p.Periodo == prorroga.Periodo);
        }

        protected static List<ProrrogaLicenciaOrdinaria> Prorrogas;
        public List<ProrrogaLicenciaOrdinaria> TodasLasProrrogas()
        {
            if (Prorrogas == null)
            {
                var result = new List<ProrrogaLicenciaOrdinaria>();
                ConexionDB cn = new ConexionDB("dbo.WEB_GetProrrogasOrdinaria");

                SqlDataReader dr;
                dr = cn.EjecutarConsulta();

                while (dr.Read())
                {
                    var unaProrroga = new ProrrogaLicenciaOrdinaria();
                    unaProrroga.UsufructoDesde = dr.GetInt16(dr.GetOrdinal("Prorroga_Desde"));
                    unaProrroga.UsufructoHasta = dr.GetInt16(dr.GetOrdinal("Prorroga_Hasta"));
                    unaProrroga.Periodo = dr.GetInt16(dr.GetOrdinal("Periodo_Usufructo"));
                    result.Add(unaProrroga);
                }
                Prorrogas = result;
            }
            return Prorrogas;
        }

        public void LoguearError(List<VacacionesPermitidas> permitidas_log, SolicitudesDeVacaciones aprobadas, Persona persona, DateTime fecha_calculo)
        {
            var parametros = new Dictionary<string, object>();

            //Persona a loguear
            parametros.Add("@apellido", persona.Apellido);
            parametros.Add("@nombre", persona.Nombre);
            parametros.Add("@documento", persona.Documento);

            //Licencia con Conflicto
            parametros.Add("@anio_maximo_imputable", aprobadas.AnioMaximoImputable().First().Periodo());
            parametros.Add("@anio_minimo_imputable", aprobadas.AnioMinimoImputable(persona));
            parametros.Add("@fecha_desde", aprobadas.Desde());
            parametros.Add("@fecha_hasta", aprobadas.Hasta());
            parametros.Add("@cantidad_de_dias", aprobadas.CantidadDeDias());

            //Próxima Licencia sin calcular
            //if (permitidas_log.Count > 0)
            //{
            //    parametros.Add("@periodo_", permitidas_log.First().Periodo);
            //    parametros.Add("@cantidad_dias", permitidas_log.First().CantidadDeDias());
            //}

            parametros.Add("@fecha_calculo", fecha_calculo);
            try
            {
                this.conexion.EjecutarSinResultado("LIC_GEN_Ins_LogErroresCalculoLicencias", parametros);
            }
            catch (SqlException sql)
            {
                throw new ErrorLogException("Error al intentar loguear error de calculo de licencias", sql);
            }
            
        }

        public int GetProrrogaPlantaGeneral(int anio)
        {
            ProrrogaLicenciaOrdinaria prorroga_del_anio = new ProrrogaLicenciaOrdinaria();
            prorroga_del_anio.Periodo = anio;
            var prorroga_aplicable = CargarDatos(prorroga_del_anio);

            return prorroga_aplicable.UsufructoHasta - prorroga_aplicable.UsufructoDesde;
        }

        public void LoguearDetalleCalculoLicencia(SolicitudesDeVacaciones aprobadas, int anio, Persona persona, DateTime fecha_calculo, bool ya_imputados, bool error)
        {
            var parametros = new Dictionary<string, object>();

            if (error)
            {
                parametros.Add("@comentario", "Al Actualizar la prórroga dio Error por Exceso de Cantidad de Días permitidos hasta la fecha de la solicitud");
            }
            else
            {
                parametros.Add("@comentario", "");
            }

            //Persona a loguear
            parametros.Add("@apellido", "N/A");
            parametros.Add("@nombre", "N/A");
            parametros.Add("@documento", persona.Documento);

            //Licencia con Conflicto
            parametros.Add("@anio_maximo_imputable", aprobadas.AnioMaximoImputable().First().Periodo());
            parametros.Add("@anio_minimo_imputable", aprobadas.AnioMinimoImputable(persona));
            parametros.Add("@fecha_desde", aprobadas.Desde());
            parametros.Add("@fecha_hasta", aprobadas.Hasta());

            parametros.Add("@anio_imputado", anio);
            if (ya_imputados)
            {
                parametros.Add("@cantidad_de_dias", aprobadas.GetDiasYaImputados());
            }
            else
            {
                parametros.Add("@cantidad_de_dias", aprobadas.CantidadDeDias());
            }

            parametros.Add("@fecha_calculo", fecha_calculo);

            this.conexion.EjecutarSinResultado("LIC_GEN_Ins_LogErroresCalculoLicencias", parametros);


            //if (aprobadas.CantidadDeDias() > vacacionesPermitidas.First().CantidadDeDias())
            //{
            //    parametros.Add("@anio_imputado", vacacionesPermitidas.First().Periodo);
            //    parametros.Add("@cantidad_de_dias", vacacionesPermitidas.First().CantidadDeDias());

            //    this.conexion.EjecutarSinResultado("LIC_GEN_Ins_LogErroresCalculoLicencias", parametros);

            //    parametros.Clear();

            //    parametros.Add("@apellido", "N/A");
            //    parametros.Add("@nombre", "N/A");
            //    parametros.Add("@documento", persona.Documento);
            //    parametros.Add("@anio_maximo_imputable", aprobadas.AnioMaximoImputable().First().Periodo());
            //    parametros.Add("@anio_minimo_imputable", aprobadas.AnioMinimoImputable(persona));
            //    parametros.Add("@fecha_desde", aprobadas.Desde());
            //    parametros.Add("@fecha_hasta", aprobadas.Hasta());
            //    parametros.Add("@anio_imputado", vacacionesPermitidas.Last().Periodo);
            //    parametros.Add("@cantidad_de_dias", aprobadas.CantidadDeDias() - vacacionesPermitidas.First().CantidadDeDias());
            //    parametros.Add("@fecha_calculo", fecha_calculo);
            //    this.conexion.EjecutarSinResultado("LIC_GEN_Ins_LogErroresCalculoLicencias", parametros);

            //}
            //else {
            //    parametros.Add("@anio_imputado", vacacionesPermitidas.First().Periodo);
            //    parametros.Add("@cantidad_de_dias", aprobadas.CantidadDeDias());
            //    this.conexion.EjecutarSinResultado("LIC_GEN_Ins_LogErroresCalculoLicencias", parametros);
            //}

            //Próxima Licencia sin calcular
            //if (permitidas_log.Count > 0)
            //{
            //    parametros.Add("@periodo_", permitidas_log.First().Periodo);
            //    parametros.Add("@cantidad_dias", permitidas_log.First().CantidadDeDias());
            //}




        }

        public TablaDeDatos TablaLogAnalisisLicencia()
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@documento", -1);

            return this.conexion.Ejecutar("LIC_GEN_Get_LogAnalisisLicencia", parametros);
        }

        public TablaDeDatos TablaLogSaldoAnalisisLicencia()
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@documento", -1);

            return this.conexion.Ejecutar("LIC_GEN_Get_LogSaldoLicencia", parametros);
        }

        public void AddToBulkAnalisisLicencias(AnalisisDeLicenciaOrdinaria analisis, int documento, DataTable tabla_log_analisis_licencia)
        {
            var i = 1;
            int last = 0;
            var now = DateTime.Now;
            analisis.lineas.ForEach(l =>
            {
                var row = tabla_log_analisis_licencia.NewRow();
                row["id"] = i++;
                row["documento"] = documento;
                row["cantidad_de_dias_imputables"] = l.CantidadDiasDescontados;

                if (l.PeriodoAutorizado == 0 && last != 0)
                {
                    row["anio_imputado"] = last;
                }
                else
                {
                    row["anio_imputado"] = l.PeriodoAutorizado;
                }

                if (l.LicenciaDesde.Equals(DateTime.MinValue))
                {
                    row["fecha_desde_solicitada"] = DBNull.Value;
                }
                else
                {
                    row["fecha_desde_solicitada"] = l.LicenciaDesde;
                }

                if (l.LicenciaHasta.Equals(DateTime.MinValue))
                {
                    row["fecha_hasta_solicitada"] = DBNull.Value;
                }
                else
                {
                    row["fecha_hasta_solicitada"] = l.LicenciaHasta;
                }

                if (l.PeriodoAutorizado != 0)
                {
                    last = l.PeriodoAutorizado;
                }

                row["fecha_de_calculo"] = now;

                tabla_log_analisis_licencia.Rows.Add((DataRow)row);
            });
        }

        public void BulkInsertTablaAnalisisLicencia(DataTable analisis)
        {
            this.conexion.Bulk(analisis, "LIC_LogAnalisisCalculoLicencia");
        }

        public void AddToBulkSaldosAnalisisLicencias(AnalisisDeLicenciaOrdinaria analisis, int documento, DataTable tabla_log_saldos_analisis_licencia)
        {
            var i = 1;
            analisis.Saldo.ForEach(l =>
            {
                var row = tabla_log_saldos_analisis_licencia.NewRow();
                row["disponible"] = l.Dias;
                row["periodo"] = l.Period;
                row["documento"] = documento;
                tabla_log_saldos_analisis_licencia.Rows.Add((DataRow)row);
            });
        }

        public void BulkInsertTablaSaldosAnalisisLicencia(DataTable analisis)
        {
            this.conexion.Bulk(analisis, "LIC_LogSaldosCalculoLicencia");
        }

        public int GetSegmentosUtilizados(int documento, int anio) {
            
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Nro_Documento", documento);
            parametros.Add("@PeriodoAnual", anio);

            var tablaDatos = this.conexion.Ejecutar("ASIS_GET_PeriodosLic_DelAnio", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                return tablaDatos.Rows.First().GetInt("Periodos");
            }
            else {
                return 0;
            }

        }


        public bool guardarInasistencia(Inasistencia inasistencia, int idUsuario)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idPersona", inasistencia.Persona.Id);
                parametros.Add("@idUsuario", idUsuario);
                parametros.Add("@desde", inasistencia.Desde);
                parametros.Add("@hasta", inasistencia.Hasta);
                parametros.Add("@motivo", inasistencia.Motivo);

                var tablaDatos = this.conexion.Ejecutar("LIC_INS_Ausencias", parametros);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<MotivoBaja> getMotivosAusencias()
        {
            var tablaDatos = this.conexion.Ejecutar("LIC_GET_Motivos_Ausencias");

            List<MotivoBaja> motivos = new List<MotivoBaja>();

            tablaDatos.Rows.ForEach(row =>
            {
                motivos.Add(new MotivoBaja(row.GetInt("id",0), row.GetString("descripcion","")));
            });

            return motivos;
        }
    }
}
