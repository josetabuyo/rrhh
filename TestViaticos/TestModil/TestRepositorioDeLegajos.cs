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


            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").With(new string[] { "dbo.LEG_GET_Datos_Personales" }).Will(Return.Value(resultado_sp_legajo));
            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").With(new string[] { "dbo.LEG_GET_Indice_Documentos" }).Will(Return.Value(resultado_sp_documentos));

            repositorioDeLegajos = new RepositorioDeLegajos(conexion);

        }
        
        [TestMethod]
        public void deberia_poder_obtener_un_legajo_completo_pasando_el_numero_de_documento()
        {
            LegajoModil un_legajo = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.AreEqual(29193500, un_legajo.numeroDeDocumento);
            Assert.AreEqual(205171, un_legajo.idInterna);
            Assert.AreEqual("Jorge", un_legajo.nombre);
            Assert.AreEqual("Silva", un_legajo.apellido);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ExcepcionDeLegajoInexistente), "El legajo no existe")]
        //public void si_el_legajo_que_busco_no_existe_deberia_tirar_una_excepcion_acorde()
        //{
        //    LegajoModil un_legajo = repositorioDeLegajos.getLegajo(234);
        //}

        [TestMethod]
        public void el_legajo_de_jorge_deberia_tener_3_documentos_en_el_sistema_de_recursos_humanos()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.AreEqual(3, legajo_de_jorge.cantidadDeDocumentos());
        }

        [TestMethod]
        public void uno_de_los_documentos_del_legajo_de_jorge_deberia_ser_un_curriculum()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos().Any(un_documento => un_documento.descripcionEnRRHH == "curriculum"));
        }

        [TestMethod]
        public void los_tres_documentos_del_legajo_de_jorge_deberian_estar_en_la_jurisdiccion_del_Ministerio_de_desarrollo_social()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos().All(un_documento => un_documento.jurisdiccion == "Ministerio de desarrollo social"));
        }

        [TestMethod]
        public void un_documento_del_legajo_de_jorge_deberian_pertenecer_al_organismo_secretaria_de_coordinacion()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos().Any(un_documento => un_documento.organismo == "Secretaria de coordinacion"));
        }

        [TestMethod]
        public void un_documento_del_legajo_de_jorge_deberian_tener_un_folio_igual_a_cero()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos().Any(un_documento => un_documento.folio == "00-000/000"));
        }

        [TestMethod]
        public void todos_los_documentos_del_legajo_de_jorge_deberian_tener_como_fecha_desde_el_21_de_mayo_del_2012()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos().Any(un_documento => un_documento.fechaDesde == DateTime.Parse("2012-05-21 00:00:00.000")));
        }

        [TestMethod]
        public void un_documento_del_legajo_de_jorge_deberia_se_de_la_tabla_curriculums_y_tener_como_id_221()
        {
            LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajoPorDocumento(29193500);
            Assert.IsTrue(legajo_de_jorge.documentos().Any(un_documento => un_documento.tabla == "curriculums" && un_documento.id == 221));
        }

        //[TestMethod]
        //public void uno_de_los_documentos_del_legajo_de_jorge_deberia_ser_un_curriculum()
        //{
        //    LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajo(123);
        //    Assert.IsTrue(legajo_de_jorge.documentos().Any(un_documento => un_documento.tieneImagenes()));
        //}

        //[TestMethod]
        //public void uno_de_los_documentos_del_legajo_de_jorge_deberia_ser_un_curriculum_que_ya_tiene_una_imagen_scanneada_y_dos_pendientes()
        //{
        //    LegajoModil legajo_de_jorge = repositorioDeLegajos.getLegajo(123);
        //    var documentos_con_imagenes = legajo_de_jorge.documentos().FindAll(un_documento => un_documento.tieneImagenes());
        //    var documentos_sin_imagenes = legajo_de_jorge.documentos().FindAll(un_documento => !un_documento.tieneImagenes());
        //    Assert.AreEqual(1, documentos_con_imagenes.Count);
        //    Assert.AreEqual(2, documentos_sin_imagenes.Count);
        //}
    }
}
