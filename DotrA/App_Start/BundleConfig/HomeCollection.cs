using System.Web.Optimization;

namespace DotrA.App_Start
{
    public class HomeCollection
    {
        internal static void Initial(BundleCollection bundles)
        {
            #region minishop JS & CSS
            bundles.Add(new StyleBundle("~/home/css").Include(
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
                "~/Assets/css/style.css",
                "~/Assets/css/Glow.css",
                "~/Assets/css/LoginStyle.css"
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
        }
    }
}