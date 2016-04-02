using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Stands.Data;

namespace Stands.WebRole.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (var db = new DataEntities())
            {
                ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                           .GetUserManager<ApplicationUserManager>();

                var users = db.AspNetUsers.Include(i => i.AspNetRoles).ToList();

                foreach (var user in users)
                {
                    user.Role = userManager.GetRoles(user.Id).FirstOrDefault();
                }

                return View(users);
            }

        }

        public ActionResult Customers()
        {
            return View();
        }
    }
}