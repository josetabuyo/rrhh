using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using General.Contrato;
using System.Data.SqlClient;
using General.MAU;

namespace General
{
    public class RepositorioServicios
    {

        public List<Serv_Adm_Publica_Privada> GetServicios_Adm_Publica_Principal(int documento, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.LEG_GET_Servicios_Adm_Publica_Principal");
            cn.AsignarParametro("@Documento", documento);

            dr = cn.EjecutarConsulta();

            Serv_Adm_Publica_Privada Servicio;
            List<Serv_Adm_Publica_Privada> listaServAdmPubica = new List<Serv_Adm_Publica_Privada>();

            while (dr.Read())
            {
                Servicio = new Serv_Adm_Publica_Privada();
                Servicio.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Servicio.Ambito = new Ambito();
                Servicio.Ambito.Descripcion = dr.GetString(dr.GetOrdinal("Ambito"));
                Servicio.Jurisdiccion = dr.GetString(dr.GetOrdinal("Jurisdiccion"));
                Servicio.Folio = dr.GetString(dr.GetOrdinal("Folio"));
                Servicio.Caja = dr.GetString(dr.GetOrdinal("Caja"));
                Servicio.Afiliado = dr.GetString(dr.GetOrdinal("Afiliado"));
                
                listaServAdmPubica.Add(Servicio);
            }

            cn.Desconestar();

            return listaServAdmPubica;
        }


        public List<Serv_Adm_Publica_Privada> GetServicios_Adm_Privada_Principal(int documento, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.LEG_GET_Servicios_Adm_Privada_Principal");
            cn.AsignarParametro("@Documento", documento);

            dr = cn.EjecutarConsulta();

            Serv_Adm_Publica_Privada Servicio;
            List<Serv_Adm_Publica_Privada> listaServAdmPubica = new List<Serv_Adm_Publica_Privada>();

            while (dr.Read())
            {
                Servicio = new Serv_Adm_Publica_Privada();
                Servicio.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Servicio.Ambito = new Ambito();
                Servicio.Ambito.Descripcion = dr.GetString(dr.GetOrdinal("Ambito"));
                Servicio.Organismo = dr.GetString(dr.GetOrdinal("Institucion"));
                Servicio.Folio = dr.GetString(dr.GetOrdinal("Folio"));
                Servicio.Caja = dr.GetString(dr.GetOrdinal("Caja"));
                Servicio.Afiliado = dr.GetString(dr.GetOrdinal("Afiliado"));

                listaServAdmPubica.Add(Servicio);
            }

            cn.Desconestar();

            return listaServAdmPubica;
        }



        public List<Serv_Adm_Publica_Privada> GetOtrosServicios(int documento, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.LEG_GET_Otros_Servicios");
            cn.AsignarParametro("@Legajo", documento); //el @Legajo es el documento en el SP

            dr = cn.EjecutarConsulta();

            Serv_Adm_Publica_Privada Servicio;
            List<Serv_Adm_Publica_Privada> listaOtrosServicios = new List<Serv_Adm_Publica_Privada>();

            while (dr.Read())
            {
                Servicio = new Serv_Adm_Publica_Privada();
                Servicio.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Servicio.Organismo = dr.GetString(dr.GetOrdinal("Institucion"));
                Servicio.Domicilio = dr.GetString(dr.GetOrdinal("Domicilio"));
                Servicio.Cargo = new Cargo();
                Servicio.Cargo.Id = dr.GetInt16(dr.GetOrdinal("Cargo"));
                Servicio.Remunerativo = dr.GetBoolean(dr.GetOrdinal("Remun"));
                Servicio.Fecha_Desde = dr.GetDateTime(dr.GetOrdinal("Fecha_Desde"));
                Servicio.Fecha_Hasta = dr.GetDateTime(dr.GetOrdinal("Fecha_Hasta"));
                Servicio.Causa_Egreso = dr.GetString(dr.GetOrdinal("Causa_Egreso"));
                Servicio.Caja = dr.GetString(dr.GetOrdinal("Caja"));
                Servicio.Afiliado = dr.GetString(dr.GetOrdinal("Afiliado"));
                Servicio.Folio = dr.GetString(dr.GetOrdinal("Folio"));
                Servicio.DatoDeBaja = dr.GetBoolean(dr.GetOrdinal("datodebaja"));
                //Servicio.datonoimprime = dr.GetBoolean(dr.GetOrdinal("datonoimprime"));

                listaOtrosServicios.Add(Servicio);
            }

            cn.Desconestar();

            return listaOtrosServicios;
        }


        public List<GeneralCombos> GetAmbitos()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.TG_Tabla_Ambitos_Antiguedad");
            
