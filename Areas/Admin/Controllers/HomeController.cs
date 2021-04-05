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
        private GamesPlayedUnitOfWork data { get; set; }
        public HomeController(DiscGolfContext ctx) => data = new GamesPlayedUnitOfWork(ctx);

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlayerList()
        {
            var playerOptions = new QueryOptions<Player>
            {
                OrderBy = d => d.Name
            };
            return View(data.Players.List(playerOptions));
        }
        public IActionResult CourseList()
        {
            var holeOptions = new QueryOptions<Hole>
            {
                Includes = "Course"
            };
            var courseOptions = new QueryOptions<Course>
            {
                OrderBy = d => d.CourseName
            };
            ViewBag.Holes = data.Holes.List(holeOptions);
            return View(data.Courses.List(courseOptions));
        }
        public IActionResult GamePlayedList()
        {
            var gameOptions = new QueryOptions<GamePlayed>
            {
                Includes = "Player, Course",
                Where = d => d.GameFinished != false,
                OrderBy = d => d.Course.CourseName,
                ThenOrderBy = d => d.Score
            };
            var openGameOptions = new QueryOptions<GamePlayed>
            {
                Includes = "Player, Course",
                Where = d => d.GameFinished != true,
                OrderBy = d => d.Course.CourseName,
                ThenOrderBy = d => d.Score
            };
            var playerOptions = new QueryOptions<Player>{ };
            ViewBag.Players = data.Players.List(playerOptions);
            ViewBag.OpenGames = data.GamesPlayed.List(openGameOptions);
            return View(data.GamesPlayed.List(gameOptions));
        }
        
        [HttpGet]
        public IActionResult DeletePlayer(int id)
        {
            return View(data.Players.Get(id));
        }
        [HttpPost]
        public  RedirectToActionResult DeletePlayer(Player p)
        {
            data.Players.Delete(p);
            data.Players.Save();
            return RedirectToAction("PlayerList");
        }

        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            return View(data.Players.Get(id));
        }
        [HttpPost]
        public RedirectToActionResult EditPlayer(Player p)
        {
            data.Players.Update(p);
            data.Players.Save();
            return RedirectToAction("PlayerList");
        }

        [HttpGet]
        public IActionResult DeleteCourse(int id)
        {
            return View(data.Courses.Get(id));
        }
        [HttpPost]
        public RedirectToActionResult DeleteCourse(Course c)
        {
            data.Courses.Delete(c);
            data.Courses.Save();
            return RedirectToAction("CourseList");
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            data.Courses.Insert(course);
            data.Courses.Save();
            return RedirectToAction("CourseList");
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            ViewBag.Holes = data.Holes.List(new QueryOptions<Hole>
            {
                Includes = "Course",
                Where = h => h.CourseID == id,
                OrderBy = h => h.SequenceNumber
            });
            return View(data.Courses.Get(id));
        }
        [HttpPost]
        public RedirectToActionResult EditCourse(Course c)
        {
            data.Courses.Update(c);
            data.Courses.Save();
            return RedirectToAction("CourseList");
        }

        [HttpGet]
        public IActionResult ViewCourse(int id)
        {
            ViewBag.Holes = data.Holes.List(new QueryOptions<Hole>
            {
                Includes = "Course",
                Where = h => h.CourseID == id,
                OrderBy = h => h.SequenceNumber
            });
            return View(data.Courses.Get(id));
        }

        [HttpGet]
        public IActionResult DeleteHole(int id)
        {
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course>{});
            return View(data.Holes.Get(id));
        }
        [HttpPost]
        public RedirectToActionResult DeleteHole(Hole h)
        {
            data.Holes.Delete(h);
            data.Holes.Save();
            return RedirectToAction("CourseList");
        }

        [HttpGet]
        public IActionResult AddHole()
        {
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course>
            {
                OrderBy = c => c.CourseName
            });
            return View();
        }
        [HttpPost]
        public IActionResult AddHole(Hole hole)
        {
            data.Holes.Insert(hole);
            data.Holes.Save();
            return RedirectToAction("CourseList");
        }

        [HttpGet]
        public IActionResult EditHole(int id)
        {
            ViewBag.Courses = data.Courses.List(new QueryOptions<Course> { });
            return View(data.Holes.Get(id));
        }
        [HttpPost]
        public RedirectToActionResult EditHole(Hole h)
        {
            data.Holes.Update(h);
            data.Holes.Save();
            return RedirectToAction("CourseList");
        }

        [HttpGet]
        public IActionResult DeleteGamePlayed(int id)
        {
            return View(data.GamesPlayed.Get(id));
        }
        [HttpPost]
        public RedirectToActionResult DeleteGamePlayed(GamePlayed gp)
        {
            data.GamesPlayed.Delete(gp);
            data.GamesPlayed.Save();
            return RedirectToAction("GamePlayedList");
        }
    }
}
