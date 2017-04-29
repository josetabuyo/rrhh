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
using System.Xml.XPath;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// XmlTransformationManager handles trasformation between XML culture and XSLT.    
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public class XmlTransformationManager
    {
        /// <summary>
        /// XSLT extensions, used to extend the functionality of style sheets.
        /// </summary>
        public XsltArgumentList XsltExtensions;

        /// <summary>
        /// Trasformation style sheet.
        /// </summary>
        public IXPathNavigable XsltStyleSheet; 
        
        /// <summary>
        /// Localization resource XML.
        /// </summary>
        public IXPathNavigable LocalizedXml;

        /// <summary>
        /// IPrintableDocument instance.
        /// </summary>
        public IPrintableDocument Document { get; set; }

        /// <summary>
        /// Creates a new instance of XmlTransformationManager with <see cref="IPrintableDocument"/> and a trasformation style sheet.
        /// </summary>
        public XmlTransformationManager(IPrintableDocument document, IXPathNavigable xsltStyleSheet) : this(document, xsltStyleSheet, null) { }

        /// <summary>
        /// Creates a new instance of XmlTransformationManager with <see cref="IPrintableDocument"/>, a trasformation style sheet and a localized XML.
        /// </summary>
        public XmlTransformationManager(IPrintableDocument document, IXPathNavigable xsltStyleSheet, IXPathNavigable localizedXml)
        {
            if (document == null || xsltStyleSheet == null)
                throw new ArgumentException("Invalid arguments");

            this.Document = document;
            this.XsltStyleSheet = xsltStyleSheet;
            this.LocalizedXml = localizedXml;

            this.XsltExtensions = new XsltArgumentList();
            XsltExtensions.AddExtensionObject("pdfprinter:extensions:utility", new XsltExtensionService());
        }

        /// <summary>
        /// Returns an <see cref="XmlDocument"/> as a result of the trasformation.
        /// <code>
        /// XML + IPrintableDocument.ToXml() -> XSLT -> Ouput XmlDocument
        /// </code>
        /// </summary>        
        public XmlDocument Transform()
        {
            StringBuilder content = new StringBuilder();
            content.Append("<PdfPrinter>");

            if (LocalizedXml != null)
            {
                content.Append(LocalizedXml.CreateNavigator().InnerXml);
            }

            content.Append(Document.ToXml());
            content.Append("</PdfPrinter>");

            XPathNavigator xmlContent = new XPathDocument(new XmlTextReader(new StringReader(content.ToString()))).CreateNavigator();
            return Transform(XsltStyleSheet, xmlContent, this.XsltExtensions);
        }

        /// <summary>
        /// Returns an <see cref="XmlDocument"/> as a result of the trasformation.
        /// <code>
        public static XmlDocument Transform(IXPathNavigable xsltTemplate, IXPathNavigable xmlContent, XsltArgumentList xsltExtensions)
        {
            using (MemoryStream xslFoStream = new MemoryStream())
            {
                XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.Encoding = new UTF8Encoding(false);
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.Indent = true;

                using (XmlWriter xwriter = XmlWriter.Create(xslFoStream, settings))
                {
                    XslCompiledTransform transformer = new XslCompiledTransform(false);

                    transformer.Load(xsltTemplate);
                    transformer.Transform(xmlContent, xsltExtensions, xwriter);

                    xwriter.Flush();
                }

                string transformedXml = Encoding.UTF8.GetString(xslFoStream.ToArray());
                XmlDocument transformedXmlDoc = new XmlDocument();
                transformedXmlDoc.LoadXml(transformedXml);

                return transformedXmlDoc;
            }
        } 
    }
}