            dr = cn.EjecutarConsulta();

            GeneralCombos ambitos;
            List<GeneralCombos> listaAmbitos = new List<GeneralCombos>();

            while (dr.Read())
            {
                ambitos = new GeneralCombos();
                ambitos.id = dr.GetInt16(dr.GetOrdinal("Id"));
                ambitos.descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));

                listaAmbitos.Add(ambitos);
            }

            cn.Desconestar();
            return listaAmbitos;
        }

        public List<GeneralCombos> GetCargos()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.TG_Tabla_Funciones_Cargos");

            dr = cn.EjecutarConsulta();

            GeneralCombos cargo;
            List<GeneralCombos> listaCargos = new List<GeneralCombos>();

            while (dr.Read())
            {
                cargo = new GeneralCombos();
                cargo.id = dr.GetInt16(dr.GetOrdinal("Id"));
                cargo.descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));

                listaCargos.Add(cargo);
            }

            cn.Desconestar();
            return listaCargos;
        }


        public List<Serv_Adm_Publica_Privada> GET_Servicios_Adm_Publica_Detalles(int legajo, string folio, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.LEG_GET_Servicios_Adm_Publica_Detalles");
            cn.AsignarParametro("@Id_interna", legajo);
            cn.AsignarParametro("@Folio", folio);

            dr = cn.EjecutarConsulta();

            Serv_Adm_Publica_Privada Servicio;
            List<Serv_Adm_Publica_Privada> listaServAdmPubica = new List<Serv_Adm_Publica_Privada>();

            while (dr.Read())
            {
                Servicio = new Serv_Adm_Publica_Privada();
                Servicio.Id = dr.GetInt32(dr.GetOrdinal("id_adm_publica"));
                Servicio.Ambito = new Ambito();
                Servicio.Ambito.Id = dr.GetInt16(dr.GetOrdinal("ambito"));
                Servicio.Jurisdiccion = dr.GetString(dr.GetOrdinal("jurisdiccion"));
                Servicio.Organismo = dr.GetString(dr.GetOrdinal("organismo"));
                Servicio.Cargo = new Cargo();
                Servicio.Cargo.Id = dr.GetInt16(dr.GetOrdinal("Id_Cargo"));
                Servicio.Cargo.Descripcion = dr.GetString(dr.GetOrdinal("cargo"));
                Servicio.Remunerativo = dr.GetBoolean(dr.GetOrdinal("remunerativo"));
                Servicio.Fecha_Desde = dr.GetDateTime(dr.GetOrdinal("fecha_desde"));
                Servicio.Fecha_Hasta = dr.GetDateTime(dr.GetOrdinal("fecha_hasta"));
                Servicio.Causa_Egreso = dr.GetString(dr.GetOrdinal("causa_egreso"));
                Servicio.Folio = dr.GetString(dr.GetOrdinal("folio"));
                Servicio.Id_Interna = dr.GetInt32(dr.GetOrdinal("id_interna"));
                Servicio.Doc_Titular = dr.GetInt32(dr.GetOrdinal("Doc_Titular"));
                Servicio.Caja = dr.GetString(dr.GetOrdinal("caja"));
                Servicio.Afiliado = dr.GetString(dr.GetOrdinal("afiliado"));
                Servicio.DatoDeBaja = dr.GetBoolean(dr.GetOrdinal("datodebaja"));
                //Servicio.datonoimprime = dr.GetBoolean(dr.GetOrdinal("datonoimprime"));
                if (dr.IsDBNull(dr.GetOrdinal("Ctr_Cert")))
                    Servicio.Ctr_Cert = null;
                else
                    Servicio.Ctr_Cert = dr.GetBoolean(dr.GetOrdinal("Ctr_Cert"));

                if (dr.IsDBNull(dr.GetOrdinal("Usuario")))
                    Servicio.Usuario = 0;
                else
                    Servicio.Usuario = dr.GetInt16(dr.GetOrdinal("Usuario"));

                if (dr.IsDBNull(dr.GetOrdinal("Fecha_Carga")))
                    Servicio.Fecha_Carga = null;
                else
                    Servicio.Fecha_Carga = dr.GetDateTime(dr.GetOrdinal("Fecha_Carga"));

                Servicio.Domicilio = dr.GetString(dr.GetOrdinal("Domicilio"));

                listaServAdmPubica.Add(Servicio);
            }

            cn.Desconestar();

            return listaServAdmPubica;
        }


        public List<Serv_Adm_Publica_Privada> GET_Servicios_Adm_Privada_Detalles(int legajo, string folio, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.LEG_GET_Servicios_Adm_Privada_Detalles");
            cn.AsignarParametro("@Id_interna", legajo);
            cn.AsignarParametro("@Folio", folio);

            dr = cn.EjecutarConsulta();

            Serv_Adm_Publica_Privada Servicio;
            List<Serv_Adm_Publica_Privada> listaServAdmPrivada = new List<Serv_Adm_Publica_Privada>();

            while (dr.Read())
            {
                Servicio = new Serv_Adm_Publica_Privada();
                Servicio.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Servicio.Ambito = new Ambito();
                Servicio.Ambito.Id = dr.GetInt16(dr.GetOrdinal("ambito"));
                Servicio.Organismo = dr.GetString(dr.GetOrdinal("institucion"));
                Servicio.Cargo = new Cargo();
                Servicio.Cargo.Id = dr.GetInt16(dr.GetOrdinal("Id_Cargo"));
                Servicio.Cargo.Descripcion = dr.GetString(dr.GetOrdinal("cargo"));
                Servicio.Remunerativo = dr.GetBoolean(dr.GetOrdinal("remunerativo"));
                Servicio.Fecha_Desde = dr.GetDateTime(dr.GetOrdinal("fecha_desde"));
                Servicio.Fecha_Hasta = dr.GetDateTime(dr.GetOrdinal("fecha_hasta"));
                Servicio.Causa_Egreso = dr.GetString(dr.GetOrdinal("causa_egreso"));
                Servicio.Folio = dr.GetString(dr.GetOrdinal("folio"));
                Servicio.Id_Interna = dr.GetInt32(dr.GetOrdinal("id_interna"));
                Servicio.Doc_Titular = dr.GetInt32(dr.GetOrdinal("documento"));
                Servicio.Caja = dr.GetString(dr.GetOrdinal("caja"));
                Servicio.Afiliado = dr.GetString(dr.GetOrdinal("afiliado"));
                Servicio.DatoDeBaja = dr.GetBoolean(dr.GetOrdinal("datodebaja"));
                //Servicio.datonoimprime = dr.GetBoolean(dr.GetOrdinal("datonoimprime"));
                if (dr.IsDBNull(dr.GetOrdinal("Ctr_Cert")))
                    Servicio.Ctr_Cert = null;
                else
                    Servicio.Ctr_Cert = dr.GetBoolean(dr.GetOrdinal("Ctr_Cert"));

                if (dr.IsDBNull(dr.GetOrdinal("Usuario")))
                    Servicio.Usuario = 0;
                else
                    Servicio.Usuario = dr.GetInt16(dr.GetOrdinal("Usuario"));

                if (dr.IsDBNull(dr.GetOrdinal("Fecha_Carga")))
                    Servicio.Fecha_Carga = null;
                else
                    Servicio.Fecha_Carga = dr.GetDateTime(dr.GetOrdinal("Fecha_Carga"));

                Servicio.Domicilio = dr.GetString(dr.GetOrdinal("Domicilio"));

                listaServAdmPrivada.Add(Servicio);
            }

            cn.Desconestar();

            return listaServAdmPrivada;
        }


        public bool Alta_Servicios_Adm_Publica(Serv_Adm_Publica_Privada[] servicio, Serv_Adm_Publica_Privada AdmPublicaPrivada, Usuario usuario)
        {
            ConexionDB cn = new ConexionDB("dbo.LEG_DEL_Servicios_Adm_Publica");
            cn.AsignarParametro("@Id_Interna", AdmPublicaPrivada.Id_Interna);
            cn.AsignarParametro("@Folio", AdmPublicaPrivada.Folio);

            cn.BeginTransaction();

            try
            {
                cn.EjecutarSinResultado();

                foreach (var item in servicio)
                {
                   cn.CrearComandoConTransaccionIniciada("dbo.LEG_ADD_Servicios_Adm_Publica");
                   cn.AsignarParametro("@Ambito_1", AdmPublicaPrivada.Ambito.Id); //  smallint,    
                   cn.AsignarParametro("@Jurisdiccion_2", AdmPublicaPrivada.Jurisdiccion); //  [varchar](50),    
                   cn.AsignarParametro("@Organismo_3",item.Organismo); //  [varchar](50),    
                   cn.AsignarParametro("@Cargo_4", item.Cargo.Id); //  smallint,    
                   cn.AsignarParametro("@Remunerativo_5", AdmPublicaPrivada.Remunerativo); //  bit,    
                   cn.AsignarParametro("@Fecha_Desde_6", item.Fecha_Desde); //  [datetime],    
                   cn.AsignarParametro("@Fecha_Hasta_7", item.Fecha_Hasta); //  [datetime],    
                   cn.AsignarParametro("@Causa_Egreso_8", AdmPublicaPrivada.Causa_Egreso); //  [varchar](100),    
                   cn.AsignarParametro("@Folio_9", AdmPublicaPrivada.Folio); //  [char](10),    
                   cn.AsignarParametro("@Id_Interna_10", AdmPublicaPrivada.Id_Interna); //  [int],    
                   cn.AsignarParametro("@doc_tit_11", AdmPublicaPrivada.Doc_Titular); //   [int] ,    
                   cn.AsignarParametro("@Caja_12", AdmPublicaPrivada.Caja); //  [varchar](50),     
                   cn.AsignarParametro("@Afiliado_13", AdmPublicaPrivada.Afiliado); //  [varchar](50),    
                   //cn.AsignarParametro("@datonoimprime", servicio[servicio.Length - 1].datonoimprime); // bit,    

                   if ((bool?)AdmPublicaPrivada.Ctr_Cert == null)
                   {
                       cn.AsignarParametro("@Ctr_Cert", null); // bit =null, 
                   }
                   else
                   {
                       cn.AsignarParametro("@Ctr_Cert", (bool)AdmPublicaPrivada.Ctr_Cert); // bit =null, 
                   }

                   cn.AsignarParametro("@Usuario", AdmPublicaPrivada.Usuario); // smallint
                   cn.AsignarParametro("@Domicilio", item.Domicilio);
                   cn.EjecutarSinResultado();
                }
            }
            catch (Exception e)
            {
                cn.RollbackTransaction();
                return false;
            }

            cn.CommitTransaction();
            cn.Desconestar();

            return true;

        }


        public bool Alta_Servicios_Adm_Privada(Serv_Adm_Publica_Privada[] servicio, Serv_Adm_Publica_Privada AdmPublicaPrivada, Usuario usuario)
        {
            ConexionDB cn = new ConexionDB("dbo.LEG_DEL_Servicios_Adm_Privada");
            cn.AsignarParametro("@Id_Interna", AdmPublicaPrivada.Id_Interna);
            cn.AsignarParametro("@Folio", AdmPublicaPrivada.Folio);

            cn.BeginTransaction();

            try
            {
                cn.EjecutarSinResultado();

                foreach (var item in servicio)
                {
                    cn.CrearComandoConTransaccionIniciada("dbo.LEG_ADD_Otros_Servicios");
                    cn.AsignarParametro("@Ambito", AdmPublicaPrivada.Ambito.Id); //  smallint,    
                    cn.AsignarParametro("@Institución_1", item.Organismo); //  [varchar](50),    
                    cn.AsignarParametro("@Cargo_3", item.Cargo.Id); //  smallint,    
                    cn.AsignarParametro("@Remun_4", AdmPublicaPrivada.Remunerativo); //  bit,    
                    cn.AsignarParametro("@Fecha_Desde_5", item.Fecha_Desde); //  [datetime],    
                    cn.AsignarParametro("@Fecha_Hasta_6", item.Fecha_Hasta); //  [datetime],    
                    cn.AsignarParametro("@Causa_Egreso_7", AdmPublicaPrivada.Causa_Egreso); //  [varchar](100),    
                    cn.AsignarParametro("@Folio_10", AdmPublicaPrivada.Folio); //  [char](10),    
                    cn.AsignarParametro("@Id_Interna_8", AdmPublicaPrivada.Id_Interna); //  [int],    
                    cn.AsignarParametro("@documento", AdmPublicaPrivada.Doc_Titular); //   [int] ,    
                    cn.AsignarParametro("@Caja", AdmPublicaPrivada.Caja); //  [varchar](50),     
                    cn.AsignarParametro("@afiliado", AdmPublicaPrivada.Afiliado); //  [varchar](50),    
                    cn.AsignarParametro("@Datodebaja", AdmPublicaPrivada.DatoDeBaja); // bit,    

                    if ((bool?) AdmPublicaPrivada.Ctr_Cert == null)
                    {
                        cn.AsignarParametro("@Ctr_Cert", null); // bit =null, 
                    }
                    else
                    {
                        cn.AsignarParametro("@Ctr_Cert", (bool)AdmPublicaPrivada.Ctr_Cert); // bit =null, 
                    }

                    cn.AsignarParametro("@Usuario", AdmPublicaPrivada.Usuario); // smallint
                    cn.AsignarParametro("@Domicilio_2", item.Domicilio);
                    cn.EjecutarSinResultado();
                }
            }
            catch (Exception e)
            {
                cn.RollbackTransaction();
                return false;
            }

            cn.CommitTransaction();
            cn.Desconestar();

            return true;

        }

        



    }
}

