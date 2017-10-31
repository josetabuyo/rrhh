using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using General.MED;
using General.MAU;

/// <summary>
/// Descripción breve de EvaluacionDeDesempenioToPdfConverter
/// </summary>
public class EvaluacionDeDesempenioToPdfConverter : ModeloToPdfConverter
{

    public EvaluacionDeDesempenioToPdfConverter()
    {
    }


    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {
        AsignacionEvaluadoAEvaluador asignacion = (AsignacionEvaluadoAEvaluador)modelo.First();
        Usuario usr = (Usuario)modelo[1];

        mapa.Add("Nivel_Form", asignacion.nivel.descripcion_corta);
        mapa.Add("Jurisdiccion", asignacion.agente_evaluado.area.jurisdiccion);
        mapa.Add("Secretaria", asignacion.agente_evaluado.area.secretaria);
        mapa.Add("Subsecretaria", asignacion.agente_evaluado.area.sub_secretaria);
        mapa.Add("Dir_nac_gral", asignacion.agente_evaluado.area.direccion);
        mapa.Add("Unidad_eval", asignacion.unidad_de_evaluacion.NombreArea);
        mapa.Add("Cod_unidad_eval", asignacion.unidad_de_evaluacion.Codigo);

        mapa.Add("Periodo_desde", asignacion.periodo.desde.ToString("dd/MM/yyyy"));
        mapa.Add("Periodo_hasta", asignacion.periodo.hasta.ToString("dd/MM/yyyy"));

        mapa.Add("Evaluador_nya", asignacion.agente_evaluador.apellido + ", " + asignacion.agente_evaluador.nombre);
        mapa.Add("Evaluador_dni", asignacion.agente_evaluador.nro_documento.ToString());
        mapa.Add("Evaluador_escalaf", "SINEP");
        mapa.Add("Evaluador_nivel", asignacion.agente_evaluador.nivel);
        mapa.Add("Evaluador_grado", asignacion.agente_evaluador.grado);
        mapa.Add("Evaluador_agrupamiento", asignacion.agente_evaluador.agrupamiento);
        mapa.Add("Evaluador_cargo", asignacion.agente_evaluador.puesto_o_cargo);

        mapa.Add("Evaluado_nya", asignacion.agente_evaluado.apellido + ", " + asignacion.agente_evaluado.nombre);
        mapa.Add("Evaluado_dni", asignacion.agente_evaluado.nro_documento.ToString());
        mapa.Add("Evaluado_legajo", asignacion.agente_evaluado.legajo.ToString());
        mapa.Add("Evaluado_nivel", asignacion.agente_evaluado.nivel);
        mapa.Add("Evaluado_grado", asignacion.agente_evaluado.grado);
        mapa.Add("Evaluado_agrupamiento", asignacion.agente_evaluado.agrupamiento);

        mapa.Add("Evaluado_nivel_educativo", asignacion.agente_evaluado.nivel_educativo);
        mapa.Add("Cod_unidad_eval.0", asignacion.unidad_de_evaluacion.Codigo);

        int i = 1;
        var subtotal_1a6 = 0;
        var subtotal_7a12 = 0;
        if (asignacion.evaluacion.detalle_preguntas.Count > 12)
        {
            throw new Exception("El formulario seleccionado no soporta mas de 12 preguntas");
        }

        foreach (var pregunta in asignacion.evaluacion.detalle_preguntas)
        {
            mapa.Add("Factor_" + i.ToString("00"), pregunta.factor + ' ' + pregunta.enunciado);
            mapa.Add("Cualidad_" + i.ToString("00"), pregunta.RespuestaElegida());
            mapa.Add("Puntos_" + i.ToString("00"), (5 - pregunta.opcion_elegida).ToString());

            mapa.Add("Factor_" + i.ToString("00") + "_num", pregunta.factor);
            mapa.Add("Valor_" + i.ToString("00") + "_num", (5 - pregunta.opcion_elegida).ToString());

            if (i < 7)
            {
                subtotal_1a6 += (5 - pregunta.opcion_elegida);
            }
            else
            {
                subtotal_7a12 += (5 - pregunta.opcion_elegida);
            }
            i++;
        }

        for (int j = asignacion.evaluacion.detalle_preguntas.Count + 1; j <= 12; j++)
        {
            mapa.Add("Factor_" + j.ToString("00"), "--");
            mapa.Add("Cualidad_" + j.ToString("00"), "--");
            mapa.Add("Puntos_" + j.ToString("00"), "--");

            mapa.Add("Factor_" + j.ToString("00") + "_num", "--");
            mapa.Add("Valor_" + j.ToString("00") + "_num", "--");
        }

        mapa.Add("Subtotal_1_a_6", subtotal_1a6.ToString());
        mapa.Add("Subtotal_7_a_12", subtotal_7a12.ToString());

        var total = subtotal_1a6 + subtotal_7a12;
        mapa.Add("Total", total.ToString());

        mapa.Add("Total_deficiente", "--");
        mapa.Add("Total_regular", "--");
        mapa.Add("Total_bueno", "--");
        mapa.Add("Total_destacado", "--");

        mapa["Total_" + asignacion.nivel.CalificacionPara(total).ToLower()] = total.ToString();

        //mapa.Add("Nombre_usu", usr.Owner.Apellido + ", " + usr.Owner.Nombre + " (" + usr.Owner.Documento.ToString() + ")");
        mapa.Add("Nombre_usu", asignacion.agente_evaluador.apellido + ", " + asignacion.agente_evaluador.nombre + " (" + asignacion.agente_evaluador.nro_documento.ToString() + ")");
        mapa.Add("Fecha_hora", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
        mapa.Add("Identif_Formulario", "---");

        return mapa;
    }
}
