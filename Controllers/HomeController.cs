using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscGolf.Models;

namespace DiscGolf.Controllers
{
    public class HomeController : Controller
    {
        private DiscGolfContext context { get; set; }

        public HomeController(DiscGolfContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Action = "Login";
            return View("Login", new Player());
        }

        [HttpPost]
        public IActionResult Login(Player player)
        {
            var players= context.Players
                .ToList();
            foreach (Player p in players)
            {
                if (player.Username == p.Username)
                {
                    if (player.Password == p.Password)
                    {
                        return View("../Player/Index", p);
                    }
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Action = "Add";
            return View("Register", new Player());
        }

        [HttpPost]
        public IActionResult Register(Player player)
        {
            if (ModelState.IsValid)
            {
                if (player.PlayerID == 0)
                    context.Players.Add(player);
                context.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
