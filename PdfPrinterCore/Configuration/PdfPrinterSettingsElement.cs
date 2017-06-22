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
using System.Configuration;

namespace PdfPrinter.Core.Configuration
{
    /// <summary>
    /// PdfPrinterSettingsElement defines library settings within config file.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public class PdfPrinterSettingsElement : ConfigurationElement
    {
        public PdfPrinterSettingsElement()
        { }        

        /// <summary>
        /// Defines XSLT folder.
        /// </summary>
        [ConfigurationProperty("xsltFolderPath", IsRequired = true)]
        public string XsltFolderPath {
            get
            {
                return (string)base["xsltFolderPath"];
            }
            set
            {
                base["xsltFolderPath"] = value;
            }
        }

        /// <summary>
        /// Defines culture XML folder.
        /// </summary>
        [ConfigurationProperty("localizationXmlFolderPath", IsRequired = true)]
        public string LocalizationXmlFolderPath
        {
            get
            {
                return (string)base["localizationXmlFolderPath"];
            }
            set
            {
                base["localizationXmlFolderPath"] = value;
            }
        }

        /// <summary>
        /// Defines default culture.
        /// </summary>
        [ConfigurationProperty("defaultCulture", IsRequired = false, DefaultValue = "en-US")]
        public string DefaultCulture
        {
            get
            {
                return (string)base["defaultCulture"];
            }
            set
            {
                base["defaultCulture"] = value;
            }
        }

        /// <summary>
        /// Defines default date format.
        /// </summary>
        [ConfigurationProperty("defaultDateFormat", IsRequired = false, DefaultValue = "MM/dd/yyyy")]
        public string DefaultDateFormat
        {
            get
            {
                return (string)base["defaultDateFormat"];
            }
            set
            {
                base["defaultDateFormat"] = value;
            }
        }

        /// <summary>
        /// Defines pdf output folder.
        /// </summary>
        [ConfigurationProperty("pdfOutputFolder", IsRequired = true)]
        public string PdfOutputFolder
        {
            get
            {
                return (string)base["pdfOutputFolder"];
            }
            set
            {
                base["pdfOutputFolder"] = value;
            }
        }
    }
}
