using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebRhUI;
using WSViaticos;

public partial class FormularioReportes_FReportePorProvincia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        ControladorDeWebControls controlador_controles = new ControladorDeWebControls();

        Usuario usuario = ((Usuario)Session["usuario"]);
        var dDLAreas = new DropDownList();

        var ws = new WSViaticosSoapClient();
        var areas_usuario = ws.AreasAdministradasPor(usuario);

        foreach (Area area in areas_usuario)
        {
            dDLAreas.Items.Add(new ListItem(area.Nombre, area.Id.ToString()));
        }

        var idAreasUsuario = areas_usuario.Select(a => a.Id);

        if (Session["zonas"] == null)
        {
            WSViaticosSoapClient service = new WSViaticosSoapClient();
            Session["zonas"] = service.ZonasDeViaticos();
        }

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
            this.TBFechaDesde.Text = DateTime.Now.ToShortDateString();
            this.TBFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.Provincias = vectorProvincias;
        }

        
    }

    private void MostrarReportePorAreaPorProvincia(List<List<string>> reporte, Table tablaResultado)
    {
        RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new ReportePorProvinciaSerialize());
        //Area[] areas_del_usuario = un_usuario.Areas;

        renderizador.EstiloCeldaCabecera = "reporte_por_provincia_titulo";
        renderizador.EstiloCeldaCuerpo = "reporte_por_provincia_celda_detalle";
        renderizador.AgregarCabeceras(new string[] { "PROVINCIA", "CANT. DE VIATICOS", "MONTO DE VIATICO", "TOTAL DE DIAS" }, tablaResultado);

        renderizador.RenderTo(reporte, tablaResultado);

        tablaResultado.CssClass = "tabla_area_provincia";
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
        List<Provincia> lista_prov = GetProvinciasSeleccionadas();

        DateTime fechaDesde = DateTime.Parse(this.TBFechaDesde.Text);// new DateTime(2012, 10, 01);
        DateTime fechaHasta = DateTime.Parse(this.TBFechaHasta.Text);// new DateTime(2012, 12, 01);

        var lista_de_viaticos = ViaticosFromWS();

        List<List<string>> reporte = FiltrarViaticosPor(lista_prov, fechaDesde, fechaHasta, lista_de_viaticos);

        MostrarReportePorAreaPorProvincia(reporte, this.TablaResultado);

        this.label_fecha_desde.Text = this.TBFechaDesde.Text + " - ";
        this.label_fecha_hasta.Text = this.TBFechaHasta.Text;

    }

    private List<List<string>> FiltrarViaticosPor(List<Provincia> lista_prov, DateTime fechaDesde, DateTime fechaHasta, List<ComisionDeServicio> comisiones)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();

        string[][] rto = ws_viaticos.GetComisionesPorProvincia(lista_prov.ToArray(), fechaDesde, fechaHasta, comisiones.ToArray());

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