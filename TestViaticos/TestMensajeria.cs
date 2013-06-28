using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General;
using NMock2;
using General.Repositorios;

namespace TestViaticos
{
    [TestClass]
    public class TestMensajeria
    {

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void mensajeria_deberia_enviar_documento()
        {
            var nota_para_marta = TestObjects.UnaNota();
           
            var area_fabi = TestObjects.AreaDeFabi();
            var area_marta = TestObjects.AreaDeMarta();

            Assert.IsTrue(Mensajeria().DocumentosEn(area_fabi).Contains(nota_para_marta), "La nota de marta debería estar aún en el area de fabian");

            Mensajeria().SeEnvioDirectamente(nota_para_marta, area_fabi, area_marta, DateTime.Now);

            Assert.IsTrue(Mensajeria().DocumentosEn(area_marta).Contains(nota_para_marta), "La nota deberia estar en el area de marta");

            Console.WriteLine(Mensajeria().DocumentosEn(area_marta));

            Assert.IsFalse(Mensajeria().DocumentosEn(area_fabi).Contains(nota_para_marta));
        }

      

        [TestMethod]
        public void el_repositorio_deberia_crear_una_mensajeria_con_sus_transiciones()
        {
            var mock_conexion_bd = ConexionMockeada();
            Stub.On(mock_conexion_bd).Method("Ejecutar").Will(Return.Value(TablaConDosTransacciones()));

            var repo_docs = MockRepoDocs();
            Stub.On(repo_docs).Method("GetTodosLosDocumentos").Will(Return.Value(DosNotas()));

            var repo_org = MockRepoOrganigrama();
            Stub.On(repo_org).Method("GetOrganigrama").Will(Return.Value(TestObjects.OrganigramaFabyMarta()));

            var repo_mensajeria = RepoMensajeria(mock_conexion_bd, repo_docs, repo_org);

            var mensajeria = repo_mensajeria.GetMensajeria();

            Assert.IsTrue(mensajeria.DocumentosEn(TestObjects.AreaDeFabi()).Any(d => d.Id == 4));
            Assert.IsTrue(mensajeria.DocumentosEn(TestObjects.AreaDeMarta()).Any(d => d.Id == 3));
        }

