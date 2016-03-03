using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace GalleriaDesign.Models
{
    public class SessionExpireAttribute : System.Web.Mvc.ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //HttpSessionStateBase session = filterContext.HttpContext.Session;
            //var user = session["User"];

            //if (((user == null) && (!session.IsNewSession)) || (session.IsNewSession))
            //{
            //    //send them off to the login page
            //    var url = new UrlHelper(filterContext.RequestContext);
            //    var loginUrl = url.Content("~/Account/cerrarSesion");
            //    //session.RemoveAll();
            //    //session.Clear();
            //    //session.Abandon();
            //    filterContext.HttpContext.Response.Redirect(loginUrl, true);
            //}

            if (HttpContext.Current.Session.IsNewSession)
            {
                // Si la información es nula, redireccionar a 
                // página de error u otra página deseada.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "Controller", "Account" },
                    { "Action", "cerrarSesion" }
                });
            }

            base.OnActionExecuting(filterContext);
        }

    }

}