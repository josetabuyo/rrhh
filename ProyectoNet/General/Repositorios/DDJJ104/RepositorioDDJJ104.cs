using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using General.Repositorios;
using General.MAU;

namespace General
{
    //Estados
    //1. Generar
    //2. Imprimir
    //3. ReImprimir

    public class RepositorioDDJJ104
    {

        public int GetEstadoDDJJ(DDJJ104 ddjj)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PLA_GET_DDJJ104");
            cn.AsignarParametro("@Id_Area", ddjj.Area.Id);
            cn.AsignarParametro("@Mes", ddjj.Mes);
            cn.AsignarParametro("@Año", ddjj.Anio);

            dr = cn.EjecutarConsulta();

            int estado = 1;

            if (dr.Read())
            {
                estado = dr.GetInt16(dr.GetOrdinal("Estado"));
            }

            cn.Desconestar();

            return estado;
        }


        public bool GenerarDDJJ104(Usuario usuario, List<DDJJ104> ddjj)
        {
            ConexionDB cn = new ConexionDB("dbo.PLA_ADD_DDJJ104_Cabecera");
            cn.AsignarParametro("@Id_Area", ddjj.First().Area.Id);
            cn.AsignarParametro("@Mes", ddjj.First().Mes);
            cn.AsignarParametro("@Año", ddjj.First().Anio);
            cn.AsignarParametro("@Usuario_Generacion", usuario.Id);

            //INICIO TRANSACCION
            cn.BeginTransaction();

            int id_ddjj_nuevo = 0;
            try
            {
                id_ddjj_nuevo = (int)cn.EjecutarEscalar();

                if (id_ddjj_nuevo > 0)
                {
                    int orden = 1;
                    foreach (var personas in ddjj.First().Area.Personas)
                    {

                        string[] Cat_Mod = personas.Categoria.ToString().Split('#');

                        cn.CrearComandoConTransaccionIniciada("dbo.PLA_ADD_DDJJ104_Detalle");
                        cn.AsignarParametro("@Id_DDJJ", id_ddjj_nuevo);
                        cn.AsignarParametro("@Id_Persona", personas.Id);
                        cn.AsignarParametro("@Orden", orden);
                        //cn.AsignarParametro("@Id_Area_Persona", personas.Area.Id);
                        cn.AsignarParametro("@Id_Area_Persona", ddjj.First().Area.Id);
                        cn.AsignarParametro("@Mod_Contratacion", Cat_Mod[1].Trim());
                        cn.AsignarParametro("@Categoria", Cat_Mod[0].Trim());

                        cn.EjecutarSinResultado();

                        orden++;
                    }
                }

            }
            catch (Exception e)
            {
                cn.RollbackTransaction();
                throw;
            }

            cn.CommitTransaction();
            cn.Desconestar();

            return true;

        }



        public List<DDJJ104> ImprimirDDJJ104(List<DDJJ104> ddjj)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PLA_GET_DDJJ104");
            cn.AsignarParametro("@Id_Area", ddjj.First().Area.Id);
            cn.AsignarParametro("@Mes", ddjj.First().Mes);
            cn.AsignarParametro("@Año", ddjj.First().Anio);

            dr = cn.EjecutarConsulta();

            DDJJ104 ddjj104;
            List<DDJJ104> listaddjj104 = new List<DDJJ104>();

            while (dr.Read())
            {
                ddjj104 = new DDJJ104();

                ddjj104.Area = new Area() { Id = dr.GetInt32(dr.GetOrdinal("Id_Area")), Nombre = dr.GetString(dr.GetOrdinal("Area")), Direccion = dr.GetString(dr.GetOrdinal("Direccion")), Dependencias = new List<Area>() { new Area() { Nombre = dr.GetString(dr.GetOrdinal("Dependencia")) }} };
                ddjj104.Agente = new Persona()
                {
                    Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                    Cuit = dr.GetString(dr.GetOrdinal("Cuil_Nro")),
                    Categoria = dr.GetString(dr.GetOrdinal("Categoria")) + '#' + dr.GetString(dr.GetOrdinal("Mod_Contratacion"))
                };
                ddjj104.Mes = dr.GetInt16(dr.GetOrdinal("Mes"));
                ddjj104.Anio = dr.GetInt16(dr.GetOrdinal("Año"));

                listaddjj104.Add(ddjj104);
            }

            cn.Desconestar();

            return listaddjj104;
        }

    }

}
