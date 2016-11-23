using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General;
using General.Repositorios;
using NMock2;
using General.MAU;

namespace TestViaticos
{
    [TestClass]
    public class TestLicencias
    {
        AnalisisDeLicenciaOrdinaria analisis;
        List<VacacionesPermitidas> perdidas;
        [TestInitialize]
        public void setup()
        {
            analisis = new AnalisisDeLicenciaOrdinaria();
            perdidas = new List<VacacionesPermitidas>();
        }

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

        //analisis ya testeado
        [TestMethod]
        public void juan_deberia_poder_solicitar_5_dias_para_2001()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2001, 5) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>();
            var fecha_de_hoy = new DateTime(2002, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2001, vacaciones_solicitables.Periodo());
            Assert.AreEqual(5, vacaciones_solicitables.CantidadDeDias());

        }

        [TestMethod]
        public void deberia_acarrear_lo_sobrante_de_una_licencia_al_periodo_siguiente()
        {
            var fecha_de_hoy = new DateTime(2002, 01, 01);
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 10), VacacionesPermitidas(2013, 10) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, F("01/02/2014"), F("15/02/2014")),
                                                                            new VacacionesAprobadas(juan, F("01/04/2015"), F("01/04/2015")),
                                                                                };
            //var repo = TestObjects.RepoLicenciaMockeado();
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));
            //Expect.AtLeastOnce.On(repo).
            //Method("GetProrrogaPlantaGeneral").
            //Will(Return.Value(5));
            
            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(3, analisis.Count());
            AssertAnalisis(analisis.First(), 2012, F("01/02/2014"), F("15/02/2014"), 10, 10);
            AssertAnalisis(analisis.At(1), 2013, DateTime.MinValue, DateTime.MinValue, 5, 10);
            AssertAnalisis(analisis.Last(), 0, F("01/04/2015"), F("01/04/2015"), 1, 0);
            
        }

        //analisis ya testeado
        [TestMethod]
        public void juan_deberia_poder_solicitar_5_dias_para_2001_y_10_dias_para_2002_en_el_2003()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 5), VacacionesPermitidas(2012, 10) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>();

            var fecha_de_hoy = new DateTime(2003, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);
            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2011, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(5, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2012, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(10, vacaciones_solicitables_2002.CantidadDeDias());
        }

        #region analisis_de_licencias

        [TestMethod]
        public void deberia_ver_un_registro_de_analisis_cuando_juan_puede_solicitar_5_dias_para_el_2001()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2001, 5) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>();
            var fecha_de_hoy = new DateTime(2002, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            AssertAnalisis(analisis.First(), 2001, DateTime.MinValue, DateTime.MinValue, 0, 5);
        }

        [TestMethod]
        public void deberia_ver_dos_registros_de_analisis_cuando_juan_tiene_autorizados_5_dias_para_2001_y_10_dias_para_2002_en_el_2003()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 5), VacacionesPermitidas(2012, 10) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>();
            var fecha_de_hoy = new DateTime(2003, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, analisis.Count());

            AssertAnalisis(analisis.First(), 2011, DateTime.MinValue, DateTime.MinValue, 0, 5);
            AssertAnalisis(analisis.Last(), 2012, DateTime.MinValue, DateTime.MinValue, 0, 10);

        }

        [TestMethod]
        public void deberia_ver_el_registro_de_analisis_cuando_juan_solicita_7_dias_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()) };
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(1, analisis.Count());
            AssertAnalisis(analisis.First(), 2012, primero_de_enero_2013(), cinco_de_enero_2013(), 5, 12);
        }

        [TestMethod]
        public void deberia_ver_dos_registros_de_analisis_si_juan_solicitaro_2_veces_dias_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_febrero_2013(), cinco_de_febrero_2013()) };
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, analisis.Count());
            AssertAnalisis(analisis.First(), 2012, primero_de_enero_2013(), cinco_de_enero_2013(), 5, 12);
            AssertAnalisis(analisis.Last(), 0, primero_de_febrero_2013(), cinco_de_febrero_2013(), 5, 0);
        }

        [TestMethod]
        public void deberia_ver_dos_registros_cuando_juan_solicita_7_dias_para_2012_y_le_quedan_20_mas_para_2013()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12), VacacionesPermitidas(2013, 20) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()) };
            var fecha_hoy = new DateTime(2013, 01, 01);
            TestObjects.ResetInstanceRepoLicencia();
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, analisis.Count());
            AssertAnalisis(analisis.First(), 2012, primero_de_enero_2013(), cinco_de_enero_2013(), 5, 12);
            AssertAnalisis(analisis.Last(), 2013, DateTime.MinValue, DateTime.MinValue, 0, 20);
        }

        [TestMethod]
        public void una_segunda_licencia_para_una_misma_autorizacion_debe_agregar_un_segundo_registro()
        {
            var f1 = new DateTime(2008, 02, 04);
            var f2 = new DateTime(2008, 02, 08);
            var f3 = new DateTime(2008, 01, 19);
            var f4 = new DateTime(2008, 01, 23);
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2007, 10) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, f1, f2), new VacacionesAprobadas(juan, f3, f4) };
            var fecha_hoy = new DateTime(2016, 01, 01);
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, analisis.Count());
            AssertAnalisis(analisis.First(), 2007, f1, f2, 5, 10);
            AssertAnalisis(analisis.Last(), 0, f3, f4, 5, 0);
        }

        [TestMethod]
        public void una_segunda_licencia_para_una_misma_autorizacion_debe_agregar_un_segundo_registro_antes_de_la_siguiente_authorizacion()
        {
            var f1 = new DateTime(2008, 02, 04);
            var f2 = new DateTime(2008, 02, 08);
            var f3 = new DateTime(2008, 01, 19);
            var f4 = new DateTime(2008, 01, 23);
            var f5 = new DateTime(2010, 12, 27);
            var f6 = new DateTime(2011, 01, 20);

            juan = new Persona();
            var repo = TestObjects.RepoLicenciaMockeado();
            juan.TipoDePlanta = new TipoDePlantaGeneral(1, "General", repo);

            var prorroga = new ProrrogaLicenciaOrdinaria();
            prorroga.Periodo = 2007;
            prorroga.UsufructoDesde = 2000;
            prorroga.UsufructoDesde = 2010;

            Expect.AtLeastOnce.On(repo).
            Method("GetProrrogaPlantaGeneral").
            Will(Return.Value(5));

            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2007, 10), VacacionesPermitidas(2008, 25) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, f1, f2), new VacacionesAprobadas(juan, f3, f4), new VacacionesAprobadas(juan, f5, f6) };
            var fecha_hoy = new DateTime(2016, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, juan, analisis, perdidas);

            Assert.AreEqual(3, analisis.Count());
            AssertAnalisis(analisis.First(), 2007, f1, f2, 5, 10);
            AssertAnalisis(analisis.lineas[1], 0, f3, f4, 5, 0);
            AssertAnalisis(analisis.Last(), 2008, f5, f6, 25, 25);
        }

        public DateTime F(string fh)
        {
            return new DateTime(int.Parse(fh.Substring(6, 4)), int.Parse(fh.Substring(3, 2)), int.Parse(fh.Substring(0, 2)));
        }

        public VacacionesAprobadas A(string f1, string f2)
        {
            return new VacacionesAprobadas(juan, F(f1), F(f2));
        }

        [TestMethod]
        public void una_segunda_licencia_para_una_misma_autorizacion_debe_agregar_un_segundo_registro_antes_de_la_siguiente_authorizacion2()
        {

            juan = new Persona();
            var repo = TestObjects.RepoLicenciaMockeado();
            juan.TipoDePlanta = new TipoDePlantaGeneral(1, "General", repo);

            var prorroga = new ProrrogaLicenciaOrdinaria();
            prorroga.Periodo = 2007;
            prorroga.UsufructoDesde = 2000;
            prorroga.UsufructoDesde = 2010;

            Expect.AtLeastOnce.On(repo).
            Method("GetProrrogaPlantaGeneral").
            Will(Return.Value(5));

            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2007, 10), VacacionesPermitidas(2008, 25), VacacionesPermitidas(2009, 25), VacacionesPermitidas(2010, 30) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() {             
                A("04/02/2008", "08/02/2008"),
                A("19/01/2009", "23/01/2009"),
                A("27/12/2010", "20/01/2011"),
                A("21/01/2011", "18/02/2011")
            };
            var fecha_hoy = new DateTime(2016, 01, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, juan, analisis, perdidas);

            Assert.AreEqual(5, analisis.Count());
            AssertAnalisis(analisis.First(), 2007, F("04/02/2008"), F("08/02/2008"), 5, 10);
            AssertAnalisis(analisis.lineas[1], 0, F("19/01/2009"), F("23/01/2009"), 5, 0);
            AssertAnalisis(analisis.lineas[2], 2008, F("27/12/2010"), F("20/01/2011"), 25, 25);
            AssertAnalisis(analisis.lineas[3], 2009, F("21/01/2011"), F("18/02/2011"), 25, 25);
            AssertAnalisis(analisis.Last(), 2010, DateTime.MinValue, DateTime.MinValue, 4, 30);

        }

        [TestMethod]
        public void cuando_una_solicitud_excede_lo_autorizado_se_muestra_imputado_a_dos_periodos()
        {
            var f1 = new DateTime(2011, 01, 21);
            var f2 = new DateTime(2011, 02, 18);
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2009, 25), VacacionesPermitidas(2010, 30) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, f1, f2) };
            var fecha_hoy = new DateTime(2016, 01, 01);
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));


            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, analisis.Count());
            AssertAnalisis(analisis.First(), 2009, f1, f2, 25, 25);
            AssertAnalisis(analisis.Last(), 2010, DateTime.MinValue, DateTime.MinValue, 4, 30);
        }

        [TestMethod]
        public void cuando_pierde_una_cantidad_de_licencias_deberia_mostrarlas_como_perdidas()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2010, 35), VacacionesPermitidas(2011, 35), VacacionesPermitidas(2012, 35) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, F("06/01/2014"), F("17/01/2014")) };
            var fecha_hoy = new DateTime(2016, 01, 01);
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(analisis.Count(), 5);
            AssertAnalisis(analisis.First(), 2010, DateTime.MinValue, DateTime.MinValue, 0, 35);
            AssertAnalisis(analisis.At(1), 0, DateTime.MinValue, DateTime.MinValue, 35, 0);
            AssertAnalisis(analisis.At(2), 2011, DateTime.MinValue, DateTime.MinValue, 0, 35);
            AssertAnalisis(analisis.At(3), 0, DateTime.MinValue, DateTime.MinValue, 35, 0);
            AssertAnalisis(analisis.Last(), 2012, F("06/01/2014"), F("17/01/2014"), 12, 35);
        }

        [TestMethod]
        public void deberia_distinguir_entre_las_perdidas_explicitamente_en_la_tabla_y_las_perdidas_por_falta_de_prorroga()
        {

            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2009, 12), VacacionesPermitidas(2017, 35) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, F("06/01/2010"), F("17/01/2010")) };
            TestObjects.ResetInstanceRepoLicencia();
            var r = TestObjects.RepoLicenciaMockeado();
            Expect.AtLeastOnce.On(r).Method("GetVacasPermitidasPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPermitidas>() { VacacionesPermitidas(2009, 35) }));

            var fecha_hoy = new DateTime(2016, 01, 01);

            calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(analisis.Count(), 3);
            AssertAnalisis(analisis.First(), 2009, F("06/01/2010"), F("17/01/2010"), 12, 35);
            AssertAnalisis(analisis.At(1), 0, DateTime.MinValue, DateTime.MinValue, 23, 0);
            AssertAnalisis(analisis.Last(), 2017, DateTime.MinValue, DateTime.MinValue, 0, 35);
        }

        [TestMethod]
        public void deberia_marcar_licencias_perdidas_por_estar_vencidas()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(1998, 35), VacacionesPermitidas(2014, 35) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, F("09/03/2002"), F("15/03/2002")),
                                                                            new VacacionesAprobadas(juan, F("09/12/2002"), F("03/01/2003")),
                                                                            new VacacionesAprobadas(juan, F("01/01/2015"), F("02/01/2015"))
                                                                            };
            juan = new Persona();
            var repo = TestObjects.RepoLicenciaMockeado();
            juan.TipoDePlanta = new TipoDePlantaGeneral(1, "General", repo);

            Expect.AtLeastOnce.On(repo).
            Method("GetProrrogaPlantaGeneral").
            Will(Return.Value(5));
            var fecha_hoy = new DateTime(2016, 01, 01);
            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, juan, analisis, perdidas);

            Assert.AreEqual(4, analisis.Count());
            AssertAnalisis(analisis.First(), 1998, F("09/03/2002"), F("15/03/2002"), 7, 35);
            AssertAnalisis(analisis.At(1), 0, F("09/12/2002"), F("03/01/2003"), 26, 0);
            AssertAnalisis(analisis.At(2), 0, DateTime.MinValue, DateTime.MinValue, 2, 0); //perdidas
            Assert.IsFalse(analisis.At(2).PerdidaExplicitamente);
            Assert.IsTrue(analisis.At(2).PerdidaPorVencimiento);
        }

        /*[TestMethod]
        public void deberia_reproducirse_el_caso_de_bianco()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(1998, 35), VacacionesPermitidas(1999, 35) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, F("09/03/2002"), F("15/03/2002")),
                                                                            new VacacionesAprobadas(juan, F("09/12/2002"), F("03/01/2003")),
                                                                            new VacacionesAprobadas(juan, F("20/12/2003"), F("21/12/2003"))
                                                                            };
            var fecha_hoy = new DateTime(2016, 01, 01);
            juan = new Persona();
            var repo = TestObjects.RepoLicenciaMockeado();
            juan.TipoDePlanta = new TipoDePlantaGeneral(1, "General", repo);

            Expect.AtLeastOnce.On(repo).
            Method("GetProrrogaPlantaGeneral").
            Will(Return.Value(5));

            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, juan, analisis, perdidas);

            Assert.AreEqual(4, analisis.Count());
            AssertAnalisis(analisis.First(), 1997, F("09/03/2002"), F("15/03/2002"), 7, 35);
            AssertAnalisis(analisis.At(1), 0, F("09/12/2002"), F("03/01/2003"), 2, 0);
            AssertAnalisis(analisis.At(2), 0, DateTime.MinValue, DateTime.MinValue, 26, 0); //perdidas
            AssertAnalisis(analisis.Last(), 1998, F("20/12/2003"), F("21/12/2003"), 2, 35);
        }*/

        protected void AssertAnalisis(LogCalculoVacaciones registro, int periodo, DateTime desde, DateTime hasta, int descontados, int autorizados)
        {
            Assert.AreEqual(periodo, registro.PeriodoAutorizado);
            Assert.AreEqual(desde, registro.LicenciaDesde);
            Assert.AreEqual(hasta, registro.LicenciaHasta);
            Assert.AreEqual(descontados, registro.CantidadDiasDescontados);
            Assert.AreEqual(autorizados, registro.CantidadDiasAutorizados);
        }

        #endregion


        //no analizada (redundante)
        [TestMethod]
        public void juan_no_deberia_poder_solicitar_5_dias_para_2001_y_10_dias_para_2002_en_el_2014()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2001, 5), VacacionesPermitidas(2002, 10) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>();

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(0, listado_solicitables.Count());
        }

        //analizada
        [TestMethod]
        public void juan_deberia_poder_solicitar_7_dias_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()) };
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables.Periodo());
            Assert.AreEqual(7, vacaciones_solicitables.CantidadDeDias());
        }

        //analizada
        [TestMethod]
        public void juan_deberia_poder_solicitar_2_dias_para_2012()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_febrero_2013(), cinco_de_febrero_2013()) };
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);
            var vacaciones_solicitables = listado_solicitables.First();

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables.Periodo());
            Assert.AreEqual(2, vacaciones_solicitables.CantidadDeDias());
        }

        //analizada
        [TestMethod]
        public void juan_deberia_poder_solicitar_7_dias_para_2012_y_20_para_2013()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12), VacacionesPermitidas(2013, 20) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()) };
            var fecha_hoy = new DateTime(2013, 01, 01);
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            var vacaciones_solicitables_2001 = listado_solicitables.First();
            var vacaciones_solicitables_2002 = listado_solicitables.Last();

            Assert.AreEqual(2, listado_solicitables.Count());
            Assert.AreEqual(2012, vacaciones_solicitables_2001.Periodo());
            Assert.AreEqual(7, vacaciones_solicitables_2001.CantidadDeDias());
            Assert.AreEqual(2013, vacaciones_solicitables_2002.Periodo());
            Assert.AreEqual(20, vacaciones_solicitables_2002.CantidadDeDias());
        }

        [TestMethod]
        [Ignore]//temporal
        public void juan_no_deberia_poder_tener_unas_vacacioens_aprobadas_en_el_2013_si_no_hay_permitidas_para_ese_periodo()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2002, 12), VacacionesPermitidas(2003, 20) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()) };

            var listado_solicitables = new List<VacacionesSolicitables>();
            try
            {
                listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);
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
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()) };
            var fecha_hoy = new DateTime(2013, 01, 01);

            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

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
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()), new VacacionesAprobadas(juan, primero_de_diciembre_2013(), veinte_de_diciembre_2013()) };
            var fecha_de_hoy = new DateTime(2014, 12, 01);

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            var vacaciones_solicitables_2014 = listado_solicitables[0];

            Assert.AreEqual(1, listado_solicitables.Count());
            Assert.AreEqual(2013, vacaciones_solicitables_2014.Periodo());
            Assert.AreEqual(1, vacaciones_solicitables_2014.CantidadDeDias());
        }

        [TestMethod]
        [Ignore]//temporal
        public void juan_no_deberia_poder_solicitar_tantos_dias_para_el_2013_porque_solo_en_diciembre_se_puede_tomar_las_autorizadas_del_2013()
        {
            var permitidas_para_juan = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 12), VacacionesPermitidas(2013, 20) };
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2013(), diez_de_marzo_2013()), new VacacionesPendientesDeAprobacion(juan, primero_de_febrero_2013(), cinco_de_febrero_2013()) };
            var listado_solicitables = new List<VacacionesSolicitables>();
            try
            {
                listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);
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
            var aprobadas_para_juan = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2013(), cinco_de_enero_2013()), new VacacionesAprobadas(juan, primero_de_marzo_2014(), diez_de_marzo_2014()), new VacacionesPendientesDeAprobacion(juan, new DateTime(2014, 04, 01), new DateTime(2014, 04, 05)) };
            var fecha_de_hoy = new DateTime(2014, 12, 01);
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan));

            var listado_solicitables = calculador().DiasSolicitables(permitidas_para_juan, aprobadas_para_juan, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

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
            var aprobadas_para_juan_al_30_11_2013 = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, primero_de_enero_2012(), quince_de_enero_2012()) };
            var fecha_hoy = new DateTime(2013, 01, 01);
            Expect.AtLeastOnce.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan_hasta_2012));

            var listado_solicitables_al_31_11_2013 = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, aprobadas_para_juan_al_30_11_2013, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

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

            var listado_solicitables_post_01_12_2013 = calculador().DiasSolicitables(permitidas_para_juan_hasta_2013, aprobadas_para_juan_al_30_11_2013, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, listado_solicitables_post_01_12_2013.Count());
            Assert.AreEqual(2012, listado_solicitables_post_01_12_2013.First().Periodo());
            Assert.AreEqual(15, listado_solicitables_post_01_12_2013.First().CantidadDeDias());
            Assert.AreEqual(20, listado_solicitables_post_01_12_2013.Last().CantidadDeDias());
            Assert.AreEqual(2013, listado_solicitables_post_01_12_2013.Last().Periodo());

            permitidas_para_juan_hasta_2013.Add(VacacionesPermitidas(2014, 30));

            aprobadas_para_juan_al_30_11_2013.Add(new VacacionesAprobadas(juan, primero_de_marzo_2014(), diez_de_marzo_2014()));
            //Pasa el 01/12/2014
            fecha_hoy = new DateTime(2015, 01, 01);

            var listado_solicitables_al_31_11_2014 = calculador().DiasSolicitables(permitidas_para_juan_hasta_2013, aprobadas_para_juan_al_30_11_2013, fecha_hoy, TestObjects.UnaPersona(), analisis, perdidas);

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

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(new List<VacacionesPermitidas>() { vacaciones_2006 }, new List<SolicitudesDeVacaciones>(), fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            new List<VacacionesSolicitables>() { new VacacionesSolicitables(2006, 27) };


            Assert.AreEqual(1, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(2006, lista_de_dias_pendientes_por_periodo.First().Periodo());
            Assert.AreEqual(27, lista_de_dias_pendientes_por_periodo.First().CantidadDeDias());
        }

        [TestMethod]
        public void deberia_tener_20_dias_perdidos_para_2009()
        {
            var fecha_de_hoy = new DateTime(2014, 01, 01);
            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidas(), VacacionesAprobadas(), fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);
            //las aprob se deben imputar a 2011 a 2012
            Assert.AreEqual(2, lista_de_dias_pendientes_por_periodo.Count());

            Assert.AreEqual(5, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());
            Assert.AreEqual(25, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());
        }


        [TestMethod]
        public void carla_solicita_aprobacion_de_33_dias_de_vacaciones_que_deberan_imputarse_a_20_permitidas_del_2012_y_20_permitidas_del_2013_quedandole_7_dias()
        {
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesPendientesDeAprobacion(juan, new DateTime(2014, 01, 06), new DateTime(2014, 02, 07)) };
            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var fecha_de_hoy = new DateTime(2014, 03, 06);

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasParaCarla(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(1, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(7, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());

        }

        private void ElRepoDeLicenciasNoDevuelveVacasPermitidas()
        {
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(new List<VacacionesPermitidas>()));
        }

        [TestMethod]
        public void carla_jamas_se_pidio_licencias___no_tiene_pendientes_ni_aprobadas___y_se_consulta_el_formulario_quedando_20_para_2012_y_20_para_2013()
        {
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>();

            var fecha_de_hoy = new DateTime(2014, 03, 06);

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasParaCarla(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(20, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());
            Assert.AreEqual(20, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());

        }


        [TestMethod]
        public void carla_solicita_aprobacion_de_un_periodo_que_abarca_noviembre_y_diciembre_y_debe_partirse_por_la_aplicacion_de_prorroga_A()
        {
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesPendientesDeAprobacion(juan, new DateTime(2013, 11, 26), new DateTime(2013, 12, 5)) };
            var fecha_de_hoy = new DateTime(2013, 11, 30); //SI CAMBIO LA FECHA CAMBIA LA IMPUTACION
            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasParaCarla2(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(1, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(15, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());

        }
        //Y ENCIMA CON LAS VACACIONES APROBADAS PASA LO MISMO, CUANDO FUNCIONE ESTE TEST, PROBAR CAMBIANDO PENDIENTESDEAPROBACION POR APROBADAS
        [TestMethod]
        public void carla_solicita_aprobacion_de_un_periodo_que_abarca_noviembre_y_diciembre_y_debe_partirse_por_la_aplicacion_de_prorroga_A_A()
        {
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesPendientesDeAprobacion(juan, new DateTime(2013, 11, 26), new DateTime(2013, 12, 5)) };
            var fecha_de_hoy = new DateTime(2013, 12, 01); //SI CAMBIO LA FECHA CAMBIA LA IMPUTACION

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasParaCarla2(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(1, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(15, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());

        }



        //[TestMethod]
        //public void test_para_hacer_fallar_la_prorroga() //Deberia pedir un límite futuro para reservar vacaciones??? cuánto límite --> hasta 6 meses (hablado con faby)
        //{
        //    var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesPendientesDeAprobacion(juan, new DateTime(2015, 03, 01), new DateTime(2014, 03, 30)) };
        //    var fecha_de_hoy = new DateTime(2014, 01, 01);

        //    var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasal2014(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona());

        //    Assert.AreEqual(1, lista_de_dias_pendientes_por_periodo.Count());
        //    Assert.AreEqual(5, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());

        //}


        [TestMethod]
        public void test_para_hacer_fallar_la_prorroga_2()
        {
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesPendientesDeAprobacion(juan, new DateTime(2014, 03, 01), new DateTime(2014, 03, 30)) };
            var fecha_de_hoy = new DateTime(2014, 01, 01);
            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasal2014(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(5, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());
            Assert.AreEqual(35, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());
        }


        [TestMethod]
        public void carla_solicita_aprobacion_de_un_periodo_que_abarca_noviembre_y_diciembre_y_debe_partirse_por_la_aplicacion_de_prorroga_B()
        {
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesPendientesDeAprobacion(juan, new DateTime(2013, 11, 26), new DateTime(2013, 12, 5)) };
            var fecha_de_hoy = new DateTime(2013, 10, 25);
            ElRepoDeLicenciasNoDevuelveVacasPermitidas();

            var lista_de_dias_pendientes_por_periodo = calculador().DiasSolicitables(VacacionesPermitidasParaCarla(), vacaciones_solicitadas, fecha_de_hoy, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(2, lista_de_dias_pendientes_por_periodo.Count());
            Assert.AreEqual(10, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2012).CantidadDeDias());
            Assert.AreEqual(20, lista_de_dias_pendientes_por_periodo.Find(l => l.Periodo() == 2013).CantidadDeDias());
        }


        [TestMethod]
        public void deberia_partir_en_dos_el_periodo_de_noviembre_a_diciembre()
        {
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 20), VacacionesPermitidas(2012, 20) };
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, new DateTime(2012, 11, 16), new DateTime(2012, 12, 20)) };
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan_hasta_2012));

            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, fecha_de_hoy(), TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(1, licencia_solicitables.Count());
            Assert.AreEqual(5, licencia_solicitables.First().CantidadDeDias());
            Assert.AreEqual(2012, licencia_solicitables.First().Periodo());
        }


        [TestMethod]
        public void deberia_partir_en_dos_el_periodo_de_noviembre_a_diciembre_perdiendo_dias()
        {
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { VacacionesPermitidas(2010, 20), VacacionesPermitidas(2011, 20) };
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, new DateTime(2012, 11, 16), new DateTime(2012, 12, 15)) };
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan_hasta_2012));

            var fecha = new DateTime(2012, 12, 20);
            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, fecha, TestObjects.UnaPersona(), analisis, perdidas);

            Assert.AreEqual(1, licencia_solicitables.Count());
            Assert.AreEqual(5, licencia_solicitables.First().CantidadDeDias());
            Assert.AreEqual(2011, licencia_solicitables.First().Periodo());
        }

        [TestMethod]
        public void deberia_eliminar_los_periodos_que_no_esten_comprendidos_en_prorroga_para_un_contratado_sin_aprobadas()
        {
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 20), VacacionesPermitidas(2012, 20), VacacionesPermitidas(2013, 20), };
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>();
            var una_persona = TestObjects.UnaPersona();
            una_persona.TipoDePlanta = new TipoDePlantaContratado();

            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, fecha_de_hoy(), una_persona, analisis, perdidas);

            Assert.AreEqual(2, licencia_solicitables.Count());
            Assert.AreEqual(2012, licencia_solicitables.First().Periodo());
        }

        [TestMethod]
        [Ignore]//temporal
        public void deberia_eliminar_los_periodos_que_no_esten_comprendidos_en_prorroga_para_un_permanente_sin_aprobadas()
        {
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { VacacionesPermitidas(2004, 20), VacacionesPermitidas(2005, 20), VacacionesPermitidas(2006, 20), VacacionesPermitidas(2007, 20), VacacionesPermitidas(2008, 20), VacacionesPermitidas(2009, 20), VacacionesPermitidas(2010, 20), VacacionesPermitidas(2011, 20), VacacionesPermitidas(2012, 20), VacacionesPermitidas(2013, 20) };
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>();
            var una_persona = TestObjects.UnaPersona();

            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, fecha_de_hoy(), una_persona, analisis, perdidas);

            Assert.AreEqual(9, licencia_solicitables.Count());
            Assert.AreEqual(2005, licencia_solicitables.First().Periodo());
        }

        [TestMethod]
        public void deberia_eliminar_los_periodos_que_no_esten_comprendidos_en_prorroga_para_un_contratado_con_aprobadas()
        {
            var una_persona = TestObjects.UnaPersona();
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 20), VacacionesPermitidas(2012, 20), VacacionesPermitidas(2013, 20) };
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(una_persona, new DateTime(2012, 01, 01), new DateTime(2012, 01, 15)) };//del 01-01 al 04-02
            Expect.Once.On((TestObjects.RepoLicenciaMockeado())).Method("GetVacasPermitidasPara").Will(Return.Value(permitidas_para_juan_hasta_2012));

            una_persona.TipoDePlanta = new TipoDePlantaContratado();

            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, fecha_de_hoy(), una_persona, analisis, perdidas);

            Assert.AreEqual(2, licencia_solicitables.Count());
            Assert.AreEqual(2012, licencia_solicitables.First().Periodo());
            Assert.AreEqual(20, licencia_solicitables.First().CantidadDeDias());
        }

        [TestMethod]
        [Ignore]//temporal
        public void deberia_eliminar_los_periodos_que_no_esten_comprendidos_en_prorroga_para_un_permanente_con_aprobadas()
        {
            var una_persona = TestObjects.UnaPersona();
            var permitidas_para_juan_hasta_2012 = new List<VacacionesPermitidas>() { VacacionesPermitidas(2004, 20), VacacionesPermitidas(2005, 20), VacacionesPermitidas(2006, 20), VacacionesPermitidas(2007, 20), VacacionesPermitidas(2008, 20), VacacionesPermitidas(2009, 20), VacacionesPermitidas(2010, 20), VacacionesPermitidas(2011, 20), VacacionesPermitidas(2012, 20), VacacionesPermitidas(2013, 20) };
            var vacaciones_solicitadas = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(una_persona, new DateTime(2012, 01, 01), new DateTime(2012, 01, 15)) };//del 01-01 al 04-02

            una_persona.TipoDePlanta = new TipoDePlantaGeneral(1, "Planta Permanente", TestObjects.RepoLicenciaMockeado());

            var licencia_solicitables = calculador().DiasSolicitables(permitidas_para_juan_hasta_2012, vacaciones_solicitadas, fecha_de_hoy(), una_persona, analisis, perdidas);

            Assert.AreEqual(9, licencia_solicitables.Count());
            Assert.AreEqual(2005, licencia_solicitables.First().Periodo());
            Assert.AreEqual(20, licencia_solicitables.First().CantidadDeDias());
        }

        [TestMethod]
        public void deberia_partise_la_solicitud_si_contiene_al_30_de_nov_y_1_de_dic()
        {
            var una_persona = TestObjects.UnaPersona();
            var solicitud_original = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(una_persona, new DateTime(2012, 11, 25), new DateTime(2012, 12, 05)) };
            List<SolicitudesDeVacaciones> solicitudes = calculador().DividirSolicitudes(solicitud_original);

            Assert.AreEqual(2, solicitudes.Count());
            Assert.AreEqual(new DateTime(2012, 11, 25), solicitudes.First().Desde());
            Assert.AreEqual(new DateTime(2012, 11, 30), solicitudes.First().Hasta());
            Assert.AreEqual(new DateTime(2012, 12, 01), solicitudes.Last().Desde());
            Assert.AreEqual(new DateTime(2012, 12, 05), solicitudes.Last().Hasta());
        }

        [TestMethod]
        public void deberia_partise_la_solicitud_si_contiene_al_30_de_nov_y_1_de_dic_y_poner_el_anio_correspondiente()
        {
            var una_persona = TestObjects.UnaPersona();
            var solicitud_original = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(una_persona, new DateTime(2012, 11, 25), new DateTime(2013, 01, 10)) };
            List<SolicitudesDeVacaciones> solicitudes = calculador().DividirSolicitudes(solicitud_original);

            Assert.AreEqual(2, solicitudes.Count());
            Assert.AreEqual(new DateTime(2012, 11, 25), solicitudes.First().Desde());
            Assert.AreEqual(new DateTime(2012, 11, 30), solicitudes.First().Hasta());
            Assert.AreEqual(new DateTime(2012, 12, 01), solicitudes.Last().Desde());
            Assert.AreEqual(new DateTime(2013, 01, 10), solicitudes.Last().Hasta());
        }


        [TestMethod]
        public void deberia_partir_bien_las_solicitudes_cuando_hay_mas_de_una()
        {
            var una_persona = TestObjects.UnaPersona();
            var solicitud_original = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(una_persona, new DateTime(2012, 05, 01), new DateTime(2012, 05, 15)), new VacacionesAprobadas(una_persona, new DateTime(2012, 11, 25), new DateTime(2013, 01, 10)) };
            List<SolicitudesDeVacaciones> solicitudes = calculador().DividirSolicitudes(solicitud_original);

            Assert.AreEqual(3, solicitudes.Count());
            Assert.AreEqual(new DateTime(2012, 05, 01), solicitudes.First().Desde());
            Assert.AreEqual(new DateTime(2012, 05, 15), solicitudes.First().Hasta());
            Assert.AreEqual(new DateTime(2012, 11, 25), solicitudes[1].Desde());
            Assert.AreEqual(new DateTime(2012, 11, 30), solicitudes[1].Hasta());
            Assert.AreEqual(new DateTime(2012, 12, 01), solicitudes.Last().Desde());
            Assert.AreEqual(new DateTime(2013, 01, 10), solicitudes.Last().Hasta());
        }

        [TestMethod]
        public void no_deberia_partise_la_solicitud_si_solo_contiene_al_30_de_nov()
        {
            var una_persona = TestObjects.UnaPersona();
            var solicitud_original = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(una_persona, new DateTime(2012, 11, 25), new DateTime(2012, 11, 30)) };
            List<SolicitudesDeVacaciones> solicitudes = calculador().DividirSolicitudes(solicitud_original);

            Assert.AreEqual(1, solicitudes.Count());
            Assert.AreEqual(new DateTime(2012, 11, 25), solicitudes.First().Desde());
            Assert.AreEqual(new DateTime(2012, 11, 30), solicitudes.First().Hasta());
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

        protected DateTime primero_de_diciembre_2013()
        {
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

        protected List<SolicitudesDeVacaciones> VacacionesAprobadas()
        {
            var lista_vacaciones_aprobadas = new List<SolicitudesDeVacaciones>() { new VacacionesAprobadas(juan, new DateTime(2013, 01, 01), new DateTime(2013, 02, 04)) };
            return lista_vacaciones_aprobadas;
        }

        protected VacacionesPermitidas VacacionesPermitidas(int anio, int dias)
        {
            return new VacacionesPermitidas(juan, anio, dias);
        }

        protected List<VacacionesPermitidas> VacacionesPermitidasParaCarla()
        {
            var lista_vacaciones_permitidas = new List<VacacionesPermitidas>() { VacacionesPermitidas(2012, 20), 
                                                                                 VacacionesPermitidas(2013, 20)};
            return lista_vacaciones_permitidas;
        }

        protected List<VacacionesPermitidas> VacacionesPermitidasParaCarla2()
        {
            var lista_vacaciones_permitidas = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 20), 
                                                                                 VacacionesPermitidas(2012, 20)};
            return lista_vacaciones_permitidas;
        }

        protected List<VacacionesPermitidas> VacacionesPermitidasal2014()
        {
            var lista_vacaciones_permitidas = new List<VacacionesPermitidas>() { VacacionesPermitidas(2011, 35), 
                                                                                 VacacionesPermitidas(2012, 35),
                                                                                 VacacionesPermitidas(2013, 35)};
            return lista_vacaciones_permitidas;
        }
    }
}
