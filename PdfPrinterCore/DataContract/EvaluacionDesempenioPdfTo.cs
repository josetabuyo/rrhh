using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using PdfPrinter.Core.Common;

namespace PdfPrinter.Core.DataContract
{
    [Serializable, DataContract(Namespace = "http://Schemas/PdfPrinter/Common")]
    public class EvaluacionDesempenioPdfTO : IPrintableDocument
    {
        //cabecera
        public string agente_y_periodo_en_cabecera;

        //cuadro_nivel
        public string nivel_negrita;
        public string nivel_descripcion_larga;

        //cuadro_organismo
        public string jurisdiccion;
        public string secretaria;
        public string sub_secretaria;
        public string direccion;
        public string unidad;
        public string unidad_evaluacion;//a la derecha
        public string codigo_unidad_evaluacion;
        public string periodo_evaluado;

        //cuadro evaluado/agente
        public string nombre_evaluador;
        public string documento_evaluador;
        public string situacion_escalafonaria_evaluador;
        public string nivel_evaluador;
        public string grado_evaluador;
        public string agrupamiento_evaluador;
        public string puesto_evaluador;
        public string apellido_evaluado; //a la derecha
        public string documento_evaluado;
        public string legajo_evaluado;
        public string nivel_evaluado;
        public string grado_evaluado;
        public string agrupamiento_evaluado;
        public string nivel_educativo_evaluado;
        public string apellido_y_nombre_evaluador;
        public string apellido_y_nombre_evaluado;

        //cuadro final
        public string puntaje;
        public string calificacion;
        public string[] preguntas;
        public string[] respuestas;
        public string[] puntajes;

        public string pregunta_1 { get { return GetPregunta(1); } set { } }
        public string pregunta_2 { get { return GetPregunta(2); } set { } }
        public string pregunta_3 { get { return GetPregunta(3); } set { } }
        public string pregunta_4 { get { return GetPregunta(4); } set { } }
        public string pregunta_5 { get { return GetPregunta(5); } set { } }
        public string pregunta_6 { get { return GetPregunta(6); } set { } }
        public string pregunta_7 { get { return GetPregunta(7); } set { } }
        public string pregunta_8 { get { return GetPregunta(8); } set { } }
        public string pregunta_9 { get { return GetPregunta(9); } set { } }
        public string pregunta_10 { get { return GetPregunta(10); } set { } }
        public string pregunta_11 { get { return GetPregunta(11); } set { } }
        public string pregunta_12 { get { return GetPregunta(12); } set { } }
        public string pregunta_13 { get { return GetPregunta(13); } set { } }
        public string pregunta_14 { get { return GetPregunta(14); } set { } }
        public string pregunta_15 { get { return GetPregunta(15); } set { } }

        public string respuesta_1 { get { return GetRespuesta(1); } set { } }
        public string respuesta_2 { get { return GetRespuesta(2); } set { } }
        public string respuesta_3 { get { return GetRespuesta(3); } set { } }
        public string respuesta_4 { get { return GetRespuesta(4); } set { } }
        public string respuesta_5 { get { return GetRespuesta(5); } set { } }
        public string respuesta_6 { get { return GetRespuesta(6); } set { } }
        public string respuesta_7 { get { return GetRespuesta(7); } set { } }
        public string respuesta_8 { get { return GetRespuesta(8); } set { } }
        public string respuesta_9 { get { return GetRespuesta(9); } set { } }
        public string respuesta_10 { get { return GetRespuesta(10); } set { } }
        public string respuesta_11 { get { return GetRespuesta(11); } set { } }
        public string respuesta_12 { get { return GetRespuesta(12); } set { } }
        public string respuesta_13 { get { return GetRespuesta(13); } set { } }
        public string respuesta_14 { get { return GetRespuesta(14); } set { } }
        public string respuesta_15 { get { return GetRespuesta(15); } set { } }

        public string puntaje_1 { get { return GetPuntaje(1); } set { } }
        public string puntaje_2 { get { return GetPuntaje(2); } set { } }
        public string puntaje_3 { get { return GetPuntaje(3); } set { } }
        public string puntaje_4 { get { return GetPuntaje(4); } set { } }
        public string puntaje_5 { get { return GetPuntaje(5); } set { } }
        public string puntaje_6 { get { return GetPuntaje(6); } set { } }
        public string puntaje_7 { get { return GetPuntaje(7); } set { } }
        public string puntaje_8 { get { return GetPuntaje(8); } set { } }
        public string puntaje_9 { get { return GetPuntaje(9); } set { } }
        public string puntaje_10 { get { return GetPuntaje(10); } set { } }
        public string puntaje_11 { get { return GetPuntaje(11); } set { } }
        public string puntaje_12 { get { return GetPuntaje(12); } set { } }
        public string puntaje_13 { get { return GetPuntaje(13); } set { } }
        public string puntaje_14 { get { return GetPuntaje(14); } set { } }
        public string puntaje_15 { get { return GetPuntaje(15); } set { } }

        protected string GetPregunta(int i)
        {
            return GetValueFrom(this.preguntas, i);
        }

        protected string GetRespuesta(int i)
        {
            return GetValueFrom(this.respuestas, i);
        }

        protected string GetPuntaje(int i)
        {
            return GetValueFrom(this.puntajes, i);
        }


        protected string GetValueFrom(string[] array, int i)
        {
            if (array.Length < i)
            {
                return "";
            }
            return array[i - 1];
        }

        public string ToXml()
        {
            return ObjectXmlSerializer.SerializeObjectToXmlFormattedString(this);
        }

    }
}
