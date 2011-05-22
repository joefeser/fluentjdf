﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Extensions to Xname
    /// </summary>
    public static class XNameExtension
    {
        /// <summary>
        /// Get the link name for a resource name.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static XName LinkName(this XName resourceName) {
            Contract.Requires(resourceName != null);

            return XName.Get(string.Format("{0}Link", resourceName.LocalName), resourceName.NamespaceName);
        }
    }
}