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
using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDocumentos
    {

        [TestInitialize]
        public void Setup()
        {
        }




//        [TestMethod]
//        public void deberia_poder_obtener_todos_los_documentos_que_estan_en_el_area_de_fabi()
//        {
//            string source = @"  |id_documento	|descripcion    |id_area_creadora   |id_transicion  |trans_id_area_origen       |trans_id_area_destino  |
//                                |1	            |documento1     |939                |-1             |-1                         |-1                     |
//                                |2	            |documento2     |939                |-1             |-1                         |-1                     |
//                                |3	            |documento3     |1                  |-1             |-1                         |-1                     |
//                                |4	            |documento4     |1                  |-1             |-1                         |-1                     |";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);

//            var area_de_fabi = TestObjects.AreaDeFabi();
//            var documentos = repo.GetDocumentosDelArea(area_de_fabi);

//            Assert.AreEqual(2, documentos.Count);
//        }



        [TestMethod]
        public void deberia_poder_insertar_un_documento_en_la_base_con_numero_de_ticket()
        {

            IConexionBD conexion = TestObjects.ConexionMockeada();
            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);
           

            var documento = new Documento(new TipoDeDocumentoSICOI(1, "tipo"), "1122", new CategoriaDeDocumentoSICOI(2, "cat"), TestObjects.AreaDeFabi(), "alfaomegaeee" );

            Expect.Once.On(conexion).Method("EjecutarEscalar").WithAnyArguments().Will(Return.Value("ABC123"));
            Expect.Once.On(conexion).Method("EjecutarSinResultado").WithAnyArguments().Will(Return.Value(true));

            Expect.Once.On(conexion).Method("EjecutarEscalar").WithAnyArguments().Will(Return.Value(5));
            repo.GuardarDocumento(documento, TestObjects.Fabian());
            Assert.AreEqual(5, documento.Id);
            Assert.AreEqual("ABC124", documento.ticket);

        }


        [TestMethod]
        public void deberia_poder_obtener_todos_los_documentos()
        {
            string source = @"  |IdDocumento	|IdTipoDeDocumento      |DescripcionTipoDocumento   |Numero         |IdCategoriaDeDocumento |DescripcionCategoria       |IdAreaOrigen       |NombreAreaOrigen       |Extracto      |IdAreaDestino   |NombreAreaDestino   |Ticket    |Comentarios    |FechaCargaDocumento
                                |1	            |1                      |expediente                 |e-123          |1                      |renuncia                   |54                 |INAI                   |Bla bla       |54              |Contratos           |AAA-001   |Bla bla        |2012-12-12 21:36:35.077
                                |2	            |2                      |memo                       |m-456          |2                      |pase                       |54                 |SCYMI                  |Bla bla       |54              |Legajos             |AAA-002   |Bla bla        |2012-12-12 21:36:35.077 
                                |3	            |1                      |expediente                 |e-456          |3                      |contrato                   |54                 |CNPA                   |Bla bla       |54              |Asistencia          |AAA-003   |Bla bla        |2012-12-12 21:36:35.077
                                |4	            |2                      |memo                       |e-789          |1                      |renuncia                   |54                 |DGAJ                   |Bla bla       |54              |Legajos             |AAA-004   |Bla bla        |2012-12-12 21:36:35.077 ";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);

            var documentos = repo.GetTodosLosDocumentos();

            Assert.AreEqual(4, documentos.Count);
        }

        [TestMethod]
        public void deberia_poder_actuailzar_un_documento()
        {
            string source = @"  |IdDocumento	|IdTipoDeDocumento      |DescripcionTipoDocumento   |Numero         |IdCategoriaDeDocumento |DescripcionCategoria       |IdAreaOrigen       |NombreAreaOrigen       |Extracto      |IdAreaDestino   |NombreAreaDestino   |Ticket    |Comentarios    |FechaCargaDocumento
                                |1	            |1                      |expediente                 |e-123          |1                      |renuncia                   |54                 |INAI                   |Bla bla       |54              |Contratos           |AAA-001   |Bla bla        |2012-12-12 21:36:35.077";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);

            var documento = repo.GetDocumentoPorId(1);
            Assert.AreEqual(1, documento.Id);

            documento.comentarios = "este es el comentario actualizado";

            Expect.Once.On(conexion).Method("EjecutarEscalar").WithAnyArguments().Will(Return.Value("este es el comentario actualizado"));
            
            repo.UpdateDocumento(documento, TestObjects.UsuarioMesaEntrada());

            Assert.AreEqual("este es el comentario actualizado", documento.comentarios);

        }

        [TestMethod]
        public void deberia_poder_obtener_todos_los_tipos_de_documento()
        {
            string source = @"  |Id 	        |Descripcion   |Sigla     
                                |1	            |Expediente    |E    
                                |2	            |Memo          |MEMO Nº ";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);

            var tiposDeDocumento = repo.GetTiposDeDocumentos();

            Assert.AreEqual(2, tiposDeDocumento.Count);
            Assert.AreEqual("Memo", tiposDeDocumento[1].descripcion);
        }


        [TestMethod]
        public void deberia_poder_obtener_todos_los_tipos_de_documento_con_su_sigla()
        {
            string source = @"  |Id 	        |Descripcion     |Sigla  
                                |1	            |Expediente      |E  
                                |2	            |Memo            |MEMO Nº  ";
            
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);

            var tiposDeDocumento = repo.GetTiposDeDocumentos();

            Assert.AreEqual(2, tiposDeDocumento.Count);
            Assert.AreEqual("Memo", tiposDeDocumento[1].descripcion);
            Assert.AreEqual("E", tiposDeDocumento[0].sigla);
            Assert.AreEqual("MEMO Nº", tiposDeDocumento[1].sigla);

        }

        
        [TestMethod]
        public void no_deberia_poder_guardarse_un_documento_sin_categoria()
        {
            IConexionBD conexion = TestObjects.ConexionMockeada();
            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);
            var un_doc = TestObjects.DocumentosCompletos().First();
            un_doc.categoriaDeDocumento = new CategoriaDeDocumentoSICOI(0, "No especificada");

            try
            {
                repo.GuardarDocumento(un_doc, new Usuario());
                Assert.Fail("deberia lanzar excepcion por categoria invalida");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("para la categoria de un documento 0 no es valido como id", e.Message);
            }
        }

        [TestMethod]
        public void no_deberia_poder_guardarse_un_documento_sin_tipo()
        {
            IConexionBD conexion = TestObjects.ConexionMockeada();
            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);
            var un_doc = TestObjects.DocumentosCompletos().First();
            un_doc.tipoDeDocumento = new TipoDeDocumentoSICOI(0, "No especificada");
            try
            {
                repo.GuardarDocumento(un_doc, new Usuario());
                Assert.Fail("deberia lanzar excepcion por categoria invalida");
            }
            catch (ExcepcionDeValidacion e)
            {
                Assert.AreEqual("para el tipo de un documento 0 no es valido como id", e.Message);
            }
        }


//        [TestMethod]
//        public void deberia_poder_obtener_todos_los_documentos_que_pasaron_por_el_area_de_fabi()
//        {
//            string source = @"  |id_documento	|descripcion    |id_area_creadora   |id_transicion  |trans_id_area_origen       |trans_id_area_destino  |
//                                |1	            |documento1     |1                  |1              |1                          |939                    |
//                                |2	            |documento2     |939                |1              |939                        |1                      |
//                                |3	            |documento3     |1                  |1              |-1                         |-1                     |
//                                |4	            |documento4     |1                  |1              |-1                         |-1                     |";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            RepositorioDeDocumentos repo = new RepositorioDeDocumentos(conexion);

//            var area_de_fabi = TestObjects.AreaDeFabi();
//            var documentos = repo.GetDocumentosQuePasaronPorElArea(area_de_fabi);

//            Assert.AreEqual(2, documentos.Count);
//        }
    }
}
