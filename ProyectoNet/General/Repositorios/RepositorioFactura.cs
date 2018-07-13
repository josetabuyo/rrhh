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


        public bool ValidarFacturaIngresada(int documento, string nroFactura, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.CTR_GET_Controla_Factura_Cargado");
            cn.AsignarParametro("@doc", documento);
            cn.AsignarParametro("@nro_fact", nroFactura);

            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                cn.Desconestar();
                return true;
            }

            cn.Desconestar();
            return false;
        }




        public bool GuardarFactura(int documento, DateTime FechaPase, DateTime FechaFactura, string NroFactura, DateTime FechaRecibida, decimal MontoAFactura, int idarea, int DocumentoFirmanteSeleccionado, Factura[] lista, Usuario usuario)
        {
            ConexionDB cn = new ConexionDB("dbo.CTR_GET_Maxid_Factura");

            cn.BeginTransaction();

            try
            {
                
                //dr = cn.EjecutarConsulta();
                //int Max_IdFactura = 0;
                //while (dr.Read())
                //{
                //    Max_IdFactura = dr.GetInt32(dr.GetOrdinal("id_factura"));
                //}

                int Max_IdFactura = 0;
                Max_IdFactura = (int)cn.EjecutarEscalar();

                if (Max_IdFactura == 0)
                {
                    cn.RollbackTransaction();
                    return false;
                }

            
                //INICIO TRANSACCION
                cn.CrearComandoConTransaccionIniciada("dbo.CTR_ADD_Facturas");
                cn.AsignarParametro("@doc", documento);
                cn.AsignarParametro("@Fecha_factura", FechaFactura);
                cn.AsignarParametro("@Nro_factura", NroFactura);
                cn.AsignarParametro("@Fecha_recibida", FechaRecibida);
                cn.AsignarParametro("@monto", MontoAFactura);
                cn.AsignarParametro("@area", idarea);
                cn.AsignarParametro("@Docfirmante", DocumentoFirmanteSeleccionado);
                cn.AsignarParametro("@Fecha_pase", FechaPase);
                cn.EjecutarSinResultado();


                foreach (var item in lista)
                {
                    if (item.estaSeleccionado)
	                {
                        cn.CrearComandoConTransaccionIniciada("dbo.CTR_ADD_Facturas_Detalle");
                        cn.AsignarParametro("@Id_Factura_1", Max_IdFactura + 1); //la cabecera tiene adentro el +1
                        cn.AsignarParametro("@Mes_Factura_2", item.Mes);
                        cn.AsignarParametro("@Año_Factura_3", item.Año);
                        cn.AsignarParametro("@Monto_Factura_4", item.Monto_A_Factura);
                        cn.AsignarParametro("@Id_Contrato", item.Id_Contrato);
                        cn.EjecutarSinResultado();
	                }
                }
            }
            catch (Exception exp)
            {
                cn.RollbackTransaction();
                throw;
            }

            cn.CommitTransaction();
            cn.Desconestar();

            return true;

        }
    }
}
