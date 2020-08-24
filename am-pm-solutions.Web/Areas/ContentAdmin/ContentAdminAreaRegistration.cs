using System.Web.Mvc;

namespace am_pm_solutions.Web.Areas.ContentAdmin
{
    public class ContentAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ContentAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ContentAdmin_default",
                "ContentAdmin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "am_pm_solutions.Web.Areas.ContentAdmin.Controllers" }
            );
            //context.MapRoute(
            //    "ContentAdmin_default",
            //    "ContentAdmin/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}