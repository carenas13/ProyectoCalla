using System.Web.Mvc;

namespace GalleriaDesign.Areas.GTH
{
    public class GTHAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GTH";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GTH_default",
                "GTH/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}