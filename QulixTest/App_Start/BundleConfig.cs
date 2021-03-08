using System.Web;
using System.Web.Optimization;

namespace QulixTest
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                      "~/css/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery-ui").Include(
                      "~/Scripts/jquery-ui.js"));
        }
    }
}
