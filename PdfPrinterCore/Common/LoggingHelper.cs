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
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// LoggingHelper is a simple wrapper of <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.LogWriter"/>.
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public class LoggingHelper
    {
        /// <summary>
        /// Log Categories
        /// </summary>
        public static class Categories
        {
            public static readonly string General = "General";
        }

        /// <summary>
        /// Formats input message and logs it with TraceEventType.Information (<seealso cref="TraceEventType"/>).
        /// </summary>
        public static void Info(string messageFormat, params object[] args)
        {
            LoggingHelper.Log(String.Format(messageFormat, args), TraceEventType.Information);
        }

        /// <summary>
        /// Logs input message with TraceEventType.Information (<seealso cref="TraceEventType"/>).
        /// </summary>
        public static void Info(string message)
        {
            LoggingHelper.Log(message, TraceEventType.Information);
        }

        /// <summary>
        /// Formats input message and logs it with TraceEventType.Warning (<seealso cref="TraceEventType"/>).
        /// </summary>
        public static void Warn(string messageFormat, params object[] args)
        {
            LoggingHelper.Log(String.Format(messageFormat, args), TraceEventType.Warning);
        }

        /// <summary>
        /// Logs input message with TraceEventType.Information (<seealso cref="TraceEventType"/>).
        /// </summary>
        public static void Warn(string message)
        {
            LoggingHelper.Log(message, TraceEventType.Warning);
        }

        /// <summary>
        /// Formats input exception and logs it with TraceEventType.Error (<seealso cref="TraceEventType"/>).
        /// </summary>
        public static void Error(Exception exception)
        {
            LoggingHelper.Log(String.Format("Type: {0} | Message: {1} | StackTrace: {2}", exception.GetType().ToString(), exception.Message, exception.StackTrace), System.Diagnostics.TraceEventType.Error);
        }

        /// <summary>
        /// Logs input message with the specified TraceEventType (<seealso cref="TraceEventType"/>).
        /// </summary>
        public static void Log(string message, TraceEventType severity)
        {
            LogEntry entry = new LogEntry();
            entry.Message = message;
            entry.Categories.Add(Categories.General);
            entry.Severity = severity;

            LogWriter logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
            logWriter.Write(entry);
        }
    }
}
