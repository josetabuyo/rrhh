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

        public LegajoModil getLegajoPorDocumento(int numero_de_documento)
        {
            var legajo = this.legajoPara(numero_de_documento);
            var documentos = this.documentosPara(legajo);
            legajo.agregarDocumentos(documentos);          

            return legajo;
        }

        private List<DocumentoModil> documentosPara(LegajoModil legajo)
        {
            var tablaDocumentos = _conexion.Ejecutar("dbo.LEG_GET_Indice_Documentos");
            return GetDocumentosFromTabla(tablaDocumentos);
        }

        private LegajoModil legajoPara(int numero_de_documento)
        {
            var tablaLegajo = _conexion.Ejecutar("dbo.LEG_GET_Datos_Personales");
            return GetLegajoFromTabla(tablaLegajo);
        }

        private LegajoModil GetLegajoFromTabla(TablaDeDatos tablaLegajo)
        {
            var row = tablaLegajo.Rows.First();
            return new LegajoModil(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"));
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
