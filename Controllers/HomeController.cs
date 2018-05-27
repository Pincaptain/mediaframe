using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mediaframe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Mediaframe.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext Database { get; set; }
        public ApplicationUserManager UserManager { get; set; }

        public HomeController()
        {
            Database = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { });
            }

            var userId = User.Identity.GetUserId();

            var model = new HomeViewModel()
            {
                User = Database.Profiles.FirstOrDefault(p => p.AccountId == userId)
            };

            model.Suggested = Database.Profiles
                .Where(p => p.Followers.FirstOrDefault(f => f.Id == model.User.Id) == null)
                .Where(p => p.Id != model.User.Id)
                .Take(10)
                .ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}