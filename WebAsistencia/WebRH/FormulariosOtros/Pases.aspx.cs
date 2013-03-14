#region

using System;
using WSViaticos;

#endregion

public partial class FormulariosOtros_Pases : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos ws = new WSViaticos.WSViaticos();
        Area[] areas = ws.GetAreas();
        this.ControlSeleccionDeArea1.Areas = areas;
    }
}
