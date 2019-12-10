using System.Web.Optimization;

namespace DotrA.App_Start
{
    public class SampleCollection
    {
        internal static void Initial(BundleCollection bundles)
        {
            #region minishop JS & CSS
            bundles.Add(new StyleBundle("~/minishop/css").Include(
                "~/Assets/minishop/css/font.css",
                "~/Assets/minishop/css/open-iconic-bootstrap.min.css",
                "~/Assets/minishop/css/animate.css",
                "~/Assets/minishop/css/owl.carousel.min.css",
                "~/Assets/minishop/css/owl.theme.default.min.css",
                "~/Assets/minishop/css/magnific-popup.css",
                "~/Assets/minishop/css/aos.css",
                "~/Assets/minishop/css/ionicons.min.css",
                "~/Assets/minishop/css/bootstrap-datepicker.css",
                "~/Assets/minishop/css/jquery.timepicker.css",
                "~/Assets/minishop/css/flaticon.css",
                "~/Assets/minishop/css/icomoon.css",
                "~/Assets/minishop/css/style.css"
                ));

            #region 沒有用這個 因為會自動排序 無法載入
            bundles.Add(new ScriptBundle("~/minishop/js").Include(
                  "~/Assets/minishop/js/jquery.min.js",
                  "~/Assets/minishop/js/jquery-migrate-3.0.1.min.js",
                  "~/Assets/minishop/js/popper.min.js",
                  "~/Assets/minishop/js/bootstrap.min.js",
                  "~/Assets/minishop/js/jquery.easing.1.3.js",
                  "~/Assets/minishop/js/jquery.waypoints.min.js",
                  "~/Assets/minishop/js/jquery.stellar.min.js",
                  "~/Assets/minishop/js/owl.carousel.min.js",
                  "~/Assets/minishop/js/jquery.magnific-popup.min.js",
                  "~/Assets/minishop/js/aos.js",
                  "~/Assets/minishop/js/jquery.animateNumber.min.js",
                  "~/Assets/minishop/js/bootstrap-datepicker.js",
                  "~/Assets/minishop/js/scrollax.min.js",
                  "~/Assets/minishop/js/main.js"
                ));
            #endregion
            #endregion

            #region ElaAdnin JS & CSS
            bundles.Add(new StyleBundle("~/ElaAdmin/css").Include(
                "~/Assets/ElaAdmin/css/normalize.min.css",
                "~/Assets/ElaAdmin/css/bootstrap.min.css",
                "~/Assets/ElaAdmin/css/font-awesome.min.css",
                "~/Assets/ElaAdmin/css/themify-icons.css",
                "~/Assets/ElaAdmin/css/pe-icon-7-stroke.min.css",
                "~/Assets/ElaAdmin/css/flag-icon.min.css",
                "~/Assets/ElaAdmin/css/cs-skin-elastic.css",
                "~/Assets/ElaAdmin/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/ElaAdmin/js").Include(
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