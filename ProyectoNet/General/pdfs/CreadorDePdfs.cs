using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.qrcode;
using Newtonsoft.Json;

/// <summary>
/// Descripción breve de CreadorDePdfs
/// </summary>
public class CreadorDePdfs //where T:IPrintableDocument
{
    public CreadorDePdfs()
    {
    }

    /*public string Crear(string nombre_template, T data)
    {
        
        var xslt = ResourceManager.GetXsltFileContent(nombre_template);
        var xmlLoc = ResourceManager.GetLocalizedXmlFileContent("Document");

        XmlTransformationManager transformer = new XmlTransformationManager(data, xslt, xmlLoc);
        var xslFo = transformer.Transform();

        //string outputFileName = Path.Combine(PdfPrinterConfiguration.GetCurrentSection().Settings.PdfOutputFolder, DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
        //string absoluteOutputFilePath = HostingEnvironment.MapPath(outputFileName).Replace("PdfPrinterService", "WebAsistencia\\WebRH\\" + "EvaluacionDesempenio");

        var bytes = PdfPrinterDriver.MakePdf(xslFo);

/*        System.IO.FileStream dd = System.IO.File.OpenRead(absoluteOutputFilePath);
        byte[] Bytes = new byte[dd.Length];
        dd.Read(Bytes, 0, Bytes.Length);
        return Convert.ToBase64String(bytes);
        
    }*/


    //Recibe el pdf template a rellenar, la lista de nombrecampo-dato y el stream de salida donde escribir los datos
    public byte[] FillPDF(string pathPdfTemplate, string nombrePdf, Dictionary<string, string> dic)
    {
        //respuestaHTTP.Clear();
        //respuestaHTTP.ContentType = "application/pdf";//esto obliga a descargar Response.ContentType = "application/octet-stream";
        //respuestaHTTP.Cache.SetCacheability(HttpCacheability.NoCache);
        //respuestaHTTP.AddHeader("content-disposition", "attachment;filename=" + nombrePdf);

        //Stream file = new FileStream(pathPdfTemplate, FileMode.Open);

        PdfReader reader = new PdfReader(pathPdfTemplate);
        /*byte[] Bytes;
        PdfStamper stamp;
        MemoryStream ms = new MemoryStream((int)reader.FileLength + 50000);*/


        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamp = new PdfStamper(reader, ms);
            List<string> keys_not_found = new List<string>();
            KeyNotFoundException ex = new KeyNotFoundException();
            foreach (string name in stamp.AcroFields.Fields.Keys)
            {
                try
                {
                    stamp.AcroFields.SetField(name, dic[name]);//agregar try cath por si la clave no esta en el dic
                }
                catch (KeyNotFoundException e)
                {
                    ex = e;
                    keys_not_found.Add(name);
                    //aqui va a entrar cuando no encuentre el csv en el dic
                }
            }


            if (keys_not_found.Count != 0)
            {
                //  throw ex;
            }

            /*foreach (string name in stamp.AcroFields.Fields.Keys)
            {
                stamp.AcroFields.SetField(name, "test");//agregar try cath por si la clave no esta en el dic
            }*/
            //            stamp.FormFlattening = true;

            /*Dictionary<String, String> info = reader.Info;
            info.Add("Title", "Hello World stamped");*/

            stamp.Close(); //cierro el pdf
            reader.Close();
            ms.Close();

            byte[] Bytes = ms.ToArray();



            return Bytes;

        }





        /* aca se recorre por los valores del dic, este es mas flexible porque no se esta requeriendo llenar si o si todos los campos del formulario
 * foreach (string name in dic.Keys)
{
    stamp.AcroFields.SetField(name, dic[name]);
}*/

        //stamp.FormFlattening = true; //para que no se pueda editar el pdf generado


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

        /*
        foreach (string name in stamp.AcroFields.Fields.Keys)
        {
            stamp.AcroFields.SetField(name, dic[name]);//agregar try cath por si la clave no esta en el dic
        }*/


