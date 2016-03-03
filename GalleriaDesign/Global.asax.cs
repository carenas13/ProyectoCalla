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
            var user = userManager.FindByName("galleria@galleriafarms.com");

            if (!userManager.IsInRole(user.Id, "SuperAdmin"))
            {
                userManager.AddToRole(user.Id, "SuperAdmin");
            }

        }

        private void createSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("galleria@galleriafarms.com");

               if(user == null){
                    user = new ApplicationUser
                    {
                        UserName = "galleria@galleriafarms.com",
                        Email = "galleria@galleriafarms.com"

                    };
                userManager.Create(user,"galleria");
                }

        }

        private void createRoles(ApplicationDbContext db)
        {
          var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!rolManager.RoleExists("SuperAdmin"))
            {
                rolManager.Create(new IdentityRole("SuperAdmin"));
            }
            if (!rolManager.RoleExists("InspectorQC"))
            {
                rolManager.Create(new IdentityRole("InspectorQC"));
            }
            if (!rolManager.RoleExists("InspectorSuperMarket"))
            {
                rolManager.Create(new IdentityRole("InspectorSuperMarket"));
            }
            if (!rolManager.RoleExists("UserProductioFarms"))
            {
                rolManager.Create(new IdentityRole("UserProductioFarms"));
            }

        }
    }
}
