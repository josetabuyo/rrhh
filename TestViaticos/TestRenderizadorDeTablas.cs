using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using WebRhUI;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebRhUITestNew
{
    [TestClass]
    public class TestRenderizadorDeTablas
    {
        private string Nombre = "Nombre";
        private string Dependencia = "Dependencia";

        [TestMethod]
        public void deberia_poder_agregarle_cabeceras_de_columna_a_una_tabla()
        {
            Table tabla_de_personas = TablaVacia();


            Renderizador().AgregarCabeceras(new string[] { Nombre, Dependencia }, tabla_de_personas);


            Assert.AreEqual(2, tabla_de_personas.Rows[0].Cells.Count);
            Assert.AreEqual(Nombre, tabla_de_personas.Rows[0].Cells[0].Text = Nombre);
            Assert.AreEqual(Dependencia, tabla_de_personas.Rows[0].Cells[0].Text = Dependencia);
        }



        [TestMethod]
        public void deberia_poder_agregar_un_row_desde_una_entidad_especificando_como_obtener_los_valores_a_partir_de_la_misma()
        {
            Table tabla_de_areas = TablaVacia();
            FakeArea un_area = new FakeArea(1, "Area1");
            Renderizador().AgregarCabeceras(new string[] { "Id del Area", "Nombre del Area" }, tabla_de_areas);



            Renderizador().AddRowFrom(un_area, tabla_de_areas);

            Assert.AreEqual(2, tabla_de_areas.Rows.Count);
            Assert.AreEqual("1", tabla_de_areas.Rows[1].Cells[0].Text = "1");
            Assert.AreEqual("Area1", tabla_de_areas.Rows[1].Cells[1].Text = "Area1");
        }



        private class UnConverter : EntityToRowConverter<FakeArea>
        {

            public override List<object> Serialize(FakeArea entidad)
            {
                return new List<object>() { entidad.Id.ToString(), entidad.Nombre };
            }
        }

        private Table TablaVacia()
        {
            return new Table();
        }

        private RenderizadorDeTablas<FakeArea> _renderizador;
        private RenderizadorDeTablas<FakeArea> Renderizador()
        {
            if (_renderizador == null)
                _renderizador = new RenderizadorDeTablas<FakeArea>(new UnConverter());
            return _renderizador;
        }
    }
}
