using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TestViaticos;


namespace TestViaticos
{
    [TestClass]
    public class TestCalendarioDeCurso
    {
        Curso unCursoDeUnDiaPorSemana = new Curso(TestObjects.MateriaCens(), TestObjects.unDocente(), TestObjects.EspacioFisico(), DateTime.Today, DateTime.Today, "");
        Curso unCursoDeDosDiasPorSemana = new Curso(TestObjects.MateriaCens(), TestObjects.unDocente(), TestObjects.EspacioFisico(), DateTime.Today, DateTime.Today, "");
        CalendarioDeFeriados unCalendarioGlobal = new CalendarioDeFeriados();
        ManagerDeCalendarios managerDeCalendarios;
        CalendarioDeCurso elCalendarioDeMatematicas513;
        DateTime fechaDesde;
        DateTime fechaHasta;
        DateTime dia1Jueves = DateTime.Parse("03/01/2013");
        DateTime dia2Jueves = DateTime.Parse("10/01/2013");
        DateTime dia3Jueves = DateTime.Parse("17/01/2013");
        DateTime dia4Jueves = DateTime.Parse("24/01/2013");
        DateTime dia5Jueves = DateTime.Parse("31/01/2013");
        DateTime dia6Jueves = DateTime.Parse("07/02/2013");
        DateTime dia7Jueves = DateTime.Parse("14/02/2013");
        DateTime dia8Jueves = DateTime.Parse("21/02/2013");
        DateTime dia9Jueves = DateTime.Parse("28/02/2013");

        DateTime dia1Lunes = DateTime.Parse("07/01/2013");
        DateTime dia2Lunes = DateTime.Parse("14/01/2013");
        DateTime dia5Lunes = DateTime.Parse("04/02/2013");
        DateTime dia6Lunes = DateTime.Parse("11/02/2013");
        DateTime dia7Lunes = DateTime.Parse("18/02/2013");
        DateTime dia8Lunes = DateTime.Parse("25/02/2013");
        DateTime feriadoCarnaval = DateTime.Parse("11/02/2013");
        DateTime feriadoMio = DateTime.Parse("28/02/2013");


        [TestInitialize]
        public void setup()
        {
            unCursoDeUnDiaPorSemana.AgregarDiaDeCursada(DayOfWeek.Thursday);
            unCursoDeDosDiasPorSemana.AgregarDiaDeCursada(DayOfWeek.Monday);
            unCursoDeDosDiasPorSemana.AgregarDiaDeCursada(DayOfWeek.Thursday);
            unCalendarioGlobal.AgregarFeriado(feriadoCarnaval);
            unCalendarioGlobal.AgregarFeriado(feriadoMio);

            managerDeCalendarios = new ManagerDeCalendarios(unCalendarioGlobal);
            managerDeCalendarios.AgregarCalendarioPara(unCursoDeDosDiasPorSemana);
            managerDeCalendarios.AgregarCalendarioPara(unCursoDeUnDiaPorSemana);


        }

        [TestMethod]
        public void dado_un_curso_que_se_cursa_todos_los_jueves_cuando_le_pregunto_por_las_fechas_en_que_hay_que_asistir_durante_enero_de_2013_debe_contestar_5()
        {
            fechaDesde = DateTime.Parse("01/01/2013");
            fechaHasta = DateTime.Parse("31/01/2013");
            elCalendarioDeMatematicas513 = managerDeCalendarios.CalendarioPara(unCursoDeUnDiaPorSemana);

            var diasACursarEsperados = new List<DateTime>();
            diasACursarEsperados.Add(dia1Jueves);
            diasACursarEsperados.Add(dia2Jueves);
            diasACursarEsperados.Add(dia3Jueves);
            diasACursarEsperados.Add(dia4Jueves);
            diasACursarEsperados.Add(dia5Jueves);

            var DiasACursar = elCalendarioDeMatematicas513.DiasACursarSinIncluirFeriadosEntre(fechaDesde, fechaHasta);
            Assert.AreEqual(5, DiasACursar.Count);
            Assert.IsTrue(DiasACursar.TrueForAll(unDiaDeCursada => diasACursarEsperados.Any(unDia => unDiaDeCursada.Contiene(unDia))));
        }

