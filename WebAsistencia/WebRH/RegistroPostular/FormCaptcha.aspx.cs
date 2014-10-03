using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class RegistroPostular_FormCaptcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_recuperar_Click(object sender, EventArgs e)
    {
        if (ValidarCampos())
        {
            var servicio = Servicio();
            bool ok = servicio.RecuperarUsuario(JsonConvert.SerializeObject(new { Mail = this.txt_mail_recupero.Text }));
            if (ok) {
                ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "myFunction();", true);
            }
        }
                   
    }

    private bool ValidarCampos()
    {
        //Validar el formato de la pantalla
        if (ValidarMail() && ValidarCaptcha())
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    private bool ValidarMail()
    {
        string mail = this.txt_mail_recupero.Text;
        if (mail.Equals("") || !mail.Contains("@") || !mail.Contains("."))
        { 
            return false; 
        }
        else 
        {
            return true; 
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
            return false; 
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}