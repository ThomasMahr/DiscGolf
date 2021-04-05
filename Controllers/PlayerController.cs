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
        [HttpPost]
        public IActionResult GameSetup(GameSetupViewModel model)
        {
            GamePlayed game = new GamePlayed();
            game.StartedByPlayerID = model.StartingPlayerID;
            game.CourseID = model.SelectedCourseID;
            game.GameFinished = false;
            game.PlayerID = model.StartingPlayerID;
            data.GamesPlayed.Insert(game);
            data.GamesPlayed.Save();

            var gameOptions = new QueryOptions<GamePlayed>
            { 
                Includes = "Player",
                Where = gp => gp.GameFinished == false && gp.StartedByPlayerID == model.StartingPlayerID
            };
            List<GamePlayed> openGames = new List<GamePlayed>(data.GamesPlayed.List(gameOptions));
            ViewBag.Holes = data.Holes.List(new QueryOptions<Hole> { Where = h => h.CourseID == model.SelectedCourseID });
            ViewBag.Course = data.Courses.Get(model.SelectedCourseID);
            ViewBag.StartingPlayer = data.Players.Get(model.StartingPlayerID);
            ViewBag.Players = data.Players.List(new QueryOptions<Player> { });
            return View("InGame", openGames);
        }
        [HttpGet]
        public IActionResult AddPlayer(int id)
        {
            Player loggedInPlayer = data.Players.Get(id);
            ViewBag.LoggedInPlayer = loggedInPlayer;
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course> { OrderBy = c => c.CourseName });
            ViewBag.Players = data.Players.List(new QueryOptions<Player> { OrderBy = p => p.Name, Where = p => p.PlayerID != loggedInPlayer.PlayerID && p.PlayerID != 1 });
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
        public IActionResult EndGame(int id)
        {
            GamePlayed g = new GamePlayed();
            Player p = data.Players.Get(id);
            var gOptions = new QueryOptions<GamePlayed>
            {
                Where = gp => gp.GameFinished == false && gp.StartedByPlayerID == id && gp.Score != 0
            };
            var finishedGames = data.GamesPlayed.List(gOptions);
            foreach(GamePlayed game in finishedGames)
            {
                game.GameFinished = true;
                data.GamesPlayed.Update(game);
                g = game;
            }
            data.GamesPlayed.Save();
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
        public IActionResult UpdateScore(int id)
        {
            GamePlayed game = data.GamesPlayed.Get(id);
            ViewBag.Course = data.Courses.Get(game.CourseID);
            ViewBag.Player = data.Players.Get(game.PlayerID);
            return View(game);
        }
        [HttpPost]
        public IActionResult UpdateScore(GamePlayed game)
        {
            data.GamesPlayed.Update(game);
            data.GamesPlayed.Save();

            var gameOptions = new QueryOptions<GamePlayed>
            {
                Includes = "Player",
                Where = gp => gp.GameFinished == false && gp.StartedByPlayerID == game.StartedByPlayerID
            };
            List<GamePlayed> openGames = new List<GamePlayed>(data.GamesPlayed.List(gameOptions));
            ViewBag.Holes = data.Holes.List(new QueryOptions<Hole> { Where = h => h.CourseID == game.CourseID });
            ViewBag.Course = data.Courses.Get(game.CourseID);
            ViewBag.StartingPlayer = data.Players.Get(game.StartedByPlayerID);
            ViewBag.Players = data.Players.List(new QueryOptions<Player> { });
            return View("InGame", openGames);
        }
    }
}
