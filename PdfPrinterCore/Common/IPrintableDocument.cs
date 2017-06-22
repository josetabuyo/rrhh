﻿/*
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

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// IPrintableDocument interface
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public interface IPrintableDocument
    {
        /// <summary>
        /// Returns an XML representation of this instance.
        /// </summary>
        string ToXml();
    }
}