using System.Web.Optimization;

namespace DotrA.App_Start
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
                "~/Assets/BackEndSystem/js/jquery.min.js",
                "~/Assets/BackEndSystem/js/popper.min.js",
                "~/Assets/BackEndSystem/js/bootstrap.min.js",
                "~/Assets/BackEndSystem/js/jquery.matchHeight-min.js",
                "~/Assets/BackEndSystem/js/main.js"
                ));

            bundles.Add(new ScriptBundle("~/BackEndSystem/datatable").Include(
                "~/Assets/BackEndSystem/js/datatable/jszip.min.js",
                "~/Assets/BackEndSystem/js/datatable/pdfmake.min.js",
                "~/Assets/BackEndSystem/js/datatable/vfs_fonts.js",
                "~/Assets/BackEndSystem/js/datatable/jquery.dataTables.min.js",
                "~/Assets/BackEndSystem/js/datatable/dataTables.bootstrap4.min.js",
                "~/Assets/BackEndSystem/js/datatable/dataTables.buttons.min.js",
                "~/Assets/BackEndSystem/js/datatable/buttons.bootstrap4.min.js",
                "~/Assets/BackEndSystem/js/datatable/buttons.colVis.min.js",
                "~/Assets/BackEndSystem/js/datatable/buttons.html5.min.js",
                "~/Assets/BackEndSystem/js/datatable/buttons.print.min.js"
                ));
            #endregion
        }
    }
}