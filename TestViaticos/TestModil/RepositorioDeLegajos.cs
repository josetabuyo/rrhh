using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace TestViaticos.TestModil
{
    public class RepositorioDeLegajos
    {
        private IConexionBD _conexion;

        public RepositorioDeLegajos(IConexionBD conexion)
        {
            _conexion = conexion;           
        }

        public LegajoModil getLegajoPorDocumento(int numero_de_documento)
        {
            var legajo = this.legajoPara(numero_de_documento);
            var documentos = this.documentosPara(legajo);
            legajo.agregarDocumentos(documentos);          

            return legajo;
        }

        private List<DocumentoModil> documentosPara(LegajoModil legajo)
        {
            var tablaDocumentos = _conexion.Ejecutar("dbo.MODI_GetDocumentosParaUnLegajo");
            return GetDocumentosFromTabla(tablaDocumentos);
        }

        private LegajoModil legajoPara(int numero_de_documento)
        {
            var tablaLegajo = _conexion.Ejecutar("dbo.MODI_GetDatosParaUnLegajo");
            return GetLegajoFromTabla(tablaLegajo);
        }

        private LegajoModil GetLegajoFromTabla(TablaDeDatos tablaLegajo)
        {
            var row = tablaLegajo.Rows.First();
            return new LegajoModil(row.GetInt("id_interna"),
                                    row.GetInt("documento"),
                                    row.GetString("nombre"),
                                    row.GetString("apellido"));
        }

        private List<DocumentoModil> GetDocumentosFromTabla(TablaDeDatos tablaDocumentos)
        {
            List<DocumentoModil> documentos = new List<DocumentoModil>();

            if (tablaDocumentos.Rows.Count > 0)
            {
                tablaDocumentos.Rows.ForEach(row =>
                {
                    var nuevoDocumento = new DocumentoModil(row.GetString("tabla"), 
                                                            row.GetInt("id"),
                                                            row.GetString("descripcion"), 
                                                            row.GetString("jurisdiccion"),
                                                            row.GetString("organismo"),
                                                            row.GetString("folio"),
                                                            row.GetDateTime("fecha_desde"));
                    documentos.Add(nuevoDocumento);
                });
            }

            return documentos;
        }
    }
}