        /* aca se recorre por los valores del dic, este es mas flexible porque no se esta requeriendo llenar si o si todos los campos del formulario
         * foreach (string name in dic.Keys)
        {
            stamp.AcroFields.SetField(name, dic[name]);
        }*/


    }


    public byte[] AgregarImagenAPDF(byte[] bytes, String codigoBarras)
    {
        PdfReader reader = null;
        FileStream fs = null;
        MemoryStream ms = null;
        PdfStamper stamper = null;

        try
        {
            // agrego la imagen en una capa separada
            //creo el objeto reader para leer el documento pdf
            reader = new PdfReader(bytes);
            ms = new MemoryStream();
            //creo el objeto stamper para escribir datos desde el objeto pdfreader al objeto memorystream/filestream
            stamper = new PdfStamper(reader, ms);


            // creo una nueva capa
            PdfLayer layer = new PdfLayer("Foto", stamper.Writer);

            // Getting the Page Size
            //Rectangle rect = reader.GetPageSize(i);

            // obtengo el objeto ContentByte de la pagina i
            //          int i = 1;

            int total = reader.NumberOfPages + 1;
            for (int i = 1; i < total; i++)
            {

                //PdfContentByte cb = stamper.GetOverContent(i);//;GetUnderContent(i);
                PdfContentByte cb = stamper.GetOverContent(i);

                //Le indico al cb que los proximos comandos  seran ligados a esta nueva capa
                cb.BeginLayer(layer);
                //           cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 50);

                /* esto es para que aparezca ser una marca de agua 
                 */
                /* PdfGState gState = new PdfGState();
                 gState.FillOpacity = 0.25f;
                 cb.SetGState(gState);*/

                // cb.SetColorFill(BaseColor.BLACK);
                /* cb.BeginText();
                 cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, rect.Width / 2, rect.Height / 2, 45f);
                 cb.EndText();*/

                // Creamos la imagen y le ajustamos el tamaño
                //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaFoto);
                //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(bytes_img);

                Barcode128 bc128 = new Barcode128();
                bc128.Code = codigoBarras;
                bc128.Font = null;
                Image imagen = bc128.CreateImageWithBarcode(cb, null, null);


                imagen.BorderWidth = 0;
                imagen.Alignment = Element.ALIGN_TOP;
                float percentage = 0.0f;
                percentage = 150 / imagen.Width;
                imagen.ScaleAbsolute(1.0f, 1.0f);//mismo tamaño
                imagen.ScalePercent(percentage * 85);//escalo a un 85%
                //imagen.ScalePercent(100.0f); // 100.0f == same size
                imagen.SetAbsolutePosition(360, 690);

                cb.AddImage(imagen);
                ///aggrego la capa que hace la imagen redonda
                //                   iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance("c:/oie_trans_redim.gif");
                //iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance("c:/oie_trans2.gif");
                //                   imagen2.BorderWidth = 0;
                //                   imagen2.Alignment = Element.ALIGN_TOP;
                //                   float percentage2 = 0.0f;
                //                   percentage2 = 150 / imagen2.Width;
                //                   imagen2.ScaleAbsolute(1.0f, 1.0f);//mismo tamaño
                //imagen.ScalePercent(percentage2 * 100); 
                //                   imagen2.ScalePercent(100.0f); // 100.0f == same size
                //                   imagen2.SetAbsolutePosition(483, 708);

                // cb.AddImage(imagen2);

                // Close the layer
                cb.EndLayer();
                //               }
            }
            int length = Convert.ToInt32(ms.Length);
            byte[] data = new byte[length];
            ms.Read(data, 0, length);

            //                stamper.FormFlattening = true;//para que no se pueda editar el pdf generado
            stamper.Close(); //cierro el pdf
            reader.Close();
            ms.Close();

            byte[] Bytes = ms.ToArray();

            return Bytes;

        }
        finally
        {

            // Garantizamos que aunque falle se cierran los objetos

            // alternativa:usar using

            reader.Close();

            if (stamper != null) stamper.Close();

            if (fs != null) fs.Close();

            /* if (document != null) document.Close();*/

        }


    }

    /*nota:::: no la uso*/
    public byte[] AgregarCSVAPDF(byte[] bytes, String csv)
    {
        /*    PdfReader reader = null;
            FileStream fs = null;
            MemoryStream ms = null;
            PdfStamper stamper = null;

            try
            {
                // agrego la imagen en una capa separada
                //creo el objeto reader para leer el documento pdf
                reader = new PdfReader(bytes);
                ms = new MemoryStream();
                //creo el objeto stamper para escribir datos desde el objeto pdfreader al objeto memorystream/filestream
                stamper = new PdfStamper(reader, ms);

                stamper.AcroFields.SetField("csv", codigoBarras);
            
                    int length = Convert.ToInt32(ms.Length);
                    byte[] data = new byte[length];
                    ms.Read(data, 0, length);

                    stamper.FormFlattening = true;//para que no se pueda editar el pdf generado
                    stamper.Close(); //cierro el pdf
                    reader.Close();
                    ms.Close();

                    byte[] Bytes = ms.ToArray();
            
                    return Bytes;
            
            }
            finally
            {

                // Garantizamos que aunque falle se cierran los objetos

                // alternativa:usar using

                reader.Close();

                if (stamper != null) stamper.Close();

                if (fs != null) fs.Close();

                /* if (document != null) document.Close();*/

        /*}*/

        PdfReader reader = new PdfReader(bytes);


        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamp = new PdfStamper(reader, ms);

            /* foreach (string name in stamp.AcroFields.Fields.Keys)
             {
                 Console.WriteLine(name + " ");
             }*/

            List<string> keys_not_found = new List<string>();
            KeyNotFoundException ex = new KeyNotFoundException();
            try
            {
                stamp.AcroFields.SetField("csv", csv);
            }
            catch (KeyNotFoundException e)
            {
                ex = e;
                keys_not_found.Add("csv");
            }

            /*foreach (string name in stamp.AcroFields.Fields.Keys)
            {
                stamp.AcroFields.SetField(name, "test");//agregar try cath por si la clave no esta en el dic
            }*/
            stamp.FormFlattening = true;   //recien aca cierro el pdf para que no puedan setearse los campos del pdf
            stamp.Close(); //cierro el pdf
            reader.Close();
            ms.Close();

            byte[] Bytes = ms.ToArray();

            return Bytes;

        }


    }

    /*Se agrega el codigo CSV y QR al recibo digital*/
    public byte[] AgregarCSVyQRAPDF(byte[] bytes, String csv, int paginas)
    {

        PdfReader reader = new PdfReader(bytes);

        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamp = new PdfStamper(reader, ms);
            List<string> keys_not_found = new List<string>();
            KeyNotFoundException ex = new KeyNotFoundException();
            try
            {
                stamp.AcroFields.SetField("csv", csv);
                Dictionary<EncodeHintType, Object> qrParam = new Dictionary<EncodeHintType, Object>();
                qrParam[EncodeHintType.ERROR_CORRECTION] = ErrorCorrectionLevel.M;
                qrParam[EncodeHintType.CHARACTER_SET] = "UTF-8";

                BarcodeQRCode barcodeQRCode = new BarcodeQRCode("https://rrhh.desarrollosocial.gob.ar/verificador/csv.aspx?c=" + csv, 100, 100, qrParam);
                Image codeQRImage = barcodeQRCode.GetImage();
                //codeQRImage.ScaleAbsolute(100f,100f);
                //codeQRImage.SetAbsolutePosition(doc.PageSize.Width - 36f - 128f, doc.PageSize.Height - 36f - 686.6f);//216
                codeQRImage.ScaleAbsolute(75, 75);
                codeQRImage.SetAbsolutePosition(420, 115);

                if (paginas >= 1)
                {
                    PdfContentByte content = stamp.GetUnderContent(1); //imprimo en la 1 pagina
                    content.AddImage(codeQRImage);

                    if (paginas >= 2) {
                        PdfContentByte content2 = stamp.GetUnderContent(2); //imprimo en la 2 pagina
                        content2.AddImage(codeQRImage);

                        if (paginas >= 3) {
                            PdfContentByte content3 = stamp.GetUnderContent(3); //imprimo en la 3 pagina
                            content3.AddImage(codeQRImage);

                        }
                    }

                }

            }
            catch (KeyNotFoundException e)
            {
                ex = e;
                keys_not_found.Add("csv");
            }

            /*foreach (string name in stamp.AcroFields.Fields.Keys)
            {
                stamp.AcroFields.SetField(name, "test");//agregar try cath por si la clave no esta en el dic
            }*/
            stamp.FormFlattening = true; //recien aca cierro el pdf para que no puedan editarse los campos llenables del pdf
            stamp.Close(); //cierro el pdf
            reader.Close();
            ms.Close();

            byte[] Bytes = ms.ToArray();

            return Bytes;

        }


    }

    //esta funcion ya no se usa porque al utilizarla genera una copia del archivo y descarta la firma digital,no es solo por el ref de los parametros
    public void ObtenerCsvYcerrarPDF(ref string csv2, ref byte[] bytes)
    {

        PdfReader reader = new PdfReader(bytes);
        string csv ="";

        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamp = new PdfStamper(reader, ms);
            List<string> keys_not_found = new List<string>();
            KeyNotFoundException ex = new KeyNotFoundException();
            try
            {
                csv = stamp.AcroFields.GetField("csv");
            }
            catch (KeyNotFoundException e)
            {
                ex = e;
                keys_not_found.Add("csv");
            }

            stamp.FormFlattening = true;//recien aca cierro el pdf para que no puedan setearse los campos del pdf
            stamp.Close(); //cierro el pdf
            reader.Close();
            ms.Close();

            csv2 = csv;
            bytes = ms.ToArray();

        }


    }


    public byte[] AgregarQRsAPDF(byte[] bytes, String contenidoQR, List<int> listaPaginaImagen, List<int> listaTamEscalasImagen, List<float> listaPosicionesX, List<float> listaPosicionesY)
    {

        PdfReader reader = new PdfReader(bytes);
        BarcodeQRCode barcodeQRCode;
        Image codeQRImage;

        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamp = new PdfStamper(reader, ms);
            try
            {
                //stamp.AcroFields.SetField("texto5", csv);--ACA se debe agregar el nuevo codigo CSV
                Dictionary<EncodeHintType, Object> qrParam = new Dictionary<EncodeHintType, Object>();
                qrParam[EncodeHintType.ERROR_CORRECTION] = ErrorCorrectionLevel.M;
                qrParam[EncodeHintType.CHARACTER_SET] = "UTF-8";
                 
                //codeQRImage.ScaleAbsolute(100f,100f);
                //codeQRImage.SetAbsolutePosition(doc.PageSize.Width - 36f - 128f, doc.PageSize.Height - 36f - 686.6f);//216

                //foreach (float escala in listaTamEscalasImagen) {
                for (int i=0; i<listaTamEscalasImagen.Count;i++) {
                    barcodeQRCode = new BarcodeQRCode(contenidoQR, listaTamEscalasImagen.ElementAt(i), listaTamEscalasImagen.ElementAt(i), qrParam);
                    codeQRImage = barcodeQRCode.GetImage(); 
                    //codeQRImage.ScaleAbsolute(listaTamEscalasImagen.ElementAt(i), listaTamEscalasImagen.ElementAt(i));
                    codeQRImage.SetAbsolutePosition(listaPosicionesX.ElementAt(i), listaPosicionesY.ElementAt(i));

                    //codeQRImage.Rotate();
                    //codeQRImage.Rotate();
                    //codeQRImage.Rotation = (float)Math.PI / 2; //angulo en radianes, osea esto equivale a 90 grados
                //    codeQRImage.RotationDegrees = 90f;

                    PdfContentByte content = stamp.GetOverContent(listaPaginaImagen.ElementAt(i)); //imprimo en la 1 pagina
                    content.AddImage(codeQRImage);
                }

                //codeQRImage.ScaleAbsolute(75, 75);  //escala el tamaño de la imagen
                //codeQRImage.SetAbsolutePosition(420, 115);

            }
            catch (Exception e)
            {
                throw new Exception("no se pudieron agregar las imagenes de Qr al pdf");
            }

            stamp.FormFlattening = true; //recien aca cierro el pdf para que no puedan editarse los campos llenables del pdf
            stamp.Close(); //cierro el pdf
            reader.Close();
            ms.Close();

            byte[] Bytes = ms.ToArray();

            return Bytes;

        }


    }



}