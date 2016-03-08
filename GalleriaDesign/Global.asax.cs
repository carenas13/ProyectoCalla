using GalleriaDesign.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GalleriaDesign
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.GalleriaDesignContext, QCGalleriaMigrations.Configuration>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.GTHContext, GTHMigrations.Configuration>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Supermarket.Models.SupermarketContext, SuperMarketMigrations.Configuration>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationProductionsFarms.Models.ApplicationProductionsFarmsContext, ProductionFarmsMigrations.Configuration>());

            ApplicationDbContext db = new ApplicationDbContext();
            createRoles(db);
            createSuperUser(db);
            addPermisionSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void addPermisionSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManager.FindByName(System.Web.Configuration.WebConfigurationManager.AppSettings["superUser"]);

            if (!userManager.IsInRole(user.Id, System.Web.Configuration.WebConfigurationManager.AppSettings["SuperAdmin"]))
            {
                userManager.AddToRole(user.Id, System.Web.Configuration.WebConfigurationManager.AppSettings["SuperAdmin"]);
            }

        }

        private void createSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName(System.Web.Configuration.WebConfigurationManager.AppSettings["superUser"]);

               if(user == null){
                    user = new ApplicationUser
                    {
                        UserName = System.Web.Configuration.WebConfigurationManager.AppSettings["superUser"],
                        Email = System.Web.Configuration.WebConfigurationManager.AppSettings["superUser"]

                    };
                userManager.Create(user, System.Web.Configuration.WebConfigurationManager.AppSettings["contrasenaSuperAdmin"]);
                }

        }

        private void createRoles(ApplicationDbContext db)
        {
          var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //  if (!rolManager.RoleExists("SuperAdmin"))
            if (!rolManager.RoleExists(System.Web.Configuration.WebConfigurationManager.AppSettings["SuperAdmin"])) 
            {
                // rolManager.Create(new IdentityRole("SuperAdmin"));
                rolManager.Create(new IdentityRole(System.Web.Configuration.WebConfigurationManager.AppSettings["SuperAdmin"]));
            }
            if (!rolManager.RoleExists(System.Web.Configuration.WebConfigurationManager.AppSettings["InspectorQC"]))
            {
                rolManager.Create(new IdentityRole(System.Web.Configuration.WebConfigurationManager.AppSettings["InspectorQC"]));
            }
            if (!rolManager.RoleExists(System.Web.Configuration.WebConfigurationManager.AppSettings["InspectorSuperMarket"]))
            {
                rolManager.Create(new IdentityRole(System.Web.Configuration.WebConfigurationManager.AppSettings["InspectorSuperMarket"]));
            }
            if (!rolManager.RoleExists(System.Web.Configuration.WebConfigurationManager.AppSettings["UserProductioFarms"]))
            {
                rolManager.Create(new IdentityRole(System.Web.Configuration.WebConfigurationManager.AppSettings["UserProductioFarms"]));
            }
            if (!rolManager.RoleExists(System.Web.Configuration.WebConfigurationManager.AppSettings["UserOrders"]))
            {
                rolManager.Create(new IdentityRole(System.Web.Configuration.WebConfigurationManager.AppSettings["UserOrders"]));
            }
            if (!rolManager.RoleExists(System.Web.Configuration.WebConfigurationManager.AppSettings["UserGTH"]))
            {
                rolManager.Create(new IdentityRole(System.Web.Configuration.WebConfigurationManager.AppSettings["UserGTH"]));
            }


        }
    }
}
