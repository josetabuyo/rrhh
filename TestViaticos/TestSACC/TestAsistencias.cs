using System.Linq;
using System;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;
using NMock2;

namespace TestViaticos
{
   
    [TestClass]
    public class TestAsistencias
    {
        [TestMethod]
        public void dado_un_dia_cursado_de_tres_horas_y_un_alumno_que_estuvo_presente_una_hora_deberia_poder_saber_cuantas_horas_no_asistio()
        {
            var valor_propio = 1;
            var horas_del_dia_cursado = 3;

            var obj_acumulador_una_hora = new AcumuladorHorasDiaCursado(valor_propio, horas_del_dia_cursado);
            Assert.AreEqual(2, obj_acumulador_una_hora.HorasNoAsistidas());
        }

        [TestMethod]
        public void dados_dos_dias_cursados_de_tres_horas_y_un_alumno_que_estuvo_presente_una_hora_en_cada_dia_deberia_poder_saber_cuantas_horas_no_asistio()
        {
            var valor_propio = 1;
            var horas_del_dia_cursado = 3;
            var obj_acumulador_primer_dia = new AcumuladorHorasDiaCursado(valor_propio, horas_del_dia_cursado);
            var obj_acumulador_segundo_dia = new AcumuladorHorasDiaCursado(valor_propio, horas_del_dia_cursado);

            Assert.AreEqual(4, obj_acumulador_segundo_dia.AcumularHorasNoAsistidas(obj_acumulador_primer_dia.HorasNoAsistidas()));
        }

        [TestMethod]
        public void dados_dos_dias_cursados_de_tres_horas_y_un_alumno_que_no_estuvo_presente_ningun_dia_deberia_poder_saber_cuantas_horas_no_asistio()
        {
            var valor_propio = 0;
            var horas_del_dia_cursado = 3;
            var obj_acumulador_primer_dia = new AcumuladorHorasDiaCursado(valor_propio, horas_del_dia_cursado);
            var obj_acumulador_segundo_dia = new AcumuladorHorasDiaCursado(valor_propio, horas_del_dia_cursado);

            Assert.AreEqual(6, obj_acumulador_segundo_dia.AcumularHorasNoAsistidas(obj_acumulador_primer_dia.HorasNoAsistidas()));
        }

        [TestMethod]
        public void deberia_poder_identificar_que_un_dia_no_se_tomo_asistencia_para_un_alumno_porque_no_debia_hacerse()
        {
            var valor_propio = "-";
            var horas_del_dia_cursado = 3;
            var obj_acumulador = new AcumuladorHorasDiaNoCursado(valor_propio, horas_del_dia_cursado);

            Assert.AreEqual(0, obj_acumulador.HorasNoAsistidas());
            Assert.AreEqual(0, obj_acumulador.HorasAsistidas());
        }

    }
}
