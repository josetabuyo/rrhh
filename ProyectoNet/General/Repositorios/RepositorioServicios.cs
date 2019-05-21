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



    }
}
