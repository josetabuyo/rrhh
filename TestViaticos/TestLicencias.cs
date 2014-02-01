using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General;
using General.Repositorios;
using NMock2;

namespace TestViaticos
{
    [TestClass]
    public class TestLicencias
    {


        [TestMethod]
        public void calcula_el_saldo_de_10_dias_pendientes_para_juan()
        {
            var permitidas_para_juan = VacacionesPermitidas(2013, 20);
            var aprobadas_para_juan = new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013());
            var pendientes_de_aprobar_a_juan = new VacacionesPendientesDeAprobacion(juan, primero_de_febrero_2013(), cinco_de_febrero_2013());

            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            Assert.AreEqual(10, dias_restantes_de_juan);
        }


        [TestMethod]
        public void calcula_el_saldo_de_20_dias_pendientes_para_juan()
        {
            var permitidas_para_juan = VacacionesPermitidas(2013, 30);
            var aprobadas_para_juan = new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013());
            var pendientes_de_aprobar_a_juan = new VacacionesPendientesDeAprobacion(juan, primero_de_febrero_2013(), cinco_de_febrero_2013());

            var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

            Assert.AreEqual(20, dias_restantes_de_juan);
        }


        //[TestMethod]
        //public void calcula_el_saldo_de_40_dias_permitidos_para_juan_para_2_anios()
        //{
        //    var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2013, 20), VacacionesPermitidas(2012, 20) };

        //    var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, new List<VacacionesAprobadas>(), new List<VacacionesPendientesDeAprobacion>());

        //    Assert.AreEqual(40, dias_restantes_de_juan);
        //}

        //[TestMethod]
        //public void calcula_el_saldo_de_30_dias_permitidas_para_juan_para_2_anios()
        //{
        //    var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2013, 10), VacacionesPermitidas(2012, 20) };

        //    var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, new List<VacacionesAprobadas>(), new List<VacacionesPendientesDeAprobacion>());

        //    Assert.AreEqual(30, dias_restantes_de_juan);
        //}

        //[TestMethod]
        //public void calcula_el_saldo_de_25_dias_permitidas_para_juan_para_2_anios()
        //{
        //    var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2013, 10), VacacionesPermitidas(2012, 20) };
        //    var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()) };
        //    var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, new List<VacacionesPendientesDeAprobacion>());

        //    Assert.AreEqual(25, dias_restantes_de_juan);
        //}

        //[TestMethod]
        //public void calcula_el_saldo_de_20_dias_permitidas_y_aprobadas_para_juan_para_2_anios()
        //{
        //    var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2013, 10), VacacionesPermitidas(2012, 20) };
        //    var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()), new VacacionesAprobadas(juan, primero_de_febrero(), cinco_de_febrero()) };
        //    var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, new List<VacacionesPendientesDeAprobacion>());

        //    Assert.AreEqual(20, dias_restantes_de_juan);
        //}

        //[TestMethod]
        //public void calcula_el_saldo_de_20_dias_permitidas_pendientes_para_juan_para_2_anios()
        //{
        //    var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2013, 10), VacacionesPermitidas(2012, 20) };
        //    var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_enero(), cinco_de_enero()), new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero()) };
        //    var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, new List<VacacionesAprobadas>(), pendientes_de_aprobar_a_juan);

        //    Assert.AreEqual(20, dias_restantes_de_juan);
        //}

        //[TestMethod]
        //public void calcula_el_saldo_de_20_dias_permitidas__aprobadas_pendientes_para_juan_para_2_anios()
        //{
        //    var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2013, 10), VacacionesPermitidas(2012, 20) };
        //    var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero(), cinco_de_enero()) };
        //    var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_febrero(), cinco_de_febrero()) };
        //    var dias_restantes_de_juan = calculador().DiasRestantes(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan);

        //    Assert.AreEqual(20, dias_restantes_de_juan);
        //}

        [TestMethod]
        public void juan_deberia_poder_solicitar_5_dias_para_2001()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2001, 5) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>();
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();
            var fecha_de_hoy = new DateTime(2002, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2001, vacaciones_solicitables.Periodo());
            Assert.AreEqual(5, vacaciones_solicitables.CantidadDeDias());

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_5_dias_para_2001_y_10_dias_para_2002_en_el_2003()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 5), VacacionesPermitidas(2012, 10) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>();
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();
            var fecha_de_hoy = new DateTime(2003, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy);
            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2011, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(5, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2012, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(10, vacaciones_solicitables_2002.CantidadDeDias());
        }

        [TestMethod]
        public void juan_no_deberia_poder_solicitar_5_dias_para_2001_y_10_dias_para_2002_en_el_2014()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2001, 5), VacacionesPermitidas(2002, 10) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>();
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy());

            Assert.AreEqual(0, listado_solicitables.Count());
        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_7_dias_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy());
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables.Periodo());
            Assert.AreEqual(7, vacaciones_solicitables.CantidadDeDias());
        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_2_dias_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_febrero_2013(), cinco_de_febrero_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy());
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables.Periodo());
            Assert.AreEqual(2, vacaciones_solicitables.CantidadDeDias());

        }


        [TestMethod]
        public void juan_deberia_poder_solicitar_7_dias_para_2012_y_20_para_2013()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12), VacacionesPermitidas(2013, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();
            var fecha_hoy = new DateTime(2013, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_hoy);

            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(7, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2013, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(20, vacaciones_solicitables_2002.CantidadDeDias());

        }

        [TestMethod]
        public void juan_no_deberia_poder_tener_unas_vacacioens_aprobadas_en_el_2013_si_no_hay_permitidas_para_ese_periodo()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2002, 12), VacacionesPermitidas(2003, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();

            var listado_solicitables = new List<VacacionesSolicitables>();
            try
            {
                listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy());
                Assert.Fail("Deberia haber lanzado excepcion al intentar pedir licencias cuando no tiene nada autorizado");
            }
            catch (SolicitudInvalidaException e)
            {
                Assert.AreEqual(e.Message(), "Inconsistencia de datos en licencias: Existen solicitudes de licencia ingresadas sin una autorizacion previa.");
                Assert.AreEqual(0, listado_solicitables.Count());
            }
        }


        [TestMethod]
        public void juan_deberia_poder_solicitar_0_dias_para_2011_y_17_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 12), VacacionesPermitidas(2012, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();
            var fecha_hoy = new DateTime(2013, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_hoy);

            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(17, vacaciones_solicitables_2002.CantidadDeDias());

        }

        [TestMethod]
        public void en_diciembre_ya_deberia_tener_disponibles_los_dias_de_ese_anio()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 15), VacacionesPermitidas(2013, 21) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()), new VacacionesAprobadas(juan, primero_de_diciembre_2013(), veinte_de_diciembre_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>();
            var fecha_de_hoy = new DateTime(2014, 12, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy);

            var vacaciones_solicitables_2014 = listado_solicitables[0];

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2013, vacaciones_solicitables_2014.Periodo());
            Assert.AreEqual(1, vacaciones_solicitables_2014.CantidadDeDias());
        }

        [TestMethod]
        public void juan_no_deberia_poder_solicitar_tantos_dias_para_el_2013_porque_solo_en_diciembre_se_puede_tomar_las_autorizadas_del_2013()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12), VacacionesPermitidas(2013, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_febrero_2013(), cinco_de_febrero_2013()) };
            var listado_solicitables = new List<VacacionesSolicitables>();
            try
            {
                 listado_solicitables= calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy());
                Assert.Fail("Deberia haber lanzado excepcion al intentar pedir licencias cuando no tiene nada autorizado");
            }
            catch (SolicitudInvalidaException e)
            {
                Assert.AreEqual(e.Message(), "Inconsistencia de datos en licencias: Existen solicitudes de licencia ingresadas sin una autorizacion previa.");
                Assert.AreEqual(0, listado_solicitables.Count());
            }

        }

        [TestMethod]
        public void juan_deberia_poder_solicitar_12_para_2013_y_tener_pendiente_5()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12), VacacionesPermitidas(2013, 20) };
            var aprobadas_para_juan = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2014(), diez_de_marzo_2014()) };
            var pendientes_de_aprobar_a_juan = new List<VacacionesPendientesDeAprobacion>() { new VacacionesPendientesDeAprobacion(juan, primero_de_febrero_2013(), cinco_de_febrero_2013()) };
            var fecha_de_hoy = new DateTime(2014, 12, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, pendientes_de_aprobar_a_juan, fecha_de_hoy);

            var vacaciones_solicitables_2013 = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2013, vacaciones_solicitables_2013.Periodo());
            Assert.AreEqual(12, vacaciones_solicitables_2013.CantidadDeDias());
        }


        [TestMethod]
        public void deberia_calcular_dias_solicitables_a_medida_que_pasa_el_tiempo()
        {
            var vacaciones_permitidas_2011 = VacacionesPermitidas(2011, 20);
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { vacaciones_permitidas_2011, VacacionesPermitidas(2012, 20) };
            var aprobadas_para_juan_al_30_11_2013 = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, primero_de_enero_2012(), quince_de_enero_2012())  };
            var fecha_hoy = new DateTime(2013, 01, 01);
            var listado_solicitables_al_31_11_2013 = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, aprobadas_para_juan_al_30_11_2013, new List<VacacionesPendientesDeAprobacion>(), fecha_hoy);

            Assert.AreEqual(2, listado_solicitables_al_31_11_2013.Count());
            Assert.AreEqual(5, listado_solicitables_al_31_11_2013.First().CantidadDeDias());
            Assert.AreEqual(2011, listado_solicitables_al_31_11_2013.First().Periodo());
            Assert.AreEqual(20, listado_solicitables_al_31_11_2013.Last().CantidadDeDias());
            Assert.AreEqual(2012, listado_solicitables_al_31_11_2013.Last().Periodo());

            //Pasa el 01/12/2013

            var permitidas_para_juan_hasta_2013 = permitidas_para_juan_hasta_2012;

            //permitidas_para_juan_hasta_2013.Remove(vacaciones_permitidas_2011);
            permitidas_para_juan_hasta_2013.Add(VacacionesPermitidas(2013, 20));
            aprobadas_para_juan_al_30_11_2013.Add(new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()));

            var listado_solicitables_post_01_12_2013 = calculador().DiasSolicitables(permitidas_para_juan_hasta_2013, aprobadas_para_juan_al_30_11_2013, new List<VacacionesPendientesDeAprobacion>(), fecha_de_hoy());

            Assert.AreEqual(2, listado_solicitables_post_01_12_2013.Count());
            Assert.AreEqual(2012, listado_solicitables_post_01_12_2013.First().Periodo());
            Assert.AreEqual(15, listado_solicitables_post_01_12_2013.First().CantidadDeDias());
            Assert.AreEqual(20, listado_solicitables_post_01_12_2013.Last().CantidadDeDias());
            Assert.AreEqual(2013, listado_solicitables_post_01_12_2013.Last().Periodo());

            permitidas_para_juan_hasta_2013.Add(VacacionesPermitidas(2014, 30));

            aprobadas_para_juan_al_30_11_2013.Add(new VacacionesAprobadas(juan, primero_de_marzo_2014(), diez_de_marzo_2014()));
            //Pasa el 01/12/2014
            fecha_hoy = new DateTime(2015, 01, 01);

            var listado_solicitables_al_31_11_2014 = calculador().DiasSolicitables(permitidas_para_juan_hasta_2013, aprobadas_para_juan_al_30_11_2013, new List<VacacionesPendientesDeAprobacion>(), fecha_hoy);

            Assert.AreEqual(2, listado_solicitables_al_31_11_2014.Count());
            Assert.AreEqual(20, listado_solicitables_al_31_11_2014.First().CantidadDeDias());
            Assert.AreEqual(2013, listado_solicitables_al_31_11_2014.First().Periodo());
            Assert.AreEqual(30, listado_solicitables_al_31_11_2014.Last().CantidadDeDias());
            Assert.AreEqual(2014, listado_solicitables_al_31_11_2014.Last().Periodo());
        }


        [TestMethod]
        public void debe_ser_año_imputable_2011()
        {
            var aprobacion = new VacacionesAprobadas(juan, primero_de_enero_2012(), quince_de_enero_2012());

            Assert.AreEqual(1, aprobacion.AnioMaximoImputable().Count());
            Assert.AreEqual(2011, aprobacion.AnioMaximoImputable().First().Periodo());
            Assert.AreEqual(15, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
        }

        [TestMethod]
        public void debe_ser_año_imputable_2012()
        {
            var aprobacion = new VacacionesAprobadas(juan, primero_de_marzo_2013(), veinte_de_marzo_2013());

            Assert.AreEqual(1, aprobacion.AnioMaximoImputable().Count());
            Assert.AreEqual(2012, aprobacion.AnioMaximoImputable().First().Periodo());
            Assert.AreEqual(20, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
        }

        [TestMethod]
        public void debe_ser_año_imputable_2012_en_diciembre()
        {
            var aprobacion = new VacacionesAprobadas(juan, new DateTime(2012, 12, 01), new DateTime(2012, 12, 15));

            Assert.AreEqual(1, aprobacion.AnioMaximoImputable().Count());
            Assert.AreEqual(2012, aprobacion.AnioMaximoImputable().First().Periodo());
            Assert.AreEqual(15, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
        }

        [TestMethod]
        public void debe_ser_año_imputable_2011_y_2012_desde_nov_a_dic()
        {
            var aprobacion = new VacacionesAprobadas(juan, new DateTime(2012, 11, 15), new DateTime(2012, 12, 05));

            Assert.AreEqual(2, aprobacion.AnioMaximoImputable().Count());
            Assert.AreEqual(2011, aprobacion.AnioMaximoImputable().First().Periodo());
            Assert.AreEqual(16, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
            Assert.AreEqual(2012, aprobacion.AnioMaximoImputable().Last().Periodo());
            Assert.AreEqual(5, aprobacion.AnioMaximoImputable().Last().CantidadDeDias());
        }

        [TestMethod]
        public void debe_ser_año_imputable_2012_desde_dic_a_ene()
        {
            var aprobacion = new VacacionesAprobadas(juan, new DateTime(2012, 12, 15), new DateTime(2013, 01, 05));
            Assert.AreEqual(1, aprobacion.AnioMaximoImputable().Count());
            Assert.AreEqual(2012, aprobacion.AnioMaximoImputable().First().Periodo());
            Assert.AreEqual(22, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
        }

        [TestMethod]
        public void debe_ser_año_imputable_2011_y_2015_nov_a_ene()
        {
            var aprobacion = new VacacionesAprobadas(juan, new DateTime(2012, 11, 20), new DateTime(2013, 01, 05));

            Assert.AreEqual(2, aprobacion.AnioMaximoImputable().Count());
            Assert.AreEqual(2011, aprobacion.AnioMaximoImputable().First().Periodo());
            Assert.AreEqual(11, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
            Assert.AreEqual(2012, aprobacion.AnioMaximoImputable().Last().Periodo());
            Assert.AreEqual(36, aprobacion.AnioMaximoImputable().Last().CantidadDeDias());

        }

        //[TestMethod]
        //public void debe_ser_año_imputable_2012_desde_dic_a_enebaaaa()
        //{
        //    var aprobacion = new VacacionesAprobadas(juan, new DateTime(2012, 01, 01), new DateTime(2012, 11, 01));
        //    Assert.AreEqual(1, aprobacion.AnioMaximoImputable().Count());
        //    Assert.AreEqual(2011, aprobacion.AnioMaximoImputable().First().Periodo());
        //    Assert.AreEqual(306666, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
        //}

        //[TestMethod]
        //public void debe_ser_año_imputable_2012_desde_dic_a_enebaaaaeeeeeeeeeeeeeee()
        //{
        //    var aprobacion = new VacacionesAprobadas(juan, new DateTime(2012, 01, 01), new DateTime(2012, 12, 05));
        //    Assert.AreEqual(2, aprobacion.AnioMaximoImputable().Count());
        //    Assert.AreEqual(2011, aprobacion.AnioMaximoImputable().First().Periodo());
        //    Assert.AreEqual(3356666, aprobacion.AnioMaximoImputable().First().CantidadDeDias());
        //    Assert.AreEqual(2012, aprobacion.AnioMaximoImputable().Last().Periodo());
        //    Assert.AreEqual(566666, aprobacion.AnioMaximoImputable().Last().CantidadDeDias());
        //}


        [TestMethod]
        public void pregunto_por_las_vacaciones_pendientes_para_juan_y_me_indica_que_tengo_27_dias_del_2006()
        {
            var vacaciones_2006 = VacacionesPermitidas(2006, 27);
            var fecha_de_hoy = new DateTime(2007, 01, 01);

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(new List<VacacionesPermitidas>() { vacaciones_2006 }, new List<VacacionesAprobadas>(), new List<VacacionesPendientesDeAprobacion>(), fecha_de_hoy);

            new List<VacacionesSolicitables>() { new VacacionesSolicitables(2006, 27) };


            Assert.AreEqual(1, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(2006, lista_de_dias_pendientes_por_periodo.First().Periodo());
            Assert.AreEqual(27, lista_de_dias_pendientes_por_periodo.First().CantidadDeDias());
        }

        [TestMethod]
        public void deberia_tener_20_dias_perdidos_para_2009()
        {
            var fecha_de_hoy = new DateTime(2014, 01, 01);
            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidas(), VacacionesAprobadas(), new List<VacacionesPendientesDeAprobacion>(), fecha_de_hoy);

            Assert.AreEqual(2, lista_de_dias_pendientes_por_periodo.Count());

            Assert.AreEqual(5, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());
            Assert.AreEqual(25, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());
        }

        [TestMethod]
        public void deberia_partir_en_dos_el_periodo_de_noviembre_a_diciembre()
        {
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() {  VacacionesPermitidas(2011, 20), VacacionesPermitidas(2012, 20) };
            var vacaciones_solicitadas = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, new DateTime(2012, 11, 16), new DateTime(2012, 12, 20)) };

            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, new List<VacacionesPendientesDeAprobacion>(), fecha_de_hoy());

            Assert.AreEqual(1, licencia_solicitables.Count());
            Assert.AreEqual(5, licencia_solicitables.First().CantidadDeDias());
            Assert.AreEqual(2012, licencia_solicitables.First().Periodo());
        }

        public Persona juan { get; set; }

        public DateTime primero_de_febrero_2013() { return new DateTime(2013, 02, 01); }
        public DateTime cinco_de_febrero_2013() { return new DateTime(2013, 02, 05); }

        public DateTime primero_de_enero_2013() { return new DateTime(2013, 01, 01); }
        public DateTime cinco_de_enero_2013() { return new DateTime(2013, 01, 05); }

        public DateTime primero_de_marzo_2013() { return new DateTime(2013, 03, 01); }
        public DateTime diez_de_marzo_2013() { return new DateTime(2013, 03, 10); }

        public DateTime primero_de_abril_2013() { return new DateTime(2013, 04, 01); }
        public DateTime veinte_de_abril_2013() { return new DateTime(2013, 04, 20); }

        protected DateTime veinte_de_marzo_2013() { return new DateTime(2013, 03, 20); }
        protected DateTime fecha_de_hoy() { return new DateTime(2014, 01, 01); }

        protected DateTime quince_de_enero_2012()
        {
            return new DateTime(2012, 01, 15);
        }

        protected DateTime primero_de_diciembre_2013() {
            return new DateTime(2013, 12, 01);
        }

        protected DateTime veinte_de_diciembre_2013()
        {
            return new DateTime(2013, 12, 20);
        }

        protected DateTime primero_de_enero_2012()
        {
            return new DateTime(2012, 01, 01);
        }

        protected DateTime primero_de_marzo_2014()
        {
            return new DateTime(2014, 03, 01);
        }

        protected DateTime diez_de_marzo_2014()
        {
            return new DateTime(2014, 03, 10);
        }

        public CalculadorDeVacaciones calculador() { return new CalculadorDeVacaciones(TestObjects.RepoLicenciaMockeado()); }

        protected List<VacacionesPermitidas> VacacionesPermitidas()
        {
            var lista_vacaciones_permitidas = new List<VacacionesPermitidas>() { VacacionesPermitidas(2009, 20), 
                                                                                 VacacionesPermitidas(2010, 20), 
                                                                                 VacacionesPermitidas(2011, 20), 
                                                                                 VacacionesPermitidas(2012, 20), 
                                                                                 VacacionesPermitidas(2013, 25) };
            return lista_vacaciones_permitidas;
        }

        protected List<VacacionesAprobadas> VacacionesAprobadas()
        {
            var lista_vacaciones_aprobadas = new List<VacacionesAprobadas>() { new VacacionesAprobadas(juan, new DateTime(2013, 01, 01), new DateTime(2013, 02, 04)) };
            return lista_vacaciones_aprobadas;
        }

        protected VacacionesPermitidas VacacionesPermitidas(int anio, int dias)
        {
            return new VacacionesPermitidas(juan, anio, dias);
        }

    }
}
