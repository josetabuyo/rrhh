using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using WSViaticos;
using WebRhUI;


public class CargaEstadiaToRowSerializer : EntityToRowConverter<Estadia>
{
    private ControladorDeWebControls controlador;
   
    public CargaEstadiaToRowSerializer()
    {
        controlador = new ControladorDeWebControls();
    }

    public override List<object> Serialize(Estadia estadia)
    {
        //int dias_totales = DiasTotalesParaLaEstadia(estadia);

        return new List<object>() { 
            
            estadia.Provincia.Nombre, 
            estadia.Desde.ToShortDateString(),
            estadia.Hasta.ToShortDateString(),
            CalcularDiasEstadia(estadia).ToString(),
            "$ " + String.Format("{0:0.00}",  CalcularImporteDiario(estadia)),        
            "$ " + String.Format("{0:0.00}", estadia.Eventuales),
            "$ " + String.Format("{0:0.00}", estadia.AdicionalParaPasajes),   
            boton_quitar(estadia)
        };
    }

        private string boton_quitar(Estadia estadia)
        {
            //return controlador.DibujarLink(estadia, "QuitarEstadia");
            return controlador.DibujarLinkParaRequest(estadia, "EstadiaAQuitar");
        }


        private float CalcularDiasEstadia(Estadia estadia)
        {
            //float dias = 0;
            WSViaticosSoapClient ws = new WSViaticosSoapClient();
            return ws.CalcularDiasPara(estadia);

            //foreach (Estadia estadia in comision.Estadias)
            //{
            //    dias = dias + ws.CalcularDiasPara(estadia);
            //}
            //return dias;
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