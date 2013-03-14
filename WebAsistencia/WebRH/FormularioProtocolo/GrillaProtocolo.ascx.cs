using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebRhUI;
using WSViaticos;

public partial class FormularioProtocolo_GrillaProtocolo : System.Web.UI.UserControl
{
    public Table _tabla_listado_areas = new Table();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Area> lista_areas = new List<Area>();

        }

        this.Controls.Add(_tabla_listado_areas);

    }

    public void AgregarEncabezado()
    {
        RenderizadorDeTablas<Area> renderizador = new RenderizadorDeTablas<Area>(new CargaAreaToRowSerializer());
        //Código Área 	Área/s 	Responsable/s 	Secretaria/s 	Teléfono 	Fax 	e-mail 	Dirección
        renderizador.EstiloCeldaCabecera = "protocolo_tabla_titulo";

        renderizador.AgregarCabeceras(new string[] { "Código Área", "Área/s", "Responsable/s", "Asistente/s", "Teléfono", "Fax", "e-mail", "Dirección" }, this._tabla_listado_areas);
        this._tabla_listado_areas.CssClass = "protocolo_tabla";

    }

    public void MostrarTablaDeAreas()
    {
        RenderizadorDeTablas<Area> renderizador = new RenderizadorDeTablas<Area>(new CargaAreaToRowSerializer());

        WSViaticosSoapClient ws = new WSViaticosSoapClient();

        List<Area> lista_de_areas = ws.AreasCompletas().ToList();
        //falta completar toda la lista de áreas
        renderizador.EstiloCeldaCuerpo = "protocolo_tabla_detalle";
        renderizador.RenderTo(lista_de_areas, this._tabla_listado_areas);

      
    }





    ////Tuve que agregar aca el metodo porque no puedo ver el metodo de Estadia
    //public string CalcularCantidadDeDias(Estadia estadia)
    //{
    //    WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();

    //    return ws_viaticos.CalcularDiasPara(estadia).ToString();
    
    //}

    //public Decimal CalcularValorDelViaticoPorDia(Estadia estadia, Persona persona)
    //{
    //    WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        
    //    return  ws_viaticos.CalcularViaticoPara(estadia, persona);

    //}
    
}