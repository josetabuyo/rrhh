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
            
        public string ToXml()
        {
            return ObjectXmlSerializer.SerializeObjectToXmlFormattedString(this);
        }

    }
}
