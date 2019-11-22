using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using General.Repositorios;

namespace General.Repositorios
{
    public class RepositorioDocumentosRecepcionados
    {
        
        public List<TipoDeDocumento> GetTipoDocumento_A_Generar()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.GET_Tabla_Tipo_Documento");
            dr = cn.EjecutarConsulta();

            List<TipoDeDocumento> listaTipoDoc = new List<TipoDeDocumento>();

            while (dr.Read())
            {
                TipoDeDocumento TipoDoc = new TipoDeDocumento();
                TipoDoc.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                TipoDoc.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
                listaTipoDoc.Add(TipoDoc);
            }

            cn.Desconestar();

            return listaTipoDoc;
        }


        public List<DocumentosRecepcionados> GetDocumentos_Recepcionados()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.TRAM_GET_Documentos_Recepcionados");
            dr = cn.EjecutarConsulta();

            List<DocumentosRecepcionados> listaDoc = new List<DocumentosRecepcionados>();

            while (dr.Read())
            {
                DocumentosRecepcionados Doc = new DocumentosRecepcionados();
                Doc.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Doc.Id_Tipo_Doc = dr.GetInt32(dr.GetOrdinal("Id_Tipo_Doc"));
                Doc.IdPersona = dr.GetInt32(dr.GetOrdinal("Id_Persona"));
                Doc.Cantidad_Folios = dr.GetInt32(dr.GetOrdinal("Cantidad_Folios"));
                Doc.Fecha_Recepcion = dr.GetDateTime(dr.GetOrdinal("Fecha_Recepcion"));
                Doc.Usuario_Recepcion = dr.GetInt32(dr.GetOrdinal("Usuario_Recepcion"));
                Doc.Fecha_Carga = dr.GetDateTime(dr.GetOrdinal("Fecha_Carga"));
                Doc.Usuario_Carga = dr.GetInt32(dr.GetOrdinal("Usuario_Carga"));
                
                listaDoc.Add(Doc);
            }

            cn.Desconestar();

            return listaDoc;
        }



    }
}
