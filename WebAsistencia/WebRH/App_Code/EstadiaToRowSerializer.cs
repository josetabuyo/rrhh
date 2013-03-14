using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using WSViaticos;
using WebRhUI;

/// <summary>
/// Descripción breve de EstadiaToRowSerializer
/// </summary>
public class EstadiaToRowSerializer : EntityToRowConverter<Estadia>
{
    private ControladorDeWebControls controlador;

	public EstadiaToRowSerializer()
	{
        controlador = new ControladorDeWebControls();
	}

    private float ObtenerDiasEstadia(Estadia estadia)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        return ws.CalcularDiasPara(estadia);


    }


    public override List<object> Serialize(Estadia estadia)
    {
        

        return new List<object>() { estadia.Provincia.Nombre,
            estadia.Desde.ToShortDateString(),
            estadia.Desde.ToShortTimeString(),
            estadia.Hasta.ToShortDateString(),
            estadia.Hasta.ToShortTimeString(),
            "$ " + String.Format("{0:0.00}", estadia.Eventuales),
            "$ " + String.Format("{0:0.00}", estadia.AdicionalParaPasajes),
            "$ " + String.Format("{0:0.00}",  CalcularImporteDiario(estadia)),   
            estadia.Motivo        
        };
    }


    private decimal CalcularImporteDiario(Estadia estadia)
    {
        //decimal importe = 0;
        WSViaticosSoapClient ws = new WSViaticosSoapClient();


        return ws.CalcularViaticoPara(estadia, estadia.Persona);
        //foreach (Estadia estadia in comision.Estadias)
        //{
        //    importe = importe + ws.CalcularViaticoPara(estadia, persona);
        //}
        //return importe;

    }
}