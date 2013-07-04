using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;


using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace TestViaticos
{
    [TestClass]
    public class TestMail
    {

        [TestInitialize]
        public void SetUp()
        {
        }

        [TestMethod]
        public void deberia_poder_mandar_un_mail()
        {
            var cred = new NetworkCredential("prueba@desarrollosocial.gov.ar", "bla");
            var envio_ok = false;
            Action on_success = () => envio_ok = true;
            Action on_error = () => envio_ok = false;
            var enviador = new EnviadorDeMails();
            enviador.EnviarMail(cred,
                                "jlurgo@gmail.com", 
                                "Prueba", 
                                "Esto es un test",
                                on_success,
                                on_error);
            Assert.IsTrue(envio_ok);
        }
    }
}
