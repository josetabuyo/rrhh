#region

using System;
using WSViaticos;

#endregion

public partial class FormulariosDeLicencia_MPSolicitudLicencia : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //utilizado para pruebas hardcodeadas
   /*     Area area = new Area();
        area.Nombre = "Area de Prueba general para los conceptos de licencia";
        area.Id = 1327;
        Session["areaActual"] = area;

        Persona agente = new Persona();
        agente.Nombre = "Juan Carlos";
        agente.Apellido = "Testeando";
        agente.Documento = 29753914;
        Session["persona"] = agente;*/
        
        /////

        this.DatosDelAgente1.Area = (Area)Session["areaActual"];
        this.DatosDelAgente1.Agente = (Persona)Session["persona"];
    }

}


