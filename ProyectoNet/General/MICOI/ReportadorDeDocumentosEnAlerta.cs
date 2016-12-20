using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using General.Repositorios;
using General;
using Newtonsoft.Json;
using System.Threading;
using System.Configuration;
using System.IO;

namespace General
{  
    public class ReportadorDeDocumentosEnAlerta
    {
        private List<FiltroDeDocumentos> filtros;
        private string mail_to;
        private Timer timer;
        public EnviadorDeMails enviador { get; set; }
        public RepositorioDeDocumentos repo_documentos { get; set; }
        private string plantilla_html;
        private string plantilla_html_head;
        private string plantilla_html_body;

      

        public ReportadorDeDocumentosEnAlerta(List<FiltroDeDocumentos> _filtros, string mail_to, EnviadorDeMails _enviador, RepositorioDeDocumentos repo_docs)
        {
            this.filtros = _filtros;
            this.mail_to = mail_to;
            this.enviador = _enviador;
            this.repo_documentos = repo_docs;
            this.estado = "Idle";
        }

        public string estado { get; set; }

        public void start(string plantillaHtmlHead, string PlantillaHtmlBody)
        {
            this.estado = "Running";
            timer = new Timer((object o) => { verificarAlertas(); }, null, 10000, 43200000);
          //  this.plantilla_html = plantillaHtml;
            this.plantilla_html_head = plantillaHtmlHead;
            this.plantilla_html_body = PlantillaHtmlBody;
        }

        public void start()
        {
            this.estado = "Running";
            timer = new Timer((object o) => { verificarAlertas(); }, null, 10000, 43200000);
           
        }

       

        public void stop()
        {
            this.estado = "Idle";
            timer.Dispose();
        }

        public void verificarAlertas()
        {
            if (hayDocumentosEnAlerta()) enviarAlertasPorMail();
        }

        private void enviarAlertasPorMail()
        {
            EnviadorDeMails.EnviarMail(new NetworkCredential("serviciodealertas@desarrollosocial.gob.ar", "1234"),
                this.mail_to,
                "Documentos en alerta",
            
            HtmlFinal(),// PlantillaHtml(),
                
                () => { },
                () => { }
                );
        }

       
        private string HeadHtml()
        {
              using (StreamReader sReader = new StreamReader(this.plantilla_html_head))
              {
                  string htmlhead = sReader.ReadToEnd();
                  string texto_email = "El presente e-mail corresponde a una notificación automática del sistema de alertas del módulo MCOI, de acuerdo a parámetros establecidos previamente. La información que se muestra a continuación corresponde al/los documentos mencionados: ";

                  htmlhead = htmlhead.Replace("[MailRedactado]", texto_email);
                  return htmlhead;
                  }
        }



        private string HtmlFinal()
        {

            return HeadHtml() + BodyHtml()  +  "</body> </html>";

        }


     private string BodyHtml()
     {
            var mensajeria = Mensajeria();
            string html_final ="";
     foreach (Documento un_documento in this.documentosEnAlerta())
     {
        
     using (StreamReader sReader = new StreamReader(this.plantilla_html_body))
     {
       string htmlbody = sReader.ReadToEnd();
      
       htmlbody = htmlbody.Replace("[Ticket]", un_documento.ticket);
       htmlbody = htmlbody.Replace("[TipoDoc]", un_documento.tipoDeDocumento.descripcion);
       htmlbody = htmlbody.Replace("[Sigla]", un_documento.tipoDeDocumento.sigla);
       htmlbody = htmlbody.Replace("[Numero]", un_documento.numero);
       htmlbody = htmlbody.Replace("[CategoriaDoc]", un_documento.categoriaDeDocumento.descripcion);
       htmlbody = htmlbody.Replace("[Extracto]", un_documento.extracto);
       htmlbody = htmlbody.Replace("[Comentarios]", un_documento.comentarios);
   
       var area_actual_documento = mensajeria.EstaEnElArea(un_documento).Nombre.ToString(); ;

       htmlbody = htmlbody.Replace("[AreaActual] ", area_actual_documento);

       var tiempo_area_actual = mensajeria.TiempoEnElAreaActualPara(un_documento).Days;

       htmlbody = htmlbody.Replace("[DiasAreaActual] ", tiempo_area_actual.ToString());
          

       string bodycreado = (string)htmlbody.Clone();
       html_final = html_final + bodycreado;


         
        }

   
         }
   
     return html_final; ;
        }


     public Mensajeria Mensajeria()
     {
         var repo_transiciones = RepoMensajeria();
         return repo_transiciones.GetMensajeria();
     }

     public RepositorioMensajeria RepoMensajeria()
     {
         var conexion = Conexion();
         var repo_documentos = new RepositorioDeDocumentos(conexion);
         var repo_organigrama = RepositorioDeOrganigrama.NuevoRepositorioOrganigrama(conexion);//new RepositorioDeOrganigrama(conexion);
         return new RepositorioMensajeria(conexion, repo_documentos, repo_organigrama);
     }

     public ConexionBDSQL Conexion()
     {
         return new ConexionBDSQL(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
     }

     public Area EstaEnElArea(Documento documento)
     {
         var mensajeria = Mensajeria();
         return mensajeria.EstaEnElArea(documento);
     }


        public bool hayDocumentosEnAlerta()
        {
            return this.documentosEnAlerta().Any();
        }

        public List<Documento> documentosEnAlerta()
        {
            return repo_documentos.GetDocumentosFiltrados(this.filtros);
        }
    }
}
