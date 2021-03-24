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
        public IActionResult HoleList()
        {
            var holeOptions = new QueryOptions<Hole>
            {
                Includes = "Course",
                OrderBy = d => d.Course.CourseName
            };
            return View(data.Holes.List(holeOptions));
        }
        public IActionResult GamePlayedList()
        {
            var gameOptions = new QueryOptions<GamePlayed>
            {
                Includes = "Player, Course",
                OrderBy = d => d.GamePlayedID
            };
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
    }
}
