using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using General.MED;

/// <summary>
/// Descripción breve de EvaluacionDeDesempenioToPdfConverter
/// </summary>
public class EvaluacionDeDesempenioToPdfConverter:ModeloToPdfConverter
{
    private List<object> modelo_para_pdf;

    
	public EvaluacionDeDesempenioToPdfConverter()
	{
	}


    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {
        AsignacionEvaluadoAEvaluador asignacion = (AsignacionEvaluadoAEvaluador)modelo.First();
        return mapa;
    }
    
}