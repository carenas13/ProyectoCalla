using GalleriaDesign.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GalleriaDesign.Controllers
{
    public class ManagementController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Management
        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();
           
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// se muestra todos los usuarios del sistema
        /// </summary>
        /// <returns></returns>
        public ActionResult usersList() {

            var users = db.Users.ToList();
            List<UserGalleria> usersGalleria = new List<UserGalleria>();
            foreach (var user in users) {

                var userGalleria = new UserGalleria
                {
                    IDUser = user.Id,
                    userName = user.UserName,
                    fullName = user.fullName

                };
                usersGalleria.Add(userGalleria);

            }
            
            return View(usersGalleria);
        }
        /// <summary>
        /// Metodo para eliminar un usuario del sistema
        /// </summary>
        /// <param name="idUser">id del usuario a borrar</param>
        /// <returns></returns>
        public ActionResult deleteUser(string idUser) {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == idUser);
            userManager.Delete(user);
            return RedirectToAction("usersList");

        }
        /// <summary>
        /// Metodo para eliminar Roles
        /// </summary>
        /// <param name="idRol"></param>
        /// <param name="rolName"></param>
        /// <returns></returns>
        public ActionResult deleteRol(string idRol, string rolName ) {

            var rol = new IdentityRole();
            rol.Id = idRol;
            rol.Name = rolName;
            var rolMaager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = rolMaager.Roles.ToList();
            var rolDe= roles.Find(r => r.Id == rol.Id);
            rolMaager.Delete(rolDe);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Metodo para listar todos los roles del usuario recibe como parametro el id del usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult seeRolesUser(string id) {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolMaager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManager.Users.ToList().Find(u => u.Id == id);
            var roles = rolMaager.Roles.ToList();
            var rolesUser = new List<RolGalleria>();
            if (user.Roles!=null)
            {

                foreach(var rol in user.Roles)
                {
                    var role = roles.Find(r => r.Id == rol.RoleId);
                    var rolGallleria = new RolGalleria
                    {
                        IdRol = role.Id,
                        nameRol = role.Name

                    };
                    rolesUser.Add(rolGallleria);
                }

            }
            var userGalleria = new UserGalleria
            {
                IDUser = user.Id,
                userName = user.UserName,
                fullName = user.UserName,
                roles = rolesUser


            };
            return View(userGalleria);
        }

        /// <summary>
        /// Metodo para asignarle un rol a un usuario del sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult addRolesUser(string id) {

            var user = db.Users.Find(id);
            var userGalleria = new UserGalleria
            {
                IDUser = user.Id,
                userName = user.UserName,
                fullName = user.UserName

            };
            ViewBag.rol = new SelectList(db.Roles, "id", "Name");
            return View(userGalleria);
        }
        [HttpPost]
        public ActionResult addRolesUser(UserGalleria usuario) {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolMaager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.Users.ToList().Find(u => u.Id == usuario.IDUser);
            var rol = rolMaager.Roles.ToList().Find(r => r.Id == usuario.rol);
            if (!userManager.IsInRole(user.Id, rol.Name))
            {

                userManager.AddToRole(user.Id, rol.Name);
            }

            return RedirectToAction("usersList");
           
        }
        /// <summary>
        /// metodo para eliminar un rol al usuario 
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public ActionResult deleteRoleUser(string idUser, string idRol) {

            if (string.IsNullOrEmpty(idUser)|| string.IsNullOrEmpty(idRol))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolMaager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.Users.ToList().Find(u => u.Id == idUser);
            var rol = rolMaager.Roles.ToList().Find(r => r.Id == idRol);

            if (userManager.IsInRole(user.Id, rol.Name))
            {

                userManager.RemoveFromRole(user.Id, rol.Name);
            }


      /// retornando la vista para mostrar el usuario
            var Listaroles = rolMaager.Roles.ToList();
            var rolesUser = new List<RolGalleria>();
            if (user.Roles != null)
            {

                foreach (var rolUser in user.Roles)
                {
                    var role = Listaroles.Find(r => r.Id == rolUser.RoleId);
                    var rolGallleria = new RolGalleria
                    {
                        IdRol = role.Id,
                        nameRol = role.Name

                    };
                    rolesUser.Add(rolGallleria);
                }

            }
            var userGalleria = new UserGalleria
            {
                IDUser = user.Id,
                userName = user.UserName,
                fullName = user.UserName,
                roles = rolesUser


            };
            return View("seeRolesUser", userGalleria);
        }






        /// <summary>
        /// Metodo para cerrar las conexiones a la base de datos
        /// </summary>
        /// <param name="disposing"></param>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}