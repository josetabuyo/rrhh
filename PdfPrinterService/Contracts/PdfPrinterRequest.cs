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
using System.ServiceModel;
using PdfPrinter.Core.Common;
using PdfPrinter.Core.DataContract;

namespace PdfPrinter.WebServices.Contracts
{
    /// <summary>
    /// Service request data contract.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    [MessageContract]
    public class PdfPrinterRequest
    {
        private Document _document;

        [MessageBodyMember]
        public Document Document
        {
            get { return _document; }
            set { _document = value; }
        }

    }
}