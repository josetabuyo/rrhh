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

namespace TestViaticos
{
    [TestClass]
    public class TestViaticos
    {
        CreadorDeDatosFicticios creador_de_datos;
        [TestInitialize]
        public void SetUp()
        {
            creador_de_datos = new CreadorDeDatosFicticios();
        }

        #region TestObjectsMethods

        private ComisionDeServicio ComisionDeAgus1Dia(Persona agus, List<Estadia> estadia_agus, List<Pasaje> pasaje_de_agus, EstadosDeComision estadosDeComision)
        {
            return TestObjects.ComisionDeAgus1Dia(agus, estadia_agus, pasaje_de_agus, estadosDeComision);
        }

        private Persona AgustinContratacionNormal()
        {
            return TestObjects.AgustinContratacionNormal();
        }

        private Persona Alicia()
        {
            return TestObjects.Alicia();
        }

        private Persona Carazo()
        {
            return TestObjects.Carazo();
        }

        private Persona Martinelli()
        {
            return TestObjects.Martinelli();
        }

        private List<Pasaje> PasajeDeAgus()
        {
            List<Pasaje> lista_pasajes = new List<Pasaje>();
            lista_pasajes.Add(TestObjects.PasajeDeAgus());
            return lista_pasajes;
        }

        private List<Estadia> EstadiaDeAgusIniciaYTerminaElMismoDia()
        {
            List<Estadia> lista_estadias = new List<Estadia>();
            lista_estadias.Add(TestObjects.EstadiaDeAgusIniciaYTerminaElMismoDia());
            return lista_estadias;
        }

        private List<Estadia> EstadiaDeAgusIniciaUnDiaYTerminaAlDiaSiguiente()
        {
            List<Estadia> lista_estadias = new List<Estadia>();
            lista_estadias.Add(TestObjects.EstadiaDeAgusIniciaUnDiaYTerminaAlDiaSiguiente());
            return lista_estadias;
        }

        private List<Estadia> EstadiaDeAgusIniciaUnDiaYTerminaAlosDosDiasSiguientes()
        {
            List<Estadia> lista_estadias = new List<Estadia>();
            lista_estadias.Add(TestObjects.EstadiaDeAgusIniciaUnDiaYTerminaAlosDosDiasSiguientes());
            return lista_estadias;
        }

        private List<Estadia> EstadiaDeAgusIniciaUnDiaYTerminaAlCuartoDia()
        {
            List<Estadia> lista_estadias = new List<Estadia>();
            lista_estadias.Add(TestObjects.EstadiaDeAgusIniciaUnDiaYTerminaAlCuartoDia());
            return lista_estadias;
        }

        private List<Estadia> EstadiaDeAgusIniciaUnDiaYTerminaAlSiguienteDiaDespues12Antes12()
        {
            List<Estadia> lista_estadias = new List<Estadia>();
            lista_estadias.Add(TestObjects.EstadiaDeAgusIniciaUnDiaYTerminaAlSiguienteDiaDespues12Antes12());
            return lista_estadias;
        }

        private Estadia EstadiaDe1DiaYMedio()
        {
            return TestObjects.EstadiaDe1DiaYMedio();
        }

        private RepositorioZonas RepositorioZona()
        {
            return new RepositorioZonas(ConexionBaseLocal());
        }




        #endregion


        //FC
//        [TestMethod]
//        public void deberia_poder_dar_de_alta_una_comision()
//        {
//            creador_de_datos.AddData("VIA_MediosDePago.xml");
//            creador_de_datos.AddData("VIA_MediosDeTransporte.xml");
//            creador_de_datos.AddData("VIA_Estadias.xml");
//            creador_de_datos.AddData("Provincias.xml");
//            RepositorioComisionesDeServicio repositorio = new RepositorioComisionesDeServicio();
//            List<ComisionDeServicio> lista_comision = new List<ComisionDeServicio>();
//            ComisionDeServicio comision = this.ComisionDeAgus1Dia(this.AgustinContratacionNormal(), this.EstadiaDeAgusIniciaYTerminaElMismoDia(), this.PasajeDeAgus(), EstadosDeComision.Pendiente);
//            comision.AreaActual = new Area(1, "Secretaria");
//            lista_comision.Add(comision);
//            try
//            {
//                repositorio.AltaDeComisionesDeServicio(lista_comision);
//                Assert.IsTrue(true);
//            }
//            catch (Exception)
//            {
        
                
        //        Assert.Fail();
        //    }           
        //}

