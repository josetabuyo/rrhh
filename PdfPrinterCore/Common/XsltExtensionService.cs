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
using System.Globalization;
using PdfPrinter.Core.Configuration;
using System.Web.Hosting;

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// XsltExtensionService is a container of helper methods used to extend the functionality of style sheets.   
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public class XsltExtensionService
    {
        /// <summary>
        /// Returns the physical file path that corresponds to the specified virtual path on the Web server.
        /// </summary>
        /// <param name="path">The virtual path</param>
        public string MapPath(string path) { return HostingEnvironment.MapPath(path); }

        /// <summary>
        /// Inserts a white space after every 'breakLen' number of chars.
        /// 
        /// Example:
        /// longWord: 'supercalifragilistichespiralitoso'
        /// breakLen: 8
        /// 
        /// returns: 'supercal ifragili stichesp iralitos o'        
        /// </summary>
        /// <param name="longWord">The word to break</param>
        /// <param name="breakLen">The maximum length of each sub-word within the 'longWord'</param>        
        public string BreakWords(string longWord, int breakLen)
        {
            string[] words = longWord.Split(' ');

            List<string> breakedWords = new List<string>();
            foreach (var w in words)
                BreakWord(w, breakLen, breakedWords);

            return String.Join(" ", breakedWords.ToArray());
        }

        private void BreakWord(string longWord, int breakLen, List<string> words)
        {
            if (!String.IsNullOrEmpty(longWord))
            {
                if (longWord.Length > breakLen)
                {
                    words.Add(longWord.Substring(0, breakLen));
                    BreakWord(longWord.Substring(breakLen), breakLen, words);
                }
                else words.Add(longWord);
            }
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        public string Substring(string s, int from, int len)
        {
            if (s.Length > len)
                return s.Substring(from, len);
            return s;
        }

        /// <summary>
        /// Formats date string according to the date format string defined on web.config.
        /// See <see cref="PdfPrinterSettingsElement"/>.
        /// </summary>
        public string FormatDateTime(string dateAsString)
        {
            return FormatDateTime(dateAsString, PdfPrinterConfiguration.GetCurrentSection().Settings.DefaultDateFormat);
        }

        /// <summary>
        /// Formats input date string with the specified date format.
        /// </summary>
        public string FormatDateTime(string dateAsString, string format)
        {
            try
            {
                DateTime date = DateTime.Parse(dateAsString);
                return date.ToString(format);
            }
            catch { return dateAsString; }
        }

        /// <summary>
        /// Parses decimal string according to the current thread culture
        /// </summary>
        public bool ParseDecimalString(string decimalValue, out decimal d)
        {
            return Decimal.TryParse(
                decimalValue.Replace(" ", ""),
                NumberStyles.Integer | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowParentheses,
                CultureInfo.InvariantCulture,
                out d
                );
        }

        /// <summary>
        /// Parses integer string according to the current thread culture
        /// </summary>
        public bool ParseIntString(string intValue, out int i)
        {
            return Int32.TryParse(
                intValue.Replace(" ", ""),
                NumberStyles.Integer | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowParentheses,
                CultureInfo.InvariantCulture,
                out i);
        }

        /// <summary>
        /// Formats decimal value according to the culture defined on web.config.
        /// See <see cref="PdfPrinterSettingsElement"/>.
        /// </summary>
        public string FormatDecimal(string decimalValue) { return FormatDecimal(decimalValue, PdfPrinterConfiguration.GetCurrentSection().Settings.DefaultCulture); }

        /// <summary>
        /// Formats decimal value according to the culture name, see <see cref="System.Globalization.CultureInfo"/>.
        /// </summary>
        public string FormatDecimal(string decimalValue, string culture)
        {
            string formattedAmount = decimalValue;
            decimal y;

            if (ParseDecimalString(decimalValue, out y))
            {
                CultureInfo cultureInfo = new CultureInfo(culture);
                cultureInfo.NumberFormat.NumberDecimalDigits = 2;
                formattedAmount = y.ToString("N", cultureInfo);
            }

            return formattedAmount;
        }

        /// <summary>
        /// Formats integer value according to the culture defined on web.config.
        /// See <see cref="PdfPrinterSettingsElement"/>.
        /// </summary>
        public string FormatInteger(string intValue) { return FormatDecimal(intValue, PdfPrinterConfiguration.GetCurrentSection().Settings.DefaultCulture); }

        /// <summary>
        /// Formats integer value according to the culture name, see <see cref="System.Globalization.CultureInfo"/>.
        /// </summary>
        public string FormatInteger(string intValue, string culture)
        {
            int x;
            string formattedAmount = intValue;
            if (ParseIntString(intValue, out x))
            {
                CultureInfo cultureInfo = new CultureInfo(culture);
                cultureInfo.NumberFormat.NumberDecimalDigits = 0;
                formattedAmount = x.ToString("N", cultureInfo);
            }

            return formattedAmount;
        }

        /// <summary>
        /// Tests if the given number is negative.
        /// </summary>
        public bool IsNegativeNumber(string number)
        {
            decimal d;
            if (ParseDecimalString(number, out d))
                return d < 0;

            return false;
        }
    }
}

