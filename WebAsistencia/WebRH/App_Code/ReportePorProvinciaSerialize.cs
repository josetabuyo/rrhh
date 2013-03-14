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
/// Descripción breve de ListDeListToRowSerialize
/// </summary>
public class ReportePorProvinciaSerialize : EntityToRowConverter<List<string>>
{
    private ControladorDeWebControls controlador;

    public ReportePorProvinciaSerialize()
	{
        controlador = new ControladorDeWebControls();
	}

    public override List<object> Serialize(List<string> lista_valores)
    {
        return new List<object>() {    lista_valores[0],
                                       lista_valores[1],
                                       lista_valores[2],
                                       lista_valores[3]
                                      
        };
    }

   
}