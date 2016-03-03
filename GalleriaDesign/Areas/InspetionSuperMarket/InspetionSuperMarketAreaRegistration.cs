using System.Web.Mvc;

namespace GalleriaDesign.Areas.InspetionSuperMarket
{
    public class InspetionSuperMarketAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InspetionSuperMarket";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InspetionSuperMarket_default",
                "InspetionSuperMarket/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}