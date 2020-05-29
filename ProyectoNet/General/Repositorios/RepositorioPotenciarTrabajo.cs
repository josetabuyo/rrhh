using General.Contrato;
using General.MAU;
using General.MED;
using General.PotenciarTrabajo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace General.Repositorios
{
    public class RepositorioPotenciarTrabajo
    {
     
        public List<GeneralCombos> Get_Cargar_Combo(string nombre_combo, Usuario usuario)
        {
            SqlDataReader dr = null;
            ConexionDB cn = null;

            switch (nombre_combo)
            {
                case "GrupoTrabajo":
                    cn = new ConexionDB("dbo.PRGSOC_GET_Entidades");
                    break;


                default:
                    break;
            }

            dr = cn.EjecutarConsulta();

            GeneralCombos combo;
            List<GeneralCombos> lista = new List<GeneralCombos>();

            while (dr.Read())
            {
                combo = new GeneralCombos();
                combo.id = dr.GetInt16(dr.GetOrdinal("Id"));
                combo.descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));

                lista.Add(combo);
            }

            cn.Desconestar();
            return lista;
        }


        public List<PT_Periodo> Get_Periodos()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_GET_Periodos");
            
            dr = cn.EjecutarConsulta();

            PT_Periodo combo;
            List<PT_Periodo> lista = new List<PT_Periodo>();

            while (dr.Read())
            {
                combo = new PT_Periodo();
                combo.Id = dr.GetString(dr.GetOrdinal("Id"));
                combo.Mes = dr.GetInt32(dr.GetOrdinal("Mes"));
                combo.Anio = dr.GetInt32(dr.GetOrdinal("Anio"));
                combo.CantSemanas = dr.GetInt32(dr.GetOrdinal("Cantidad_Semannas"));

                lista.Add(combo);
            }

            cn.Desconestar();
            return lista;
        }


        public List<PT_Participacion> Get_Participacion_por_Entidad_Periodo(int idEntidad, string idPeriodo)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_GET_Participacion_Por_Entidad_Periodo");
            cn.AsignarParametro("@Id_Entidad", idEntidad);
            cn.AsignarParametro("@Periodo", idPeriodo);

            dr = cn.EjecutarConsulta();

            PT_Participacion part;
            List<PT_Participacion> lista = new List<PT_Participacion>();

            while (dr.Read())
            {
                part = new PT_Participacion();
                part.Persona = new PT_Personas();
                part.Persona.Id = dr.GetInt32(dr.GetOrdinal("Id_Persona"));
                part.Persona.CUIL = dr.GetString(dr.GetOrdinal("CUIL"));
                part.Persona.Nombre_Apellido = dr.GetString(dr.GetOrdinal("Apellido_Nombre"));
                part.PartSemana1 = dr.GetInt32(dr.GetOrdinal("Part_Semana1"));
                part.PartSemana2 = dr.GetInt32(dr.GetOrdinal("Part_Semana2"));
                part.PartSemana3 = dr.GetInt32(dr.GetOrdinal("Part_Semana3"));
                part.PartSemana4 = dr.GetInt32(dr.GetOrdinal("Part_Semana4"));
                part.PartSemana5 = dr.GetInt32(dr.GetOrdinal("Part_Semana5"));
                part.Observacion = dr.GetString(dr.GetOrdinal("Observacion"));

                lista.Add(part);
            }

            cn.Desconestar();
            return lista;
        }



    }
}
