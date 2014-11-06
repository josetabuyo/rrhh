using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using General.MAU;

namespace General
{
   public class RepositorioDeFoliados
    {

        protected IConexionBD conexion_bd;

        public RepositorioDeFoliados(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public void GuardarDocumentacionRecibida(List<DocumentacionRecibida> lista_docRecibida, Usuario usuario)
        {
            foreach (var doc_recibida in lista_docRecibida)
            {
                if (doc_recibida.Folio != "" && doc_recibida.Id == 0)
                {
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("@IdPostulacion", doc_recibida.IdPostulacion);
                    parametros.Add("@IdItemCV", doc_recibida.IdItemCV);
                    parametros.Add("@Folio", doc_recibida.Folio);
                    parametros.Add("@IdTabla", doc_recibida.IdTabla);
                    parametros.Add("@IdUsuario", usuario.Id);

                    var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Ins_DocumentacionRecibida", parametros);
                }
            }


            /*
             * 
             * La primera vez que alguien entra a recibir la documentacion (no hay nada persistido)

a->Ingresa un nro de folio (doc_recibida.id = 0 y nro_folio_pant=X)
=>Inserta un nuevo documento, con el folio ingresado (INSERT DATOS PANTALLA)

b->No ingresa un numero de folio(doc_recibida.id = 0 y nro_folio_pant=null)
=>No hace nada


La segunda vez que alguien entra a recibir la documentacion (hay algun documento recibido de antes)

-> No cambie nada (vuelve a guardar el mismo folio) (doc_recibida.id = X y nro_folio_pant=nro_folio_persistido)
=>No hace nada

-> Borre el folio que habia ya recibido (doc_recibida.id = X nro_folio_pant=null)
=>Borra el documento de el folio que habia antes (DELETE WHERE id=doc_recibida.id)

-> Modifica el nro de folio(doc_recibida.id = X nro_folio_pant!=nro_folio_persistido)
=>Hace update del nro de folio (UPDATE nro_folio_pant WHERE id=doc_recibida.id)
             * 
             * 
             * 
             * */
        }


        public List<DocumentacionRecibida> GetDocumentacionRecibidaByPostulacion(Postulacion postulacion)
        {
            List<DocumentacionRecibida> lista_doc_recibida = new List<DocumentacionRecibida>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPostulacion", postulacion.Id);
            
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_DocumentacionRecibida", parametros);

            tablaCVs.Rows.ForEach(row =>
            lista_doc_recibida.Add(ArmarDocRecibida(row))
            );

            return lista_doc_recibida;

        }

        private DocumentacionRecibida ArmarDocRecibida(RowDeDatos row)
        {
            ItemCv item = new ItemCv(row.GetInt("IdItem"), row.GetString("DescripcionItem"), row.GetSmallintAsInt("IdTabla"));

            return new DocumentacionRecibida(row.GetInt("IdDocRecibida"), item, row.GetString("Folio"), row.GetInt("idPostulacion"), row.GetDateTime("Fecha"));
        }
    }
}
