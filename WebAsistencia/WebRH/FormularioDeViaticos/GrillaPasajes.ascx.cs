using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using WebRhUI;

public partial class FormularioDeViaticos_GrillaPasajes : System.Web.UI.UserControl
{
    private Table _tabla_listado_pasajes = new Table();

    protected void Page_Load(object sender, EventArgs e)
    {
        //this._tabla_listado_pasajes = ContruirTablaEncabezado();

        //AgregarEncabezado();

        this.Controls.Add(_tabla_listado_pasajes);

    }

    public void AgregarEncabezado()
    {
        RenderizadorDeTablas<Pasaje> renderizador = new RenderizadorDeTablas<Pasaje>(new CargaPasajeToRowSerializer());
        renderizador.AgregarCabeceras(new string[] { "FECHA DE VIAJE", "ORIGEN", "DESTINO", "TRANSPORTE", "MEDIO DE PAGO", "PRECIO", "" }, this._tabla_listado_pasajes);
        this._tabla_listado_pasajes.CssClass = "table table-striped table-bordered table-condensed";
    }

    public void MostrarTablaDePasajes(ComisionDeServicio comision)
    {
        RenderizadorDeTablas<Pasaje> renderizador = new RenderizadorDeTablas<Pasaje>(new CargaPasajeToRowSerializer());

        renderizador.RenderTo(new List<Pasaje>(comision.Pasajes.ToList()), this._tabla_listado_pasajes);

        //this._tabla_listado_estadias.CssClass = "table table-striped table-bordered table-condensed";
        //this.Controls.Add(TablaViaticos);
    }

    //private Table ContruirTablaEncabezado()
    //{
    //    Table tabla = new Table();

    //    TableHeaderCell celda_encabezado_fecha_viaje = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_origen = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_destino = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_transporte = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_medios_pago = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_precios = new TableHeaderCell();


    //    celda_encabezado_fecha_viaje.Text = "Fecha De Viaje";
    //    celda_encabezado_origen.Text = "Origen";
    //    celda_encabezado_destino.Text = "Destino";
    //    celda_encabezado_transporte.Text = "Transporte";
    //    celda_encabezado_medios_pago.Text = "Medio De Pago";
    //    celda_encabezado_precios.Text = "Precio";

    //    TableHeaderRow fila_encabezado = new TableHeaderRow();

    //    fila_encabezado.Cells.Add(celda_encabezado_fecha_viaje);
    //    fila_encabezado.Cells.Add(celda_encabezado_origen);
    //    fila_encabezado.Cells.Add(celda_encabezado_destino);
    //    fila_encabezado.Cells.Add(celda_encabezado_transporte);
    //    fila_encabezado.Cells.Add(celda_encabezado_medios_pago);
    //    fila_encabezado.Cells.Add(celda_encabezado_precios);

    //    tabla.Rows.Add(fila_encabezado);
    //    tabla.CssClass = "table table-striped table-bordered table-condensed";

    //    return tabla;

    //}

    //public void ConstruirDatosDeTabla(List<Pasaje> pasajes)
    //{

    //    //WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
    //    foreach (Pasaje un_pasaje in pasajes)
    //    {
    //        TableCell celda_fecha_desde = new TableCell();
    //        TableCell celda_origen = new TableCell();
    //        TableCell celda_destino = new TableCell();
    //        TableCell celda_transporte = new TableCell();
    //        TableCell celda_medios_pago = new TableCell();
    //        TableCell celda_precio = new TableCell();
    //        TableRow fila = new TableRow();

    //        celda_fecha_desde.Text = un_pasaje.FechaDeViaje.ToShortDateString();
    //        celda_origen.Text = un_pasaje.Origen.Nombre;
    //        celda_destino.Text = un_pasaje.Destino.Nombre;
    //        celda_transporte.Text = un_pasaje.MedioDeTransporte.Nombre;
    //        celda_medios_pago.Text = un_pasaje.MedioDePago.Nombre;
    //        celda_precio.Text = "$ " + un_pasaje.Precio.ToString();

    //        fila.Cells.Add(celda_fecha_desde);
    //        fila.Cells.Add(celda_origen);
    //        fila.Cells.Add(celda_destino);
    //        fila.Cells.Add(celda_transporte);
    //        fila.Cells.Add(celda_medios_pago);
    //        fila.Cells.Add(celda_precio);

    //        _tabla_listado_pasajes.Rows.Add(fila);
    //    }
    //}
}