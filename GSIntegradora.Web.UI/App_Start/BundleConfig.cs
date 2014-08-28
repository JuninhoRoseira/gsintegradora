using System.Web.Optimization;

namespace GSIntegradora.Web.UI
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js",
				"~/Scripts/jquery.captcha.js"
				));

						// Piccasso
			bundles.Add(new ScriptBundle("~/bundles/Piccasso/js").Include(
				"~/Scripts/js/libs/all_in_one_libs.js",
				"~/Scripts/js/libs/colorpicker/colpick.js",
				"~/Scripts/js/libs/less-1.5.1.min.js",
				"~/Scripts/js/libs/jquery.cookie.js",
				"~/Scripts/js/styleSwitcher.js",
				"~/Scripts/js/front.js"));

			//AgileUI
			bundles.Add(new ScriptBundle("~/bundles/AgileUI/js").Include(
						"~/Scripts/agile/js/minified/aui-production.min.js",
						"~/Scripts/agile/js/aui-demo.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						"~/Scripts/jquery-ui-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.unobtrusive*",
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
						"~/Content/themes/base/jquery.ui.core.css",
						"~/Content/themes/base/jquery.ui.resizable.css",
						"~/Content/themes/base/jquery.ui.selectable.css",
						"~/Content/themes/base/jquery.ui.accordion.css",
						"~/Content/themes/base/jquery.ui.autocomplete.css",
						"~/Content/themes/base/jquery.ui.button.css",
						"~/Content/themes/base/jquery.ui.dialog.css",
						"~/Content/themes/base/jquery.ui.slider.css",
						"~/Content/themes/base/jquery.ui.tabs.css",
						"~/Content/themes/base/jquery.ui.datepicker.css",
						"~/Content/themes/base/jquery.ui.progressbar.css",
						"~/Content/themes/base/jquery.ui.theme.css"));

						//Piccasso
			bundles.Add(new StyleBundle("~/Content/Piccasso/css").Include(
				"~/Content/css/libs/animate.min.css",
				"~/Content/css/libs/font-awesome/css/font-awesome.min.css",
				"~/Content/css/style.css",
				"~/Scripts/js/libs/colorpicker/colpick.css"));

				// AgileUI
			bundles.Add(new StyleBundle("~/Content/AgileUI/css").Include(
			"~/Content/agile/css/minified/aui-production.min.css",
			"~/Content/agile/themes/minified/agileui/color-schemes/layouts/default.min.css",
			"~/Content/agile/themes/minified/agileui/color-schemes/elements/default.min.css",
			"~/Content/agile/themes/minified/agileui/responsive.min.css",
			"~/Content/agile/themes/minified/agileui/animations.min.css"));

		}
	}
}