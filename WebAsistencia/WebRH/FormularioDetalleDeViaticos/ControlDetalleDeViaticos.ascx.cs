using System;
using System.Linq;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;
using WebRhUI;
using System.Web.Script.Services;
using System.Web.Services;


public partial class FormularioDetalleDeViaticos_ControlDetalleDeViaticos : System.Web.UI.UserControl
{
    
    ComisionDeServicio comision;

    public ComisionDeServicio ComisionServicio
    {        
        set
        {
            comision = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["comisionActual"] != null)
        {            
            comision = (ComisionDeServicio)Session["comisionActual"];        
        }

        //Table tabla_encabezado_datos_persona = ConstruirTabla("Datos Personales");
        //Table tabla_detalle_datos_persona = ContruirTablaDetalleDatosPersonales();

        //Table tabla_encabezado_estadia = ConstruirTabla("Detalle de Estadías");
        //Table tabla_detalle_estadia = ConstruirTablaDetalleEstadia();

        MostrarTablaDePersona();
        MostrarTablaEstadias();
        MostrarTablaDePasajes();
       // Table tabla_encabezado_pasaje = ConstruirTabla("Detalle de Pasajes");
        //Table tabla_detalle_pasaje = ConstruirTablaDetallePasaje();
        
        System.Web.UI.WebControls.Panel lista_firmantes = ConstruirListaFirmantes();
                   
        this.Controls.Add(lista_firmantes);

        Usuario usuario = ((Usuario)Session["usuario"]);
        var idAreasUsuario = usuario.Areas.Select(a => a.Id);

        if (!idAreasUsuario.Contains(comision.AreaActual.Id))
        {
            this.BotonModificar.Visible = false;
        }

        if (ValidacionesEnComisionesDeServicios.Validar72Horas(comision.FechaCreacion, comision.Estadias.Select(es => es.Desde).Min()))
        {

            this.lbValidacion72horas.Text = "El Viático fue solicitado con menos de 72 horas hábiles";
        }
    }

