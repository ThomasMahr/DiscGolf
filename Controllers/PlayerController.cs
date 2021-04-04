using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscGolf.Models;

namespace DiscGolf.Controllers
{
    public class PlayerController : Controller
    {
        private GamesPlayedUnitOfWork data { get; set; }
        public PlayerController(DiscGolfContext ctx) => data = new GamesPlayedUnitOfWork(ctx);

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BackToIndex(int id)
        {
            var gamesToDelete = new QueryOptions<GamePlayed>
            {
                Where = gp => gp.GameFinished == false && gp.StartedByPlayerID == id
            };
            var toDelete = data.GamesPlayed.List(gamesToDelete);
            foreach(GamePlayed gp in toDelete)
            {
                data.GamesPlayed.Delete(gp);
            }
            data.GamesPlayed.Save();
            Player p = data.Players.Get(id);
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
            return View("Index");
        }
        [HttpGet]
        public IActionResult GameSetup(int id)
        {
            Player loggedInPlayer = data.Players.Get(id);
            ViewBag.LoggedInPlayer = loggedInPlayer;
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course>{});
            ViewBag.Games = data.GamesPlayed.List(new QueryOptions<GamePlayed>
            {
                Includes = "Player",
                Where = gp => gp.GameFinished == false && gp.StartedByPlayerID == id
            });
            return View();
        }
        [HttpGet]
        public IActionResult AddPlayer(int id)
        {
            Player loggedInPlayer = data.Players.Get(id);
            ViewBag.LoggedInPlayer = loggedInPlayer;
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course> { OrderBy = c => c.CourseName });
            ViewBag.Players = data.Players.List(new QueryOptions<Player> { OrderBy = p => p.Name });
            return View();
        }
        [HttpPost]
        public IActionResult AddPlayer(GamePlayed game)
        {
            game.GameFinished = false;
            data.GamesPlayed.Insert(game);
            data.GamesPlayed.Save();

            Player loggedInPlayer = data.Players.Get(game.StartedByPlayerID);
            ViewBag.LoggedInPlayer = loggedInPlayer;
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course> { });
            ViewBag.Games = data.GamesPlayed.List(new QueryOptions<GamePlayed>
            {
                Includes = "Player",
                Where = gp => gp.GameFinished == false && gp.StartedByPlayerID == game.StartedByPlayerID
            });
            return View("GameSetup");
        }
    }
}
