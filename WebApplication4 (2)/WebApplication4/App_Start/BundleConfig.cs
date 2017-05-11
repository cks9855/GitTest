using System.Web.Optimization;

namespace WebApplication4
{
    public class BundleConfig
    {
        // 번들 작성에 대한 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=301862 링크를 참조하십시오.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jssor.slider-21.1.6.min.js",
                        "~/Scripts/register.js",
                        "~/Scripts/translate-it.js",
                        "~/Scripts/slider.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션할 준비가 되면 http://modernizr.com 링크의 빌드 도구를 사용하여 필요한 테스트만 선택하십시오.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.theme.css",
                      "~/Content/font-awesome.css",
                      "~/Content/slider.css",
                      "~/Content/buy.css",
                      "~/Content/videocss.css",
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Site").Include(
                      "~/Scripts/index.js",
                      "~/Scripts/Login.js"));
        }
    }
}