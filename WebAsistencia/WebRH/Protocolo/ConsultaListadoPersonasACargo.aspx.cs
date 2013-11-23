using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioProtocolo_ConsultaListadoPersonasACargo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var servicio = new WSViaticos.WSViaticosSoapClient();
        MostrarPersonasEnLaGrilla();
    }

    private void MostrarPersonasEnLaGrilla()
    {
        this.personasJSON.Value = JsonConvert.SerializeObject((Persona[])Session["personas"]);
        //this.areasJSON.Value = JsonConvert.SerializeObject(servicio.GetAreasParaProtocolo());
    }

    protected void btnAsistenciaAlumno_Click(object sender, EventArgs e)
    {
        var s = new WSViaticos.WSViaticosSoapClient();
        var dni = int.Parse(this.DNIPersona.Value);
        Persona persona = JsonConvert.DeserializeObject<Persona>(s.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));
        Session["persona"] = persona;
        //Session["areaActual"] = 
        Response.Redirect("~\\ConceptosLicencia.aspx");
    }


    protected void btnPasePersona_Click(object sender, EventArgs e)
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        var dni = int.Parse(this.DNIPersona.Value);
        Persona persona = JsonConvert.DeserializeObject<Persona>(ws.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));
        Session["personaPase"] = persona;
        Response.Redirect("~\\FormulariosOtros\\Pases.aspx");
    }


    protected void btnEliminarPasePersona_Click(object sender, EventArgs e)
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        var dni = int.Parse(this.DNIPersona.Value);
        Persona persona = JsonConvert.DeserializeObject<Persona>(ws.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));
        PaseDeArea pase = new PaseDeArea();
        pase.Id = persona.PasePendiente.Id;
        ws.EliminarPase(pase);
        Response.Redirect("~\\Principal.aspx");
    }
}