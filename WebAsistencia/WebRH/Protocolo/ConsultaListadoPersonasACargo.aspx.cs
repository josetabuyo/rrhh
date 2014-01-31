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
        var servicio = new WSViaticos.WSViaticosSoapClient();
        Usuario usuario = ((Usuario)Session["usuario"]);
        Persona[] personas;
        List<Persona> personas_todas_areas_a_cargo = new List<Persona>();


        foreach (var area in servicio.AreasAdministradasPor(usuario))
        {
            personas = servicio.GetPersonasACargo(area);

            foreach (var per in personas)
            {
                per.Area = ArmarArea(area);
                personas_todas_areas_a_cargo.Add(per);
            }
        }

        Session["personas"] = personas_todas_areas_a_cargo.ToArray();


        MostrarPersonasEnLaGrilla();
    }

    private void MostrarPersonasEnLaGrilla()
    {
        this.personasJSON.Value = JsonConvert.SerializeObject((Persona[])Session["personas"]);
        //this.areasJSON.Value = JsonConvert.SerializeObject(servicio.GetAreasParaProtocolo());
    }

    private Area ArmarArea(Area area)
    {
        var mi_area = new Area();
        mi_area.Id = area.Id;
        mi_area.Alias = area.Alias;

        return mi_area;
    }

}