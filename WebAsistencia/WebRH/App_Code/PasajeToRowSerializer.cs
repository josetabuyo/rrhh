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
/// Descripción breve de PasajeToRowSerializer
/// </summary>
public class PasajeToRowSerializer : EntityToRowConverter<Pasaje>
{
    private ControladorDeWebControls controlador;

	public PasajeToRowSerializer()
	{
        controlador = new ControladorDeWebControls();
	}

    public override List<object> Serialize(Pasaje pasaje)
    {
        return new List<object>() {  pasaje.FechaDeViaje.ToShortDateString(),
            pasaje.Origen.Nombre,
            pasaje.Destino.Nombre,
            pasaje.MedioDeTransporte.Nombre,
            pasaje.MedioDePago.Nombre,
            "$ " + String.Format("{0:0.00}", pasaje.Precio)        
        };
    }

}