using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class RegistroPostular_FormCaptchaRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_registrar_Click(object sender, EventArgs e)
    {
        if (ValidarCampos())
        {
            var servicio = Servicio();
            var personas = servicio.BuscarPersonas(JsonConvert.SerializeObject(new { Documento = this.txt_dni_registro.Text }));
            if (personas.Length > 0)
            {
                this.lb_mensajeError.Text = "El documento ingresado ya está registrado, inicie sesión con el usuario asignado. Si no los recuerda, utilice la opción: '¿Olvidó sus datos?' o comuníquese con <br/> Recursos Humanos.";

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "RegistroOk", "RegistroOk();", true);

            }
            
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "RegistroError", "RegistroError();", true);
        }
                   
    }

    private bool ValidarCampos()
    {
        //Validar el formato de la pantalla
        if (ValidarDNI() && ValidarCaptcha())
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    private bool ValidarDNI()
    {
        string dni = this.txt_dni_registro.Text;
        var dni_array = dni.ToArray();
        bool valido = true;
        foreach (var numero in dni_array)
        {
            if (!(numero.Equals('1') || numero.Equals('2') || numero.Equals('3') || numero.Equals('4') || numero.Equals('5') ||
               numero.Equals('6') || numero.Equals('7') || numero.Equals('8') || numero.Equals('9') || numero.Equals('0')))
            {
                valido = false;
                break;
            }
        }
        if (valido) //arreglar
        {
            return true;
        }
        else 
        {
            this.lb_mensajeError.Text = "El formato del DNI no es válido.";
            return false; 
        }
    }

    private bool ValidarCaptcha()
    {
        if (txtImg.Text.ToString().ToLower().Equals(Session["RandomNumero"].ToString().ToLower()))
        { 
            return true; 
        }
        else 
        {
            this.lb_mensajeError.Text = "Los dígitos ingresados no coninciden con los de la Imagen.";
            return false; 
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}