using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


public partial class CtrlAcc_ReporteXPersona : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    [WebMethod]
    public static string GetData( string nombre, string apellido )
    {
        return "Prueba " + nombre + " " + apellido; 
    }

}