using System;
using System.Collections.Generic;

using System.Text;
using General;
using General.Repositorios;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioLicencias : RepositorioLazy<List<VacacionesPermitidas>>, General.Repositorios.IRepositorioLicencia
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioLicencias(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
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

            var tablaDatos = conexion_bd.Ejecutar("dbo.GEN_LIC_GetDiasPermitidos");

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

        public List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            var parametros = new Dictionary<string, object>();

            if (persona != null)
                parametros.Add("@nro_documento", persona.Documento);
            if (periodo != null)
                parametros.Add("@periodo", periodo.anio);
            if (licencia != null)
                parametros.Add("@id_concepto_licencia", licencia.Concepto);


            var tablaDatos = conexion_bd.Ejecutar("dbo.GEN_LIC_GetDiasPermitidos", parametros);

            return ConstruirVacacionesPermitidas(tablaDatos);
           
        }

        public List<VacacionesAprobadas> GetVacacionesAprobadasPara(Persona persona, Periodo periodo, Licencia licencia)
        {
            var parametros = new Dictionary<string, object>();

           
                parametros.Add("@nro_documento", persona.Documento);

                parametros.Add("@periodo", periodo.anio);
           
                parametros.Add("@id_concepto_licencia", licencia.Concepto);


            var tablaDatos = conexion_bd.Ejecutar("dbo.GEN_LIC_GetDiasAprobados", parametros);

            return ConstruirVacacionesAprobadas(tablaDatos);

        }

        protected List<VacacionesAprobadas> ConstruirVacacionesAprobadas(TablaDeDatos tablaDatos)
        {
            throw new NotImplementedException();
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

                Periodo periodo = new Periodo();


              
                
                periodo.anio = row.GetSmallintAsInt("Periodo");

                int dias = row.GetSmallintAsInt("Dias_Autorizados");
                int concepto = row.GetSmallintAsInt("Id_Concepto_Licencia");

                VacacionesPermitidas vacaciones = new VacacionesPermitidas(persona, periodo, dias, concepto);

                vacaciones_permitidas.Add(vacaciones);
            });

            return vacaciones_permitidas;
        }



        public List<VacacionesPermitidas> GetVacacionPermitidaPara(Persona persona)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@nro_documento", persona.Documento);

            var tablaDatos = conexion_bd.Ejecutar("dbo.GEN_LIC_GetDiasAprobados", parametros);

            return ConstruirVacacionesPermitidas(tablaDatos);


        }
    }
}
