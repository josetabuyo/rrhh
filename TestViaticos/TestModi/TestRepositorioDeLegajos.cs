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
using General.Modi;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDeLegajos
    {
        private RepositorioDeLegajos repositorioDeLegajos;

        [TestInitialize]
        public void Setup()
        {
            string sourceDocumentos = @"    tabla       |id     |JUR	                            |ORG                            |TIPO               |FOLIO	    |fecha_comunicacion    	    |Fecha_Hasta
                                            curriculums |221    |Ministerio de desarrollo social	|Direccion de recursos humanos	|curriculum         |00-000/000	|2012-05-21 00:00:00.000	|1900-01-01 00:00:00.000
                                            domicilios  |444    |Ministerio de desarrollo social	|Secretaria de coordinacion     |domicilio          |00-000/001	|2012-05-21 00:00:00.000	|1900-01-01 00:00:00.000
                                            titulos     |333    |Ministerio de desarrollo social    |DGRHyORG	                    |titulo sec         |00-000/002	|2012-05-21 00:00:00.000	|1900-01-01 00:00:00.000";
            var resultado_sp_documentos = TablaDeDatos.From(sourceDocumentos);

            string sourceLegajo = @"    Nro_Documento   |id_interna |Nombre	    |Apellido
                                        29193500    |205171     |Jorge      |Silva	";
            var resultado_sp_legajo = TablaDeDatos.From(sourceLegajo);

            IConexionBD conexion = TestObjects.ConexionMockeada();
            
            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").With(new object[] { "dbo.LEG_GET_Datos_Personales", Is.Anything }).Will(Return.Value(resultado_sp_legajo));
            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").With(new object[] { "dbo.LEG_GET_Indice_Documentos", Is.Anything }).Will(Return.Value(resultado_sp_documentos));

            var mocks = new Mockery();
            var mock_repo_imagenes = mocks.NewMock<IRepositorioDeLegajosEscaneados>();

            var lista_imagenes = new List<ImagenModi>();
            lista_imagenes.Add(new ImagenModi("imagen_1"));
            lista_imagenes.Add(new ImagenModi("imagen_2"));

            Expect.AtLeastOnce.On(mock_repo_imagenes).Method("getImagenesParaUnLegajo").WithAnyArguments().Will(Return.Value(lista_imagenes));

            repositorioDeLegajos = new RepositorioDeLegajos(conexion, mock_repo_imagenes);

        }
        
        [TestMethod]
        public void deberia_poder_obtener_un_legajo_completo_pasando_el_numero_de_documento()
        {
            RespuestaAPedidoDeLegajo un_legajo = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.AreEqual(29193500, un_legajo.numeroDeDocumento);
            Assert.AreEqual(205171, un_legajo.idInterna);
            Assert.AreEqual("Jorge", un_legajo.nombre);
            Assert.AreEqual("Silva", un_legajo.apellido);
        }

        [TestMethod]
        public void el_legajo_de_jorge_deberia_tener_3_documentos_en_el_sistema_de_recursos_humanos()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.AreEqual(3, legajo_de_jorge.cantidadDeDocumentos());
        }

        [TestMethod]
        public void el_legajo_de_jorge_deberia_tener_2_imagenes_sin_asignar()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.AreEqual(2, legajo_de_jorge.imagenesSinAsignar.Count);
        }

        [TestMethod]
        public void uno_de_los_documentos_del_legajo_de_jorge_deberia_ser_un_curriculum()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos.Any(un_documento => un_documento.descripcionEnRRHH == "curriculum"));
        }

        [TestMethod]
        public void los_tres_documentos_del_legajo_de_jorge_deberian_estar_en_la_jurisdiccion_del_Ministerio_de_desarrollo_social()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos.All(un_documento => un_documento.jurisdiccion == "Ministerio de desarrollo social"));
        }

        [TestMethod]
        public void un_documento_del_legajo_de_jorge_deberian_pertenecer_al_organismo_secretaria_de_coordinacion()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos.Any(un_documento => un_documento.organismo == "Secretaria de coordinacion"));
        }

        [TestMethod]
        public void un_documento_del_legajo_de_jorge_deberian_tener_un_folio_igual_a_cero()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos.Any(un_documento => un_documento.folio == "00-000/000"));
        }

        [TestMethod]
        public void todos_los_documentos_del_legajo_de_jorge_deberian_tener_como_fecha_desde_el_21_de_mayo_del_2012()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos.Any(un_documento => un_documento.fechaDesde == DateTime.Parse("2012-05-21 00:00:00.000")));
        }

        [TestMethod]
        public void un_documento_del_legajo_de_jorge_deberia_se_de_la_tabla_curriculums_y_tener_como_id_221()
        {
            RespuestaAPedidoDeLegajo legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos.Any(un_documento => un_documento.tabla == "curriculums" && un_documento.id == 221));
            Assert.AreEqual("OK", legajo_de_jorge.codigoDeResultado);
        }

        [TestMethod]
        public void deberia_devolverme_LEGAJO_NO_ENCONTRADO_si_no_existe_el_legajo()
        {
            var resultado_sp_legajo = new TablaDeDatos();
            IConexionBD conexion = TestObjects.ConexionMockeada();
            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").With(new object[] { "dbo.LEG_GET_Datos_Personales", Is.Anything }).Will(Return.Value(resultado_sp_legajo));

            var mocks = new Mockery();
            var mock_repo_imagenes = mocks.NewMock<IRepositorioDeLegajosEscaneados>();
           
            repositorioDeLegajos = new RepositorioDeLegajos(conexion, mock_repo_imagenes);

            RespuestaAPedidoDeLegajo un_legajo = repositorioDeLegajos.getLegajoPorDocumento(234);

            Assert.AreEqual("LEGAJO_NO_ENCONTRADO", un_legajo.codigoDeResultado);
        }
    }
}
