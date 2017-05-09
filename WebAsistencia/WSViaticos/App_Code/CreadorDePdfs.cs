using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PdfPrinter.Core.Common;
using System.Web.Hosting;
using PdfPrinter.Core.Configuration;
using System.IO;


/// <summary>
/// Descripción breve de CreadorDePdfs
/// </summary>
public class CreadorDePdfs<T> where T:IPrintableDocument
{
	public CreadorDePdfs()
	{
	}

    public string Crear(string nombre_template, T data)
    {
        var xslt = ResourceManager.GetXsltFileContent(nombre_template);
        var xmlLoc = ResourceManager.GetLocalizedXmlFileContent("Document");

        XmlTransformationManager transformer = new XmlTransformationManager(data, xslt, xmlLoc);
        var xslFo = transformer.Transform();

        string outputFileName = Path.Combine(PdfPrinterConfiguration.GetCurrentSection().Settings.PdfOutputFolder, DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
        string absoluteOutputFilePath = HostingEnvironment.MapPath(outputFileName).Replace("PdfPrinterService", "WebAsistencia\\WebRH\\" + "EvaluacionDesempenio");

        PdfPrinterDriver.MakePdf(xslFo, absoluteOutputFilePath);

        System.IO.FileStream dd = System.IO.File.OpenRead(absoluteOutputFilePath);
        byte[] Bytes = new byte[dd.Length];
        dd.Read(Bytes, 0, Bytes.Length);
        return Convert.ToBase64String(Bytes);
    }
}