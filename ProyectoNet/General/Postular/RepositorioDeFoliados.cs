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
