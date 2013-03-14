using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using WebRhUI;
using System.Web.Script.Services;
using System.Web.Services;

public partial class FormularioDeViaticos_GrillaEstadias : System.Web.UI.UserControl
{
    protected Table _tabla_listado_estadias = new Table();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Estadia> lista_estadias = new List<Estadia>();
            //Session["cantidadDeEstadias"] = 1;
        }

        //FC:tuve que construir la cabecera en el PageLoad porque si lo agrego en el metodo MostrarTabla... me duplica el encabezado
        //AgregarEncabezado();

        //var comision = (ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        //MostrarTablaDeEstadias(comision.Estadias.ToList());

        //this._tabla_listado_estadias = ContruirTablaEncabezado();

        this.Controls.Add(_tabla_listado_estadias);
    }

    public void AgregarEncabezado()
    {
        RenderizadorDeTablas<Estadia> renderizador = new RenderizadorDeTablas<Estadia>(new CargaEstadiaToRowSerializer());
        renderizador.AgregarCabeceras(new string[] { "PROVINCIA", "DESDE", "HASTA", "TOTAL DE DIAS", "VALOR VIATICO X DIA", "EVENTUALES", "ADIC. POR PASAJE", "" }, this._tabla_listado_estadias);
        this._tabla_listado_estadias.CssClass = "table table-striped table-bordered table-condensed";
    }

    public void MostrarTablaDeEstadias(ComisionDeServicio comision)
    {
        RenderizadorDeTablas<Estadia> renderizador = new RenderizadorDeTablas<Estadia>(new CargaEstadiaToRowSerializer());

        List<Estadia> lista_de_estadias = new List<Estadia>(comision.Estadias.ToList());

        //List<ComisionDeServicio> lista_de_comisiones = new List<ComisionDeServicio>();
        //lista_de_comisiones.Add(comision);

        //lista_de_estadias.ForEach(e => e.ComisionDeServicio = comision);


        renderizador.RenderTo(lista_de_estadias, this._tabla_listado_estadias);

        //this._tabla_listado_estadias.CssClass = "table table-striped table-bordered table-condensed";
        //this.Controls.Add(TablaViaticos);
    }



    //[ScriptMethod, WebMethod]
    //public static string QuitarPasaje(object id_pasaje)
    //{
    //    //MeterAreaEnSession(id_comision);
    //    return "";
    //}


    //private Table ContruirTablaEncabezado()
    //{
    //    Table tabla = new Table();

    //    TableHeaderCell celda_encabezado_desde = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_hasta = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_duracion = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_valor_viatico = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_eventual = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_adicional = new TableHeaderCell();
    //    TableHeaderCell celda_encabezado_provincia = new TableHeaderCell();


    //    celda_encabezado_desde.Text = "Desde";
    //    celda_encabezado_hasta.Text = "Hasta";
    //    celda_encabezado_duracion.Text = "Total Días";
    //    celda_encabezado_valor_viatico.Text = "Valor de Viático";
    //    celda_encabezado_eventual.Text = "Eventuales";
    //    celda_encabezado_adicional.Text = "Adic. x Pasajes";
    //    celda_encabezado_provincia.Text = "Provincia";
       
    //    TableHeaderRow fila_encabezado = new TableHeaderRow();

    //    fila_encabezado.Cells.Add(celda_encabezado_provincia);
    //    fila_encabezado.Cells.Add(celda_encabezado_desde);
    //    fila_encabezado.Cells.Add(celda_encabezado_hasta);
    //    fila_encabezado.Cells.Add(celda_encabezado_duracion);
    //    fila_encabezado.Cells.Add(celda_encabezado_valor_viatico);
    //    fila_encabezado.Cells.Add(celda_encabezado_eventual);
    //    fila_encabezado.Cells.Add(celda_encabezado_adicional);
        
       
    //    tabla.Rows.Add(fila_encabezado);
    //    tabla.CssClass = "table table-striped table-bordered table-condensed";

    //    return tabla;

    //}

    //public  void ConstruirDatosDeTabla(List<Estadia> estadias)
    //{
    //    Persona persona = (Persona)Session["persona"];        
    //    WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        
    //    foreach (Estadia una_estadia in estadias)
    //    {
    //        TableCell celda_desde = new TableCell();
    //        TableCell celda_hasta = new TableCell();
    //        TableCell celda_duracion = new TableCell();
    //        TableCell celda_valor_viatico = new TableCell();
    //        TableCell celda_eventuales = new TableCell();
    //        TableCell celda_adic = new TableCell();
    //        TableCell celda_prov = new TableCell();
    //        TableRow fila = new TableRow();


    //        //Session[boton.GetHashCode().ToString()] = una_comision;

    //        celda_desde.Text = una_estadia.Desde.ToShortDateString();
    //        celda_hasta.Text = una_estadia.Hasta.ToShortDateString();
    //        celda_duracion.Text = CalcularCantidadDeDias(una_estadia);
    //        celda_valor_viatico.Text = "$ " + String.Format("{0:0.00}",CalcularValorDelViaticoPorDia(una_estadia, persona));

    //        celda_eventuales.Text = "$ " + una_estadia.Eventuales.ToString();
    //        celda_adic.Text = "$ " + una_estadia.AdicionalParaPasajes.ToString();
    //        celda_prov.Text = una_estadia.Provincia.Nombre;

    //        fila.Cells.Add(celda_prov);
    //        fila.Cells.Add(celda_desde);
    //        fila.Cells.Add(celda_hasta);
    //        fila.Cells.Add(celda_duracion);
    //        fila.Cells.Add(celda_valor_viatico);
    //        fila.Cells.Add(celda_eventuales);
    //        fila.Cells.Add(celda_adic);
            

    //        _tabla_listado_estadias.Rows.Add(fila);
    //    }

       
    //}




    //Tuve que agregar aca el metodo porque no puedo ver el metodo de Estadia
    public string CalcularCantidadDeDias(Estadia estadia)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();

        //DateTime desde = estadia.Desde;
        //DateTime hasta = estadia.Hasta;

        //TimeSpan periodo = hasta - desde;

        return ws_viaticos.CalcularDiasPara(estadia).ToString();
    
    }

    public Decimal CalcularValorDelViaticoPorDia(Estadia estadia, Persona persona)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        
        return  ws_viaticos.CalcularViaticoPara(estadia, persona);

    }

    //public DateTime ObtenerFechaMaximaEstadia()
    //{
    //    if (lista_estadias == null )
    //    {
    //        return new DateTime(2000, 01, 01);
    //    }

    //    return lista_estadias.Max().Hasta; 

    //}

    
}