using System.Collections.Generic;
using System;
using General.MAU;
namespace General.Repositorios
{
    public class RepositorioDeDocumentos : General.Repositorios.IRepositorioDeDocumentos
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeDocumentos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Documento> GetTodosLosDocumentos()
        {
            var tablaDocumentos = conexion_bd.Ejecutar("dbo.SIC_GetDocumentos");

            return GetDocumentosFromTabla(tablaDocumentos);
        }

        public List<Documento> GetDocumentosFromTabla(TablaDeDatos tablaDocumentos)
        {
            List<Documento> documentos = new List<Documento>();

            if (tablaDocumentos.Rows.Count > 0)
            {
                var un_documento = new Documento();
                var area_origen = new Area();
                var area_destino = new Area();

                tablaDocumentos.Rows.ForEach(row =>
                {
                    if (documentos.FindAll(d => d.Id == row.GetInt("IdDocumento")).Count == 0)
                    {
                        un_documento = new Documento();
                        un_documento.Id = row.GetInt("IdDocumento");
                        string sigla;
                        if (row.GetObject("SiglaTipoDocumento") is DBNull)
                        {
                            sigla = "";
                        }
                        else
                        {
                            sigla = row.GetString("SiglaTipoDocumento");
                        }
                        un_documento.tipoDeDocumento = new TipoDeDocumentoSICOI(row.GetInt("IdTipoDeDocumento"), row.GetString("DescripcionTipoDocumento"), sigla);

                        
                        un_documento.numero = row.GetString("Numero");
                        un_documento.extracto = row.GetString("Extracto");
                        un_documento.fecha = row.GetDateTime("FechaCargaDocumento");
                        un_documento.comentarios = row.GetString("Comentarios");

                       if (row.GetObject("FechaDocumento") is DBNull)
	                   {
                           un_documento.fecha_documento = null;
	                   }
                       else
                       {
                           un_documento.fecha_documento = row.GetDateTime("FechaDocumento");
                       }
                    
                        
                        
                        if (un_documento.comentarios == null)
                        {
                            un_documento.comentarios = "";
                        }
                        un_documento.categoriaDeDocumento = new CategoriaDeDocumentoSICOI(row.GetInt("IdCategoriaDeDocumento"), row.GetString("DescripcionCategoria"));
                        un_documento.ticket = row.GetString("Ticket");

                        documentos.Add(un_documento);
                       
                    }                   
                   
                });
            }

            return documentos;
        
        }

       
        public void GuardarDocumento(Documento un_documento, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            RepositorioDeTickets repoTicket = new RepositorioDeTickets(conexion_bd);

            Validador().EsValidoComoId(un_documento.categoriaDeDocumento.Id, "para la categoría de un documento");
            Validador().EsValidoComoId(un_documento.tipoDeDocumento.Id, "para el tipo de un documento");
            
            un_documento.ticket = repoTicket.GenerarTicket();

            parametros.Add("@idTipoDeDocumento", un_documento.tipoDeDocumento.Id);
            parametros.Add("@numero", un_documento.numero);
            parametros.Add("@idCategoria", un_documento.categoriaDeDocumento.Id);
            parametros.Add("@extracto", un_documento.extracto);
            parametros.Add("@ticket", un_documento.ticket);
            parametros.Add("@comentarios", un_documento.comentarios); // decidir si dejamos que tenga comentarios el documento
            parametros.Add("@idUsuario", usuario.Id);
            /**/
            parametros.Add("@fecha_documento", un_documento.fecha_documento);
            /**/
            var id = conexion_bd.EjecutarEscalar("dbo.SIC_GuardarDocumento", parametros);

            un_documento.Id = int.Parse(id.ToString());           
        }

        private ValidadorMICOI Validador()
        {
            return new ValidadorMICOI();
        }

        public List<TipoDeDocumentoSICOI> GetTiposDeDocumentos()
        {
            var tablaTipoDeDocumentos = conexion_bd.Ejecutar("dbo.SIC_GetTiposDeDocumento");

            List<TipoDeDocumentoSICOI> tiposDeDocumento = new List<TipoDeDocumentoSICOI>();

            if (tablaTipoDeDocumentos.Rows.Count > 0)
            {
                tablaTipoDeDocumentos.Rows.ForEach(row =>
                {
                    var unTipoDeDdocumento = new TipoDeDocumentoSICOI();
                    unTipoDeDdocumento.Id = row.GetInt("Id");
                    unTipoDeDdocumento.descripcion = row.GetString("Descripcion");

                    if (row.GetObject("Sigla") is DBNull)
                    {
                        unTipoDeDdocumento.sigla = "";
                    }
                    else
                    {
                        unTipoDeDdocumento.sigla = row.GetString("Sigla");
                    }
                    
              
                    
                  
                    tiposDeDocumento.Add(unTipoDeDdocumento);

                });
            }

            return tiposDeDocumento;
        
        }

        public List<CategoriaDeDocumentoSICOI> GetCategoriasDeDocumentos()
        {
            var tablaCategoriaDeDocumentos = conexion_bd.Ejecutar("dbo.SIC_GetCategoriasDeDocumento");

            List<CategoriaDeDocumentoSICOI> categoriasDeDocumentos = new List<CategoriaDeDocumentoSICOI>();

            if (tablaCategoriaDeDocumentos.Rows.Count > 0)
            {
                tablaCategoriaDeDocumentos.Rows.ForEach(row =>
                {
                    var unaCategoriaDeDocumento = new CategoriaDeDocumentoSICOI();
                    unaCategoriaDeDocumento.Id = row.GetInt("Id");
                    unaCategoriaDeDocumento.descripcion = row.GetString("Descripcion");
                    categoriasDeDocumentos.Add(unaCategoriaDeDocumento);
                });
            }
            return categoriasDeDocumentos;
        }

        public List<Documento> GetDocumentosFiltrados(List<FiltroDeDocumentos> filtros)
        {
            BuscadorDeDocumentos buscador_de_documentos = new BuscadorDeDocumentos(GetTodosLosDocumentos());
            var lista_a_devolver = buscador_de_documentos.Buscar(filtros);
            return lista_a_devolver;
        }

        public Documento GetDocumentoPorId(int id_documento)
        {
            var documentos = this.GetTodosLosDocumentos();
            return documentos.Find(d => d.Id == id_documento);
        }

        public void UpdateDocumento(Documento un_documento, Usuario usuario)
        {         
            var parametros = new Dictionary<string, object>();

            parametros.Add("@idDocumento", un_documento.Id);
            parametros.Add("@idTipoDeDocumento", un_documento.tipoDeDocumento.Id);
            parametros.Add("@numero", un_documento.numero);
            parametros.Add("@idCategoria", un_documento.categoriaDeDocumento.Id);
            //parametros.Add("@idAreaOrigen", un_documento.areaOrigen.Id);
            parametros.Add("@extracto", un_documento.extracto);
            parametros.Add("@ticket", un_documento.ticket);
            //if (un_documento.areaDestino != null)
            //    parametros.Add("@idAreaDestino", un_documento.areaDestino.Id);// un_documento.areaDestino.Id);
            parametros.Add("@comentarios", un_documento.comentarios); // decidir si dejamos que tenga comentarios el documento //por ahora se lo dejamos al documento
            parametros.Add("@idUsuario", usuario.Id);
            parametros.Add("@Fecha", un_documento.fecha);

            var id = conexion_bd.EjecutarEscalar("dbo.SIC_ActualizarDocumentos", parametros);

        }
    }
}
