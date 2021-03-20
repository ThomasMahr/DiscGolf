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
        private DiscGolfContext context { get; set; }

        public HomeController(DiscGolfContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlayerList()
        {
            var players = context.Players
                .OrderBy(m => m.Name)
                .ToList();
            return View(players);
        }
        public IActionResult CourseList()
        {
            var courses = context.Courses
                .OrderBy(m => m.CourseName)
                .ToList();
            return View(courses);
        }
        public IActionResult HoleList()
        {
            var holes = context.Holes
                .OrderBy(m => m.CourseID)
                .ToList();
            return View(holes);
        }
        public IActionResult GamePlayedList()
        {
            var games = context.GamesPlayed
                .OrderBy(m => m.PlayerID)
                .ToList();
            return View(games);
        }

        [HttpGet]
        public IActionResult DeletePlayer(int id)
        {
            var player = context.Players.Find(id);
            return View(player);
        }
        [HttpPost]
        public  IActionResult DeletePlayer(Player p)
        {
            context.Players.Remove(p);
            context.SaveChanges();
            return RedirectToAction("PlayerList", "Home");
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            ViewBag.Action = "Add";
            return View(new Course());
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.CourseID == 0)
                    context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("CourseList", "Home");
            }
            else
            {
                return View("CourseList");
            }
        }

        [HttpGet]
        public IActionResult DeleteCourse(int id)
        {
            var course = context.Courses.Find(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult DeleteCourse(Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction("CourseList", "Home");
        }
    }
}
