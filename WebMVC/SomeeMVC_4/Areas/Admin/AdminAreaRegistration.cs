using System.Web.Mvc;
using System.Web.Routing;
using LowercaseDashedRouting;

namespace SomeeMVC_4.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var route = new LowercaseDashedRoute("Admin/{controller}/{action}/{id}",
                new RouteValueDictionary(new { action = "Index", id = UrlParameter.Optional }), 
                    new DashedRouteHandler(), this, context);

            context.Routes.Add("Admin_default", route);
        }
    }
}
