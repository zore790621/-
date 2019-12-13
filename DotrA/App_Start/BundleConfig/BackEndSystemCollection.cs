using System.Web.Optimization;

namespace DotrA
{
    internal class BackEndSystemCollection
    {
        internal static void Initial(BundleCollection bundles)
        {
            #region ElaAdnin JS & CSS
            bundles.Add(new StyleBundle("~/BackEndSystem/css").Include(
                "~/Assets/ElaAdmin/css/normalize.min.css",
                "~/Assets/ElaAdmin/css/bootstrap.min.css",
                "~/Assets/ElaAdmin/css/font-awesome.min.css",
                "~/Assets/ElaAdmin/css/themify-icons.css",
                "~/Assets/ElaAdmin/css/pe-icon-7-stroke.min.css",
                "~/Assets/ElaAdmin/css/flag-icon.min.css",
                "~/Assets/ElaAdmin/css/cs-skin-elastic.css",
                "~/Assets/ElaAdmin/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/BackEndSystem/js").Include(
                "~/Assets/ElaAdmin/js/jquery.min.js",
                "~/Assets/ElaAdmin/js/popper.min.js",
                "~/Assets/ElaAdmin/js/bootstrap.min.js",
                "~/Assets/ElaAdmin/js/jquery.matchHeight.min.js",
                "~/Assets/ElaAdmin/js/main.js"
                ));
            #endregion
        }
    }
}