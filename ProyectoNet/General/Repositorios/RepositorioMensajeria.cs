using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioMensajeria
    {

        private IConexionBD conexion_bd;
        private IRepositorioDeDocumentos repo_docs;
        private IRepositorioDeOrganigrama repo_organigrama;

        public RepositorioMensajeria(IConexionBD conexion, IRepositorioDeDocumentos repo_docs, IRepositorioDeOrganigrama repo_organigrama)
        {
            this.conexion_bd = conexion;
            this.repo_docs = repo_docs;
            this.repo_organigrama = repo_organigrama;
        }

        public Mensajeria GetMensajeria()
        {
            var transiciones = new List<TransicionDeDocumento>();
            var tablaDocumentos = conexion_bd.Ejecutar("dbo.SIC_GetTransicionesDeDocumentos");

            var documentos = repo_docs.GetTodosLosDocumentos();
            var areas = repo_organigrama.GetOrganigrama().ObtenerAreas(true);

            Area area_destino;
            DateTime fecha_transicion;


            tablaDocumentos.Rows.ForEach((r) =>
            {
                if (r.GetObject("IdAreaDestino") is DBNull)
                {
                    area_destino = null;
                }
                else
                {
                    area_destino = areas.First(a => a.Id == r.GetInt("IdAreaDestino"));
                }

                if (r.GetObject("Fecha") is DBNull)
                {
                    fecha_transicion = DateTime.MinValue; //null
                }
                else
                {
                    fecha_transicion = r.GetDateTime("Fecha");
                }

                transiciones.Add(
                new TransicionDeDocumento(
                    r.GetInt("Id"),
                    areas.First(a => a.Id == r.GetInt("IdAreaOrigen")),
                    area_destino,
                    fecha_transicion,
                    documentos.Find(d => d.Id == r.GetInt("IdDocumento")),
                    r.GetString("Tipo")
                    )
                    );
            }
                   );
            return new Mensajeria(transiciones);
        }

        public void GuardarTransicionesDe(Mensajeria mensajeria)
        {
            mensajeria.GuardarTransicionesEn(this);
        }

        public void GuardarTransiciones(List<TransicionDeDocumento> transiciones)
        {
            var transiciones_no_persistidas = transiciones.FindAll(t => t.Id == 0);
            if (transiciones_no_persistidas.Count < 1) return;

            transiciones_no_persistidas.ForEach((t) =>
            {
                BorrarTransicionFuturaPara(t.Documento);

                var parametros = new Dictionary<string, object>();
                parametros.Add("@IdAreaOrigen", t.AreaOrigen.Id);
                if (t.AreaDestino != null)
                    parametros.Add("@IdAreaDestino", t.AreaDestino.Id);

                if (!t.Fecha.Equals(DateTime.MinValue)) //null value
                    parametros.Add("@Fecha", t.Fecha);
                parametros.Add("@IdUsuario", 1);
                parametros.Add("@IdDocumento", t.Documento.Id);
                parametros.Add("@Tipo", t.Tipo);

                var id = conexion_bd.EjecutarEscalar("dbo.[SIC_InsertTransicionDeDocumentos]", parametros);
                t.Id = (int)((Decimal)id);
            });
        }

        public  void BorrarTransicionFuturaPara(Documento documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdDocumento", documento.Id);
            parametros.Add("@Tipo", TransicionDeDocumento.FUTURA);
            conexion_bd.EjecutarEscalar("dbo.[SIC_DelTransicionDeDocumentos]", parametros);
        }
    }
}
