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

        public IActionResult UserList()
        {
            var users = context.Users
                .OrderBy(m => m.Name)
                .ToList();
            return View(users);
        }
        public IActionResult CourseList()
        {
            var courses = context.Courses
                .OrderBy(m => m.CourseName)
                .ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public  IActionResult DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("UserList", "Home");
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
