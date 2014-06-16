using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using WebRhUI;
using Newtonsoft.Json;

public partial class FormularioDetalleDeViaticos_FDetalleDeViaticos : System.Web.UI.Page
{
    ComisionDeServicio comision;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        comision = (ComisionDeServicio)Session["comisionActual"];    
    
        Usuario usuario = ((Usuario)Session["usuario"]);

        var ws = new WSViaticosSoapClient();
        var areas_usuario = ws.AreasAdministradasPor(usuario);

        var idAreasUsuario = areas_usuario.Select(a => a.Id).ToList();

        Session["personaViatico"] = comision.Persona;

        MostrarDatosViajante();
        MostrarTablaEstadias();
        MostrarTablaDePasajes();
        MostrarTablaDeFirmantes();
        if (!idAreasUsuario.Contains(comision.AreaActual.Id)) // || !usuario.EsFirmante) NOTA IMPORTANTE: volver a poner obteniendo desde la bd esta condición porque el login ya no lo trae más
        {
            this.controlDeTransiciones.Visible = false;
        }
        else
        {
            CargarControlesDeTransicion();
            this.controlDeTransiciones.Visible = true;
        }

        if (!idAreasUsuario.Contains(comision.AreaActual.Id))  this.BotonModificar.Visible = false;
        else this.BotonModificar.Visible = true;
        
    }

    private void MostrarDatosViajante()
    {
        Encriptador crypt = new Encriptador();
        WSViaticosSoapClient service = new WSViaticosSoapClient();
        Persona personaViat = (Persona)Session["personaViatico"];
        personaViat = service.CompletarDatosDeContratacion(personaViat);
        Session[ConstantesDeSesion.PERSONA] = personaViat;

        string documentoEncriptado = crypt.getMd5Hash(personaViat.Documento + ".jpg");
        this.img_perfil.ImageUrl = "../Imagenes/fotosEncriptadas/" + documentoEncriptado + ".jpg";
        this.LabelNombreApellidoViajante.Text = comision.Persona.Apellido + ", " + comision.Persona.Nombre;
        this.LabelAreaViajante.Text = comision.Persona.Area.Nombre;
        this.LabelTelefonoViajante.Text = comision.Persona.Telefono;
        this.LabelCuilViajante.Text = DarFormatoACuil(comision.Persona.Cuit);
        this.LabelCategoriaViajante.Text = comision.Persona.Categoria + " " + comision.Persona.Nivel;
        this.LabelLegajoViajante.Text = comision.Persona.Legajo;
        this.LabelResumenViatico.Text = "Son: " + CalcularDiasEstadia().ToString() + " días de viáticos a un valor promedio de $ " + String.Format("{0:0.00}", CalcularImporteDiario(comision.Persona)) + " diarios.";
    }

    private string DarFormatoACuil(string cuil)
    {
        return string.Format("{0}-{1}-{2}", cuil.Substring(0, 2), cuil.Substring(2, 8), cuil.Substring(10, 1));
    }

    private float CalcularDiasEstadia()
    {
        float dias = 0;
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        foreach (Estadia estadia in comision.Estadias)
        {
            dias = dias + ws.CalcularDiasPara(estadia);
        }
        return dias;
    }

    private decimal CalcularImporteDiario(Persona persona)
    {
        decimal importe = 0;
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        foreach (Estadia estadia in comision.Estadias)
        {
            importe = importe + ws.CalcularViaticoPara(estadia, persona);
        }
        importe = (importe / comision.Estadias.Length);

        return importe;
    }

    private void MostrarTablaEstadias()
    {
        RenderizadorDeTablas<Estadia> renderizador = new RenderizadorDeTablas<Estadia>(new EstadiaToRowSerializer());

        //renderizador.AgregarCabeceras(new string[] { "Provincia", "Desde", "Hasta", "Eventuales", "Adicional por pasajes", "Monto por categoría", "Motivo" }, this.TablaEstadias);
        renderizador.EstiloCeldaCabecera="detalle_viatico_titulo_tabla_detalle";
        renderizador.EstiloCeldaCuerpo="detalle_viatico_celda_tabla_detalle";
        renderizador.AgregarCabeceras(new string[] { "Provincia", "Desde", "Hora", "Hasta", "Hora", "Eventuales", "Adicional por pasajes", "Monto por categoría", "Motivo" }, this.TablaEstadias);

        renderizador.RenderTo(new List<Estadia>(comision.Estadias), this.TablaEstadias);

        this.TablaEstadias.CssClass = "table table-striped table-bordered table-condensed";
    }

    private void MostrarTablaDePasajes()
    {
        RenderizadorDeTablas<Pasaje> renderizador = new RenderizadorDeTablas<Pasaje>(new PasajeToRowSerializer());

        renderizador.EstiloCeldaCabecera = "detalle_viatico_titulo_tabla_detalle";
        renderizador.EstiloCeldaCuerpo = "detalle_viatico_celda_tabla_detalle";
        renderizador.AgregarCabeceras(new string[] { "Fecha", "Origen", "Destino", "Transporte", "Medio De Pago", "Precio" }, this.TablaPasajes);

        renderizador.RenderTo(new List<Pasaje>(comision.Pasajes), this.TablaPasajes);

        this.TablaPasajes.CssClass = "table table-striped table-bordered table-condensed";
    }

    private void MostrarTablaDeFirmantes()
    {
        var listaTransiciones = new List<TransicionDeViatico>(comision.TransicionesRealizadas);

        listaTransiciones.Sort((t1, t2) => DateTime.Compare(t1.Fecha, t2.Fecha));

        foreach (var t in listaTransiciones)
        {
            var row = new TableRow();
            var cell = new TableCell();
            cell.Text += "<div class='detalle_viatico_contenedor_datos_firmante'>";
                cell.Text += "<div class='detalle_viatico_dato_firmante'>" + t.Fecha.ToShortDateString() + " - </div>";
                cell.Text += "<div class='detalle_viatico_dato_firmante'>" + t.AreaOrigen.Responsables[0].Apellido + ", " + t.AreaOrigen.Responsables[0].Nombre + " - </div>";
                cell.Text += "<div class='detalle_viatico_dato_firmante'>" + t.AreaOrigen.Responsables[0].Nivel + " - </div>";
                cell.Text += "<div class='detalle_viatico_dato_firmante'>" + t.AreaOrigen.Nombre + " </div>";
                cell.Text += "<br />";
                cell.Text += "<div class='detalle_viatico_dato_firmante'> <strong>Acción:</strong> </div>";
                cell.Text += "<div class='detalle_viatico_dato_firmante'>" + t.Accion.DescripcionPasado + " </div>";
                cell.Text += "<br />";
                cell.Text += "<div class='detalle_viatico_dato_firmante'> <strong>Observaciones:</strong> </div>";
                cell.Text += "<div class='detalle_viatico_dato_firmante'>" + t.Comentario + " </div>";
                cell.Text += "<div class='detalle_viatico_alerta_rendiciones_pendientes'>RP* </div>";
                cell.Text += "<div class='detalle_viatico_alerta_viatico_menos_72'>SV* </div>";
            cell.Text += "</div>";
            row.Cells.Add(cell);
            this.TablaFirmantes.Rows.Add(row);    
        }       
    }

    private void CargarControlesDeTransicion()
    {
        var viaticoActual = (ComisionDeServicio)Session["comisionActual"];
        WSViaticosSoapClient ws = new WSViaticosSoapClient();

        //Areas de transicion por defecto
        var areaSiguiente = ws.SiguientePasoDelCircuitoDelArea(viaticoActual.AreaActual);
        this.selectorDeAreaAprobacion.Value = areaSiguiente.Nombre;
        this.AreaSeleccionadaAprobacion.Value = areaSiguiente.Id.ToString();

        var transicion = viaticoActual.TransicionesRealizadas.ToList().Find(t => 
                                            t.AreaDestino.Id == viaticoActual.AreaActual.Id && 
                                            (t.Accion.Id == 1||t.Accion.Id == 4));
        
        if (transicion != null)
        {
            var areaAnterior = transicion.AreaOrigen;
            this.selectorDeAreaModificacion.Value = areaAnterior.Nombre;
            this.AreaSeleccionadaModificacion.Value = areaAnterior.Id.ToString();

            this.selectorDeAreaRechazo.Value = areaAnterior.Nombre;
            this.AreaSeleccionadaRechazo.Value = areaAnterior.Id.ToString();
        }
        List<Area> areas = ws.GetAreas().ToList();
        var dataSourceAreas = new List<Object>();

        areas.ForEach(delegate(Area a)
        {
            dataSourceAreas.Add(new { label = a.Nombre, value = a.Id.ToString() });
        });
        this.ListaAreas.Value = JsonConvert.SerializeObject(dataSourceAreas);
        this.AlertaTransicionInvalida.Visible = false;

        //if (ValidacionesEnComisionesDeServicios.Validar72Horas(comision.FechaCreacion, comision.Estadias.Select(es => es.Desde).Min()))
        //{

        //    this.lbValidacion72horas.Text = "El Viático fue solicitado con menos de 72 horas hábiles";
        //}
    }

    //private void AgregarAreasAnterioresAlComboDeSolicitarModificacion(ComisionDeServicio viaticoActual)
    //{
        //foreach (var t in viaticoActual.TransicionesRealizadas)
        //{
        //    var a = t.AreaOrigen;
        //    //Agrego las areas distintas entre si y distintas al area actual
        //    if (this.cmbAreasTransicionesAnteriores.Items.FindByValue(a.Id.ToString()) == null)
        //    {
        //        if (a.Id != viaticoActual.AreaActual.Id)
        //        {
        //            this.cmbAreasTransicionesAnteriores.Items.Add(new System.Web.UI.WebControls.ListItem(a.Nombre, a.Id.ToString()));
        //        }
        //    }
        //}
    //}


    //protected void Btn_AccesoDirectoAprobar_Click(object sender, EventArgs e)
    //{
    //    WSViaticosSoapClient ws = new WSViaticosSoapClient();
    //    ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
    //    ws.ReasignarComision(una_comision, ws.GetAreaSuperiorA(((ComisionDeServicio)Session["comisionActual"]).AreaActual).Id, 1, "");
    //    Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
    //}

    //protected void Btn_AccesoDirectoSolicitarModificacion_Click(object sender, EventArgs e)
    //{
    //    WSViaticosSoapClient ws = new WSViaticosSoapClient();
    //    ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];

    //    ws.ReasignarComision(una_comision, Int32.Parse(this.cmbAreasTransicionesAnteriores.SelectedValue), 2, "");
    //    Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
    //}

    //protected void btnEnviar_Click(object sender, EventArgs e)
    //{
    //    WSViaticosSoapClient ws = new WSViaticosSoapClient();
    //    ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
    //    try
    //    {
    //        Int32 id_area = Int32.Parse(this.AreaSeleccionada.Value);
    //        ws.ReasignarComision(una_comision, id_area, Int32.Parse(this.cmbAccion.SelectedValue), this.txtComentarios.Text);
    //        Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
    //    }
    //    catch (FormatException ex)
    //    {
    //        this.AlertaTransicionInvalida.InnerText = "Debe seleccionar un área destino para enviar el viático";
    //        this.AlertaTransicionInvalida.Visible = true;
    //    }

    //}

    protected void botonAprobar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
        try
        {
            Int32 id_area = Int32.Parse(this.AreaSeleccionadaAprobacion.Value);
            ws.ReasignarComision(una_comision, id_area, 1, this.txtComentarios.Text);
            Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
        }
        catch (FormatException)
        {
            this.AlertaTransicionInvalida.InnerText = "Debe seleccionar un área destino para enviar el viático";
            this.AlertaTransicionInvalida.Visible = true;
        }
    }

    protected void botonModificar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
        try
        {
            Int32 id_area = Int32.Parse(this.AreaSeleccionadaModificacion.Value);
            ws.ReasignarComision(una_comision, id_area, 2, this.txtComentarios.Text);
            Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
        }
        catch (FormatException)
        {
            this.AlertaTransicionInvalida.InnerText = "Debe seleccionar un área destino para enviar el viático";
            this.AlertaTransicionInvalida.Visible = true;
        }
    }

    protected void botonRechazar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
        try
        {
            Int32 id_area = Int32.Parse(this.AreaSeleccionadaRechazo.Value);
            ws.ReasignarComision(una_comision, id_area, 3, this.txtComentarios.Text);
            Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
        }
        catch (FormatException)
        {
            this.AlertaTransicionInvalida.InnerText = "Debe seleccionar un área destino para enviar el viático";
            this.AlertaTransicionInvalida.Visible = true;
        }
    }

    protected void Modificar_Click(object sender, EventArgs e)
    {
        ComisionDeServicio comisionEnEdicion = new ComisionDeServicio();
        comisionEnEdicion.Estadias = new Estadia[0];
        comisionEnEdicion.Pasajes = new Pasaje[0];

        Session[ConstantesDeSesion.VIATICO_EN_EDICION] = comision;
        Session[ConstantesDeSesion.AREA_ACTUAL] = comision.AreaCreadora;
        Session["personaViatico"] = comision.Persona;
        Session["VieneDeModificacion"] = true;
        Session["EstadiasQuitadas"] = new List<string>();
        Session["PasajesQuitadas"] = new List<string>();
        Session["Viatico vacio"] = comisionEnEdicion;
        Response.Redirect("~\\FormularioDeViaticos\\FCargaComisionDeServicio.aspx");
    }
}