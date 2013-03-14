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
/// Descripción breve de ComisionToRowSerializer
/// </summary>
public class DocumentoSICOIToRowSerializer : EntityToRowConverter<Documento>
{
    private ControladorDeWebControls controlador;

    public DocumentoSICOIToRowSerializer()
	{
        controlador = new ControladorDeWebControls();
	}

    public override List<object> Serialize(Documento documento)
    {
        string nombre_area_destino = "";
        string nombre_area_actual = "";
        string htmlBotonEnviar = "";

        WSViaticosSoapClient ws = new WSViaticosSoapClient();
       
        Area area_actual = ws.EstaEnElArea(documento);
       if (area_actual != null)
       {
           nombre_area_actual = area_actual.Nombre;
       }
        
        //if(documento.areaDestino != null) htmlBotonEnviar = "<input type='button' onclick='javascript:$(\"#idDocumentoAEnviar\").val(" + documento.Id + "); $(\"#idAreaDestinoDocumentoAEnviar\").val(" + documento.areaDestino.Id + "); $(\"#btnEnviarDocumento\").click();' class='btn btn-primary' runat='server' value='enviar'/>";
        
        return new List<object>() {
           documento.tipoDeDocumento.descripcion,
           documento.numero,
           documento.ticket,
           documento.extracto,
           documento.fecha.ToShortDateString(),
           "A remitir",
           nombre_area_actual,
           nombre_area_destino,
           MostrarAsterisco(documento),
           htmlBotonEnviar
        };
    }

    private string MostrarAsterisco(Documento documento)
    {
        if (documento.comentarios != "")
            return " * ";
        return "";
        
    }



}