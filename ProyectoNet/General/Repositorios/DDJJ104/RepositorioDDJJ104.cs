using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using General.Repositorios;
using General.MAU;

namespace General
{

    public class RepositorioDDJJ104
    {

        public List<DDJJ104_2001> GetDDJJParaElArea(Area area)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PLA_GET_DDJJ_AREA");
            cn.AsignarParametro("@id_area", area.Id);

            dr = cn.EjecutarConsulta();

            List<DDJJ104_2001> listaddjj104 = new List<DDJJ104_2001>();

            while (dr.Read())
            {
                DDJJ104_2001 ddjj104 = new DDJJ104_2001();
                ddjj104.Id = dr.GetInt32(dr.GetOrdinal("Id_DDJJ"));
                ddjj104.Mes = dr.GetInt16(dr.GetOrdinal("Mes"));
                ddjj104.Anio = dr.GetInt16(dr.GetOrdinal("Año"));
                ddjj104.Estado = dr.GetInt16(dr.GetOrdinal("Estado"));
                ddjj104.FechaGeneracion = dr.GetDateTime(dr.GetOrdinal("Fecha_Generacion"));
                listaddjj104.Add(ddjj104);
            }

            cn.Desconestar();

            return listaddjj104;
        }


        //public int GetEstadoDDJJ(AreaParaDDJJ104 ddjj)
        //{
        //    SqlDataReader dr;
        //    ConexionDB cn = new ConexionDB("dbo.PLA_GET_DDJJ104");
        //    cn.AsignarParametro("@Id_Area", ddjj.Area.Id);
        //    cn.AsignarParametro("@Mes", ddjj.Mes);
        //    cn.AsignarParametro("@Año", ddjj.Anio);

        //    dr = cn.EjecutarConsulta();

        //    int estado = 1;

        //    if (dr.Read())
        //    {
        //        estado = dr.GetInt16(dr.GetOrdinal("Estado"));
        //    }

        //    cn.Desconestar();

        //    return estado;
        //}


        public DDJJ104_2001 GenerarDDJJ104(Usuario usuario, AreaParaDDJJ104 area, int mes, int anio)
        {
            ConexionDB cn = new ConexionDB("dbo.PLA_ADD_DDJJ104_Cabecera");
            cn.AsignarParametro("@Id_Area", area.Id);
            cn.AsignarParametro("@Mes", mes);
            cn.AsignarParametro("@Año", anio);
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
                    //foreach (var personas in new RepositorioPersonas().GetPersonasDelAreaParaDDJJ104(mes, anio, area )) //new Area(id_area)
                    foreach (var personas in area.Personas)
                    {
                        string[] Cat_Mod = personas.Categoria.ToString().Split('#');

                        cn.CrearComandoConTransaccionIniciada("dbo.PLA_ADD_DDJJ104_Detalle");
                        cn.AsignarParametro("@Id_DDJJ", id_ddjj_nuevo);
                        cn.AsignarParametro("@Id_Persona", personas.Id);
                        cn.AsignarParametro("@Orden", orden);
                        cn.AsignarParametro("@Id_Area_Persona", personas.Area.Id);
                        cn.AsignarParametro("@Mod_Contratacion", Cat_Mod[1].Trim());
                        cn.AsignarParametro("@Categoria", Cat_Mod[0].Trim());

                        cn.EjecutarSinResultado();

                        orden++;
                    }


                    foreach (var areasDependiente in area.AreasInformalesDependientes)
                    {
                        foreach (var personas in areasDependiente.Personas)
                        {
                            string[] Cat_Mod = personas.Categoria.ToString().Split('#');

                            cn.CrearComandoConTransaccionIniciada("dbo.PLA_ADD_DDJJ104_Detalle");
                            cn.AsignarParametro("@Id_DDJJ", id_ddjj_nuevo);
                            cn.AsignarParametro("@Id_Persona", personas.Id);
                            cn.AsignarParametro("@Orden", orden);
                            cn.AsignarParametro("@Id_Area_Persona", personas.Area.Id);
                            cn.AsignarParametro("@Mod_Contratacion", Cat_Mod[1].Trim());
                            cn.AsignarParametro("@Categoria", Cat_Mod[0].Trim());

                            cn.EjecutarSinResultado();

                            orden++;
                        }
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

            var ddjj = new DDJJ104_2001();
            ddjj.Anio = anio;
            ddjj.Mes = mes;
            ddjj.Id = id_ddjj_nuevo;
            ddjj.FechaGeneracion = DateTime.Now;
            return ddjj;

        }

        //public List<AreaParaDDJJ104> ImprimirDDJJ104(Usuario usuario, int id_area, int mes, int anio)
        //{
        //    SqlDataReader dr;
        //    ConexionDB cn = new ConexionDB("dbo.PLA_GET_DDJJ104");
        //    cn.AsignarParametro("@Id_Area", id_area);
        //    cn.AsignarParametro("@Mes", mes);
        //    cn.AsignarParametro("@Año", anio);

        //    dr = cn.EjecutarConsulta();

        //    AreaParaDDJJ104 ddjj104 = new AreaParaDDJJ104();

        //    List<AreaParaDDJJ104> listaddjj104 = new List<AreaParaDDJJ104>();

        //    while (dr.Read())
        //    {

        //        ddjj104 = new AreaParaDDJJ104()
        //        {
        //            Id = dr.GetInt32(dr.GetOrdinal("Id_Area")),
        //            Nombre = dr.GetString(dr.GetOrdinal("Area")),
        //            //Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
        //            //Dependencias = new List<Area>() { new Area() { Nombre = dr.GetString(dr.GetOrdinal("Dependencia")) } }
        //        };

        //        ddjj104.Personas = new List<Persona>();


        //        //ddjj104.Agente = new Persona()
        //        //{
        //        //    Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
        //        //    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
        //        //    Cuit = dr.GetString(dr.GetOrdinal("Cuil_Nro")),
        //        //    Categoria = dr.GetString(dr.GetOrdinal("Categoria")) + '#' + dr.GetString(dr.GetOrdinal("Mod_Contratacion"))
        //        //};
        //        ddjj104.Mes = dr.GetInt16(dr.GetOrdinal("Mes"));
        //        ddjj104.Anio = dr.GetInt16(dr.GetOrdinal("Año"));
        //        ddjj104.LeyendaPorAnio = dr.GetString(dr.GetOrdinal("Leyenda"));
        //        ddjj104.IdDDJJ = dr.GetInt32(dr.GetOrdinal("Id_DDJJ"));

        //        listaddjj104.Add(ddjj104);
        //    }

        //    cn.Desconestar();

        //    return listaddjj104;
        //}


        //public void MarcarDDJJ104Impresa(int nroDDJJ, int estado)
        //{
        //    SqlDataReader dr;
        //    ConexionDB cn = new ConexionDB("dbo.PLA_UPD_DDJJ104_Cabecera");
        //    cn.AsignarParametro("@id_ddjj", nroDDJJ);
        //    cn.AsignarParametro("@id_estado", estado);

        //    dr = cn.EjecutarConsulta();

        //    cn.Desconestar();
        //}


       


    }

}
