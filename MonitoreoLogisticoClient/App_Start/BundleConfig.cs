using System.Web;
using System.Web.Optimization;

namespace MonitoreoLogisticoClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor/jquery/jquery.min.js")); 


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/vendor/jquery-validation/jquery.validate.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/vendor/popper.js/umd/popper.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/vendor/jquery.cookie/jquery.cookie.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/respond.js"
                      ));


            //added for bootstrap date time picker
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.js",
                "~/Scripts/moment.min.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/moment-with-locales.min.js"
                ));

            //added for SignalR
            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/jquery.signalR-2.2.3.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.css",
                      "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/css/fontastic.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/bootstrap-datetimepicker.min.css"
                      ));
        }
    }
}
