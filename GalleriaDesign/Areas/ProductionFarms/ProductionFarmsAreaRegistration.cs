using System.Web.Mvc;

namespace GalleriaDesign.Areas.ProductionFarms
{
    public class ProductionFarmsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProductionFarms";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProductionFarms_default",
                "ProductionFarms/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}