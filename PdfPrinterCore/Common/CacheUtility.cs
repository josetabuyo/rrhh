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
using System.Web;
using System.Web.Caching;
using System.Xml.XPath;
using System.Xml;
using System.Runtime.CompilerServices;

namespace PdfPrinter.Core.Common
{
    /// <summary>
    /// CacheUtility is a simple wrapper for <see cref="System.Web.Caching.Cache"/> object.    
    /// </summary>
    /// <remarks>
    /// Author: Marco Merola
    /// </remarks>
    public static class CacheUtility
    {
        /// <summary>
        /// Searches the specified key within <see cref="System.Web.Caching.Cache"/> object and returns it as T.
        /// </summary>
        public static T Get<T>(string key)
        {
            object result = HttpContext.Current.Cache[key];
            if (result != null)
                return (T)result;
            else
                return default(T);
        }

        /// <summary>
        /// Inserts the specified object within <see cref="System.Web.Caching.Cache"/> with the specified key and 'NoAbsoluteExpiration' and 'NoSlidingExpiration' settings.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Insert(string key, object obj)
        {
            HttpContext.Current.Cache.Insert(key, obj, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// Inserts the specified object within <see cref="System.Web.Caching.Cache"/> with the specified key and expiration seconds from insertion.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Insert(string key, object obj, int expirationSecondsFromNow)
        {
            HttpContext.Current.Cache.Add(key, obj, null, DateTime.Now.AddSeconds(expirationSecondsFromNow), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// Inserts the specified object within <see cref="System.Web.Caching.Cache"/> with the specified key and expiration seconds from insertion.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Insert(string key, object obj, string resourceAbsolutePath)
        {
            HttpContext.Current.Cache.Insert(key, obj, new CacheDependency(resourceAbsolutePath), Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// Tests if the specified key is in <see cref="System.Web.Caching.Cache"/>.
        /// </summary>
        public static bool Contains(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }
    }
}
