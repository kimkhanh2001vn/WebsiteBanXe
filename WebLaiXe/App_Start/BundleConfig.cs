using System.Web.Optimization;

namespace WebLaiXe
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
                      "~/assets/js/bootstrap.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/Scripts").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/bootstrap.js"
                        ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/assets/css/bootstrap.min.css",
                      "~/Content/PagedList.css"
                      ));
            bundles.Add(new StyleBundle("~/assets/css").Include(
                "~/assets/css/owl.carousel.css",
                "~/assets/css/fontawesome-all.css",
                "~/assets/css/flaticon.css",
                "~/assets/css/meanmenu.css",
                "~/assets/css/bootstrap.min.css",
                "~/assets/css/video.min.css",
                "~/assets/css/animate.min.css",
                "~/assets/css/lightbox.css",
                "~/assets/css/progess.css",
                "~/assets/css/style.css",
                "~/assets/css/responsive.css",
                "~/assets/css/Cart.css"
                ));
            bundles.Add(new ScriptBundle("~/assets/js").Include(
                "~/assets/js/jquery-2.1.4.min.js",
                "~/assets/js/popper.min.js",
                "~/assets/js/owl.carousel.min.js",
                "~/assets/js/jarallax.js",
                "~/assets/js/jquery.magnific-popup.min.js",
                "~/assets/js/lightbox.js",
                "~/assets/js/jquery.meanmenu.js",
                "~/assets/js/scrollreveal.min.js",
                "~/assets/js/jquery.counterup.min.js",
                "~/assets/js/waypoints.min.js",
                "~/assets/js/jquery-ui.js",
                "~/assets/js/script.js",
                "~/assets/js/gmap3.min.js",
                "~/assets/js/switch.js",
                "~/Content/LoginTemple.css"
                ));
            bundles.Add(new StyleBundle("~/Areas/Admin/Resources/bundles/css")
                .Include("~/assets/js/jquery-2.1.4.min.js")
                .Include("~/Areas/Admin/Resources/bootstrap/css/bootstrap.min.css")
                .Include("~/Areas/Admin/Resources/css/font-awesome.min.css")
                .Include("~/Areas/Admin/Resources/plugins/datatables/dataTables.bootstrap.css")
                .Include("~/Areas/Admin/Resources/dist/css/AdminLTE.min.css")
                .Include("~/Areas/Admin/Resources/dist/css/skins/_all-skins.min.css")
                .Include("~/Areas/Admin/Resources/plugins/morris/morris.css")
                .Include("~/Areas/Admin/Resources/plugins/jvectormap/jquery-jvectormap-1.2.2.css")
                //.Include("~/Areas/Admin/Resources/plugins/datepicker/datepicker3.css")
                .Include("~/Areas/Admin/Resources/plugins/daterangepicker/daterangepicker.css")
                .Include("~/Areas/Admin/Resources/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
                .Include("~/Areas/Admin/Resources/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker(mod).min.css")
                .Include("~/Areas/Admin/Resources/css/style.css")
                .Include("~/Areas/Admin/Resources/ckeditor/fonts.css")

             );
            bundles.Add(new ScriptBundle("~/Areas/Admin/Resources/bundles/js")
                .Include("~/Areas/Admin/Resources/plugins/jQuery/jquery-2.2.3.min.js")
                .Include("~/Areas/Admin/Resources/js/sweetalert.js")
                .Include("~/Areas/Admin/Resources/Knockout/knockout-3.4.2.js")
                .Include("~/Areas/Admin/Resources/js/jquery-ui.min.js")
                .Include("~/Areas/Admin/Resources/bootstrap/js/bootstrap.min.js")
                .Include("~/Areas/Admin/Resources/js/raphael-min.js")
                .Include("~/Areas/Admin/Resources/plugins/morris/morris.min.js")
                .Include("~/Areas/Admin/Resources/plugins/sparkline/jquery.sparkline.min.js")
                .Include("~/Areas/Admin/Resources/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js")
                .Include("~/Areas/Admin/Resources/plugins/jvectormap/jquery-jvectormap-world-mill-en.js")
                .Include("~/Areas/Admin/Resources/plugins/knob/jquery.knob.js")
                .Include("~/Areas/Admin/Resources/plugins/momentjs/moment-with-locales.min.js")
                .Include("~/Areas/Admin/Resources/plugins/daterangepicker/daterangepicker.js")
                .Include("~/Areas/Admin/Resources/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Areas/Admin/Resources/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js")
                .Include("~/Areas/Admin/Resources/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js")
                .Include("~/Areas/Admin/Resources/plugins/datatables/jquery.dataTables.min.js")
                .Include("~/Areas/Admin/Resources/plugins/datatables/plugin/date-uk.js")
                .Include("~/Areas/Admin/Resources/plugins/datatables/plugin/datetime-moment.js")
                .Include("~/Areas/Admin/Resources/plugins/datatables/dataTables.bootstrap.min.js")
                .Include("~/Areas/Admin/Resources/plugins/slimScroll/jquery.slimscroll.min.js")
                .Include("~/Areas/Admin/Resources/plugins/fastclick/fastclick.js")
                .Include("~/Areas/Admin/Resources/dist/js/app.js")
                .Include("~/Areas/Admin/Resources/dist/js/demo.js")
                .Include("~/Areas/Admin/Resources/js/ChangesStatus/ChangeStatus.js")
                .Include("~/Areas/Admin/Resources/js/Delete/DeleteConfirm.js")
                .Include("~/Areas/Admin/Resources/js/selectImage.js")
                );
        }
    }
}
