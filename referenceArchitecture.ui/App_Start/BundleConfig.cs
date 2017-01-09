using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace referenceArchitecture.ui
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Javascript ===========================================================
            // ks Vendors
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include( // Jquery
                "~/Scripts/Vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include( // JqueryValidate
                "~/Scripts/Vendor/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include( // Bootstrap and respond
                "~/Scripts/Vendor/bootstrap.js",
                "~/Scripts/Vendor/respond.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Vendor/modernizr-*"));

            // js Common - Components
            var jsCommon = new ScriptBundle("~/bundles/Common").Include(
                "~/Scripts/Common/common1.js",
                "~/Scripts/Common/common2.js"
                );
            jsCommon.Orderer = new PassthruBundleOrderer();
            bundles.Add(jsCommon);

            // js Views
            var jsViews = new ScriptBundle("~/bundles/Views").Include(
                "~/Scripts/Views/Index.js",
                "~/Scripts/Views/CommonView.js"
                );
            jsViews.Orderer = new PassthruBundleOrderer();
            bundles.Add(jsViews);

            // CSS Style ===========================================================
            // css Vendor
            var cssVendor = new StyleBundle("~/Content/cssVendor").Include(
                "~/Content/Vendor/bootstrap.css"
            );
            cssVendor.Orderer = new PassthruBundleOrderer();
            bundles.Add(cssVendor);

            // css Main
            var cssMain = new StyleBundle("~/Content/cssMain").Include(
                "~/Content/Main/site.css"
            );
            cssMain.Orderer = new PassthruBundleOrderer();
            bundles.Add(cssMain);

            // css Views
            var cssViews = new StyleBundle("~/Content/cssViews").Include(
                "~/Content/Views/Index.css"
            );
            cssViews.Orderer = new PassthruBundleOrderer();
            bundles.Add(cssViews);
        }
    }

    /// <summary>
    /// Class to order the js and css files.
    /// </summary>
    public class PassthruBundleOrderer : IBundleOrderer
    {
        /// <summary>
        /// Order the css and js files.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="files">Files.</param>
        /// <returns>An collection of bundlefile.</returns>
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
