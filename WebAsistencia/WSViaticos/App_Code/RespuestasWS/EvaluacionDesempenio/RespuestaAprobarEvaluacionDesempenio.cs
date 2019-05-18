using General.MED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RespuestaAprobarEvaluacionDesempenio
/// </summary>
public class RespuestaAprobarEvaluacionDesempenio:RespuestaWS
{
    public AprobacionPorComite Aprobacion { get; set; }
    public RespuestaAprobarEvaluacionDesempenio()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}