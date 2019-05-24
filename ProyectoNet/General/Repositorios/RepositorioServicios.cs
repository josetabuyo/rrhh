using General.Contrato;
using General.MAU;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace General.Repositorios
{
    public class RepositorioServicios
    {

        public List<Serv_Adm_Publica_Privada> GetExperienciaLaboral_Principal(int documento, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.LEG_GET_ExperienciaLaboral_Principal");
            cn.AsignarParametro("@Documento", documento);

            dr = cn.EjecutarConsulta();

            Serv_Adm_Publica_Privada Servicio;
            List<Serv_Adm_Publica_Privada> listaExperienciaLaboral = new List<Serv_Adm_Publica_Privada>();

            while (dr.Read())
            {
                Servicio = new Serv_Adm_Publica_Privada();
                Servicio.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Servicio.Ambito = new Ambito();
                Servicio.Ambito.Id = dr.GetInt16(dr.GetOrdinal("Id_Ambito"));
                Servicio.Ambito.Descripcion = dr.GetString(dr.GetOrdinal("Ambito"));
                Servicio.Jurisdiccion = dr.GetString(dr.GetOrdinal("Jurisdiccion"));
                Servicio.Folio = dr.GetString(dr.GetOrdinal("Folio"));
                Servicio.Doc_Titular = dr.GetInt32(dr.GetOrdinal("Documento"));
                Servicio.Fecha_Desde = dr.GetDateTime(dr.GetOrdinal("MIN_Fecha_Desde"));
                Servicio.Fecha_Hasta = dr.GetDateTime(dr.GetOrdinal("MAX_Fecha_Hasta"));

                if (!listaExperienciaLaboral.Exists(X=> X.Folio == Servicio.Folio && X.Doc_Titular == Servicio.Doc_Titular && X.Ambito.Id == Servicio.Ambito.Id) )
                {
                    listaExperienciaLaboral.Add(Servicio);
                }
                
                
            }

            
            cn.Desconestar();

            return listaExperienciaLaboral;
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
                    cn.AsignarParametro("@Organismo_3", item.Organismo); //  [varchar](50),    
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

                    if ((bool?)AdmPublicaPrivada.Ctr_Cert == null)
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
