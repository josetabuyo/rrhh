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
using PdfPrinter.Core.Configuration;
using System.IO;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Web.Hosting;

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// ResourceManager retrieves XML and XSLT file contents.
    /// XML and XSLT contents are cached in Application with file dependency.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public static class ResourceManager
    {
        /// <summary>
        /// Returns XSLT file as <see cref="IXPathNavigable"/>.
        /// </summary>
        /// <param name="filename">The XSLT file name. XSLT folder path is defined in web.config. See <see cref=""/>PdfPrinterSettingsElement</param>        
        public static IXPathNavigable GetXsltFileContent(string filename)
        {
            if (!filename.EndsWith(".xslt"))
                filename = filename + ".xslt";

            string resourceKey = String.Format("XSLT|{0}", filename.ToUpperInvariant());
            string resourceAbsolutePath = HostingEnvironment.MapPath(PdfPrinterConfiguration.GetCurrentSection().Settings.XsltFolderPath + filename);

            return GetXmlContent(resourceKey, resourceAbsolutePath);
        }

        /// <summary>
        /// Returns XML file as <see cref="IXPathNavigable"/>.
        /// </summary>
        /// <param name="filename">The XML file name. XML folder path is defined in web.config. See <see cref=""/>PdfPrinterSettingsElement</param>        
        public static IXPathNavigable GetLocalizedXmlFileContent(string filename)
        {
            return ResourceManager.GetLocalizedXmlFileContent(filename, PdfPrinterConfiguration.GetCurrentSection().Settings.DefaultCulture);
        }

        /// <summary>
        /// Returns XML file as <see cref="IXPathNavigable"/>.
        /// </summary>
        /// <param name="filename">The XML file name. XML folder path is defined in web.config. See <see cref=""/>PdfPrinterSettingsElement</param>        
        /// <param name="culture">The XML file culture.</param>
        public static IXPathNavigable GetLocalizedXmlFileContent(string filename, string culture)
        {
            if (!filename.EndsWith(".xml"))
                filename = filename + ".xml";

            string resourceKey = String.Format("XML|{0}|{1}", culture.ToUpperInvariant(), filename.ToUpperInvariant());
            string resourceAbsolutePath = HostingEnvironment.MapPath(PdfPrinterConfiguration.GetCurrentSection().Settings.LocalizationXmlFolderPath + culture + "/" + filename);

            return GetXmlContent(resourceKey, resourceAbsolutePath);
        }        

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static IXPathNavigable GetXmlContent(string resourceKey, string resourceAbsolutePath)
        {
            if (CacheUtility.Contains(resourceKey))
                return CacheUtility.Get<IXPathNavigable>(resourceKey);

            IXPathNavigable xpn = GetFileContent(resourceAbsolutePath, false);

            CacheUtility.Insert(resourceKey, xpn, resourceAbsolutePath);            
            return xpn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static IXPathNavigable GetFileContent(string filePath, bool editable)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Unable to find the specified file", filePath);

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                if (!editable)
                    return new XPathDocument(reader);

                XmlDocument document = new XmlDocument();
                document.Load(reader);
                return document;
            }

        }
    }
}
