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
using Newtonsoft.Json;

namespace General
{
    [TestClass]
    public class TestFiltroSiCoI
    {

        private List<Documento> documentos;
        private BuscadorDeDocumentos buscador_de_documentos;

        [TestInitialize]
        public void setUp()
        {
            documentos = TestObjects.DocumentosCompletos();
            buscador_de_documentos = new BuscadorDeDocumentos(documentos);
        }
        
// Test con Filtro por Nombre de Áreas
        [TestMethod]
        public void al_buscar_por_el_area_del_usuario_logueado_debe_traer_todos_los_documentos_que_aun_son_responsabilidad_de_dicha_area()
        {
            Area area_de_fabi = TestObjects.AreaDeFabi();
            
            List<Documento> documentos = TestObjects.Mensajeria().DocumentosEn(area_de_fabi);
            
            Assert.AreEqual(1, documentos.Count);
            //Assert.IsTrue(documentos.Any(documento => documento.areaOrigen.Equals(area_de_fabi)));
        }

        [TestMethod]
        public void al_buscar_por_fecha_desde_y_fecha_hasta_debería_traer_todos_los_documentos_cuya_fecha_está_incluída_en_ese_rango()
        {
            DateTime fecha_desde = DateTime.Parse("02/12/2012");
            DateTime fecha_hasta = DateTime.Parse("31/12/2012");

            FiltroDeDocumentos desde_fecha = new FiltroDeDocumentosPorFechaDesde(fecha_desde);
            FiltroDeDocumentos hasta_fecha = new FiltroDeDocumentosPorFechaHasta(fecha_hasta);

            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();

            filtros.Add(desde_fecha);
            filtros.Add(hasta_fecha);

            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(1, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(documento => (documento.fecha < fecha_hasta && documento.fecha > fecha_desde)));
        }


        [TestMethod]
        public void al_buscar_por_una_palabra_del_extracto_del_documento_debe_traer_todos_los_documentos_que_cumplen_con_ello()
        {
            string extracto = "creado";

            

            FiltroDeDocumentos filtro_extracto = new FiltroDeDocumentosPorExtracto(extracto);
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
            filtros.Add(filtro_extracto);
            
            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(4, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.extracto.Contains(extracto)));
        }