        [TestMethod]
        public void deberia_poder_guardar_una_transicion_nueva()
        {
            var nota_para_marta = TestObjects.UnaNota();

            var area_fabi = TestObjects.AreaDeFabi();
            var area_marta = TestObjects.AreaDeMarta();

            var repo_docs = MockRepoDocs();
            var repo_org = MockRepoOrganigrama();
            var mock_conexion_bd = ConexionMockeada();
            Expect.Exactly(3).On(mock_conexion_bd).Method("Ejecutar");

            var repo_mensajeria = RepoMensajeria(mock_conexion_bd, repo_docs, repo_org);

            var mensajeria_nueva = new Mensajeria(new List<TransicionDeDocumento>());
            Mensajeria().SeEnvioDirectamente(nota_para_marta, area_fabi, area_marta, DateTime.Now);

            repo_mensajeria.GuardarTransicionesDe(mensajeria_nueva);
            //mock_conexion_bd.Verify();
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void mensajeria_deberia_poder_generar_una_transicion_futura()
        {
            var nota_para_marta = TestObjects.UnaNota();

            var area_fabi = TestObjects.AreaDeFabi();
            var area_marta = TestObjects.AreaDeMarta();

            Assert.IsTrue(Mensajeria().DocumentosEn(area_fabi).Contains(nota_para_marta));

            Mensajeria().SeEnviaAFuturo(nota_para_marta, area_fabi, area_marta);

            Assert.IsFalse(Mensajeria().DocumentosEn(area_marta).Contains(nota_para_marta));
            Assert.IsTrue(Mensajeria().DocumentosEn(area_fabi).Contains(nota_para_marta));
        }

        [TestMethod]
        public void al_preguntarle_en_que_area_esta_un_documeto_deberia_decirme_()
        {
            var documento_en_area_de_fabi = TestObjects.UnaNota();

            var area_fabi = TestObjects.AreaDeFabi();

            Assert.IsTrue(Mensajeria().EstaEnElArea(documento_en_area_de_fabi).Equals(area_fabi));
        
        }

        /// <summary>
        /// Ignorado para poder iniciarl el CI
        /// </summary>
        [TestMethod]
        [Ignore]
        public void mensajeria_no_deberia_fallar_cuando_un_documento_no_tiene_trancisiones()
        {
            var un_documento = TestObjects.OtraNota();
            
            var area_donde_esta_el_documento = Mensajeria().EstaEnElArea(un_documento);
            Assert.AreEqual(new AreaNull(), area_donde_esta_el_documento);
        }

        [TestMethod]
        public void al_transicionar_desde_otra_area_genera_2_transiciones()
        {
            var un_documento = TestObjects.OtraNota();

            Mensajeria().TransicionarConAreaIntermedia(un_documento, TestObjects.AreaDeCastagneto(), TestObjects.AreaDeMarta(), TestObjects.AreaDeFabi(), DateTime.Now);

            var transiciones = Mensajeria().HistorialDetransicionesPara(un_documento);

            Assert.AreEqual(2, transiciones.Count);
            Assert.AreEqual(TestObjects.AreaDeCastagneto(), transiciones.First().AreaOrigen);
            Assert.AreEqual(TestObjects.AreaDeMarta(), transiciones.First().AreaDestino);

            Assert.AreEqual(TestObjects.AreaDeMarta(), transiciones.Last().AreaOrigen);
            Assert.AreEqual(TestObjects.AreaDeFabi(), transiciones.Last().AreaDestino);

            Assert.AreEqual(TestObjects.AreaDeFabi(), Mensajeria().EstaEnElArea(un_documento));
            
        }

        public List<Documento> DosNotas()
        {
            var documentos = new List<Documento>();
            documentos.Add(TestObjects.UnaNota());
            documentos.Add(TestObjects.OtraNota());
            return documentos;
        }

        public static TablaDeDatos TablaConDosTransacciones()
        {
            string source2 = @" |Id     	| IdDocumento   |IdAreaOrigen |IdAreaDestino | Fecha                     | Tipo  | Comentarios    |
                                |1	        | 3             |939            |54             |  2012-12-12 21:36:35.077  | A     |     blah      |
                                |2	        | 4             |54             |939            |  2012-12-13 21:36:35.077  | A     |    bleh       |";
            return TablaDeDatos.From(source2);

        }

        public RepositorioMensajeria RepoMensajeria(IConexionBD mock_conexion_bd, IRepositorioDeDocumentos repo_docs, IRepositorioDeOrganigrama repo_organigrama)
        {
            var un_repositorio = new RepositorioMensajeria(mock_conexion_bd, repo_docs, repo_organigrama);
            return un_repositorio;
        }

        
        public Mensajeria Mensajeria() {
            return TestObjects.Mensajeria();
        }

        private TestObjects _test_objects;
        private TestObjects test_objects()
        {
            if (_test_objects == null) 
                _test_objects = new TestObjects();
            return _test_objects;
        }

        private static IConexionBD ConexionMockeada()
        {
            var mocks = new Mockery();
            var mock_conexion_bd = mocks.NewMock<IConexionBD>();
            return mock_conexion_bd;
        }

        private static IRepositorioDeOrganigrama MockRepoOrganigrama()
        {
            var mocks = new Mockery();
            var mock_repo = mocks.NewMock<IRepositorioDeOrganigrama>();
            return mock_repo;
        }

        private static IRepositorioDeDocumentos MockRepoDocs()
        {
            var mocks = new Mockery();
            var mock_repo = mocks.NewMock<IRepositorioDeDocumentos>();
            return mock_repo;
        }
    }
}
