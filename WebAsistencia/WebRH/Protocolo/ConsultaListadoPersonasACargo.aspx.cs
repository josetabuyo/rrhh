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

    protected void btnAsistencia_Click(object sender, EventArgs e)
    {
        var s = new WSViaticos.WSViaticosSoapClient();
        var dni = int.Parse(this.DNIPersona.Value);
        Area area = new Area();
        area.Nombre = this.areaPersona.Value;
        Persona persona = JsonConvert.DeserializeObject<Persona>(s.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));
        Persona[] personas = (Persona[])Session["personas"];

        Session["persona"] = persona;
        Session["areaActual"] = personas.ToList().Find(p => p.Documento.Equals(persona.Documento)).Area;
        Response.Redirect("~\\ConceptosLicencia.aspx");
    }

    protected void btnEliminarAsistencia_Click(object sender, EventArgs e)
    {
        //var s = new WSViaticos.WSViaticosSoapClient();
        //var dni = int.Parse(this.DNIPersona.Value);
        //Area area = new Area();
        //area.Nombre = this.areaPersona.Value;
        //Persona persona = JsonConvert.DeserializeObject<Persona>(s.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));
        //Persona[] personas = (Persona[])Session["personas"];

        //Session["persona"] = persona;
        //Session["areaActual"] = personas.ToList().Find(p => p.Documento.Equals(persona.Documento)).Area;
        //Response.Redirect("~\\ConceptosLicencia.aspx");
    } 
}