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

namespace TestViaticos
{
    [TestClass]
    public class TestDocumentos
    {
        CreadorDeDatosFicticios creador_de_datos;
        [TestInitialize]
        public void SetUp()
        {
        }

        [TestMethod]
        public void el_usuario_usumesa_deberia_tener_permisos_para_documentos()
        {
            Usuario usu_mesa = new Usuario();
            usu_mesa.TienePermisosParaSiCoI = true;
            Assert.IsTrue(usu_mesa.TienePermisosParaSiCoI);
        }

        [TestMethod]
        public void el_usuario_fabian_no_deberia_tener_permisos_para_documentos()
        {
            Usuario fabian = new Usuario();
            fabian.TienePermisosParaSiCoI = false;
            Assert.IsFalse(fabian.TienePermisosParaSiCoI);
        }


    }
}
