using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using General.Repositorios;
using General;
using Newtonsoft.Json;
using System.Threading;

namespace General
{
    public class ReportadorDeDocumentosEnAlerta
    {
        private List<FiltroDeDocumentos> filtros;
        private string mail_to;
        private Timer timer;
        public EnviadorDeMails enviador { get; set; }
        public RepositorioDeDocumentos repo_documentos { get; set; }

        public ReportadorDeDocumentosEnAlerta(List<FiltroDeDocumentos> _filtros, string mail_to, EnviadorDeMails _enviador, RepositorioDeDocumentos repo_docs)
        {
            this.filtros = _filtros;
            this.mail_to = mail_to;
            this.enviador = _enviador;
            this.repo_documentos = repo_docs;
            this.estado = "Idle";
        }

        public object estado { get; set; }

        public void start()
        {
            this.estado = "Running";
            timer = new Timer( (object o) => { verificarAlertas(); }, null, 10000, 10000);
        }

        public void stop()
        {
            this.estado = "Idle";
        }

        public void verificarAlertas()
        {
            if (hayDocumentosEnAlerta()) enviarAlertasPorMail();
        }

        private void enviarAlertasPorMail()
        {
            enviador.EnviarMail(new NetworkCredential("serviciodealertas@desarrollosocial.gov.ar", "1234"),
                this.mail_to,
                "Documentos en alerta",
                JsonConvert.SerializeObject(this.documentosEnAlerta()),
                () => { },
                () => { }
                );
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
