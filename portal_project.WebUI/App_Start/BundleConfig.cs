using System.Web;
using System.Web.Optimization;

namespace portal_project.WebUI
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/Scripts/js/").Include(
                      "~/Scripts/js/bootstrap.js",
                      "~/Scripts/js/bootstrap.bundle.js",
                      
                      "~/Scripts/js/sidebars.js"));
                       

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sidebars.css",
                      
                      "~/Content/features.css"));
        }
    }
}
