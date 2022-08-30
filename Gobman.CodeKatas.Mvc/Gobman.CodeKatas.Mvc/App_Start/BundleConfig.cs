using System.Web.Optimization;

namespace Gobman.CodeKatas.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include(
                    "~/Scripts/jquery-3.5.1.js",
                    "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"));
        }
    }
}
