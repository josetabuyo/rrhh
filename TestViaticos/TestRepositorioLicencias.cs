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


            var persona = TestObjects.UnaPersona();
            var repo_licencia = new RepositorioLicencias(conexion);
            // ServicioDeLicencias servicio_de_licencias = new ServicioDeLicencias(new RepositorioLicencias(conexion));

            Assert.AreEqual(4, repo_licencia.GetVacacionPermitidaDescontandoPerdidasPara(persona, TestObjects.ConceptoLicenciaOrdinaria(), new List<VacacionesPermitidas>()).Count());
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
            var tipo_planta = new TipoDePlantaContratado();// { Id = 22 };
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
        [Ignore] //para que ande el teamcity
        public void cuando_se_solicita_una_licencia_general_debe_invocarse_el_metodo_del_objeto_del_ConceptoLicenciaGeneral()
        {
            var repo_licencias = TestObjects.RepoLicenciaMockeado();
            ConceptoDeLicencia concepto = new ConceptoLicenciaGeneral(2);           
            var fecha_de_consulta = new DateTime(2014, 02, 06);

            Expect.AtLeastOnce.On(repo_licencias).Method("CargarSaldoLicenciaGeneralDe").WithAnyArguments();

            var servicio_licencia = new ServicioDeLicencias(repo_licencias);
            servicio_licencia.GetSaldoLicencia(TestObjects.UnaPersona(), concepto, fecha_de_consulta, TestObjects.RepoDePersonasMockeado());

            TestObjects.Mockery().VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void cuando_se_solicita_una_licencia_para_vacaciones_debe_invocarse_el_metodo_del_objeto_del_ConceptoLicenciaAnualOrdinaria()
        {
            var repo_licencias = TestObjects.RepoLicenciaMockeado();
            var repo_personas = TestObjects.RepoDePersonasMockeado();
            ConceptoDeLicencia concepto = new ConceptoLicenciaAnualOrdinaria();
            concepto.Id = CodigosDeLicencias.Vacaciones;
            var fecha_de_consulta = new DateTime(2014, 02, 06);
            var persona = TestObjects.UnaPersona();
            var tipo_planta = new TipoDePlantaContratado();// { Id = 1 };
            var prorroga = new ProrrogaLicenciaOrdinaria { Periodo = 2014, UsufructoDesde = 2005, UsufructoHasta = 2013 };
            var calculador_de_vacaciones = new CalculadorDeVacaciones();
            var vacaciones_solicitables = new List<VacacionesSolicitables>() { new VacacionesSolicitables(2013, 20) };

            IConexionBD conexion = TestObjects.ConexionMockeada();
            Expect.AtLeastOnce.On(repo_personas).Method("GetTipoDePlantaActualDe").WithAnyArguments().Will(Return.Value(tipo_planta));
            //Expect.AtLeastOnce.On(repo_licencias).Method("CargarDatos").WithAnyArguments().Will(Return.Value(prorroga));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionPermitidaPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPermitidas>() { new VacacionesPermitidas(persona, 2013, 20) }));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionesAprobadasPara").WithAnyArguments().Will(Return.Value(new List<VacacionesAprobadas>()));
            Expect.AtLeastOnce.On(repo_licencias).Method("GetVacacionesPendientesPara").WithAnyArguments().Will(Return.Value(new List<VacacionesPendientesDeAprobacion>()));


            var servicio_licencia = new ServicioDeLicencias(repo_licencias);
            servicio_licencia.GetSaldoLicencia(TestObjects.UnaPersona(), concepto, fecha_de_consulta, TestObjects.RepoDePersonasMockeado());

            TestObjects.Mockery().VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void cuando_le_solicito_a_un_tipo_de_planta_la_prorroga_debe_devolver_su_correspondiente_prorroga()
        {
            TipoDePlantaContratado tipo_planta_contratado = new TipoDePlantaContratado();
            TipoDePlantaGeneral tipo_planta_general = new TipoDePlantaGeneral(1, "Planta Permanente", TestObjects.RepoLicenciaMockeado());
            var fecha_calculo = new DateTime(2014, 01, 01);

            Assert.AreEqual(2012, tipo_planta_contratado.Prorroga(fecha_calculo).UsufructoDesde);
            Assert.AreEqual(2005, tipo_planta_general.Prorroga(fecha_calculo).UsufructoDesde);   
        }

        [TestMethod]
        public void deberia_obtener_los_feriados_del_2014_que_son_3_mas_1_fijos()
        {
            string source = @"     |id		|fecha	                |año	   |periodico	           
                                   |1	    |2014-10-26 00:00:00	|2014 	   |false
                                   |2	    |2014-07-14 00:00:00	|2014 	   |false
                                   |3	    |2010-01-01 00:00:00	|2014 	   |true
                                   |4	    |2012-01-23 00:00:00	|2012 	   |false
                                   |5	    |2014-03-01 00:00:00	|2014 	   |false";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.AreEqual(4, repo_licencia.ObtenerFeriados(2014).Count());
        }

        [TestMethod]
        public void deberia_obtener_los_dias_habiles_entre_el_01_10_y_15_10_que_son_10_porque_hay_un_feriado()
        {
            DateTime desde = new DateTime(2014, 10, 01);
            DateTime hasta = new DateTime(2014, 10, 15);
            string source = @"     |id		|fecha	                |año	   |periodico	           
                                   |1	    |2014-10-26 00:00:00	|2014 	   |false
                                   |2	    |2014-10-14 00:00:00	|2014 	   |false
                                   |3	    |2010-01-01 00:00:00	|2014 	   |true
                                   |4	    |2012-01-23 00:00:00	|2012 	   |false
                                   |5	    |2014-03-01 00:00:00	|2014 	   |false";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.AreEqual(10, repo_licencia.DiasHabilesEntreFechas(desde, hasta));
        }

        [TestMethod]
        public void deberia_obtener_los_dias_habiles_entre_el_20_12_y_15_01_que_son_16_porque_hay_un_feriado()
        {
            DateTime desde = new DateTime(2014, 12, 20);
            DateTime hasta = new DateTime(2015, 01, 15);
            string source = @"     |id		|fecha	                |año	   |periodico	           
                                   |1	    |2014-10-26 00:00:00	|2014 	   |false
                                   |2	    |2014-10-14 00:00:00	|2014 	   |false
                                   |3	    |2010-01-01 00:00:00	|2010 	   |true
                                   |4	    |2012-01-23 00:00:00	|2012 	   |false
                                   |5	    |2001-12-24 00:00:00	|2001 	   |true
                                   |5	    |2001-12-25 00:00:00	|2001 	   |true";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.AreEqual(16, repo_licencia.DiasHabilesEntreFechas(desde, hasta));
        }

        [TestMethod]
        public void es_sabado_por_lo_tanto_es_fin_de_semana()
        {
            DateTime sabado_25_de_octubre_de_2014 = new DateTime(2014, 10, 25);
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var repo_licencia = new RepositorioLicencias(conexion);

            Assert.IsTrue(repo_licencia.EsFinDeSemana(sabado_25_de_octubre_de_2014));
        }

        [TestMethod]
        public void es_domingo_por_lo_tanto_es_fin_de_semana()
        {
            DateTime sabado_26_de_octubre_de_2014 = new DateTime(2014, 10, 26);
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var repo_licencia = new RepositorioLicencias(conexion);

            Assert.IsTrue(repo_licencia.EsFinDeSemana(sabado_26_de_octubre_de_2014));
        }

        [TestMethod]
        public void es_miercoles_y_no_es_fin_de_semana()
        {
            DateTime miercoles_22_de_octubre_de_2014 = new DateTime(2014, 10, 22);
            IConexionBD conexion = TestObjects.ConexionMockeada();
            var repo_licencia = new RepositorioLicencias(conexion);

            Assert.IsFalse(repo_licencia.EsFinDeSemana(miercoles_22_de_octubre_de_2014));
        }

        [TestMethod]
        public void quiero_pedirme_4_dias_habiles_para_matrimonio_de_mi_hijo_y_no_puedo_porque_son_3()
        {
            DateTime desde = new DateTime(2014, 11, 11);
            DateTime hasta = new DateTime(2014, 11, 14);
            int id_matrimonio = 19;
            string source = @"     |Dias_Autorizados	|id_Concepto	|Dias_Habiles  |id		|fecha	                |año	   |periodico      
                                   |3	                |19	            |True          |1	    |2014-11-24 00:00:00	|2014 	   |false
                                   |3	                |19	            |True          |2	    |2014-12-08 00:00:00	|2014 	   |true
                                   |3	                |19	            |True          |3	    |2010-01-01 00:00:00	|2010 	   |true
                                   |3	                |19	            |True          |4	    |2012-12-26 00:00:00	|2014 	   |false
                                   |3	                |19	            |True          |5	    |2001-12-24 00:00:00	|2001 	   |true
                                   |3	                |19	            |True          |5	    |2001-12-25 00:00:00	|2001 	   |true";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.IsFalse(repo_licencia.DiasHabilitadosEntreFechas(desde, hasta, id_matrimonio));
            Assert.AreEqual(4, repo_licencia.DiasHabilesEntreFechas(desde, hasta));
        }

        [TestMethod]
        public void quiero_pedirme_3_dias_habiles_para_matrimonio_de_mi_hijo_y_puedo_porque_son_3()
        {
            DateTime desde = new DateTime(2014, 11, 14);
            DateTime hasta = new DateTime(2014, 11, 18);
            int id_matrimonio = 19;
            string source = @"     |Dias_Autorizados	|id_Concepto	|Dias_Habiles  |id		|fecha	                |año	   |periodico      
                                   |3	                |19	            |True          |1	    |2014-11-24 00:00:00	|2014 	   |false
                                   |3	                |19	            |True          |2	    |2014-12-08 00:00:00	|2014 	   |true
                                   |3	                |19	            |True          |3	    |2010-01-01 00:00:00	|2010 	   |true
                                   |3	                |19	            |True          |4	    |2012-12-26 00:00:00	|2014 	   |false
                                   |3	                |19	            |True          |5	    |2001-12-24 00:00:00	|2001 	   |true
                                   |3	                |19	            |True          |5	    |2001-12-25 00:00:00	|2001 	   |true";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.IsTrue(repo_licencia.DiasHabilitadosEntreFechas(desde, hasta, id_matrimonio));
            Assert.AreEqual(3, repo_licencia.DiasHabilesEntreFechas(desde, hasta));
        }


        [TestMethod]
        public void quiero_pedirme_20_dias_habiles_para_mi_matrimonio_y_no_puedo_porque_son_10()
        {
            DateTime desde = new DateTime(2014, 11, 21);
            DateTime hasta = new DateTime(2014, 12, 22);
            int id_matrimonio = 18;
            string source = @"     |Dias_Autorizados	|id_Concepto	|Dias_Habiles  |id		|fecha	                |año	   |periodico      
                                   |10	                |18	            |True          |1	    |2014-11-24 00:00:00	|2014 	   |false
                                   |10                  |18	            |True          |2	    |2014-12-08 00:00:00	|2014 	   |true
                                   |10	                |18	            |True          |3	    |2010-01-01 00:00:00	|2010 	   |true
                                   |10	                |18	            |True          |4	    |2012-12-26 00:00:00	|2014 	   |false
                                   |10	                |18	            |True          |5	    |2001-12-24 00:00:00	|2001 	   |true
                                   |10	                |18	            |True          |5	    |2001-12-25 00:00:00	|2001 	   |true";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.IsFalse(repo_licencia.DiasHabilitadosEntreFechas(desde, hasta, id_matrimonio));
            Assert.AreEqual(20, repo_licencia.DiasHabilesEntreFechas(desde, hasta));
        }

        [TestMethod]
        public void quiero_pedirme_10_dias_habiles_para_mi_matrimonio_y_puedo_porque_son_10()
        {
            DateTime desde = new DateTime(2014, 11, 21);
            DateTime hasta = new DateTime(2014, 12, 05);
            int id_matrimonio = 18;
            string source = @"     |Dias_Autorizados	|id_Concepto	|Dias_Habiles  |id		|fecha	                |año	   |periodico      
                                   |10	                |18	            |True          |1	    |2014-11-24 00:00:00	|2014 	   |false
                                   |10                  |18	            |True          |2	    |2014-12-08 00:00:00	|2014 	   |true
                                   |10	                |18	            |True          |3	    |2010-01-01 00:00:00	|2010 	   |true
                                   |10	                |18	            |True          |4	    |2012-12-26 00:00:00	|2014 	   |false
                                   |10	                |18	            |True          |5	    |2001-12-24 00:00:00	|2001 	   |true
                                   |10	                |18	            |True          |5	    |2001-12-25 00:00:00	|2001 	   |true";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.IsTrue(repo_licencia.DiasHabilitadosEntreFechas(desde, hasta, id_matrimonio));
            Assert.AreEqual(10, repo_licencia.DiasHabilesEntreFechas(desde, hasta));
        }

        [TestMethod]
        public void deberia_obtener_las_prorrogas_del_2014()
        {
            string source = @"     |id		|fecha	                |año	   |periodico	           
                                   |1	    |2014-10-26 00:00:00	|2014 	   |false
                                   |2	    |2014-07-14 00:00:00	|2014 	   |false
                                   |3	    |2010-01-01 00:00:00	|2014 	   |true
                                   |4	    |2012-01-23 00:00:00	|2012 	   |false
                                   |5	    |2014-03-01 00:00:00	|2014 	   |false";


            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            var repo_licencia = new RepositorioLicencias(conexion);


            Assert.AreEqual(4, repo_licencia.ObtenerFeriados(2014).Count());
        }


//        [TestMethod]
//        public void quiero_pedirme_un_14f_y_como_me_tome_los_6_del_anio_no_puedo()
//        {
//            DateTime dia_licencia = new DateTime(2014, 11, 14);
//            ConceptoDeLicencia concepto = new ConceptoDeLicencia();
//            concepto.Id = 32;
//            Persona persona = TestObjects.UnaPersona();
            
//            string source = @"     |SaldoAnual	|SaldoMensual |Concepto   |NroDocumento    |desde               |hasta	    	        |Apellido   |Nombre	   |Id_Interna      |fecha_solicitud                  
//                                   |6	        |2	          |32	      |31507315        |2014-11-24 00:00:00	|2014-11-24 00:00:00	|Cevey 	    |Belén     |31507315        |2014-11-24 00:00:00
//                                   |6	        |2	          |32	      |31507315        |2014-12-08 00:00:00	|2014-12-08 00:00:00	|Cevey 	    |Belén     |31507315        |2014-12-08 00:00:00
//                                   |6	        |2	          |32	      |31507315        |2010-01-01 00:00:00	|2010-01-01 00:00:00	|Cevey 	    |Belén     |31507315        |2010-01-01 00:00:00
//                                   |6	        |2	          |32	      |31507315        |2012-12-26 00:00:00	|2012-12-26 00:00:00	|Cevey 	    |Belén     |31507315        |2012-12-26 00:00:00
//                                   |6	        |2	          |32	      |31507315        |2001-12-24 00:00:00	|2001-12-24 00:00:00	|Cevey 	    |Belén     |31507315        |2001-12-24 00:00:00
//                                   |6	        |2	          |32	      |31507315        |2001-12-25 00:00:00	|2001-12-25 00:00:00	|Cevey 	    |Belén     |31507315        |2001-12-25 00:00:00  ";


//            IConexionBD conexion = TestObjects.ConexionMockeada();
//            var resultado_sp = TablaDeDatos.From(source);

//            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

//            var repo_licencia = new RepositorioLicencias(conexion);

//            Assert.AreEqual(0, repo_licencia.CargarSaldoLicencia14FoHDe(concepto, persona, dia_licencia).SaldoAnual);
//            Assert.AreEqual(0, repo_licencia.CargarSaldoLicencia14FoHDe(concepto, persona, dia_licencia).SaldoMensual);
//        }


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
