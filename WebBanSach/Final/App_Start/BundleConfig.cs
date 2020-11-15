using System.Web;
using System.Web.Optimization;

namespace Final
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));



            /* ************************************************************************************************* */


            bundles.Add(new StyleBundle("~/DoAnCSS").Include("~/css/bootstrap.min.css",
                "~/css/font-awesome.min.css",
                "~/css/elegant-icons.css",
                "~/css/nice-select.css",
                "~/css/jquery-ui.min.css",
                "~/css/owl.carousel.min.css",
                "~/css/slicknav.min.css",
                "~/css/style.css"));

            bundles.Add(new ScriptBundle("~/DoAnJS1").Include("~/js/jquery-3.3.1.min.js",
                "~/js/bootstrap.min.js",
                "~/js/jquery.nice-select.min.js",
                "~/js/jquery-ui.min.js",
                "~/js/jquery.slicknav.js",
                "~/js/mixitup.min.js",
                "~/js/owl.carousel.min.js",
                "~/js/main.js"));

            bundles.Add(new StyleBundle("~/LoginCSS").Include("~/css/bootstrap.min.css",
                "~/vendor/bootstrap/css/bootstrap.min.css",
                "~/fonts_login/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/fonts_login/iconic/css/material-design-iconic-font.min.css",
                "~/vendor/animate/animate.css",
                "~/vendor/css-hamburgers/hamburgers.min.css",
                "~/vendor/animsition/css/animsition.min.css",
                "~/vendor/select2/select2.min.css",
                "~/vendor/daterangepicker/daterangepicker.css",
                "~/css_login/util.css",
                "~/css_login/main.css"));


            bundles.Add(new ScriptBundle("~/LoginJS1").Include("~/vendor/jquery/jquery-3.2.1.min.js",
                "~/vendor/animsition/js/animsition.min.js",
                "~/vendor/bootstrap/js/popper.js",
                "~/vendor/bootstrap/js/bootstrap.min.js",
                "~/vendor/select2/select2.min.js",
                "~/vendor/daterangepicker/moment.min.js",
                "~/vendor/daterangepicker/daterangepicker.js",
                "~/vendor/countdowntime/countdowntime.js",
                "~/js/main.js"));


            bundles.Add(new StyleBundle("~/RegisterCSS").Include(
                     "~/fonts_register/material-icon/css/material-design-iconic-font.min.css",
                     "~/css_register/style.css"));


            bundles.Add(new ScriptBundle("~/RegisterJS1").Include(
                      "~/vendor_register/jquery/jquery.min.js",
                      "~/js_register/main.js"));


            bundles.Add(new StyleBundle("~/HomeCSS").Include("~/css/bootstrap.min.css",
               "~/assets_home/css/bootstrap.min.css",
               "~/assets_home/css/owl.carousel.min.css",
               "~/assets_home/css/flaticon.css",
               "~/assets_home/css/slicknav.css",
               "~/assets_home/css/animate.min.css",
               "~/assets_home/css/magnific-popup.css",
               "~/assets_home/css/fontawesome-all.min.css",
               "~/assets_home/css/themify-icons.css",
               "~/assets_home/css/slick.css",
               "~/assets_home/css/nice-select.css",
               "~/assets_home/css/style.css"));

            bundles.Add(new ScriptBundle("~/HomeJS1").Include("~/js/jquery-3.3.1.min.js",
                "~/assets_home/js/vendor/modernizr-3.5.0.min.js",
                "~/assets_home/js/vendor/jquery-1.12.4.min.js",
                "~/assets_home/js/popper.min.js",
                "~/assets_home/js/bootstrap.min.js",
                "~/assets_home/js/jquery.slicknav.min.js",
                "~/assets_home/js/owl.carousel.min.js",
                "~/assets_home/js/slick.min.js",
                "~/assets_home/js/wow.min.js",
                "~/assets_home/js/animated.headline.js",
                "~/assets_home/js/jquery.magnific-popup.js",
                "~/assets_home/js/jquery.scrollUp.min.js",
                "~/assets_home/js/jquery.nice-select.min.js",
                "~/assets_home/js/jquery.sticky.js",
                "~/assets_home/js/contact.js",
                "~/assets_home/js/jquery.form.js",
                "~/assets_home/js/jquery.validate.min.js",
                "~/assets_home/js/mail-script.js",
                "~/assets_home/js/jquery.ajaxchimp.min.js",
                "~/assets_home/js/plugins.js",
                "~/assets_home/js/main.js"));



            bundles.Add(new StyleBundle("~/AdminCSS").Include("~/bootstrap/css/bootstrap.min.css",
               "~/plugins/morris/morris.css",
               "~/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
               "~/plugins/daterangepicker/daterangepicker-bs3.css",
               "~/dist/css/AdminLTE.min.css",
               "~/dist/css/skins/_all-skins.min.css"));

            bundles.Add(new ScriptBundle("~/AdminJS1").Include("~/plugins/jQuery/jQuery-2.1.3.min.js",
                "~/bootstrap/js/bootstrap.min.js",
                "~/plugins/fastclick/fastclick.min.js",
                "~/dist/js/app.min.js",
                "~/plugins/sparkline/jquery.sparkline.min.js",
                "~/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                "~/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/plugins/daterangepicker/daterangepicker.js",
                "~/plugins/datepicker/bootstrap-datepicker.js",
                "~/plugins/iCheck/icheck.min.js",
                "~/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/plugins/chartjs/Chart.min.js",
                "~/dist/js/pages/dashboard2.js",
                "~/dist/js/demo.js"));





        }
    }
}
