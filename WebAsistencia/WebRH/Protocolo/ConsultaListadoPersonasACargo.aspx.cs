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
        var s = new WSViaticos.WSViaticosSoapClient();

        Usuario usuario = ((Usuario)Session["usuario"]);

        Persona[] personas;
        List<Persona> personas_todas_areas_a_cargo = new List<Persona>();

        if (Session["personas"] == null)
        {

            foreach (var area in usuario.Areas)
            {
                personas = s.GetPersonas(area);

                foreach (var per in personas)
                {
                    per.Area = ArmarArea(area);
                    personas_todas_areas_a_cargo.Add(per);
                }
            }

            personas_todas_areas_a_cargo.Sort((persona1, persona2) => persona1.Apellido.CompareTo(persona2.Apellido));

            Session["personas"] = personas_todas_areas_a_cargo.ToArray();
        }
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


    protected void btnPasePersona_Click(object sender, EventArgs e)
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        var dni = int.Parse(this.DNIPersona.Value);
        //Persona persona = JsonConvert.DeserializeObject<Persona>(ws.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));

        Persona[] personas = (Persona[])Session["personas"];
        Persona persona = personas.ToList().Find(p => p.Documento == dni);
        
        Session["personaPase"] = persona;
        Session["areaActual"] = persona.Area;
        Response.Redirect("~\\FormulariosOtros\\Pases.aspx");
    }


    protected void btnEliminarPasePersona_Click(object sender, EventArgs e)
    {
        var ws = new WSViaticos.WSViaticosSoapClient();
        var dni = int.Parse(this.DNIPersona.Value);
        //Persona persona = JsonConvert.DeserializeObject<Persona>(ws.GetPersonaByDNI(dni, (Usuario)Session[ConstantesDeSesion.USUARIO]));
        PaseDeArea pase = new PaseDeArea();


        Persona[] personas = (Persona[])Session["personas"];
        

        Persona persona = personas.ToList().Find(p => p.Documento == dni);
        pase.Id = persona.PasePendiente.Id;
        ws.EliminarPase(pase);
        Response.Redirect("~\\SeleccionDeArea.aspx");
    }

    private Area ArmarArea(Area area)
    {
        var mi_area = new Area();
        mi_area.Id = area.Id;
        mi_area.Alias = area.Alias;
        mi_area.Nombre = area.Nombre;

        return mi_area;
    }
}