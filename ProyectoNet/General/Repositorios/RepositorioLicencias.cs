using System;
using System.Collections.Generic;

using System.Text;
using General;
using General.Repositorios;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioLicencias
    {
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
    }
}
