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

    }
}