        [TestMethod]
        public void al_buscar_por_nombre_de_numero_de_documento_y_fechas_desde_y_hasta_y_extracto_de_un_documento_debe_traer_todos_los_documentos_que_cumplen_con_ello()
        {
            string numero_dumento = "123";
            DateTime fecha_desde = DateTime.Parse("12/12/2012");
            DateTime fecha_hasta = DateTime.Parse("02/12/2015");
            string extracto = "creado";
           

            

            FiltroDeDocumentos por_nro = new FiltroDeDocumentosPorNumero(numero_dumento);
            FiltroDeDocumentos desde_fecha = new FiltroDeDocumentosPorFechaDesde(fecha_desde);
            FiltroDeDocumentos hasta_fecha = new FiltroDeDocumentosPorFechaHasta(fecha_hasta);
            FiltroDeDocumentos por_extracto = new FiltroDeDocumentosPorExtracto(extracto);
   
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
                filtros.Add(por_nro);
                filtros.Add(desde_fecha);
                filtros.Add(hasta_fecha);
                filtros.Add(por_extracto);
            
            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(1, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.numero.Contains(numero_dumento)));
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.fecha > fecha_desde && unDocumento.fecha < fecha_hasta));
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.extracto.Contains(extracto)));
        }

        //Hacer
        //Test para los comentarios
        [TestMethod]
        public void al_buscar_por_una_palabra_del_comentario_del_documento_debe_traer_todos_los_documentos_que_cumplen_con_ello()
        {
            string comentario = "Urgen";

            

            FiltroDeDocumentos filtro_comentario = new FiltroDeDocumentosPorComentarios(comentario);
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
            filtros.Add(filtro_comentario);

            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(3, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.comentarios.Contains(comentario)));
        }
        //test para numero de tickets
        [TestMethod]
        public void al_buscar_por_un_numero_de_ticket__de_documento_o_parte_de_él_debe_traer_todos_los_documentos_que_cumplen_con_ello()
        {
            string ticket = "AA";

            

            FiltroDeDocumentos filtro_ticket = new FiltroDeDocumentosPorTicket(ticket);
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
            filtros.Add(filtro_ticket);

            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(3, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.ticket.Contains(ticket)));
        }

        //test para numero de tickets
        [TestMethod]
        public void el_filtro_por_numero_de_ticket_debe_ser_case_insensitive()
        {
            string ticket = "aAb321";

            FiltroDeDocumentos filtro_ticket = new FiltroDeDocumentosPorTicket(ticket);
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
            filtros.Add(filtro_ticket);

            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(1, documentos_filtrados.Count);
        }

        ////test para filtro por area origen
        //[TestMethod]
        //public void se_deberia_poder_filtrar_por_el_area_que_envio_un_documento_a_un_area_especificada()
        //{
        //    var filtro_por_transicion = new FiltroDeDocumentosPorTransicion(TestObjects.Mensajeria(),);
        //    var filtros = new List<FiltroDeDocumentos>();
        //    filtros.Add(filtro_por_transicion);

        //    List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

        //    Assert.AreEqual(1, documentos_filtrados.Count);
        //}


        //test para categoría
        [TestMethod]
        public void al_buscar_por_una_categoria_de_documento_debe_traer_todos_los_documentos_que_cumplen_con_ello()
        {
            int categoria = TestObjects.LICENCIAS; //no está igual que la descripción de la categoría por las dudas de que no sea un combo y se cambio Equals por Contains

            FiltroDeDocumentos filtro_categoría = new FiltroDeDocumentosPorCategoria(categoria);
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
            filtros.Add(filtro_categoría);

            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(2, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.categoriaDeDocumento.Id == categoria));
        }

        
        //test para tipo de documento
        [TestMethod]
        public void al_buscar_por_un_tipo_de_documento_debe_traer_todos_los_documentos_que_cumplen_con_ello()
        {
   
            FiltroDeDocumentos filtro_tipo_documento = new FiltroDeDocumentosPorTipoDocumento(TestObjects.EXPEDIENTE.Id);
            List<FiltroDeDocumentos> filtros = new List<FiltroDeDocumentos>();
            filtros.Add(filtro_tipo_documento);

            List<Documento> documentos_filtrados = buscador_de_documentos.Buscar(filtros);

            Assert.AreEqual(2, documentos_filtrados.Count);
            Assert.IsTrue(documentos_filtrados.TrueForAll(unDocumento => unDocumento.tipoDeDocumento.Equals(TestObjects.EXPEDIENTE)));
        }

        [TestMethod]
        public void un_deserializador_de_filtros_deberia_poder_desserializar_un_filtro_de_documentos_por_numero_de_ticket()
        {
            var filtroSerializado = JsonConvert.SerializeObject(new {tipoDeFiltro="FiltroDeDocumentosPorTicket", ticket="AAA016" });
            var desSerializador = new DesSerializadorDeFiltros(TestObjects.Mensajeria());
            var filtroDesSerializado = desSerializador.DesSerializarFiltro(filtroSerializado);
            var docu1 = new Documento();
            docu1.ticket = "AAA016";
            var docu2 = new Documento();
            docu2.ticket = "AAA000";
            Assert.IsTrue(filtroDesSerializado.aplicaPara(docu1));
            Assert.IsFalse(filtroDesSerializado.aplicaPara(docu2));
        }  

        private List<Documento> DocumentosCompletos()
        {
            return TestObjects.DocumentosCompletos();
        }

        private TestObjects _test_objects;
        private TestObjects test_objects()
        {
            if (_test_objects == null)
                _test_objects = new TestObjects();
            return _test_objects;
        }
    }
}
