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
using Newtonsoft.Json;

public partial class FormularioReportes_FReportesViaticos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        ControladorDeWebControls controlador_controles = new ControladorDeWebControls();
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        
        Usuario usuario = ((Usuario)Session["usuario"]);
        var dDLAreas = new DropDownList();
        foreach (Area area in usuario.Areas)
        {
            dDLAreas.Items.Add(new ListItem(area.Nombre, area.Id.ToString()));
        }

        var idAreasUsuario = usuario.Areas.Select(a => a.Id);

        if (Session["zonas"] == null)
        {
            WSViaticosSoapClient service = new WSViaticosSoapClient();
            Session["zonas"] = service.ZonasDeViaticos();           
        }

        this.TBFechaDesde.Text = DateTime.Now.ToShortDateString();
        this.TBFechaHasta.Text = DateTime.Now.ToShortDateString();

        List<Provincia> provincias = new List<Provincia>();

        foreach (Zona unaZona in (Zona[])Session["zonas"])
        {
            foreach (Provincia unaProvincia in unaZona.Provincias)
            {
                provincias.Add(unaProvincia);
            }
        }

        Provincia[] vectorProvincias = new Provincia[provincias.Count];

        for (int i = 0; i < provincias.Count; i++)
        {
            vectorProvincias[i] = provincias[i];
        }

        if (!IsPostBack)
        {
            this.Provincias = vectorProvincias;
        }

        List<Area> areas = ws.GetAreas().ToList();
        var dataSourceAreas = new List<Object>();

        areas.ForEach(delegate(Area a)
        {
            //this.BulletedList1 controlador_controles.DibujarListaConCheckbox(a, "click_checkbox");
            dataSourceAreas.Add(new { label = a.Nombre, value = a.Id.ToString() });
        });

        this.Label2.Text = JsonConvert.SerializeObject(dataSourceAreas);

    }

    private void MostrarReportePorAreaPorProvincia(List<List<string>> reporte, Table tablaResultado)
    {
        RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new ReportePorAreaYFechaSerialize());
        //Area[] areas_del_usuario = un_usuario.Areas;

        renderizador.AgregarCabeceras(new string[] { "AREA", "PROVINCIA", "CANT. DE VIATICOS", "MONTO DE VIATICO", "DIAS" }, tablaResultado);

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
        List<Area> lista_areas = GetAreasSeleccionadas();

        List<Provincia> lista_prov = GetProvinciasSeleccionadas();

        DateTime fechaDesde = DateTime.Parse(this.TBFechaDesde.Text);// new DateTime(2012, 10, 01);
        DateTime fechaHasta = DateTime.Parse(this.TBFechaHasta.Text);// new DateTime(2012, 12, 01);
  
        var lista_de_viaticos = ViaticosFromWS();

        List<List<string>> reporte = FiltrarViaticosPor(lista_areas, lista_prov, fechaDesde, fechaHasta, lista_de_viaticos);

        MostrarReportePorAreaPorProvincia(reporte, this.TablaResultado);

    }

    private List<List<string>> FiltrarViaticosPor(List<Area> lista_areas, List<Provincia> lista_prov, DateTime fechaDesde, DateTime fechaHasta, List<ComisionDeServicio> comisiones)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();

        string[][] rto = ws_viaticos.GetComisionesPorFiltro(lista_areas.ToArray(), lista_prov.ToArray(), fechaDesde, fechaHasta, comisiones.ToArray());

        List<List<string>> reporte = new List<List<string>>();

        foreach (var item in rto)
	    {
            reporte.Add(item.ToList());
	    }                

        return reporte;
    }


    private List<Provincia> GetProvinciasSeleccionadas()
    {
        List<Provincia> lista_provincias = new List<Provincia>();
        Provincia provincia = new Provincia();
   
        var indices_seleccionados = this.DDLProvincias.GetSelectedIndices().ToList();

        foreach (var indice in indices_seleccionados)
        {
            Provincia prov = new Provincia();
            prov.Id = int.Parse(this.DDLProvincias.Items[indice].Value);
            prov.Nombre = this.DDLProvincias.Items[indice].Text;

            lista_provincias.Add(prov);  
        }

        return lista_provincias;
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

    public Provincia[] Provincias
    {
        set
        {
            this.DDLProvincias.Items.Clear();
            foreach (Provincia unaProvincia in value)
            {
                ListItem unListItem = new ListItem();
                unListItem.Value = unaProvincia.Id.ToString();
                unListItem.Text = unaProvincia.Nombre;
                this.DDLProvincias.Items.Add(unListItem);    
            }
        }
    }
}