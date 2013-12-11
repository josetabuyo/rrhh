#region

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebRhUI;
using WSViaticos;
using System.Collections;
using Newtonsoft.Json;


#endregion

public partial class SeleccionDeArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        Usuario usuario = ((Usuario)Session["usuario"]);
        //WSViaticosSoapClient s = new WSViaticosSoapClient();
        if (usuario.TienePermisosParaSiCoI) { Response.Redirect("~/SiCoI/AltaDeDocumento.aspx"); }
        if (usuario.TienePermisosParaSACC) { Response.Redirect("~/SACC/Inicio.aspx"); }
        if (usuario.TienePermisosParaModil) { Response.Redirect("~/Modi/Modi.aspx"); }
        //Response.Redirect("SeleccionDeArea.aspx");
        this.areasDelUsuarioJSON.Value = JsonConvert.SerializeObject(usuario.Areas);
       // Persona[] personas;
       // List<Persona> personas_todas_areas_a_cargo = new List<Persona>();
        
        //foreach (var area in usuario.Areas)
        //{
        //    personas =  s.GetPersonas(area);
            
        //    foreach (var per in personas)
        //    {
        //        per.Area = ArmarArea(area);
        //        personas_todas_areas_a_cargo.Add(per);
        //    }
        //}

        //Session["personas"] = personas_todas_areas_a_cargo.ToArray();

    }

    //private Area ArmarArea(Area area)
    //{
    //    var mi_area = new Area();
    //    mi_area.Id = area.Id;
    //    mi_area.Alias = area.Alias;

    //    return mi_area;
    //}
}