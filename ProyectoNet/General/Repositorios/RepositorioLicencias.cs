using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using System.Data.SqlClient;

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
                if (dr.GetString(dr.GetOrdinal("Aprobada"))== "Aprobada")
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
            //List<Persona> personas, List<Periodo> periodos

            //var parametros = new Dictionary<string, object>();
            //parametros.Add("@documento", evaluacion.Alumno.Id);
            //parametros.Add("@periodo", evaluacion.Curso.Id);
            //parametros.Add("@id_concepto_licencia", 1);
            //List<VacacionesPermitidas> vacaciones_permitidas = new List<VacacionesPermitidas>();

            var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPermitidos");

            return ConstruirVacacionesPermitidas(tablaDatos);

            //tablaDatos.Rows.ForEach(row =>
            //{
            //    Persona persona = new Persona();
            //    persona.Documento = row.GetInt("NroDocumento");
            //    persona.Apellido = row.GetString("Apellido");
            //    persona.Nombre = row.GetString("Nombre");

            //    Periodo periodo = new Periodo();
            //    periodo.anio = row.GetSmallintAsInt("Periodo");

            //    int dias = row.GetSmallintAsInt("Dias_Autorizados");
            //    int concepto = row.GetSmallintAsInt("Id_Concepto_Licencia");

            //    VacacionesPermitidas vacaciones = new VacacionesPermitidas(persona, periodo, dias, concepto);

            //    vacaciones_permitidas.Add(vacaciones);
            //});

           // return vacaciones_permitidas;
        }

        
        public List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona)
        {
            var parametros = new Dictionary<string, object>();

           
                parametros.Add("@nro_documento", persona.Documento);

                //parametros.Add("@periodo", periodo.anio);
           
                //parametros.Add("@id_concepto_licencia", licencia.Concepto);


                var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasAprobados", parametros);

            return ConstruirVacacionesAprobadas(tablaDatos);

        }


        public List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona, ConceptoDeLicencia concepto)
        {
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


        public List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            var parametros = new Dictionary<string, object>();
                parametros.Add("@nro_documento", persona.Documento);
                parametros.Add("@periodo", periodo.anio);
                parametros.Add("@id_concepto_licencia", licencia.Concepto.Id);


                var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPermitidos", parametros);

            return ConstruirVacacionesPermitidas(tablaDatos);

        }

        public List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, ConceptoDeLicencia concepto)
        {
            var parametros = new Dictionary<string, object>();
                parametros.Add("@nro_documento", persona.Documento);
                parametros.Add("@id_concepto_licencia", concepto.Id);

                var tablaDatos = this.conexion.Ejecutar("dbo.LIC_GEN_GetDiasPermitidos", parametros);

            return ConstruirVacacionesPermitidas(tablaDatos);


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


        public List<VacacionesPendientesDeAprobacion> GetVacacionesPendientesPara(Persona persona, ConceptoDeLicencia concepto)
        {
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
                        Area area = new Area();
                        Persona persona_con_pase = new Persona();
                        persona_con_pase.Apellido = persona.Apellido;
                        persona_con_pase.Nombre = persona.Nombre;
                        persona_con_pase.Documento = persona.Documento;
                        area.Nombre = row.GetString("descripcion");
                        pase.Fecha = row.GetDateTime("fecha_solicitud");
                        pase.Estado = determinarEstado(row.GetSmallintAsInt("estado"));
                        pase.AreaDestino = area;
                        persona_con_pase.PasePendiente = pase;
                        personas_con_pases.Add(persona_con_pase);
                    });
                }
            }

            return personas_con_pases;
        }

        private string determinarEstado(int estado)
        {
            if (estado == 0){return "Pendiente";}else if(estado == 1){return "Aprobado";}else{return "Rechazado";}
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

        public ProrrogaLicenciaOrdinaria CargarDatos(ProrrogaLicenciaOrdinaria unaProrroga)
        {
            unaProrroga.Periodo = DateTime.Today.Year;

            ConexionDB cn = new ConexionDB("dbo.WEB_GetProrrogaOrdinaria");
            cn.AsignarParametro("@periodo", unaProrroga.Periodo);

            SqlDataReader dr;
            dr = cn.EjecutarConsulta();

            if (dr.Read())
            {
                unaProrroga.UsufructoDesde = dr.GetInt16(dr.GetOrdinal("Prorroga_Desde"));
                unaProrroga.UsufructoHasta = dr.GetInt16(dr.GetOrdinal("Prorroga_Hasta"));
            }
            else
            {
                unaProrroga = null;
            }
            return unaProrroga;
        }

    }
}
