using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using System.IO;

/// <summary>
/// Clase que rellena un formulario pdf con campos a rellenar
/// nota: la clase que la llama se debe hacer cargo de las excepciones posibles en cuanto a la apertura o seteo de campos de los pdf,
/// por ejemplo de que el campo no exista(si se recorre por la clave del diccionario) o que no este el campo a ser llenado en el diccionario(en caso de que se recorra por campos a llenar)
/// </summary>
public class RellenadorPdf
{ 
    //Recibe el pdf template a rellenar, la lista de nombrecampo-dato y el stream de salida donde escribir los datos
    public void FillPDF(string pathPdfTemplate, string nombrePdf, Dictionary<string, string> dic, System.Web.HttpResponse respuestaHTTP)
    {
        respuestaHTTP.Clear();
        respuestaHTTP.ContentType = "application/pdf";//esto obliga a descargar Response.ContentType = "application/octet-stream";
        respuestaHTTP.Cache.SetCacheability(HttpCacheability.NoCache);
        respuestaHTTP.AddHeader("content-disposition", "attachment;filename=" + nombrePdf);

        //Stream file = new FileStream(pathPdfTemplate, FileMode.Open);
        PdfReader reader = new PdfReader(pathPdfTemplate);
        PdfStamper stamp = new PdfStamper(reader, respuestaHTTP.OutputStream);
        //Console.WriteLine(stamp.AcroFields.Fields.Keys.Count); //cantidad de campos a rellenar ,los grupos se cuentan como uno independientemente de la cantidad de opciones que tenga

        /*notas:
        -stamp.AcroFields.SetField("grupo1", "op2"); //sea el checkbox a true como el indicado en el segundo parametro
        -stamp.AcroFields.SetField("grupo1", "Off");//este apaga todos los checkboxs
        -no hay validacion para los campos tipo date
        -obtengo la lista de estados posibles del grupo de checkbox, estos son Off, y los valores de los nombres
         de los checkbox, estos mismos nombres es el equivalente a true.
        -String[] checkboxstates = reader.AcroFields.GetAppearanceStates("grupo1");
        -seteo al grupo segun algun valor de los estados que decida
        -stamp.AcroFields.SetField("grupo1", checkboxstates[0]);   
        -Console.WriteLine(name + " "); //para ver los nombres de los campos
        */

        //se llena la cantidad de campos que tenga el formulario
        //por default todos los campos son obligatorios por eso el for va sobre ellos y asume que el diccionario tiene los valores
        //caso contrario poner el for sobre el diccionario

        //recorro todos los campos del formulario y los relleno con los valores del diccionario
        //que contiene de clave el nombre del campo del formulario y de valor el dato a rellenar
        foreach (string name in stamp.AcroFields.Fields.Keys)
        {
            stamp.AcroFields.SetField(name, dic[name]);//agregar try cath por si la clave no esta en el dic


        }
        /* aca se recorre por los valores del dic, este es mas flexible porque no se esta requeriendo llenar si o si todos los campos del formulario
         * foreach (string name in dic.Keys)
        {
            stamp.AcroFields.SetField(name, dic[name]);
        }*/

        stamp.FormFlattening = true; //para que no se pueda editar el pdf generado
        stamp.Close(); //cierro el pdf
        reader.Close();

    }


}