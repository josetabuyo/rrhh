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
    public class TestRepositorioLicencias
    {
        protected Licencia unaLicencia;
        protected DateTime FechaDesde;
        protected DateTime FechaHasta;
        protected ConceptoDeLicencia unConcepto;

        [TestInitialize]
        public void Setup()
        {
            FechaDesde = new DateTime(2012, 01, 01);
            FechaHasta = new DateTime(2012, 12, 31);

            unConcepto = new ConceptoDeLicencia { Id = 1 };


            unaLicencia = new Licencia
            {
                Desde = FechaDesde,
                Hasta = FechaHasta,

                Concepto = unConcepto,

            };
        }

        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_permitidas_tiene_agus()
        {
            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados  |Id_Concepto_Licencia |Periodo    |Dias_Tomados	  
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2009       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2010       |0                        
                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2011       |0                
                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |30                |1                    |2012       |0             ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            ConceptoDeLicencia concepto = new ConceptoDeLicencia();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            Licencia licencia_por_vacaciones = new Licencia();
            licencia_por_vacaciones.Concepto = concepto;

            var persona = TestObjects.UnaPersona();
            var repo_licencia = new RepositorioLicencias(conexion);
            // ServicioDeLicencias servicio_de_licencias = new ServicioDeLicencias(new RepositorioLicencias(conexion));

            Assert.AreEqual(4, repo_licencia.GetVacacionPermitidaPara(persona, licencia_por_vacaciones).Count());
        }

        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_aprobadas_tiene_agus()
        {
            string source = @"     |NroDocumento	|Apellido	|Nombre	               |Desde	            |Hasta	           
                                   |29753914	    |CALCAGNO	|Agustín Emanuel 	   |2005-10-26 00:00:00	|2005-10-28 00:00:00
                                   |29753914	    |CALCAGNO	|Agustín Emanuel 	   |2005-10-24 00:00:00	|2005-10-26 00:00:00
                                   |29753914	    |CALCAGNO	|Agustín Emanuel 	   |2005-10-13 00:00:00	|2005-10-14 00:00:00";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var persona = TestObjects.UnaPersona();
            var repo_licencia = new RepositorioLicencias(conexion);

            //ServicioDeLicencias servicio_de_licencias = new ServicioDeLicencias(new RepositorioLicencias(conexion));

            Assert.AreEqual(3, repo_licencia.GetVacacionesAprobadasPara(persona).Count());
        }

        [TestMethod]
        public void deberia_saber_cuantas_vacaciones_pendientes_tiene_agus()
        {
            string source = @"     |NroDocumento	|Apellido	|Nombre	               |Desde	            |Hasta	           
                                   |29753914	    |CALCAGNO	|Agustín Emanuel 	   |2005-10-26 00:00:00	|2005-10-28 00:00:00
                                   |29753914	    |CALCAGNO	|Agustín Emanuel 	   |2005-10-24 00:00:00	|2005-10-26 00:00:00
                                   |29753914	    |CALCAGNO	|Agustín Emanuel 	   |2005-10-13 00:00:00	|2005-10-14 00:00:00";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var persona = TestObjects.UnaPersona();

            var repo_licencia = new RepositorioLicencias(conexion);
            //ServicioDeLicencias servicio_de_licencias = new ServicioDeLicencias(new RepositorioLicencias(conexion));

            Assert.AreEqual(3, repo_licencia.GetVacacionesPendientesPara(persona).Count());
        }

        [TestMethod]
        public void deberia_obtener_el_saldo_de_dias_solicitables_de_juan()
        {
            var repo_licencias = TestObjects.RepoLicenciaMockeado();
            var persona = TestObjects.UnaPersona();
            var repo_personas = TestObjects.RepoDePersonasMockeado();
            var tipo_planta = new TipoDePlanta { Id = 1 };
            var prorroga = new ProrrogaLicenciaOrdinaria { Periodo = 2014, UsufructoDesde = 2005, UsufructoHasta = 2013 };
            var calculador_de_vacaciones = new CalculadorDeVacaciones();
            var vacaciones_solicitables = new List<VacacionesSolicitables>() { new VacacionesSolicitables(2013, 20) };

            IConexionBD conexion = TestObjects.ConexionMockeada();
            Expect.AtLeastOnce.On(repo_personas).Method("GetTipoDePlantaActualDe").WithAnyArguments().Will(Return.Value(tipo_planta));
            Expect.AtLeastOnce.On(repo_licencias).Method("CargarDatos").WithAnyArguments().Will(Return.Value(prorroga));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionPermitidaPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPermitidas>() { new VacacionesPermitidas(persona, 2013, 20) }));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionesAprobadasPara").WithAnyArguments().Will(Return.Value(new List<VacacionesAprobadas>()));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionesPendientesPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPendientesDeAprobacion>()));


            ConceptoDeLicencia concepto = new ConceptoLicenciaAnualOrdinaria();
            concepto.Id = CodigosDeLicencias.Vacaciones;


            var fecha_de_consulta = new DateTime(2014, 02, 06);
            ServicioDeLicencias servicio_de_licencias = new ServicioDeLicencias(repo_licencias);

            Assert.AreEqual(20, servicio_de_licencias.GetSaldoLicencia(persona, concepto, fecha_de_consulta, repo_personas).Detalle.First().Disponible);
            Assert.AreEqual(2013, servicio_de_licencias.GetSaldoLicencia(persona, concepto, fecha_de_consulta, repo_personas).Detalle.First().Periodo);
        }



        [TestMethod]
        public void cuando_se_colicita_una_licencia_general_debe_invocarse_el_metodo_del_objeto_del_ConceptoLicenciaGeneral()
        {
            var repo_licencias = TestObjects.RepoLicenciaMockeado();
            ConceptoDeLicencia concepto = new ConceptoLicenciaGeneral();
            concepto.Id = 2;
            var fecha_de_consulta = new DateTime(2014, 02, 06);
            Expect.AtLeastOnce.On(repo_licencias).Method("CargarSaldoLicenciaGeneralDe").WithAnyArguments();

            var servicio_licencia = new ServicioDeLicencias(repo_licencias);
            servicio_licencia.GetSaldoLicencia(TestObjects.UnaPersona(), concepto, fecha_de_consulta, TestObjects.RepoDePersonasMockeado());

            TestObjects.Mockery().VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void cuando_se_colicita_una_licencia_para_vacaciones_debe_invocarse_el_metodo_del_objeto_del_ConceptoLicenciaAnualOrdinaria()
        {
            var repo_licencias = TestObjects.RepoLicenciaMockeado();
            var repo_personas = TestObjects.RepoDePersonasMockeado();
            ConceptoDeLicencia concepto = new ConceptoLicenciaAnualOrdinaria();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            var fecha_de_consulta = new DateTime(2014, 02, 06);
            var persona = TestObjects.UnaPersona();
            var tipo_planta = new TipoDePlanta { Id = 1 };
            var prorroga = new ProrrogaLicenciaOrdinaria { Periodo = 2014, UsufructoDesde = 2005, UsufructoHasta = 2013 };
            var calculador_de_vacaciones = new CalculadorDeVacaciones();
            var vacaciones_solicitables = new List<VacacionesSolicitables>() { new VacacionesSolicitables(2013, 20) };

            IConexionBD conexion = TestObjects.ConexionMockeada();
            Expect.AtLeastOnce.On(repo_personas).Method("GetTipoDePlantaActualDe").WithAnyArguments().Will(Return.Value(tipo_planta));
           // Expect.AtLeastOnce.On(repo_licencias).Method("CargarDatos").WithAnyArguments().Will(Return.Value(prorroga));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionPermitidaPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPermitidas>() { new VacacionesPermitidas(persona, 2013, 20) }));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionesAprobadasPara").WithAnyArguments().Will(Return.Value(new List<VacacionesAprobadas>()));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionesPendientesPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPendientesDeAprobacion>()));


            var servicio_licencia = new ServicioDeLicencias(repo_licencias);
            servicio_licencia.GetSaldoLicencia(TestObjects.UnaPersona(), concepto, fecha_de_consulta, TestObjects.RepoDePersonasMockeado());

            TestObjects.Mockery().VerifyAllExpectationsHaveBeenMet();
        }


        //        [TestMethod]
        //        public void deberia_saber_cuantas_vacaciones_permitidas_tiene_agus_para_el_2012_para_el_concepto_1()
        //        {
        //            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados |Id_Concepto_Licencia  |Periodo    |Dias_Tomados	                  
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25               |1                     |2012       |0              ";

        //            IConexionBD conexion = TestObjects.ConexionMockeada();
        //            var resultado_sp = TablaDeDatos.From(source);

        //            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

        //            var persona = TestObjects.UnaPersona();

        //            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));
        //            Licencia licencia = unaLicencia;

        //            //var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
        //            var periodo = new Periodo(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31));
        //            periodo.anio = 2012;
        //            Assert.AreEqual(25, calculador.ObtenerLicenciasPermitidasPara(persona, periodo, licencia).First().CantidadDeDias());

        //        }


        //        [TestMethod]
        //        public void Si_el_concepto_de_vacaciones_es_1_deberia_saber_cuantas_vacaciones_permitidas_tiene_agus()
        //        {
        //            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados  |Id_Concepto_Licencia |Periodo    |Dias_Tomados	  
        //                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |1                    |2009       |0                
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |2                    |2010       |0                        
        //                                |29753914  	    |CALCAGNO       |Agustín Emanuel        |201530         |20                |3                    |2011       |0                
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25                |1                    |2012       |0              ";

        //            IConexionBD conexion = TestObjects.ConexionMockeada();
        //            var resultado_sp = TablaDeDatos.From(source);

        //            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

        //            var persona = TestObjects.UnaPersona();

        //            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));

        //            var lista_de_licencias_de_agus = calculador.ObtenerVacacionesPermitidasPara(persona, null,null);

        //            var vacaciones = new VacacionesPermitidas();

        //            int total = vacaciones.CalcularTotalPermitido(lista_de_licencias_de_agus);

        //            Assert.AreEqual(45, total);

        //        }

        //        [TestMethod]
        //        public void deberia_saber_cuantas_vacaciones_aprobadas_tiene_agus()
        //        {
        //            string source = @"  |NroDocumento	|Apellido       |Nombre                 |Id_Interna     |Dias_Autorizados |Id_Concepto_Licencia  |Periodo    |Dias_Tomados	                  
        //                                |29753914	    |CALCAGNO       |Agustín Emanuel        |201530         |25               |1                     |2012       |0              ";

        //            IConexionBD conexion = TestObjects.ConexionMockeada();
        //            var resultado_sp = TablaDeDatos.From(source);

        //            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

        //            var persona = TestObjects.UnaPersona();

        //            CalculadorDeVacaciones calculador = new CalculadorDeVacaciones(new RepositorioLicencias(conexion));
        //            Licencia licencia = unaLicencia;

        //            //var vacaciones_permitidas_de_agus = new VacacionesPermitidas();
        //            var periodo = new Periodo(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31));
        //            periodo.anio = 2012;
        //            Assert.AreEqual(5, calculador.ObtenerLicenciasAprobadasPara(persona, periodo, licencia));

        //        }
    }
}
