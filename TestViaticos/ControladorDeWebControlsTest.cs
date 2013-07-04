using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebRhUITestNew
{
    [TestClass]
    public class ControladorDeWebControlsTest
    {
        [TestMethod]
        public void deberia_poder_crear_un_checkbox_con_id_segun_la_entidad()
        {
            var checkbox = ControladorDeWebControls().CheckboxPara(UnArea());
            Assert.AreEqual(7, ControladorDeWebControls().IdDeLaEntidadEn(checkbox));
        }

        [TestMethod]
        public void deberia_poder_tener_los_checkboxes_seleccionados_de_un_request()
        {

            //tiene un pipe.
            string un_id_de_componente_representando_una_entidad = "Control_blah_blah|Id_7";

            //no tiene pipe
            string un_id_de_componente_que_no_representa_una_entidad = "un_control_que_no_representa_nada";

            //requets_form_all_keys es Request.Form.AllKeys en un formulario;
            List<string> request_form_all_keys = new List<string>() { un_id_de_componente_representando_una_entidad, un_id_de_componente_que_no_representa_una_entidad };


            List<string> ids_checkboxes_seleccionados = ControladorDeWebControls().IdsDeObjetosEnFormulario(request_form_all_keys);


            Assert.IsTrue(ids_checkboxes_seleccionados.Contains(un_id_de_componente_representando_una_entidad));
            Assert.IsFalse(ids_checkboxes_seleccionados.Contains(un_id_de_componente_que_no_representa_una_entidad));
        }

        [TestMethod]
        public void deberia_poder_obtener_los_ids_de_las_entidades_seleccionadas()
        {
            var checkbox_un_area = ControladorDeWebControls().CheckboxPara(UnArea());
            var checkbox_otra_area = ControladorDeWebControls().CheckboxPara(OtraArea());

            //requets_form_all_keys es Request.Form.AllKeys en un formulario;
            List<string> request_form_all_keys = new List<string>() { checkbox_un_area.ID, checkbox_otra_area.ID };

            List<int> ids_areas = ControladorDeWebControls().IdsDeEntidadesSeleccionadas(request_form_all_keys);


            Assert.AreEqual(2, ids_areas.Count);
            Assert.IsTrue(ids_areas.Contains(7));
            Assert.IsTrue(ids_areas.Contains(12));
        }

        [TestMethod]
        public void deberia_poder_obtener_el_string_de_un_link_en_imagen_de_las_entidades_seleccionadas()
        {
            string stringHTML = ControladorDeWebControls().DibujarLinkConImagen(OtraArea(),"VerDetalle","imagenes","30","30");

            string stringDePrueba = "<a href=\"#\"><img width=\"30\" height=\"30\" id=\"boton_|12\" onclick=\"VerDetalle(12)\" src=\"imagenes\"/></a>";

            Assert.AreEqual(stringDePrueba, stringHTML);              
        }

        [TestMethod]
        public void deberia_poder_obtener_el_string_de_un_chekbox()
        {
            string stringHTML = ControladorDeWebControls().DibujarChecboxPara(OtraArea());

            string stringDePrueba = "<input type=\"checkbox\" runat=\"server\" id=\"check_|12\" name=\"check$|12\"/>";

            Assert.AreEqual(stringDePrueba, stringHTML);
        }

        private FakeArea otra_area;
        private object OtraArea()
        {
            if (otra_area == null)
                otra_area = new FakeArea(12, "Area 12");
            return otra_area;
        }


        private FakeArea un_area;
        private FakeArea UnArea()
        {
            if (un_area == null)
                un_area = new FakeArea(7, "Area 7");
            return un_area;
        }

        private ControladorDeWebControls controlador;
        private ControladorDeWebControls ControladorDeWebControls()
        {
            if (controlador == null)
                controlador = new ControladorDeWebControls();
            return controlador;
        }
    }
}
