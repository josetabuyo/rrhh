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
using System.ServiceModel.Activation;
using System.ServiceModel;
using PdfPrinter.WebServices.Contracts;
using PdfPrinter.Core.Common;
using PdfPrinter.Core.DataContract;

namespace PdfPrinter.WebServices.Common
{
    /// <summary>
    /// A simple service for generating PDF documents.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(Namespace = "http://Schemas/PdfPrinter/WebServices")]
    public class PdfPrinterService : IPdfPrinter
    {
        public PdfPrinterResponse Print(PdfPrinterRequest request)
        {
            var response = PdfPrinterFacade.PrintPdf(request);
            return response;
        }
    }
}