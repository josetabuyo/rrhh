using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
            //Se habilita el registro de empleados del ministerio por pedido de Marta
            //var personas = servicio.BuscarPersonas(JsonConvert.SerializeObject(new { Documento = Convert.ToInt32(this.txt_dni_registro.Text) }));
            //if (personas.Length > 0)
            //{
            //    this.lb_mensajeError.Text = "Si bien tenemos sus datos personales registrados en nuestra base de RRHH, los mismos no se encuentran asociados a un correo electrónico de referencia. Este paso es FUNDAMENTAL para establecer una vía de comunicación estable. Por favor tenga a bien comunicarse por mail a la casilla concursos@desarrollosocial.gov.ar, enviando un mensaje con el asunto \"Solicito Alta al Sistema POSTULAR\". En el cuerpo del mensaje por favor especifique un teléfono y horario de contacto. Nos comunicaremos con usted a la mayor brevedad posible.";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "RegistroOk", "RegistroOk();", true);
            //}
            //else
            //{
                AspiranteAUsuario aspirante = new AspiranteAUsuario();
                aspirante.Apellido = this.txt_apellido_registro.Text;
                aspirante.Documento = Convert.ToInt32(this.txt_dni_registro.Text);
                aspirante.Email = this.txt_mail_registro.Text;
                aspirante.Nombre = this.txt_nombre_registro.Text;

                if (servicio.RegistrarNuevoUsuario(aspirante))
                {
                    this.lb_mensajeError.Text = "Registración finalizada correctamente. Se le ha enviado un mail con su nombre de usuario y contraseña";
                    ScriptManager.RegisterStartupScript(this, GetType(), "RegistroOk", "RegistroOk();", true);
                }
                else
                {
                    this.lb_mensajeError.Text = "No se ha podido generar el usuario. Verifique si ya se ha registrado con el mail ingresado o caso contrario contáctese con Recursos Humanos";
                    ScriptManager.RegisterStartupScript(this, GetType(), "RegistroOk", "RegistroOk();", true);
                }
            //}
            
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "RegistroError", "RegistroError();", true);
        }
                   
    }

    private bool ValidarCampos()
    {
        //Validar el formato de la pantalla
        if (ValidarDNI() && 
            ValidarString(this.txt_nombre_registro.Text) && 
            ValidarString(this.txt_apellido_registro.Text) &&
            ValidarMail() && ValidarCaptcha())
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
        int dni = 0;
        try
        {
            dni = Convert.ToInt32(this.txt_dni_registro.Text);
        }
        catch (Exception)
        {
            this.lb_mensajeError.Text = "El formato del DNI no es válido. Ingrese sólo Números";
            return false; 
        }
       

        if (100000 < dni && dni < 99999999)
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

    private bool ValidarString (string palabra)
    {
        if (palabra.Equals(""))
	{
		return false; 
	}
        return true;
    }

    private bool ValidarMail()
    {
        string email = this.txt_mail_registro.Text;
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                this.lb_mensajeError.Text = "El formato del mail no es válido.";
                return false;
            }
        }
        else
        {
            this.lb_mensajeError.Text = "El formato del mail no es válido.";
            return false;
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}