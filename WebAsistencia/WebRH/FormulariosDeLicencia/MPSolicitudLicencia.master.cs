#region

using System;
using WSViaticos;

#endregion

public partial class FormulariosDeLicencia_MPSolicitudLicencia : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //AreaE area = new AreaE();
        //area.Nombre = "Area de Prueba general para los conceptos de licencia";
        //Session["areaActual"] = area;

        //AgenteE agente = new AgenteE();
        //agente.Nombre = "Juan Carlos";
        //agente.Apellido = "Testeando";
        //agente.Documento = 29753914;
        //Session["agente"] = agente;

        this.DatosDelAgente1.Area = (Area)Session["areaActual"];
        this.DatosDelAgente1.Agente = (Persona)Session["persona"];
    }

}


