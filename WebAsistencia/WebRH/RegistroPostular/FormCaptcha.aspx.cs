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
        var servicio = Servicio();
        bool ok = servicio.RecuperarUsuario(JsonConvert.SerializeObject(new { Mail = this.txt_mail_recupero.Text }));

                   
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}