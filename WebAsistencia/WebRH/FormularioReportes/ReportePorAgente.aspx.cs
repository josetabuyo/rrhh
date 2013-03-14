using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebRhUI;
using WSViaticos;

public partial class FormularioReportes_ReportePorAgente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        ControladorDeWebControls controlador_controles = new ControladorDeWebControls();

        Usuario usuario = ((Usuario)Session["usuario"]);
        var dDLAreas = new DropDownList();
        foreach (Area area in usuario.Areas)
        {
            dDLAreas.Items.Add(new ListItem(area.Nombre, area.Id.ToString()));
        }

        var idAreasUsuario = usuario.Areas.Select(a => a.Id);

        if (!IsPostBack)
        {
            this.TBFechaDesde.Text = DateTime.Now.ToShortDateString();
            this.TBFechaHasta.Text = DateTime.Now.ToShortDateString();      
        }

    }

    private void MostrarReportePorAreaPorProvincia(List<List<string>> reporte, Table tablaResultado)
    {
        RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new ReportePorAgenteSerialize());
        //Area[] areas_del_usuario = un_usuario.Areas;

        renderizador.EstiloCeldaCabecera = "reporte_por_agente_titulo";
        renderizador.EstiloCeldaCuerpo = "reporte_por_agente_celda_detalle";
        renderizador.AgregarCabeceras(new string[] { "DNI", "NOMBRE DEL AGENTE", "AREA", "CANT. DE VIATICOS", "MONTO DE VIATICO", "DIAS" }, tablaResultado);

        renderizador.RenderTo(reporte, tablaResultado);

        tablaResultado.CssClass = "table table-striped table-bordered table-condensed";
        //this.Controls.Add(TablaViaticos);
    }

    private List<ComisionDeServicio> ViaticosFromWS()
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        //Usuario usuario = ws_viaticos.Login("fabian", "web1");
        Usuario usuario = (Usuario)Session["usuario"];
        List<ComisionDeServicio> lista_solicitudes_de_viaticos = ws_viaticos.GetTodasLasComisionesDeServicios().ToList();
        return lista_solicitudes_de_viaticos;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime fechaDesde = DateTime.Parse(this.TBFechaDesde.Text);// new DateTime(2012, 10, 01);
        DateTime fechaHasta = DateTime.Parse(this.TBFechaHasta.Text);// new DateTime(2012, 12, 01);
        
        Persona persona_a_buscar = new Persona();
        persona_a_buscar.Documento = int.Parse(this.textbox_dni.Text);

        var lista_de_viaticos = ViaticosFromWS();

        List<Area> areas = GetAreasSeleccionadas();

        List<List<string>> reporte = FiltrarViaticosPor(areas, persona_a_buscar, fechaDesde, fechaHasta, lista_de_viaticos);

        MostrarReportePorAreaPorProvincia(reporte, this.TablaResultado);

        this.label_fecha_desde.Text = this.TBFechaDesde.Text + " - ";
        this.label_fecha_hasta.Text = this.TBFechaHasta.Text;

    }

    private List<List<string>> FiltrarViaticosPor(List<Area> areas, Persona persona, DateTime fechaDesde, DateTime fechaHasta, List<ComisionDeServicio> comisiones)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();

        string[][] rto = ws_viaticos.GetComisionesPorAgente(areas.ToArray(), persona, fechaDesde, fechaHasta, comisiones.ToArray());

        List<List<string>> reporte = new List<List<string>>();

        foreach (var item in rto)
        {
            reporte.Add(item.ToList());
        }

        return reporte;
    }

    private List<Area> GetAreasSeleccionadas()
    {
        Area area_fabi = new Area();
        area_fabi.Id = 1024;
        area_fabi.Nombre = "Area de Fabian";
        area_fabi.Codigo = "010100100000400200000000";
        area_fabi.PresentaDDJJ = true;

        Area area_marta = new Area();
        area_marta.Id = 54;
        area_marta.Nombre = "Area de Marta";
        area_marta.Codigo = "010100100000400000000000";
        area_marta.PresentaDDJJ = true;

        Area area_carlos = new Area();
        area_carlos.Id = 16;
        area_carlos.Nombre = "Area de Castagneto";
        area_carlos.Codigo = "010100100000000000000000";
        area_carlos.PresentaDDJJ = true;

        List<Area> areas = new List<Area>();
        areas.Add(area_fabi);
        areas.Add(area_marta);
        areas.Add(area_carlos);

        return areas;
    }
}