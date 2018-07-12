using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Facturas;
using General.MAU;
using System.Data.SqlClient;

using General.Repositorios;
using General;


namespace General.Repositorios
{
    public class RepositorioFactura
    {

        public List<Factura> GetFacturasConSaldo(int documento, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.CTR_GET_Saldo_Factura");
            cn.AsignarParametro("@doc", documento);
            
            dr = cn.EjecutarConsulta();

            Factura factura;
            List<Factura> listaFacturas = new List<Factura>();

            while (dr.Read())
            {
                factura = new Factura();
                factura.Mes = dr.GetInt32(dr.GetOrdinal("Mes_Cont"));
                factura.Año = dr.GetInt32(dr.GetOrdinal("Año_Cont"));

                factura.Monto_Contrato = dr.GetDecimal(dr.GetOrdinal("Monto_Cont"));
                factura.Monto_Otras_Factura = dr.GetDecimal(dr.GetOrdinal("Monto_Factura"));
                factura.Monto_A_Factura = 0;
                factura.Saldo = dr.GetDecimal(dr.GetOrdinal("saldo_mes"));

                factura.Id_Contrato = dr.GetInt32(dr.GetOrdinal("Id_Contrato"));
                factura.Nro_Documento = documento;
                factura.Nro_Contrato = dr.GetString(dr.GetOrdinal("nro_contrato"));

                factura.Acto_Tipo = dr.GetString(dr.GetOrdinal("acto_tipo")).ToString();
                factura.Acto_Nro = dr.GetString(dr.GetOrdinal("acto_nro")).ToString();

                listaFacturas.Add(factura);
            }

            cn.Desconestar();

            return listaFacturas;

        }

        public List<Persona> GetFirmantes()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.GABM_Tabla_Firmantes");
            cn.AsignarParametro("@Operacion", "S");

            dr = cn.EjecutarConsulta();

            Persona persona;
            List<Persona> listaFirmante = new List<Persona>();

            while (dr.Read())
            {
                persona = new Persona();
                persona.Documento = dr.GetInt32(dr.GetOrdinal("Documento"));
                persona.Nombre = dr.GetString(dr.GetOrdinal("Apellido")).ToString();
                persona.Categoria = dr.GetString(dr.GetOrdinal("FirmaFacturas")).ToString();

                listaFirmante.Add(persona);
            }

            return listaFirmante;

        }


        public string ValidarFacturaIngresada(int documento, string nroFactura, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.CTR_GET_Controla_Factura_Cargado");
            cn.AsignarParametro("@doc", documento);
            cn.AsignarParametro("@nro_fact", nroFactura);

            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                return "1";
            }

            return "";
        }



        
        public void GuardarFactura(int documento, DateTime FechaPase, DateTime FechaFactura, string NroFactura, DateTime FechaRecibida, decimal MontoAFactura, int idarea, int DocumentoFirmanteSeleccionado, Factura[] lista, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.CTR_GET_Maxid_Factura");
            dr = cn.EjecutarConsulta();
            int Max_IdFactura = 0;
            while (dr.Read())
            {
                Max_IdFactura = dr.GetInt32(dr.GetOrdinal("id_factura"));
            }


           
            /*
            //INICIO TRANSACCION
            cn.BeginTransaction();

            try
            {
                cn = new ConexionDB("dbo.CTR_ADD_Facturas");
                cn.AsignarParametro("@doc", documento);
                cn.AsignarParametro("@Fecha_factura", FechaFactura);
                cn.AsignarParametro("@Nro_factura", NroFactura);
                cn.AsignarParametro("@Fecha_recibida", FechaRecibida);
                cn.AsignarParametro("@monto", MontoAFactura);
                cn.AsignarParametro("@area", idarea);
                cn.AsignarParametro("@firma", DocumentoFirmanteSeleccionado);
                cn.AsignarParametro("@Fecha_pase", FechaPase);
                dr = cn.EjecutarConsulta();


                //// REVISAR CALCULO ///
                decimal saldo_factura = 0;
                decimal monto_factura = 0;
                decimal saldo_a_pagar = 0;

                foreach (var item in lista)
                {
                    if (item.Saldo >= MontoFactura)
                    {
                        saldo_factura = MontoFactura - item.Saldo;
                    }


                    cn = new ConexionDB("dbo.CTR_ADD_Facturas_Detalle");
                    cn.AsignarParametro("@Id_Factura_1", Max_IdFactura);
                    cn.AsignarParametro("@Mes_Factura_2", FechaFactura.Month);
                    cn.AsignarParametro("@Año_Factura_3", FechaFactura.Year);
                    cn.AsignarParametro("@Monto_Factura_4", saldo_a_pagar);
                    cn.AsignarParametro("@Id_Contrato", item.Id_Contrato);
                    dr = cn.EjecutarConsulta();
                }
                //// REVISAR CALCULO ///

            }
            catch (Exception)
            {
                cn.RollbackTransaction();
                throw;
            }

            cn.CommitTransaction();
            cn.Desconestar();

            */
           




        }
    }
}
