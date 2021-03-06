﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Optimization;

namespace MVC
{
    // See https://stevescodingblog.co.uk/changing-the-ordering-for-single-bundles-in-asp-net-4/
    [ExcludeFromCodeCoverage]
    class PassthruBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}