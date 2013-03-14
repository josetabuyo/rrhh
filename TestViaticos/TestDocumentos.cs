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
        [TestInitialize]
        public void SetUp()
        {
        }

        [TestMethod]
        public void no_deberia_poder_tener_un_documento_sin_categoria()
        {
            try
            {
                Documento documento_uno = new Documento(new TipoDeDocumentoSICOI(23, "blah"), "1-12", new CategoriaDeDocumentoSICOI(0, "No Seleccionado"), new Area(1, "RRHH"), "Primer Documento creado a los fines de probar el filtro", TestObjects.AreaDeFabi(), "Urgente");
                Assert.Fail("Debio lanzar excepcion por categoria con id 0");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("para la categoria de un documento 0 no es valido como id", e.Message);
            }
        }

        [TestMethod]
        public void no_deberia_poder_tener_un_documento_sin_tipo()
        {
            try
            {
                Documento documento_uno = new Documento(new TipoDeDocumentoSICOI(0, "No Seleccionado"), "1-12", new CategoriaDeDocumentoSICOI(23, "blah"), new Area(1, "RRHH"), "Primer Documento creado a los fines de probar el filtro", TestObjects.AreaDeFabi(), "Urgente");
                Assert.Fail("Debio lanzar excepcion por tipo con id 0");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("para el tipo de un documento 0 no es valido como id", e.Message);
            }
        }

    }
}
