using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class Mensajeria
    {
        private List<TransicionDeDocumento> transiciones;

        public Mensajeria(List<TransicionDeDocumento> transiciones)
        {
            this.transiciones = transiciones;
        }

        public void SeEnvioDirectamente(Documento documento, Area origen, Area destino, DateTime fecha_transicion)
        {
            transiciones.Add(new TransicionDeDocumento(origen, destino, fecha_transicion, documento, TransicionDeDocumento.ATOMICA));
            YaNoSeEnviaAFuturo(documento);
        }

        public List<Documento> DocumentosEn(Area area)
        {
            transiciones = transiciones.FindAll(t => t.AreaDestino != null);
            transiciones = transiciones.FindAll(t => t.Tipo != TransicionDeDocumento.FUTURA);

            var trans_al_area = transiciones.FindAll(t => t.AreaDestino.Equals(area)).ToList();

            var docs_que_fueron_algun_dia_al_area = trans_al_area.Select(t => t.Documento).Distinct().ToList();

            var documentos_en_el_area = docs_que_fueron_algun_dia_al_area.FindAll(d => this.EstaEnElArea(d).Equals(area));

            return documentos_en_el_area;
            //var transiciones_posteriores_a_hoy_de_esos_docs = transiciones.FindAll(t => docs_que_fueron_algun_dia_al_area.Contains(t.Documento) && t.Fecha > trans_al_area.Find(tr => tr.Documento.Equals(t.Documento)).Fecha);
            //var documentos_sin_transiciones_posteriores = docs_que_fueron_algun_dia_al_area.FindAll(d => !transiciones_posteriores_a_hoy_de_esos_docs.Any(t => t.Documento.Equals(d)));
            //return documentos_sin_transiciones_posteriores;
        }

        public void GuardarTransicionesEn(Repositorios.RepositorioMensajeria repositorioMensajeria)
        {
            repositorioMensajeria.GuardarTransiciones(this.transiciones);
        }


        public TransicionDeDocumento TransicionAFuturoPara(Documento documento)
        {
            return transiciones.Find(t => t.Documento.Equals(documento) && t.Tipo.Equals(TransicionDeDocumento.FUTURA));
        }

         public Area EstaEnElArea(Documento documento)
        {
            var transiciones_realizadas = transiciones.FindAll(t => t.Tipo != TransicionDeDocumento.FUTURA);

            var transiciones_del_doc = transiciones_realizadas.FindAll(t => t.Documento.Equals(documento));

            var transiciones_del_doc_ordenadas= transiciones_del_doc.OrderByDescending(t => t.Fecha).ToList();

            if (transiciones_del_doc_ordenadas.Count > 0)
                return transiciones_del_doc_ordenadas.First().AreaDestino;
             else
                return new AreaNull();
         }

         public Area SeOriginoEnArea(Documento documento)
         {
             var transiciones_del_documento = transiciones.FindAll(t => t.Tipo != TransicionDeDocumento.FUTURA && t.Documento.Equals(documento))
                                                          .OrderBy(t => t.Fecha).ToList();

             if (transiciones_del_documento.Count > 0)
                 return transiciones_del_documento.First().AreaOrigen;
             else
                 return new AreaNull();
         }

         public Area AreaDestinoPara(Documento documento)
         {
             var trans = transiciones.FindAll(t => t.Documento.Equals(documento) && t.Tipo.Equals(TransicionDeDocumento.FUTURA));
             if (trans.Count > 0)
                 return trans.First().AreaDestino;
             else
                 return new AreaNull();
         }

         public TimeSpan TiempoEnElAreaActualPara(Documento documento)
         {
             var transiciones_realizadas = transiciones.FindAll(t => t.Tipo != TransicionDeDocumento.FUTURA);

             var transiciones_del_doc = transiciones_realizadas.FindAll(t => t.Documento.Equals(documento));

             var transiciones_del_doc_ordenadas = transiciones_del_doc.OrderByDescending(t => t.Fecha).ToList();

             if (transiciones_del_doc_ordenadas.Count > 0)
                 return DateTime.Now.Subtract(transiciones_del_doc_ordenadas.First().Fecha);
             else
                 return TimeSpan.FromDays(0);
         }
         public List<TransicionDeDocumento> HistorialDetransicionesPara(Documento documento)
         {
             return transiciones.FindAll(t => t.Documento.Equals(documento) && !t.Tipo.Equals(TransicionDeDocumento.FUTURA));
         }

         public void TransicionarConAreaIntermedia(Documento un_documento, Area area_origen, Area area_intermedia, Area area_destino, DateTime fecha)
         {
             this.SeEnvioDirectamente(un_documento, area_origen, area_intermedia, fecha);
             this.SeEnvioDirectamente(un_documento, area_intermedia, area_destino, fecha.AddSeconds(1));
             this.YaNoSeEnviaAFuturo(un_documento);
         }
        
         public void SeEnviaAFuturo(Documento documento, Area area_origen, Area area_destino)
         {
             transiciones.Add(new TransicionDeDocumento(area_origen, area_destino, DateTime.MinValue, documento, TransicionDeDocumento.FUTURA));
         }

         public void YaNoSeEnviaAFuturo(Documento un_documento)
         {
             transiciones.RemoveAll(t => t.Documento.Equals(un_documento) && t.Tipo == TransicionDeDocumento.FUTURA);
         }
    }
}