        //FC

        [TestMethod]
        [Ignore]
        public void deberia_poder_conocer_el_tipo_de_viatico_correspondiente_de_una_persona()
        {
            creador_de_datos.AddData("LEG_Desglose_NivelGrado.xml");
            creador_de_datos.AddData("LEG_Desglose_Planta.xml");
            creador_de_datos.AddData("VIA_Tipo_Viatico.xml");
            creador_de_datos.AddData("VIA_TipoPlanta_TipoViatico.xml");
            creador_de_datos.AddData("Tipo_de_Planta.xml");
            creador_de_datos.AddData("Tabla_niveles.xml");
            creador_de_datos.AddData("Tabla_grados.xml");
            creador_de_datos.AddData("Datos_Personales.xml");
            
            Persona agustin = AgustinContratacionNormal();

            RepositorioTipoDeViatico repositorio = new RepositorioTipoDeViatico();
            TipoDeViatico tipo_de_viatico = repositorio.GetTipoDeViaticoDe(agustin);

            Assert.AreEqual("CCT Dcto 214/06", tipo_de_viatico.Descripcion);
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_conocer_el_tipo_de_viatico_correspondiente_de_una_persona_de_planta3_nivel44_grado2()
        {

            creador_de_datos.AddData("LEG_Desglose_NivelGrado.xml");
            creador_de_datos.AddData("LEG_Desglose_Planta.xml");
            creador_de_datos.AddData("VIA_Tipo_Viatico.xml");
            creador_de_datos.AddData("VIA_TipoPlanta_TipoViatico.xml");
            creador_de_datos.AddData("Tipo_de_Planta.xml");
            creador_de_datos.AddData("Tabla_niveles.xml");
            creador_de_datos.AddData("Tabla_grados.xml");
            creador_de_datos.AddData("Datos_Personales.xml");

            Persona alice = Alicia();

            RepositorioTipoDeViatico repositorio = new RepositorioTipoDeViatico();
            TipoDeViatico tipo_de_viatico = repositorio.GetTipoDeViaticoDe(alice);

            Assert.AreEqual(3, tipo_de_viatico.Id);

        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_conocer_el_tipo_de_viatico_correspondiente_de_una_persona_de_planta3_nivel44_grado3()
        {

            creador_de_datos.AddData("LEG_Desglose_NivelGrado.xml");
            creador_de_datos.AddData("LEG_Desglose_Planta.xml");
            creador_de_datos.AddData("VIA_Tipo_Viatico.xml");
            creador_de_datos.AddData("VIA_TipoPlanta_TipoViatico.xml");
            creador_de_datos.AddData("Tipo_de_Planta.xml");
            creador_de_datos.AddData("Tabla_niveles.xml");
            creador_de_datos.AddData("Tabla_grados.xml");
            creador_de_datos.AddData("Datos_Personales.xml");

            Persona carazo = Carazo();

            RepositorioTipoDeViatico repositorio = new RepositorioTipoDeViatico();
            TipoDeViatico tipo_de_viatico = repositorio.GetTipoDeViaticoDe(carazo);

            Assert.AreEqual(4, tipo_de_viatico.Id);

        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_conocer_el_tipo_de_viatico_correspondiente_de_una_persona_de_planta3_nivelResto_gradoResto()
        {
            creador_de_datos.AddData("LEG_Desglose_NivelGrado.xml");
            creador_de_datos.AddData("LEG_Desglose_Planta.xml");
            creador_de_datos.AddData("VIA_Tipo_Viatico.xml");
            creador_de_datos.AddData("VIA_TipoPlanta_TipoViatico.xml");
            creador_de_datos.AddData("Tipo_de_Planta.xml");
            creador_de_datos.AddData("Tabla_niveles.xml");
            creador_de_datos.AddData("Tabla_grados.xml");
            creador_de_datos.AddData("Datos_Personales.xml");

            Persona martinelli = Martinelli();

            RepositorioTipoDeViatico repositorio = new RepositorioTipoDeViatico();
            TipoDeViatico tipo_de_viatico = repositorio.GetTipoDeViaticoDe(martinelli);

            Assert.AreEqual(5, tipo_de_viatico.Id);

        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_conocer_la_region_de_una_provincia()
        {
            creador_de_datos.AddData("VIA_Rel_Zona_Prov.xml");
            creador_de_datos.AddData("VIA_Zonas.xml");
            creador_de_datos.AddData("Provincias.xml");
            
            Provincia provincia = new Provincia();
            provincia.Id = 2;

            RepositorioZonas repoZonas = new RepositorioZonas(ConexionBaseLocal());
            Zona zona = repoZonas.GetZonaFromProvincia(provincia);

            Assert.AreEqual("N.O.A", zona.Nombre); 
        }

        private IConexionBD ConexionBaseLocal()
        {
            return new ConexionBDSQL(AppConexionTest.GetObtenerStringConexionLocal());
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_calcular_el_valor_del_viatico_segun_la_provincia_de_la_estadia_y_modalidad_de_contratacion()
        {
            creador_de_datos.AddData("VIA_Valor_ViaticoXZona.xml");
            Persona agustin = AgustinContratacionNormal();

            List<Estadia> estadias = EstadiaDeAgusIniciaYTerminaElMismoDia();

            RepositorioCalculadorDeViatico repo = new RepositorioCalculadorDeViatico();
           
            Assert.AreEqual(407, repo.GetValorDeViatico(estadias[0], agustin));
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_calcular_cuantos_dias_de_viatico_le_corresponde_a_un_agente_por_su_estadia_de_un_dia_que_sale_antes_12_y_llega_despues_de_las_12()
        {
            List<Estadia> estadias = EstadiaDeAgusIniciaUnDiaYTerminaAlDiaSiguiente();

            CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

            Assert.AreEqual(2, calculadorDeDias.CalcularDiasDe(estadias[0]));// periodo.Days);
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_saber_cuantos_dias_de_viatico_le_corresponde_a_un_agente_por_su_estadia_del_mismo_dia_antes()
        {
            List<Estadia> estadias = EstadiaDeAgusIniciaYTerminaElMismoDia();

            CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

            Assert.AreEqual(0.5F, calculadorDeDias.CalcularDiasDe(estadias[0]));
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_saber_cuantos_dias_de_viatico_le_corresponde_a_un_agente_por_su_estadia_de_dos_dias()
        {
            List<Estadia> estadias = EstadiaDeAgusIniciaUnDiaYTerminaAlosDosDiasSiguientes();

            CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

            Assert.AreEqual(3, calculadorDeDias.CalcularDiasDe(estadias[0]));
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_saber_cuantos_dias_de_viatico_le_corresponde_a_un_agente_por_su_estadia_de_4_dias_sale_despues_de_12_vuelve_despues_de_12()
        {
            List<Estadia> estadias = EstadiaDeAgusIniciaUnDiaYTerminaAlCuartoDia();

            CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

            Assert.AreEqual(4.5F, calculadorDeDias.CalcularDiasDe(estadias[0]));
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_saber_cuantos_dias_de_viatico_le_corresponde_a_un_agente_por_su_estadia_de_1_dia_sale_despues_de_12_vuelve_antes_de_12()
        {
            List<Estadia> estadias = EstadiaDeAgusIniciaUnDiaYTerminaAlSiguienteDiaDespues12Antes12();

            CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

            Assert.AreEqual(1, calculadorDeDias.CalcularDiasDe(estadias[0]));
        }

        //FC
        [TestMethod]
        [Ignore]
        public void deberia_poder_completar_los_datos_de_contratacion_de_la_persona()
        {
            creador_de_datos.AddData("LEG_Desglose_NivelGrado.xml");
            creador_de_datos.AddData("LEG_Desglose_Planta.xml");
            creador_de_datos.AddData("VIA_Tipo_Viatico.xml");
            creador_de_datos.AddData("VIA_TipoPlanta_TipoViatico.xml");
            creador_de_datos.AddData("Tipo_de_Planta.xml");
            creador_de_datos.AddData("Tabla_niveles.xml");
            creador_de_datos.AddData("Tabla_grados.xml");
            creador_de_datos.AddData("Datos_Personales.xml");
            
            Persona persona = AgustinContratacionNormal();

            RepositorioTipoDeViatico repo = new RepositorioTipoDeViatico();
            
            persona = repo.GetNivelGradoDeContratacionDe(persona);

            Assert.AreEqual("Contratada", persona.Categoria);
            Assert.AreEqual("C", persona.Nivel);
            Assert.AreEqual("4", persona.Grado);
            
        }

        ////FC
        //[TestMethod]
        //public void deberia_poder_updatear_una_comision()
        //{
        //    creador_de_datos.AddData("LEG_Desglose_NivelGrado.xml");
        //    creador_de_datos.AddData("LEG_Desglose_Planta.xml");
        //    creador_de_datos.AddData("VIA_Tipo_Viatico.xml");
        //    creador_de_datos.AddData("VIA_TipoPlanta_TipoViatico.xml");
        //    creador_de_datos.AddData("Tipo_de_Planta.xml");
        //    creador_de_datos.AddData("Tabla_niveles.xml");
        //    creador_de_datos.AddData("Tabla_grados.xml");
        //    creador_de_datos.AddData("Datos_Personales.xml");

            



        //}




        ////FC
        //[TestMethod]
        //public void deberia_poder_saber_cuantos_dias_de_viatico_le_corresponde_a_un_agente_por_su_estadia_de()
        //{
        //    List<Estadia> estadias = EstadiaDeAgusIniciaUnDiaYTerminaAlosDosDiasSiguientes();

        //    CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

        //    Assert.AreEqual(2, calculadorDeDias.CalcularDiasDe(estadias[0]));
        //}


        [TestMethod]
        [Ignore]
        public void GetMediosDeTransporte()
        {
            RepositorioMediosDeTransporte repositorio = new RepositorioMediosDeTransporte();
            List<MedioDeTransporte> transportes = repositorio.GetTodosLosMediosDeTransporte();
            Assert.IsNotNull(transportes);

        }


        [TestMethod]
        [Ignore]
        public void GetMediosDePago()
        {
            RepositorioMediosDePago repositorio = new RepositorioMediosDePago();
            List<MedioDePago> Pagos = repositorio.GetTodosLosMediosDePago();
            Assert.IsNotNull(Pagos);
        }

        //ESTE TEST ESTABA DE ANTES
        //[TestMethod]
        //public void AltaDeViatico()
        //{
        //    ComisionDeServicio comision1 = new ComisionDeServicio { Persona = new Persona { Documento = 29753914 }, Estado = EstadosDeComision.Pendiente, Baja = false };
        //    comision1.Estadias.Add(new Estadia { ComisionDeServicio = comision1, Desde = new DateTime(2009, 09, 8), Hasta = new DateTime(2009, 10, 11), Motivo = "Motivo de Prueba", Eventuales = 284.15F, CalculadoPorCategoria = 154.32F, AdicionalParaPasajes = 64.5F, Provincia = new Provincia { Id = 10 } });
        //    comision1.Estadias.Add(new Estadia { ComisionDeServicio = comision1, Desde = new DateTime(2009, 10, 12), Hasta = new DateTime(2009, 10, 15), Motivo = "Otro Motivo de Prueba", Eventuales = 274.85F, CalculadoPorCategoria = 256F, AdicionalParaPasajes = 12.5F, Provincia = new Provincia { Id = 14 } });
        //    comision1.Estadias.Add(new Estadia { ComisionDeServicio = comision1, Desde = new DateTime(2009, 10, 16), Hasta = new DateTime(2009, 10, 24), Motivo = "Tercer Motivo de Prueba", Eventuales = 224.85F, CalculadoPorCategoria = 156F, AdicionalParaPasajes = 123.5F, Provincia = new Provincia { Id = 18 } });

        //    comision1.Pasajes.Add(new Pasaje { ComisionDeServicio = comision1, FechaDeViaje = new DateTime(2009, 09, 8), MedioDeTransporte = new MedioDeTransporte(1, "Avion"), Origen = new Localidad { Id = 4800 }, Destino = new Localidad { Id = 5779 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago(1, "Efectivo") });
        //    comision1.Pasajes.Add(new Pasaje { ComisionDeServicio = comision1, FechaDeViaje = new DateTime(2009, 10, 16), MedioDeTransporte = new MedioDeTransporte(1, "Avion"), Origen = new Localidad { Id = 10204 }, Destino = new Localidad { Id = 4800 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago(1, "Efectivo") });


        //    ComisionDeServicio comision2 = new ComisionDeServicio { Persona = new Persona { Documento = 6278699 }, Estado = EstadosDeComision.Pendiente, Baja = false };
        //    comision2.Estadias.Add(new Estadia { ComisionDeServicio = comision2, Desde = new DateTime(2009, 10, 8), Hasta = new DateTime(2009, 10, 8), Motivo = "Motivo de Prueba", Eventuales = 284.15F, CalculadoPorCategoria = 154.32F, AdicionalParaPasajes = 64.5F, Provincia = new Provincia { Id = 10 } });
        //    comision2.Estadias.Add(new Estadia { ComisionDeServicio = comision2, Desde = new DateTime(2008, 11, 7), Hasta = new DateTime(2008, 11, 15), Motivo = "Otro Motivo de Prueba", Eventuales = 274.85F, CalculadoPorCategoria = 256F, AdicionalParaPasajes = 12.5F, Provincia = new Provincia { Id = 14 } });

        //    comision2.Pasajes.Add(new Pasaje { ComisionDeServicio = comision2, FechaDeViaje = new DateTime(2009, 09, 8), MedioDeTransporte = new MedioDeTransporte(1, "Avion"), Origen = new Localidad { Id = 4800 }, Destino = new Localidad { Id = 5779 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago(1, "Efectivo") });
        //    comision2.Pasajes.Add(new Pasaje { ComisionDeServicio = comision2, FechaDeViaje = new DateTime(2009, 10, 16), MedioDeTransporte = new MedioDeTransporte(1, "Avion"), Origen = new Localidad { Id = 10204 }, Destino = new Localidad { Id = 4800 }, Precio = 15.32F, Baja = false, MedioDePago = new MedioDePago(1, "Efectivo") });

        //    List<ComisionDeServicio> comisiones = new List<ComisionDeServicio>();
        //    comisiones.Add(comision1);
        //    comisiones.Add(comision2);

        //    RepositorioComisionesDeServicio repoComisiones = new RepositorioComisionesDeServicio();
        //    repoComisiones.AltaDeComisionesDeServicio(comisiones);

        //}


        //FC: refactorizar para que la comision tome listas de estadias y pasajes
        //[TestMethod]
        //public void caso1_calcular_viatico_contratacion_normal_de_un_dia()
        //{           
        //    Estadia estadia_agus = EstadiaDeAgusDeUnDia();

        //    Persona agus = AgustinContratacionNormal();

        //    Pasaje pasaje_de_agus = PasajeDeAgus();

        //    ComisionDeServicio comision_de_agus = ComisionDeAgus1Dia(agus, estadia_agus, pasaje_de_agus, EstadosDeComision.Pendiente);
                
        //    CalculadorDeViaticos calculador_de_viaticos = new CalculadorDeViaticos();
        //    calculador_de_viaticos.CalculaleLosViaticosA(comision_de_agus);

        //    Assert.AreEqual(234, calculador_de_viaticos.CalculaleLosViaticosA(comision_de_agus));

        //}

        [TestMethod]
        [Ignore]
        public void caso2_calcular_los_dias_de_una_estadia_que_inicia_y_finaliza_el_mismo_dia()
        {
            List<Estadia> lista_estadia_agus = EstadiaDeAgusIniciaYTerminaElMismoDia();
            //Calendario calendario = new Calendario();

            //Assert.AreEqual(0.5, calendario.CalcularDiasDe(lista_estadia_agus[0]));
        }

        [TestMethod]
        [Ignore]
        public void caso3_calcular_los_dias_de_una_estadia_que_inicia_dia1_antes_de_12_y_finaliza_dia2_antes_de_12()
        {
            Estadia estadia_fer = EstadiaDe1DiaYMedio();
            //Calendario calendario = new Calendario();

            //Assert.AreEqual(1.5, calendario.CalcularDiasDe(estadia_fer));
        }



        //TestCalculoDeViatico
        [TestMethod]
        [Ignore]
        public void CalcularViaticoPara1184QueCobra1910()
        {
            ModalidadDeContratacion contratacion = new ModalidadDeContratacion1184();
            ((ModalidadDeContratacion1184)contratacion).Retribucion = 1910;
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = contratacion };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona(3, "NEA"); //{ Id = 3 };
            float MontoEsperado = 84;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es contrato 1184 y cobra entre 1921 y 2919,
        /// con lo que deberia
        /// entrar en el caso del viático diario de $105
        /// </summary>
        [TestMethod]
        [Ignore]
        public void CalcularViaticoPara1184QueCobra2000()
        {
            ModalidadDeContratacion contratacion = new ModalidadDeContratacion1184();
            ((ModalidadDeContratacion1184)contratacion).Retribucion = 2000;
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = contratacion };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona(3, "NEA");// { Id = 3 };
            float MontoEsperado = 105;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es contrato 1184 y cobra más de 2920,
        /// con lo que deberia
        /// entrar en el caso del viático diario de $126
        /// </summary>
        [TestMethod]
        [Ignore]
        public void CalcularViaticoPara1184QueCobra3100()
        {
            ModalidadDeContratacion contratacion = new ModalidadDeContratacion1184();
            ((ModalidadDeContratacion1184)contratacion).Retribucion = 3100;
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = contratacion };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona(3, "NEA");// { Id = 3 };
            float MontoEsperado = 126;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato no es contrato 1184 y es de la zona Metropolitana, 
        /// y es Secretario (W3) con lo que deberia entrar en el caso del 
        /// viático diario de $182
        /// </summary>
        [TestMethod]
        [Ignore]
        public void CalcularViaticoParaNivelWGrado2EnCuyo()
        {
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = new ModalidadDeContratacionNivelPolitico() };
            ((ModalidadDeContratacionNivelPolitico)unaPersona.ModalidadDeContratacion).Nivel = "W";
            ((ModalidadDeContratacionNivelPolitico)unaPersona.ModalidadDeContratacion).Grado = 3;
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona(1, "METROPOLITANA"); //{ Nombre = "METROPOLITANA" };
            float MontoEsperado = 182;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es FuncionEjecutiva y es de la zona Metropolitana, 
        /// viático diario de $188
        /// </summary>
        [TestMethod]
        [Ignore]
        public void CalcularViaticoParaFuncionEjecutivaEnZonaMetropolitana()
        {
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = new ModalidadDeContratacionFuncionEjecutiva() };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona(1, "METROPOLITANA");// { Nombre = "METROPOLITANA" };
            float MontoEsperado = 188.6F;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }

        /// <summary>
        /// El tipo de contrato es "Normal" y es de la zona Metropolitana, 
        /// viático diario de $287
        /// </summary>
        [TestMethod]
        [Ignore]
        public void CalcularViaticoParaContratacionNormalEnZonaSur()
        {
            Persona unaPersona = new Persona { Documento = 29753914, ModalidadDeContratacion = new ModalidadDeContratacionNormal() };
            CalculadorDeViaticos unCalculador = new CalculadorDeViaticos();
            Zona unaZona = new Zona(2, "SUR"); //{ Nombre = "SUR" };
            float MontoEsperado = 287F;
            float MontoCalculado = unCalculador.CalculaleLosViaticosA(unaPersona, unaZona);
            Assert.AreEqual(MontoEsperado, MontoCalculado);
        }


        //TestCriptografia
 

        private string encriptarSHA1(string CadenaOriginal)
        {
            System.Security.Cryptography.HashAlgorithm hashValue = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(CadenaOriginal); byte[] byteHash = hashValue.ComputeHash(bytes);
            hashValue.Clear();
            return (Convert.ToBase64String(byteHash));
        }

        //TestZonas
        [TestMethod]
        [Ignore]
        public void TestGetZonas()
        {

            creador_de_datos.AddData("VIA_Zonas.xml");
            RepositorioZonas repositorio = new RepositorioZonas(ConexionBaseLocal());
            List<Zona> zonas = new List<Zona>();
            zonas = repositorio.GetTodasLasZonas();

            Assert.AreEqual(6, zonas.Count());
        }


    }
}
