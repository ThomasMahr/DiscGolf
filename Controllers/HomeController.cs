﻿using System;
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
            ViewBag.Action = "Login";
            return View("Login", new Player());
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
                        List<Course> allCourses = new List<Course>();
                        var gameOptions = new QueryOptions<GamePlayed>
                        {
                            OrderBy = gp => gp.GamePlayedID
                        };
                        var courseOptions = new QueryOptions<Course>
                        {
                            OrderBy = c => c.CourseID
                        };
                        var games = data.GamesPlayed.List(gameOptions);
                        var courses = data.Courses.List(courseOptions);
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
                        TempData["Games"] = playerGames;
                        TempData["Courses"] = allCourses;
                        TempData["Player"] = p;
                        return View("../Player/Index");
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
