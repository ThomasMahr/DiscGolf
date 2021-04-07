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
                        List<GamePlayed> playerOpenGames = new List<GamePlayed>();
                        List<Course> allPlayedCourses = new List<Course>();
                        List<Course> allPlayerOpenCourses = new List<Course>();
                        List<int?> coursePar = new List<int?>();
                        List<int?> openCoursePar = new List<int?>();
                        var gameOptions = new QueryOptions<GamePlayed>
                        {
                            OrderBy = gp => gp.Score,
                            Where = gp => gp.GameFinished == true
                        };
                        var courseOptions = new QueryOptions<Course>
                        {
                            OrderBy = c => c.CourseName
                        };
                        var openCourseOptions = new QueryOptions<Course>
                        {
                            OrderBy = c => c.CourseName
                        };
                        var openGameOptions = new QueryOptions<GamePlayed>
                        {
                            Where = gp => gp.GameFinished == false,
                            OrderBy = gp => gp.GamePlayedID
                        };
                        var games = data.GamesPlayed.List(gameOptions);
                        var openGames = data.GamesPlayed.List(openGameOptions);
                        var courses = data.Courses.List(courseOptions);
                        var openCourses = data.Courses.List(openCourseOptions);
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
                        foreach(GamePlayed openGame in openGames)
                        {
                            if(openGame.PlayerID == p.PlayerID)
                            {
                                playerOpenGames.Add(openGame);
                            }
                            foreach(Course course in openCourses)
                            {
                                if(course.CourseID == openGame.CourseID)
                                {
                                    if(allPlayerOpenCourses.Contains(course) == false)
                                    {
                                        allPlayerOpenCourses.Add(course);
                                        var holeOptions = new QueryOptions<Hole>
                                        {
                                            Where = h => h.CourseID == course.CourseID
                                        };
                                        var holes = data.Holes.List(holeOptions);
                                        int? par = 0;
                                        foreach (Hole h in holes)
                                        {
                                            par += h.Par;
                                        }
                                        openCoursePar.Add(par);
                                    }
                                }
                            }
                        }
                        TempData["OpenGames"] = playerOpenGames;
                        TempData["Games"] = playerGames;
                        TempData["Courses"] = allPlayedCourses;
                        TempData["Pars"] = coursePar;
                        TempData["Player"] = p;
                        TempData["OpenCourses"] = allPlayerOpenCourses;
                        TempData["OpenCoursePar"] = openCoursePar;
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
