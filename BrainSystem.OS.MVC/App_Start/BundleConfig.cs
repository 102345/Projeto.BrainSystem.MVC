using System.Web;
using System.Web.Optimization;

namespace BrainSystem.OS.MVC
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

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));



            bundles.Add(new ScriptBundle("~/bundles/assets/js").Include(
                     "~/assets/js/jquery-1.11.2.min.js",
                     "~/assets/js/jquery.easing.min.js",
                     "~/assets/plugins/bootstrap/js/bootstrap.min.js",
                     "~/assets/plugins/perfect-scrollbar/perfect-scrollbar.min.js",
                     "~/assets/plugins/viewport/viewportchecker.js",
                     "~/assets/plugins/jquery-ui/smoothness/jquery-ui.min.js",
                     "~/assets/plugins/timepicker/js/bootstrap-timepicker.min.js",
                     "~/assets/plugins/datepicker/js/datepicker.js",
                     "~/assets/plugins/bootstrap-datapicker/bootstrap-datepicker.js",
                     "~/assets/plugins/bootstrap-datapicker/bootstrap-datepicker-globalize.js",
                     "~/assets/plugins/bootstrap-datapicker/locales/bootstrap-datepicker.pt-BR.js",
                     "~/assets/plugins/toastr/toastr.min.js",
                     "~/assets/plugins/autosize/autosize.min.js",
                     "~/assets/plugins/icheck/icheck.min.js",
                     "~/assets/plugins/jquery.signaturepad/assets/numeric-1.2.6.min.js",
                     "~/assets/plugins/jquery.signaturepad/assets/bezier.js",
                     "~/assets/plugins/jquery.signaturepad/jquery.signaturepad.js",
                     "~/assets/plugins/jquery.signaturepad/assets/json2.min.js",
                     "~/assets/plugins/viewport/viewportchecker.js",
                     "~/assets/plugins/ladda/spin.min.js",
                     "~/assets/plugins/ladda/ladda.min.js",
                     "~/assets/plugins/ladda/prism.js",
                     "~/assets/js/OrdemServico/Utils.js",
                     "~/assets/js/OrdemServico/Index.js",
                     "~/assets/js/OrdemServico/CadastroProdutosFalhados.js",
                     "~/assets/js/OrdemServico/CadastroPecasEqptos.js",
                     "~/assets/js/OrdemServico/CadastroFuncionario.js",
                     "~/assets/js/scripts.js"));


            bundles.Add(new ScriptBundle("~/bundles/assets/datatable").Include(
                      "~/assets/plugins/datatables/js/jquery.dataTables.min.js",
                      "~/assets/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js",
                      "~/assets/plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js",
                      "~/assets/plugins/datatables/extensions/Responsive/bootstrap/3/dataTables.bootstrap.js",
                      "~/assets/plugins/responsive-tables/js/rwd-table.min.js"));


            bundles.Add(new StyleBundle("~/bundles/assets/datatable").Include(
                                      "~/assets/plugins/datatables/css/jquery.dataTables.css",
                                      "~/assets/plugins/datatables/extensions/TableTools/css/dataTables.tableTools.min.css",
                                      "~/assets/plugins/datatables/extensions/Responsive/css/dataTables.responsive.css",
                                      "~/assets/plugins/datatables/extensions/Responsive/bootstrap/3/dataTables.bootstrap.css"));



            bundles.Add(new StyleBundle("~/bundles/assets").Include(
                                        "~/assets/plugins/pace/pace-theme-flash.css",
                                        "~/assets/plugins/bootstrap/css/bootstrap.min.css",
                                        "~/assets/fonts/font-awesome/css/font-awesome.css",
                                        "~/assets/css/animate.min.css",
                                        "~/assets/plugins/perfect-scrollbar/perfect-scrollbar.css",
                                        "~/assets/css/style.css",
                                        "~/assets/plugins/timepicker/css/bootstrap-timepicker.css",
                                        "~/assets/plugins/bootstrap-datapicker/css/bootstrap-datepicker.css",
                                        "~/assets/plugins/toastr/toastr.min.css",
                                        "~/assets/plugins/fileinput/css/fileinput.min.css",
                                        "~/assets/plugins/fileinput/css/themes/explorer/theme.min.css",
                                        "~/assets/plugins/ladda/css/ladda-themeless.min.css",
                                        "~/assets/plugins/ladda/css/prism.css"));


        }
    }
}
