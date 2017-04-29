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
using System.Text;
using System.Xml;
using Fonet;
using System.IO;
using System.Runtime.CompilerServices;

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// PdfPrinterDriver is a <see cref="FonetDriver"/> wrapper.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public static class PdfPrinterDriver
    {
        /// <summary>
        /// Generates a PDF file from the specified XSL-FO document.
        /// </summary>
        /// <param name="xslFoDocument">XSL-FO document.</param>
        /// <param name="outputFileAbsolutePath">Output PDF absolute file path.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void MakePdf(XmlDocument xslFoDocument, string outputFileAbsolutePath)
        {            
            using (Stream fileStream = File.Create(outputFileAbsolutePath))
            {
                PdfPrinterDriver.MakePdf(xslFoDocument, fileStream);
            }
        }

        /// <summary>
        /// Generates a PDF from XSL-FO document and sends it to the output stream
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void MakePdf(XmlDocument xslFoDocument, Stream outputStream)
        {
            FonetDriver driver = PdfPrinterDriver.InitFonetDriver();
            driver.Render(xslFoDocument, outputStream);
        }

        /// <summary>
        /// Returns PDF bytes generated from XSL-FO document.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static byte[] MakePdf(XmlDocument xslFoDocument)
        {
            FonetDriver driver = PdfPrinterDriver.InitFonetDriver();
            byte[] pdfBytes = new byte[0];

            using (MemoryStream ms = new MemoryStream())
            {
                driver.Render(xslFoDocument, ms);
                pdfBytes = ms.ToArray();
            }

            return pdfBytes;
        }

        /// <summary>
        /// Initializes FonetDriver.
        /// </summary>        
        private static FonetDriver InitFonetDriver()
        {
            //Creating Fonet Driver and generating PDF file...
            FonetDriver driver = FonetDriver.Make();

            driver.CloseOnExit = true;

            driver.OnInfo += new Fonet.FonetDriver.FonetEventHandler(PdfPrinterDriver.OnInfo);
            driver.OnWarning += new Fonet.FonetDriver.FonetEventHandler(PdfPrinterDriver.OnWarning);

            return driver;
        }

        /// <summary>
        /// Handles OnInfo events triggered by FonetDriver.
        /// </summary>   
        private static void OnInfo(object driver, FonetEventArgs e)
        {
            LoggingHelper.Info("PdfPrinter: {0}", e.GetMessage());
        }

        /// <summary>
        /// Handles OnWarning events triggered by FonetDriver.
        /// </summary>  
        private static void OnWarning(object driver, FonetEventArgs e)
        {
            LoggingHelper.Warn("PdfPrinter: {0}", e.GetMessage());
        }
    }
}
