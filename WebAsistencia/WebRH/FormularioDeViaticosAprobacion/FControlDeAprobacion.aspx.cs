using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using System.Drawing;
using WSViaticos;
using WebRhUI;

public partial class FormularioDeViaticosJefe_FControlDeAprobacion : System.Web.UI.Page
{
    private ControladorDeWebControls controlador_controles;

    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        controlador_controles = new ControladorDeWebControls();
        Usuario usuario = ((Usuario)Session["usuario"]);
        var dDLAreas = new DropDownList();

        var ws = new WSViaticosSoapClient();
        var areas_usuario = ws.GetAreasAdministradasPorElUsuario(usuario);

        foreach (Area area in areas_usuario)
        {
            dDLAreas.Items.Add(new ListItem(area.Nombre, area.Id.ToString()));
        }

        //try
        //{
        //    this.DatosDelAgente1.Agente = ((Usuario)Session["usuario"]);
        //    this.DatosDelAgente1.Area = (Area)Session["areaActual"];
        //}
        //catch (Exception)
        //{
        //    Response.Redirect("~\\Principal.aspx");
        //}
        var lista_de_viaticos = ViaticosFromWS();
        Session["listaDeComisiones"] = lista_de_viaticos;

        var idAreasUsuario = areas_usuario.Select(a => a.Id);

        string[] columnasTabla1 = new string[] { "", "DNI", "Nombre de Agente", "Desde", "Hasta", "Importe", "Dias faltantes", "Estado", "Ver Mas" };
        string[] columnasTabla2 = new string[] { "", "DNI", "Nombre de Agente", "Desde", "Hasta", "Area Actual", "Estado", "Ver Mas" };

        MostrarTablaDeViaticos(lista_de_viaticos.FindAll(v => idAreasUsuario.Contains(v.AreaActual.Id)), this.TablaViaticosPendientesDeAprobacion, new ComisionToRowSerializer(), columnasTabla1);
        MostrarTablaDeViaticos(lista_de_viaticos.FindAll(v => !idAreasUsuario.Contains(v.AreaActual.Id)), this.TablaViaticosEnSeguimiento, new ComisionToRowSerializerSeguimiento(), columnasTabla2);
    }


    protected void btn_imprimir_Click(object sender, EventArgs e)
    {
        GuardarEnSesionViaticosSeleccionados();


        if (((List<ComisionDeServicio>)Session["ComisionesAImprimir"]).Count > 0)
        {
            Response.Redirect("~\\Impresiones\\ImpresionComisionesDeServicios.aspx");
        }
    }

    private void GuardarEnSesionViaticosSeleccionados()
    {
        var ids = controlador_controles.IdsDeEntidadesSeleccionadas(Request.Form.AllKeys.ToList());// IdsDeViaticosSeleccionados();
        Session["ComisionesAImprimir"] = ViaticosFromIdsDeViaticos(ids);
    }

    private List<ComisionDeServicio> ViaticosFromIdsDeViaticos(List<int> ids)
    {
        List<ComisionDeServicio> lista_solicitudes_de_viaticos = ViaticosFromWS();
        return lista_solicitudes_de_viaticos.FindAll(c => ids.Contains(c.Id));
    }


    protected void CerrarSessionLinkButton_Click(object sender, EventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~\\Login.aspx");
        }
    }


    //nuevo

    private void MostrarTablaDeViaticos(List<ComisionDeServicio> lista_de_viaticos, Table tablaViaticos, EntityToRowConverter<ComisionDeServicio> rowSerializer, string[] nombresColumnas)
    {


        tablaViaticos.CssClass = "table table-striped table-bordered table-condensed";

        RenderizadorDeTablas<ComisionDeServicio> renderizador = new RenderizadorDeTablas<ComisionDeServicio>(rowSerializer);

        renderizador.EstiloCeldaCabecera = "detalle_viatico_titulo_tabla_detalle";
        renderizador.EstiloCeldaCuerpo = "detalle_viatico_celda_tabla_detalle";
        renderizador.AgregarCabeceras(nombresColumnas, tablaViaticos);

        renderizador.RenderTo(new List<ComisionDeServicio>(lista_de_viaticos), tablaViaticos);

        tablaViaticos.CssClass = "table table-striped table-bordered table-condensed";

    }

    //private void MostrarTablaDeViaticosEnSeguimiento(List<ComisionDeServicio> lista_de_viaticos, Table tablaViaticos)
    //{
    //    RenderizadorDeTablas<ComisionDeServicio> renderizador = new RenderizadorDeTablas<ComisionDeServicio>(new ComisionToRowSerializerSeguimiento());

    //    renderizador.AgregarCabeceras(new string[] { "", "DNI", "Nombre de Agente", "Desde", "Hasta", "Area Actual" , "", "Estado", "Ver Mas" }, this.TablaViaticosEnSeguimiento);

    //    renderizador.RenderTo(new List<ComisionDeServicio>(lista_de_viaticos), this.TablaViaticosEnSeguimiento);

    //    this.TablaViaticosEnSeguimiento.CssClass = "table table-striped table-bordered table-condensed";

    //}

    private List<ComisionDeServicio> ViaticosFromWS()
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        //Usuario usuario = ws_viaticos.Login("fabian", "web1");
        Usuario usuario = (Usuario)Session["usuario"];
        List<ComisionDeServicio> lista_solicitudes_de_viaticos = ws_viaticos.GetComisionesDeServicioPorUsuario(usuario).ToList();
        return lista_solicitudes_de_viaticos;
    }

    [ScriptMethod, WebMethod]
    public static string VerDetalle(object id_comision)
    {
        MeterAreaEnSession(id_comision);
        return "../FormularioDetalleDeViaticos/FDetalleDeViaticos.aspx";
    }

    private static void MeterAreaEnSession(object id_comision)
    {
        List<ComisionDeServicio> lista_comisiones = (List<ComisionDeServicio>)HttpContext.Current.Session["listaDeComisiones"];

        HttpContext.Current.Session["comisionActual"] = lista_comisiones.Find(c => c.Id == (int)id_comision);

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~\\Login.aspx");
        }

    }


}