    private void MostrarTablaDePersona()
    {
        RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new ListDeListToRowSerialize());
        renderizador.RenderTo(ConstruirPersona(comision.Persona), this.TablaPersonas);
    }

    //nuevo
    private List<List<string>> ConstruirPersona(Persona persona)
    {
        List<List<string>> lista_valores_de_persona = new List<List<string>>();
        
        List<string> persona_nombre = new List<string>();
        persona_nombre.Add("<b>Nombre: </b>");
        persona_nombre.Add(persona.Apellido + ", " + persona.Nombre);
   
        List<string> persona_area = new List<string>();
        persona_area.Add("<b>Área:</b> ");
        persona_area.Add(persona.Area.Nombre);

        List<string> persona_telefono = new List<string>();
        persona_telefono.Add("<b>Teléfono:</b> ");
        persona_telefono.Add(persona.Telefono);

        List<string> persona_cuil = new List<string>();
        persona_cuil.Add("<b>CUIL:</b> ");
        persona_cuil.Add(DarFormatoACuil(persona.Cuit));

        List<string> persona_categoria = new List<string>();
        persona_categoria.Add("<b>Categoría:</b> ");
        persona_categoria.Add(persona.Categoria + " " + persona.Nivel);

        List<string> persona_legajo = new List<string>();
        persona_legajo.Add("<b>Legajo:</b> ");
        persona_legajo.Add(persona.Legajo);



        List<string> cantidad_dias_estadia = new List<string>();
        cantidad_dias_estadia.Add("<b>Son:</b> ");
        cantidad_dias_estadia.Add(CalcularDiasEstadia().ToString() + " días de viáticos a un valor promedio de $ " + String.Format("{0:0.00}",  CalcularImporteDiario(persona))  + " diarios." );

        
        lista_valores_de_persona.Add(persona_nombre);
        lista_valores_de_persona.Add(persona_area);
        lista_valores_de_persona.Add(persona_telefono);
        lista_valores_de_persona.Add(persona_cuil);
        lista_valores_de_persona.Add(persona_categoria);
        lista_valores_de_persona.Add(persona_legajo);

        lista_valores_de_persona.Add(cantidad_dias_estadia);    

        return lista_valores_de_persona;

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

    private string DarFormatoACuil(string cuil)
    {
        return string.Format("{0}-{1}-{2}", cuil.Substring(0, 2), cuil.Substring(2, 8), cuil.Substring(10, 1));
    }

    private void MostrarTablaEstadias()
    {
        RenderizadorDeTablas<Estadia> renderizador = new  RenderizadorDeTablas<Estadia>(new EstadiaToRowSerializer());

        //renderizador.AgregarCabeceras(new string[] { "Provincia", "Desde", "Hasta", "Eventuales", "Adicional por pasajes", "Monto por categoría", "Motivo" }, this.TablaEstadias);
        renderizador.AgregarCabeceras(new string[] { "Provincia", "Desde", "Hora","Hasta","Hora","Eventuales", "Adicional por pasajes", "Monto por categoría", "Motivo" }, this.TablaEstadias);

        renderizador.RenderTo(new List<Estadia>(comision.Estadias), this.TablaEstadias);

        this.TablaEstadias.CssClass = "table table-striped table-bordered table-condensed";
    }

    private void MostrarTablaDePasajes()
    {
        RenderizadorDeTablas<Pasaje> renderizador = new RenderizadorDeTablas<Pasaje>(new PasajeToRowSerializer());

        renderizador.AgregarCabeceras(new string[] { "Fecha", "Origen", "Destino", "Transporte", "Medio De Pago", "Precio" }, this.TablaPasajes);

        renderizador.RenderTo(new List<Pasaje>(comision.Pasajes), this.TablaPasajes);

        this.TablaPasajes.CssClass = "table table-striped table-bordered table-condensed";      
    }


    private Table ConstruirTabla(string titulo)
    {
        Table tabla = new Table();
        TableHeaderCell celda_encabezado = new TableHeaderCell();
        celda_encabezado.Text = titulo;

        TableHeaderRow fila_encabezado = new TableHeaderRow();
        fila_encabezado.Cells.Add(celda_encabezado);
        tabla.Rows.Add(fila_encabezado);

        tabla.CssClass = "table table-striped table-bordered table-condensed";
        return tabla;
    }


    private System.Web.UI.WebControls.Panel ConstruirListaFirmantes()
    {
        var panel = new System.Web.UI.WebControls.Panel();
        //lista.Items.Add(titulo);
        //lista.Style.Add("list-style", "none");

        Label titulo_firmantes = new Label();
        titulo_firmantes.Text = "Detalle de Firmantes";
        titulo_firmantes.Attributes.Add("class", "tituloDetalleDeFirmantes");
        panel.Controls.Add(titulo_firmantes);

        // (var t in new List<TransicionDeViatico>(comision.TransicionesRealizadas).Sort(new System.Comparison<TransicionDeViatico>((t1,t2) =>t1.Fecha>t2.Fecha)));//((t1, t2) => t1.Fecha >t2.Fecha))
        
        var listaTransiciones = new List<TransicionDeViatico>(comision.TransicionesRealizadas);

        listaTransiciones.Sort((t1, t2)=>DateTime.Compare(t1.Fecha, t2.Fecha));

        foreach (var t in listaTransiciones)
        {
            var item = new Label();
            item.Text = t.Fecha.ToShortDateString() + " - " + t.Accion.DescripcionPasado + ": " + t.AreaOrigen.Responsables[0].Apellido + ", " + t.AreaOrigen.Responsables[0].Nombre + " - " + t.AreaOrigen.Nombre;
            if (t.Comentario != null)
            {
                if (t.Comentario.Trim() != "")
                {
                    item.Text += " - " + t.Comentario;
                }
            }
            item.Attributes.Add("class", "span12");
            panel.Controls.Add(item);
        }

        //foreach (var una_estadia in comision.Estadias)
        //{
        //    lista.Items.Add(una_estadia.Desde.ToShortDateString() + '-' + comision.Persona.Apellido + ", " + comision.Persona.Nombre + " - " + " Secretaría General");
        //}

        return panel;
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