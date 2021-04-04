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
        private GamesPlayedUnitOfWork data { get; set; }
        public HomeController(DiscGolfContext ctx) => data = new GamesPlayedUnitOfWork(ctx);

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
            TempData["Incorrect"] = "";
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(Player player)
        {
            var playerOptions = new QueryOptions<Player>
            {
                OrderBy = d => d.Name
            };
            var players = data.Players.List(playerOptions);
            foreach (Player p in players)
            {
                if (player.Username == p.Username)
                {
                    if (player.Password == p.Password)
                    {
                        List<GamePlayed> playerGames = new List<GamePlayed>();
                        List<Course> allPlayedCourses = new List<Course>();
                        List<int?> coursePar = new List<int?>();
                        var gameOptions = new QueryOptions<GamePlayed>
                        {
                            OrderBy = gp => gp.GamePlayedID,
                            Where = gp => gp.Score != 0
                        };
                        var courseOptions = new QueryOptions<Course>
                        {
                            OrderBy = c => c.CourseID
                        };
                        var games = data.GamesPlayed.List(gameOptions);
                        var courses = data.Courses.List(courseOptions);
                        foreach (GamePlayed game in games)
                        {
                            if (game.PlayerID == p.PlayerID)
                            {
                                playerGames.Add(game);
                                foreach (Course c in courses)
                                {
                                    if (game.CourseID == c.CourseID)
                                    {
                                        if (allPlayedCourses.Contains(c) == false)
                                        {
                                            allPlayedCourses.Add(c);
                                            var holeOptions = new QueryOptions<Hole>
                                            {
                                                Where = h => h.CourseID == c.CourseID
                                            };
                                            var holes = data.Holes.List(holeOptions);
                                            int? par = 0;
                                            foreach (Hole h in holes)
                                            {
                                                par += h.Par;
                                            }
                                            coursePar.Add(par);
                                        }
                                    }
                                }
                            }
                        }
                        TempData["Games"] = playerGames;
                        TempData["Courses"] = allPlayedCourses;
                        TempData["Pars"] = coursePar;
                        TempData["Player"] = p;
                        return View("../Player/Index");
                    }
                }
                
            }
            TempData["Incorrect"] = "Incorrect Login";
            return View("Login");
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
                    data.Players.Insert(player);
                    data.Players.Save();
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
