using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioProtocolo_ConsultaListadoLicencias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        Usuario usuario = ((Usuario)Session["usuario"]);
        Persona[] personas;
        List<Persona> personas_todas_areas_a_cargo = new List<Persona>();
        List<Persona> personas_con_ausencias = new List<Persona>();

        foreach (var area in servicio.AreasAdministradasPor(usuario))
        {
            personas = servicio.GetPersonasACargo(area);

            foreach (var per in personas)
            {
                per.Area = ArmarArea(area);
                personas_todas_areas_a_cargo.Add(per);
            }
        }
        var desde = new DateTime(2005, 12, 31);
        var hasta = new DateTime(9999, 12, 31);

        personas_con_ausencias = servicio.GetAusentesEntreFechasPara(personas_todas_areas_a_cargo.ToArray(), desde, hasta).ToList();

        personas_con_ausencias.Sort((persona1, persona2) => persona1.Apellido.CompareTo(persona2.Apellido));
        Session["personas_inasistencia"] = personas_con_ausencias.ToArray();

        MostrarPersonasEnLaGrilla();
    }

    private void MostrarPersonasEnLaGrilla()
    {
        this.personasJSON.Value = JsonConvert.SerializeObject((Persona[])Session["personas_inasistencia"]);
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
