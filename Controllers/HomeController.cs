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
                        List<GamePlayed> playerGames = new List<GamePlayed>();
                        List<Course> allCourses = new List<Course>();
                        var games = context.GamesPlayed
                            .OrderBy(m => m.CourseID)
                            .ToList();
                        var courses = context.Courses
                            .OrderBy(m => m.CourseID)
                            .ToList();
                        foreach (Course c in courses)
                        {
                            allCourses.Add(c);
                        }
                        foreach (GamePlayed game in games)
                        {
                            if (game.PlayerID == p.PlayerID)
                            {
                                playerGames.Add(game);
                            }
                        }
                        ViewData["Games"] = playerGames;
                        ViewData["Courses"] = allCourses;
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
