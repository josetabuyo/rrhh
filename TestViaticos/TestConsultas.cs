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
using WebRhUI;
using System.Web.UI.WebControls;
using WebRhUITestNew;

namespace TestViaticos
{
    [TestClass]
    public class TestConsultas
    {

        [TestMethod]
        public void deberia_traer_viaticos_que_esten_pendientes_del_area_939_y__perido_011012_al_261012()
        {
            var reporte1 = GeneradorDeReportes().ViaticosPorAreasCreadorasYPorEstado(Filtros(EstadosDeComision.Pendiente, AreasDeFabiMartaYCarlos(), new DateTime(2012, 10, 01), new DateTime(2012, 10, 26)), Comisiones());
            Assert.AreEqual("Area de Fabian", reporte1[0][0]);
        }

        [TestMethod]
        public void deberia_traer_viaticos_que_esten_de_la_areas_939_54_16_de_la_provincia_CORDOBA_SALTA_perido_011012_al_261012()
        {
            //FC: le tuve que mandar las provincias (ademas de al filtro) al metodo del generador, xq los necesito para conseguir especificamente las estadias
            var reporte1 = GeneradorDeReportes().ViaticoPorAreasPorProvincia(Filtros(AreasDeFabiMartaYCarlos(), SaltaYCordoba(), UnoOctubre(), VeintiseisOctubre()), Comisiones(), SaltaYCordoba());

            //FC: aca ya devuelvo una lista de lista de string..VER COMO PONER LOS TOTALIZADORES
            Assert.AreEqual(3, reporte1.Count);
        }



        [TestMethod]
        public void deberia_traer_viaticos_de_la_provincia_SALTA_y_CORDOBA_en_el_periodo_011012_261012()
        {
            var reporte = GeneradorDeReportes().ViaticosPorProvincia(Filtros(SaltaYCordoba(), UnoOctubre(), VeintiseisOctubre()), Comisiones(), SaltaYCordoba()); //Comisiones(), SaltaYCordoba(), UnoOctubre(), VeintiseisOctubre());
            Assert.AreEqual("1", reporte[0][1]);
            Assert.AreEqual("1", reporte[1][1]);
        }


        [TestMethod]
        public void deberia_traer_viaticos_de_BELEN_011012_261012()
        {
            var reporte = GeneradorDeReportes().ViaticosDePersonaPorAreas(Filtros( AreasDeFabiMartaYCarlos(), Belen(), UnoOctubre(), VeintiseisOctubre()), Comisiones());// (Comisiones(),, Belen(), new DateTime(2012, 10, 01), new DateTime(2012, 10, 26));
            Assert.AreEqual("1", reporte[0][3]);
        }



        [TestMethod]
        public void deberia_traer_las_personas_que_mas_solicitaron_viaticos_en_011012_261012()
        {
            var reporte = GeneradorDeReportes().PersonasQueMasSolicitaronViaticos(Filtros(EstadosDeComision.Aprobada, AreasDeFabiMartaYCarlos(), UnoOctubre(), VeintiseisNoviembre()), Comisiones());

            //FC: tengo que fijarme si ya lo ordena por cantidad de viaticos en orden descendente
            Assert.AreEqual(1, reporte.Count);
        }

        [TestMethod]
        public void deberia_considerar_las_estadias_comenzadas_en_el_periodo()
        {
            var primero_2012 = new DateTime(2012, 10, 23);
            var fin_del_2012 = new DateTime(2012, 12, 31);
            var fecha_antigua = new DateTime(1998, 01,02);

            var periodo = new Periodo(UnoOctubre(), VeintiseisOctubre());
            //var estadia_antigua = new Estadia(primero_2012, fin_del_2012, Salta(), 0, 0, "");
            
            //tiene como fecha de inicio la estadia
            var comision = Comisiones()[0];
            
            //FC: tengo que fijarme si ya lo ordena por cantidad de viaticos en orden descendente
            Assert.IsTrue(GeneradorDeReportes().HayAlgunaEstadiaEnElPeriodo(UnoOctubre(), VeintiseisOctubre(), comision));
            Assert.IsFalse(GeneradorDeReportes().HayAlgunaEstadiaEnElPeriodo(fecha_antigua, fecha_antigua, comision));
            Assert.IsTrue(GeneradorDeReportes().HayAlgunaEstadiaEnElPeriodo(fecha_antigua, VeintiseisOctubre(), comision));
            Assert.IsFalse(GeneradorDeReportes().HayAlgunaEstadiaEnElPeriodo(primero_2012, VeintiseisOctubre(), comision));
           
        }


