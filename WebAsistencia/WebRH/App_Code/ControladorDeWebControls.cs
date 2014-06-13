using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebRhUI
{
    public class ControladorDeWebControls
    {
        public CheckBox CheckboxPara(object entidad)
        {
            CheckBox checkbox = new CheckBox();

            checkbox.ID = IdPara(entidad);

            return checkbox;
        }

        public string DibujarChecboxPara(object entidad)
        {
            return "<input type=\"checkbox\" runat=\"server\" id=\"check_" + IdPara(entidad) + "\" name=\"check$" + IdPara(entidad) + "\"/>";
        }

        public string DibujarLinkConImagen(object entidad, string metodo, string ruta_de_imagen, string ancho, string alto)
        {
            return "<a href=\"#\"><img width=\"" + ancho + "\" height=\"" + alto + "\" id=\"boton_" + IdPara(entidad) + "\" onclick=\"" + metodo + "(" + IdDeLaEntidad(entidad) + ")\" src=\"" + ruta_de_imagen + "\"/></a>";
        }

        public string DibujarLink(object entidad, string metodo, string texto)
        {
            return "<a href=\"#\" id=\"boton_" + IdPara(entidad) + "\" onclick=\"" + metodo + "(" + IdDeLaEntidad(entidad) + ")\"/>" + texto + "</a>";
        }

        public string DibujarLinkParaRequest(object entidad, string metodo)
        {
            return "<a href=FCargaComisionDeServicio.aspx?" + metodo + "=" + IdDeLaEntidad(entidad) + ">Quitar</a>";//#\" onclick=\"" + metodo + "(" + IdDeLaEntidad(entidad) + ")\"  id=\"quitar_" + IdPara(entidad) + "\">Quitar</a>";
        }

        public Button DibujarBoton(object entidad, string metodo)
        {
            Button btn = new Button();
            btn.Text = "Quitar";
            btn.OnClientClick = metodo + "(" + IdDeLaEntidad(entidad) + ")";

            return btn;

            //return "<a href=\"#\" onclick=\"" + metodo + "(" + IdDeLaEntidad(entidad) + ")\"  id=\"quitar_" + IdPara(entidad) + "\">Quitar</a>";
            //return "<input type=\"submit\" runat=\"server\" value=\"Quitar\" onclick=\"" + metodo + "(" + IdDeLaEntidad(entidad) + ")\" />";

        }

        public string DibujarListaConCheckbox(object entidad, string metodo)
        {

            return "<li>" + DibujarChecboxPara(entidad) + "<label>" + entidad + "</label></li>";
        }

        private string CaracterSeparador()
        {
            return "|";
        }

        private string IdDeLaEntidad(object entidad)
        {
            return entidad.GetType().GetProperty("Id").GetValue(entidad, null).ToString();
        }

        public int IdDeLaEntidadEn(WebControl web_control)
        {
            return IdDeLaEntidadEn(web_control.ID);
        }

        public int IdDeLaEntidadEn(string id_del_control)
        {
            return int.Parse(id_del_control.Split(CaracterSeparador().ToArray())[1]);
        }


        public List<string> IdsDeObjetosEnFormulario(List<string> request_form_all_keys)
        {
            var ids_de_controles = request_form_all_keys.FindAll(id_control => id_control.Contains(CaracterSeparador()));
            return ids_de_controles;
        }

        public List<int> IdsDeEntidadesSeleccionadas(List<string> ids_controles)
        {
            return IdsDeObjetosEnFormulario(ids_controles).Select(id_control => IdDeLaEntidadEn(id_control)).ToList();
        }


        private string IdPara(object entidad)
        {
            return CaracterSeparador() + IdDeLaEntidad(entidad);
        }
    }
}
