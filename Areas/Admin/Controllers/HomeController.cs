using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscGolf.Models;

namespace DiscGolf.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private UserContext context { get; set; }

        public HomeController(UserContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var users = context.Users
                .OrderBy(m => m.Name)
                .ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public  IActionResult Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
