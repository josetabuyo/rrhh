/*
 * Pdf Printer Service
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 * 
 * Marco Merola, March 2013 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PdfPrinter.Core.Common;
using PdfPrinter.Core.Configuration;
using System.IO;
using System.Web.Hosting;
using PdfPrinter.WebServices.Contracts;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PdfPrinter.WebServices.Common
{
    /// <summary>
    /// PdfPrinterFacade shows how to use PdfPrinterService library for generating PDF documents.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public static class PdfPrinterFacade
    {
        public static PdfPrinterResponse PrintPdf(PdfPrinterRequest request)
        {
            PdfPrinterResponse response = new PdfPrinterResponse();

            TraceManager traceManager = EnterpriseLibraryContainer.Current.GetInstance<TraceManager>();
            using (traceManager.StartTrace(LoggingHelper.Categories.General))
            {
                try
                {
                    var xslt = ResourceManager.GetXsltFileContent("Document");
                    var xmlLoc = ResourceManager.GetLocalizedXmlFileContent("Document");

                    XmlTransformationManager transformer = new XmlTransformationManager(request.Document, xslt, xmlLoc);
                    var xslFo = transformer.Transform();

                    string outputFileName = Path.Combine(PdfPrinterConfiguration.GetCurrentSection().Settings.PdfOutputFolder, DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                    string absoluteOutputFilePath = HostingEnvironment.MapPath(outputFileName).Replace("PdfPrinterService", "WebAsistencia\\WebRH\\" + request.Document.PathSubmodulo);

                    PdfPrinterDriver.MakePdf(xslFo, absoluteOutputFilePath);

                    //response.Message = "Document generated at " + absoluteOutputFilePath;
                    var folders = outputFileName.Split('/');
                    response.Message = folders[folders.Length - 2] + "\\" + folders.Last();
                }
                catch (Exception exception)
                {
                    LoggingHelper.Error(exception);
                    response.Message = "No output file has been generated";
                    response.Info = exception.Message;
                }
            }

            return response;
        }
    }
}