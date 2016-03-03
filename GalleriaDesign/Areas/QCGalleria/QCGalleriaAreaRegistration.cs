using System.Web.Mvc;

namespace GalleriaDesign.Areas.QCGalleria
{
    public class QCGalleriaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QCGalleria";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QCGalleria_default",
                "QCGalleria/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}