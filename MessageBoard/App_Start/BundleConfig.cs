using System.Web;
using System.Web.Optimization;

namespace MessageBoard
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
   

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                         "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery.validate.min.js",
                         "~/Scripts/jquery.validate.unobtrusive.min.js",
                         "~/Scripts/angular.js",
                       //  "~/Scripts/angular-ui-router.js",                    
                         "~/Scripts/angular-route.js",
                         "~/Scripts/bootstrap.min.js",
                         "~/Scripts/easing.js",
                         "~/Scripts/ddlevelsmenu.js",
                         "~/Scripts/flexslider.js",
                         "~/Scripts/jquery.prettyPhoto.js",
                         "~/Scripts/isotope.js",
                         "~/Scripts/respond.min.js",
                         "~/Scripts/html5shiv.js",
                         "~/Scripts/custom.js"
                         ));
           
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                                     "~/app/app.module.js",
                                     "~/app/topics/topics.module.js",
                                     "~/app/topics/topics.service.js",
                                     "~/app/topics/topics.controller.js",
                                     "~/app/topics/newtopic.controller.js",
                                     "~/app/topics/singletopic.controller.js"
                                     ));

        }
    }
}