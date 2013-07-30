using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.Modi
{
    public class RepositorioDeLegajos
    {
        private IConexionBD conexion;
        private IRepositorioDeLegajosEscaneados repositorio_de_imagenes;

        public RepositorioDeLegajos(IConexionBD _conexion, IRepositorioDeLegajosEscaneados repo_imagenes)
        {
            conexion = _conexion;
            repositorio_de_imagenes = repo_imagenes;
        }

        public List<LegajoModi> getLegajoPorDocumento(int numero_de_documento)
        {
            var legajos = new List<LegajoModi>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@doc", numero_de_documento);
            var tablaLegajo = conexion.Ejecutar("dbo.LEG_GET_Datos_Personales", parametros);

            if (tablaLegajo.Rows.Count == 0) { return legajos; }

            var row = tablaLegajo.Rows.First();
            var legajo = new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"));

            var documentos = this.documentosPara(legajo);
            legajo.agregarDocumentos(documentos);
            legajo.agregarIdsDeImagenesSinAsignar(this.repositorio_de_imagenes.GetIdsDeImagenesSinAsignarParaElLegajo(legajo.idInterna));

            legajos.Add(legajo);
            return legajos;
        }

        public List<LegajoModi> getLegajoPorIdInterna(int id_interna)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            var tablaLegajo = conexion.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Id_interna", parametros);

            if (tablaLegajo.Rows.Count == 0) { return legajos; }

            var row = tablaLegajo.Rows.First();
            var legajo = new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"));

            var documentos = this.documentosPara(legajo);
            legajo.agregarDocumentos(documentos);
            legajo.agregarIdsDeImagenesSinAsignar(this.repositorio_de_imagenes.GetIdsDeImagenesSinAsignarParaElLegajo(legajo.idInterna));

            legajos.Add(legajo);
            return legajos;
        }

        private List<LegajoModi> getLegajosPorApellidoYNombre(string criterio)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@criterio", criterio);
            var tablaLegajo = conexion.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Apellido_Y_Nombre", parametros);

            if (tablaLegajo.Rows.Count == 0) { return legajos; }

            var row = tablaLegajo.Rows.First();
            var legajo = new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"));

            var documentos = this.documentosPara(legajo);
            legajo.agregarDocumentos(documentos);
            legajo.agregarIdsDeImagenesSinAsignar(this.repositorio_de_imagenes.GetIdsDeImagenesSinAsignarParaElLegajo(legajo.idInterna));

            legajos.Add(legajo);
            return legajos;
        }

        //private RespuestaABusquedaDeLegajos legajoPara(int numero_de_documento, Func<RespuestaABusquedaDeLegajos> on_legajo_no_encontrado)
        //{
            
        //}

        private List<DocumentoModi> documentosPara(LegajoModi legajo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", legajo.idInterna);
            parametros.Add("@legajo", legajo.idInterna);
            var tablaDocumentos = conexion.Ejecutar("dbo.LEG_GET_Indice_Documentos", parametros);
            var documentos =  GetDocumentosFromTabla(tablaDocumentos);

            documentos.ForEach(doc =>
            {
                var id_imagenes = this.repositorio_de_imagenes.GetIdsDeImagenesAsignadasAlDocumento(doc.tabla, doc.id);
                doc.idImagenesAsignadas.AddRange(id_imagenes);

                var id_categoria = this.repositorio_de_imagenes.CategoriaDeUnDocumento(doc.tabla, doc.id);
                doc.idCategoria = id_categoria;
            });
            return documentos;
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

        public RespuestaABusquedaDeLegajos BuscarLegajos(string criterio)
        {
            var legajos = new List<LegajoModi>();
            int numero;
            if(int.TryParse(criterio, out numero)){
                legajos.AddRange(this.getLegajoPorDocumento(numero));
                legajos.AddRange(this.getLegajoPorIdInterna(numero));
            }
            else
            {
                legajos.AddRange(this.getLegajosPorApellidoYNombre(criterio));
            }
            return new RespuestaABusquedaDeLegajos(legajos);
        }
    }
}
