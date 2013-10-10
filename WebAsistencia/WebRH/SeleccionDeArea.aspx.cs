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
        this.areasDelUsuarioJSON.Value = JsonConvert.SerializeObject(usuario.Areas);
    }

    /*
     *     [ScriptMethod, WebMethod]
    public static string EditarElArea(object id_area)
    {
        MeterAreaEnSession(int.Parse(id_area.ToString()));
        return "FormulariosDatosDeContacto/FModificacionDatosDeContacto.aspx";
    }

    [ScriptMethod, WebMethod]
    public static string IrAlArea(object id_area)
    {
        MeterAreaEnSession(int.Parse(id_area.ToString()));
        return "Principal.aspx";       
    }

    private static void MeterAreaEnSession(int id_area)
    {
        var areas_del_usuario = HttpContext.Current.Session["AreasDeUsuarios"];
        List<Area> lista_de_areas = new List<Area>((Area[])areas_del_usuario);
        HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = lista_de_areas.Find(a => a.Id == (int)id_area);
    }
     * */
}