using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;

namespace General.Repositorios
{
    public class RepositorioConceptosDeLicencia
    {
        #region IRepositorioConceptosDeLicencia Members

        public List<GrupoConceptosDeLicencia> GetGruposConceptosLicencia()
        {
            List<GrupoConceptosDeLicencia> grupos = new List<GrupoConceptosDeLicencia>();
            GrupoConceptosDeLicencia grupo;

            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.Web_GetConceptosLicenciaAgrupados");

            dr = cn.EjecutarConsulta();

            if (dr.Read())
            {
                grupo = new GrupoConceptosDeLicencia { Id = dr.GetInt32(dr.GetOrdinal("idGrupo")), Descripcion = dr.GetString(dr.GetOrdinal("descripcionGrupo")), Detalle = dr.GetString(dr.GetOrdinal("detalleGrupo")) };
                grupo.Conceptos = new List<ConceptoDeLicencia>();
                grupo.Conceptos.Add(new ConceptoDeLicencia { Id = dr.GetInt16(dr.GetOrdinal("idConcepto")), Articulo = dr.GetString(dr.GetOrdinal("Nro_Articulo")), Inciso = dr.GetString(dr.GetOrdinal("inciso")), Descripcion = dr.GetString(dr.GetOrdinal("descripcionConcepto")), PathFormularioWeb = dr.GetString(dr.GetOrdinal("PathFormularioWeb")), DiasHabiles = dr.GetBoolean(dr.GetOrdinal("diasHabiles"))});
                while (dr.Read())
                {
                    if (grupo.Id != dr.GetInt32(dr.GetOrdinal("idGrupo")))
                    {
                        grupos.Add(grupo);
                        grupo = new GrupoConceptosDeLicencia { Id = dr.GetInt32(dr.GetOrdinal("idGrupo")), Descripcion = dr.GetString(dr.GetOrdinal("descripcionGrupo")), Detalle = dr.GetString(dr.GetOrdinal("detalleGrupo")) };
                        grupo.Conceptos = new List<ConceptoDeLicencia>();
                    }
                    grupo.Conceptos.Add(new ConceptoDeLicencia { Id = dr.GetInt16(dr.GetOrdinal("idConcepto")), Articulo = dr.GetString(dr.GetOrdinal("Nro_Articulo")), Inciso = dr.GetString(dr.GetOrdinal("inciso")), Descripcion = dr.GetString(dr.GetOrdinal("descripcionConcepto")), PathFormularioWeb = dr.GetString(dr.GetOrdinal("PathFormularioWeb")), DiasHabiles = dr.GetBoolean(dr.GetOrdinal("diasHabiles"))});
                }
                grupos.Add(grupo);
            }


            ////GRUPO PARA VIATICOS
            grupo = new GrupoConceptosDeLicencia { Id = 5, Descripcion = "Viaticos", Detalle = "1. Generación de Viáticos del Personal." };
            grupo.Conceptos = new List<ConceptoDeLicencia>();
            grupo.Conceptos.Add(new ConceptoDeLicencia { Id = 0, Articulo = "101", Inciso = "VIA", Descripcion = "Viáticos", PathFormularioWeb = "~\\FormularioDeViaticos\\FCargaComisionDeServicio.aspx", DiasHabiles = false });
            grupos.Add(grupo);
            

            return grupos;
        }
        #endregion
    }
}
