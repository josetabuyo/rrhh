using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSViaticos;
using WebRhUI;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de AreaToRowSerializer
/// </summary>
public class AreaToRowSerializer : EntityToRowConverter<List<string>>
{
    private ControladorDeWebControls controlador;


    public AreaToRowSerializer()
    {
        controlador = new ControladorDeWebControls();        
    }

    public override List<object> Serialize(List<string> lista_valores)
    {
        return new List<object>()
                   {
                       lista_valores[0],
                       lista_valores[1], 
                       boton_adminitracion_personal(lista_valores[2]),
                       boton_solicitar_modificacion(lista_valores[3])
                   };
    }
  

    private string boton_adminitracion_personal(string idArea)
    {
        if (idArea != "")
        {
            Area area = new Area();
            area.Id = Convert.ToInt32(idArea);

            return controlador.DibujarLinkConImagen(area, "IrAlArea", "Imagenes/Botones/administrar_s2.png", "99", "13");

            
        }

        return "";
    }


    private string boton_solicitar_modificacion(string idArea)
    {
        if (idArea != "")
        {
            Area area = new Area();
            area.Id = Convert.ToInt32(idArea);

            return controlador.DibujarLinkConImagen(area, "EditarElArea", "Imagenes/Botones/solicitar_modificacion_s2.png", "147", "12");    
        }

        return "";
    }

}