        [TestMethod]
        public void dado_un_curso_que_se_cursa_lunes_y_jueves_cuando_le_pregunto_cuantos_dias_de_cursada_hay_en_la_primer_quincena_de_enero_me_dice_4()
        {
            fechaDesde = DateTime.Parse("01/01/2013");
            fechaHasta = DateTime.Parse("15/01/2013");
            elCalendarioDeMatematicas513 = managerDeCalendarios.CalendarioPara(unCursoDeDosDiasPorSemana); ;

            var diasACursarEsperados = new List<DateTime>();
            diasACursarEsperados.Add(dia1Jueves);
            diasACursarEsperados.Add(dia2Jueves);
            diasACursarEsperados.Add(dia1Lunes);
            diasACursarEsperados.Add(dia2Lunes);

            var DiasACursar = elCalendarioDeMatematicas513.DiasACursarSinIncluirFeriadosEntre(fechaDesde, fechaHasta);
            Assert.AreEqual(4, DiasACursar.Count);
            //Assert.IsTrue(DiasACursar.TrueForAll(unDia => diasACursarEsperados.Contains(unDia)));
        }

        [TestMethod]
        public void dado_un_curso_que_se_cursa_los_lunes_y_jueves_cuando_le_pregunto_cuantos_dias_de_cursada_hay_en_febrero_de_2013_me_dice_6_porque_dos_son_feriados()
        {
            fechaDesde = DateTime.Parse("01/02/2013");
            fechaHasta = DateTime.Parse("28/02/2013");
            var diaFeriado2 = DateTime.Parse("11/02/2013");
            var diaFeriado1 = DateTime.Parse("28/02/2013");

            elCalendarioDeMatematicas513 = managerDeCalendarios.CalendarioPara(unCursoDeDosDiasPorSemana);

            var diasACursarEsperados = new List<DateTime>();
            diasACursarEsperados.Add(dia6Jueves);
            diasACursarEsperados.Add(dia7Jueves);
            diasACursarEsperados.Add(dia8Jueves);
            diasACursarEsperados.Add(dia9Jueves);
            diasACursarEsperados.Add(dia5Lunes);
            diasACursarEsperados.Add(dia6Lunes);
            diasACursarEsperados.Add(dia7Lunes);
            diasACursarEsperados.Add(dia8Lunes);

            var DiasACursar = elCalendarioDeMatematicas513.DiasACursarSinIncluirFeriadosEntre(fechaDesde, fechaHasta);
            Assert.AreEqual(6, DiasACursar.Count);
            //Assert.IsTrue(DiasACursar.TrueForAll(unDia => diasACursarEsperados.Contains(unDia)));
            //Assert.IsFalse(DiasACursar.Contains(diaFeriado1));
            //Assert.IsFalse(DiasACursar.Contains(diaFeriado2));
        }

        [TestMethod]
        public void dado_un_curso_que_se_cursa_los_lunes_y_jueves_cuando_le_pregunto_cuantos_dias_de_cursada_hay_inlcuyendo_feriados_en_febrero_de_2013_me_dice_8_porque_dos_son_feriados()
        {
            fechaDesde = DateTime.Parse("01/02/2013");
            fechaHasta = DateTime.Parse("28/02/2013");
            var diaFeriado2 = DateTime.Parse("11/02/2013");
            var diaFeriado1 = DateTime.Parse("28/02/2013");

            elCalendarioDeMatematicas513 = managerDeCalendarios.CalendarioPara(unCursoDeDosDiasPorSemana);

            var diasACursarEsperados = new List<DateTime>();
            diasACursarEsperados.Add(dia6Jueves);
            diasACursarEsperados.Add(dia7Jueves);
            diasACursarEsperados.Add(dia8Jueves);
            diasACursarEsperados.Add(dia9Jueves);
            diasACursarEsperados.Add(dia5Lunes);
            diasACursarEsperados.Add(dia6Lunes);
            diasACursarEsperados.Add(dia7Lunes);
            diasACursarEsperados.Add(dia8Lunes);

            var DiasACursar = elCalendarioDeMatematicas513.DiasACursarIncluyendoFeriadosEntre(fechaDesde, fechaHasta);
            Assert.AreEqual(8, DiasACursar.Count);

            var diasDeCursadaFeriados = DiasACursar.FindAll(unDiaDeCursada => unDiaDeCursada.EsFeriado());
            Assert.AreEqual(2, diasDeCursadaFeriados.Count);

            var diasDeCursadaNoFeriados = DiasACursar.FindAll(unDiaDeCursada => !unDiaDeCursada.EsFeriado());
           // Assert.AreEqual(6, diasDeCursadaFeriados.Count); TERMINAR! aaaaaaaaaaaaaaaaaaaa
        }
    }
}
