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
                Servicio.Institucion = dr.GetString(dr.GetOrdinal("Institucion"));
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
                Servicio.datonoimprime = dr.GetBoolean(dr.GetOrdinal("datonoimprime"));

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
                //Servicio.Doc_Titular = dr.GetInt32(dr.GetOrdinal("Doc_Titular"));
                Servicio.Caja = dr.GetString(dr.GetOrdinal("caja"));
                Servicio.Afiliado = dr.GetString(dr.GetOrdinal("afiliado"));
                Servicio.DatoDeBaja = dr.GetBoolean(dr.GetOrdinal("datodebaja"));
                Servicio.datonoimprime = dr.GetBoolean(dr.GetOrdinal("datonoimprime"));
                Servicio.Ctr_Cert = dr.GetBoolean(dr.GetOrdinal("ctr_cert"));
                //Servicio.Usuario = dr.GetInt16(dr.GetOrdinal("Usuario"));
                //Servicio.Fecha_Carga = dr.GetDateTime(dr.GetOrdinal("Fecha_Carga"));
                

                listaServAdmPubica.Add(Servicio);
            }

            cn.Desconestar();

            return listaServAdmPubica;
        }





    }
}

