using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General.Calendario;
using General;
using Newtonsoft.Json;

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
                Documento documento_uno = new Documento(new TipoDeDocumentoSICOI(23, "blah"), "1-12", new CategoriaDeDocumentoSICOI(0, "No Seleccionado"), new Area(1, "RRHH"), "Primer Documento creado a los fines de probar el filtro", "Urgente");
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
                Documento documento_uno = new Documento(new TipoDeDocumentoSICOI(0, "No Seleccionado"), "1-12", new CategoriaDeDocumentoSICOI(23, "blah"), new Area(1, "RRHH"), "Primer Documento creado a los fines de probar el filtro", "Urgente");
                Assert.Fail("Debio lanzar excepcion por tipo con id 0");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("para el tipo de un documento 0 no es valido como id", e.Message);
            }
        }

        /**/

        //[TestMethod]
        //public void debo_poder_convertir_de_un_objeto_DocumentoDTO_a_un_objeto_Documento()
        //{
        //    Documento_DTO_Alta doc = new Documento_DTO_Alta();

        //    doc.categoria = "1";
        //    doc.comentarios = "Prueba rápida";
        //    doc.extracto = "Prueba rápida";
        //    doc.id_area_actual = "3";
        //    doc.id_area_destino = "5";
        //    doc.numero = "45234";
        //    doc.tipo = "4";
            

        //    Documento doc_convertido =doc.toDocumento();
        //    Assert.AreEqual("45234", doc_convertido.numero);

            

        //}



        /**/






    }
}
