using System.Web;
using System.Web.Optimization;

namespace GalleriaDesign
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/Style1.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jasny").Include(
                    "~/Scripts/jasny-bootstrap.js",
                    "~/Scripts/jasny-bootstrap.min.js",
                    "~/Scripts/fileinput.js"));

            bundles.Add(new ScriptBundle("~/bundles/webcam").Include(
                    "~/Scripts/jquery.webcam.js",
                    "~/Scripts/jquery.webcam.min.js",
                    "~/Scripts/jscam.sf"
                   //"~/Scripts/jscam_canvas_only.swf"
                   //"~/Scripts/webcam.jquery.json",
                   //"~/Scripts/bower.json"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/pagination").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap.min.js"));

            // BundleTable.EnableOptimizations = true;


            bundles.Add(new ScriptBundle("~/bundles/WizardBootstrap").Include(
                "~/Scripts/jquery.bootstrap.wizard.js",
                "~/Scripts/jquery.bootstrap.wizard.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Select").Include(
                 "~/Scripts/bootstrap-select.js",
                 "~/Scripts/bootstrap-select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/supermarket").Include(

            "~/Scripts/Supermarket/InspectionSupermarket.js"
           ));


            bundles.Add(new ScriptBundle("~/bundles/Validation").Include(
                 "~/Scripts/bootstrapValidator.js",
                 "~/Scripts/bootstrapValidator.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/QRCode").Include(
                 "~/Scripts/ProductionFarms/qrcode.js"));

            bundles.Add(new ScriptBundle("~/bundles/ReadQR").Include(
                 "~/Scripts/ProductionFarms/html5-qrcode.min.js",
                 "~/Scripts/ProductionFarms/jsqrcode-combined.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/CascadingDrop").Include(
             "~/Scripts/ProductionFarms/Dimensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/georeferenzacion").Include(
                        "~/Scripts/Supermarket/geo.js"));
        }
    }
}
