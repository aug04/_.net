using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SomeeMVC_4.Extensions
{
    public static class HtmlExtensions
    {
        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {
            // optional condition: I didn't wanted it to show on home and account controller
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return string.Empty;
            }

            StringBuilder breadcrumb = new StringBuilder("<ol class='breadcrumb'><li class='breadcrumb-item'>").Append(helper.ActionLink("Trang chủ", "Index", "Admin").ToHtmlString()).Append("</li>");


            breadcrumb.Append("<li class='breadcrumb-item'>");
            breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["controller"].ToString().Titleize(),
                                               "Index",
                                               helper.ViewContext.RouteData.Values["controller"].ToString()));
            breadcrumb.Append("</li>");

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.Append("<li class='breadcrumb-item active'>");
                //breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["action"].ToString().Titleize(),
                //                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                //                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                breadcrumb.Append(helper.ActionLink(helper.ViewData["Title"].ToString(),
                                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                breadcrumb.Append("</li>");
            }

            return breadcrumb.Append("</ol>").ToString();
        }
    }
}