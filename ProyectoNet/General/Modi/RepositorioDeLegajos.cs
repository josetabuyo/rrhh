using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.Modi
{
    public class RepositorioDeLegajos
    {
        private IConexionBD _conexion;

        public RepositorioDeLegajos(IConexionBD conexion)
        {
            _conexion = conexion;           
        }

        public LegajoModi getLegajoPorDocumento(int numero_de_documento)
        {
            try
            {
                var legajo = this.legajoPara(numero_de_documento);
                var documentos = this.documentosPara(legajo);
                legajo.agregarDocumentos(documentos);
                return legajo;
            }
            catch (Exception e)
            {
                throw new ExcepcionDeLegajoInexistente();
            }          
        }

        private List<DocumentoModi> documentosPara(LegajoModi legajo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", legajo.idInterna);
            parametros.Add("@legajo", legajo.idInterna);
            var tablaDocumentos = _conexion.Ejecutar("dbo.LEG_GET_Indice_Documentos", parametros);
            return GetDocumentosFromTabla(tablaDocumentos);
        }

        private LegajoModi legajoPara(int numero_de_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@doc", numero_de_documento);
            var tablaLegajo = _conexion.Ejecutar("dbo.LEG_GET_Datos_Personales", parametros);
            return GetLegajoFromTabla(tablaLegajo);
        }

        private LegajoModi GetLegajoFromTabla(TablaDeDatos tablaLegajo)
        {
            var row = tablaLegajo.Rows.First();
            return new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"));
        }

        private List<DocumentoModi> GetDocumentosFromTabla(TablaDeDatos tablaDocumentos)
        {
            List<DocumentoModi> documentos = new List<DocumentoModi>();

            if (tablaDocumentos.Rows.Count > 0)
            {
                tablaDocumentos.Rows.ForEach(row =>
                {
                    var nuevoDocumento = new DocumentoModi(row.GetString("tabla"), 
                                                            row.GetInt("id"),
                                                            row.GetString("TIPO"),
                                                            row.GetString("JUR"),
                                                            row.GetString("ORG"),
                                                            row.GetString("FOLIO"),
                                                            row.GetDateTime("fecha_comunicacion"));
                    documentos.Add(nuevoDocumento);
                });
            }

            return documentos;
        }
    }
}
