using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace TestViaticos
{
    [TestClass]
    public class TestAlertas
    {

        [TestInitialize]
        public void SetUp()
        {
        }

        [TestMethod]
        public void deberia_poder_iniciar_un_proceso_que_verifique_periodicamente_si_hay_documentos_en_alerta_e_informe_por_mail_si_los_hay()
        {
            var filtros = new List<FiltroDeDocumentos>();
            var reportador = new ReportadorDeDocumentosEnAlerta(filtros, "jlurgo@gmail.com", new EnviadorDeMails(), new RepositorioDeDocumentos(TestObjects.ConexionMockeada()));
            Assert.AreEqual("Idle", reportador.estado);
            reportador.start();
            Assert.AreEqual("Running", reportador.estado);
        }

        [TestMethod]
        public void deberia_poder_detener_el_proceso()
        {
            var filtros = new List<FiltroDeDocumentos>();
            var reportador = new ReportadorDeDocumentosEnAlerta(filtros, "jlurgo@gmail.com", new EnviadorDeMails(), new RepositorioDeDocumentos(TestObjects.ConexionMockeada()));
            Assert.AreEqual("Idle", reportador.estado);
            reportador.start();
            Assert.AreEqual("Running", reportador.estado);
            reportador.stop();
            Assert.AreEqual("Idle", reportador.estado);
        }
    }
}