        private GeneradorDeReportes GeneradorDeReportes()
        {
            return new GeneradorDeReportes();
        }

        private static DateTime VeintiseisOctubre()
        {
            return new DateTime(2012, 10, 26);
        }

        private static DateTime UnoOctubre()
        {
            return new DateTime(2012, 10, 01);
        }

        private List<ComisionDeServicio> Comisiones()
        {
            return TestObjects.Comisiones();
        }

        private Provincia Salta()
        {
            return TestObjects.Salta();
        }

        private List<Provincia> SaltaYCordoba()
        {
            List<Provincia> lista_provincias = new List<Provincia>();
            lista_provincias.Add(TestObjects.Salta());
            lista_provincias.Add(TestObjects.Cordoba());

            return lista_provincias;
        }

        private static Persona Belen()
        {
            return TestObjects.Belen();
        }

        private List<Area> AreasDeFabiMartaYCarlos()
        {
            return TestObjects.AreasDeFabiMartaYCarlos();
        }

        private DateTime VeintiseisNoviembre()
        {
            return new DateTime(2012, 11, 26);
        }

        private DateTime UnoNoviembre()
        {
            return new DateTime(2012, 11, 01);
        }

        private List<FiltroDeComisiones> Filtros(EstadosDeComision estado, List<Area> areas_creadoras, DateTime fechaDesde, DateTime fechaHasta)
        {
            var filtro_estado = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuEstadoEs(estado)));
            var filtro_area = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuAreaCreadoraEstaEn(areas_creadoras)));
            var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));
            return new List<FiltroDeComisiones>() { filtro_estado, filtro_area, filtro_periodo };
        }

        private List<FiltroDeComisiones> Filtros(List<Area> areas_creadoras, List<Provincia> lista_provincias, DateTime fechaDesde, DateTime fechaHasta)
        {
            //var filtro_estado = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuEstadoEs(estado)));
            
            var filtro_area = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuAreaCreadoraEstaEn(areas_creadoras)));
            var filtro_provincia = new FiltroDeComisiones(lista => lista.FindAll(c => c.Estadias.Any(e => lista_provincias.Any(p => p.Id == e.Provincia.Id))));
            var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));
            return new List<FiltroDeComisiones>() { filtro_area, filtro_provincia, filtro_periodo };
        }

        private List<FiltroDeComisiones> Filtros(List<Provincia> lista_provincias, DateTime fechaDesde, DateTime fechaHasta)
        {
            var filtro_provincia = new FiltroDeComisiones(lista => lista.FindAll(c => c.Estadias.Any(e => lista_provincias.Any(p => p.Id == e.Provincia.Id))));
            var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));
            return new List<FiltroDeComisiones>() { filtro_provincia, filtro_periodo };
        }

        private List<FiltroDeComisiones> Filtros(List<Area> areas_creadoras, Persona persona, DateTime fechaDesde, DateTime fechaHasta)
        {
            var filtro_area = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuAreaCreadoraEstaEn(areas_creadoras)));
            var filtro_persona = new FiltroDeComisiones(lista => lista.FindAll(c => c.Persona.Documento == persona.Documento));
            var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));

            return new List<FiltroDeComisiones>() { filtro_area, filtro_persona, filtro_periodo };
        }


    }
}
