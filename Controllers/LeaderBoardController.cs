using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscGolf.Models;

namespace DiscGolf.Controllers
{
    public class LeaderBoardController : Controller
    {
        private GamesPlayedUnitOfWork data { get; set; }
        public LeaderBoardController(DiscGolfContext ctx) => data = new GamesPlayedUnitOfWork(ctx);

        public IActionResult Index()
        {
            var courseOptions = new QueryOptions<Course>
            {
                OrderBy = c => c.CourseName
            };
            var gameOptions = new QueryOptions<GamePlayed>
            {
                Includes = "Player, Course",
                OrderBy = gp => gp.GamePlayedID,
                Where = gp => gp.GameFinished == true
            };

            var games = data.GamesPlayed.List(gameOptions);
            var courses = data.Courses.List(courseOptions);
            List<GamePlayed> finalGames = new List<GamePlayed>();
            List<int?> coursePar = new List<int?>();

            foreach (Course c in courses)
            {
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
                var lowScore = 101;
                List<GamePlayed> bestGames = new List<GamePlayed>();
                foreach (GamePlayed gp in games)
                {
                    if (gp.CourseID == c.CourseID)
                    {
                        if (gp.Score < lowScore)
                        {
                            lowScore = gp.Score;
                            bestGames.Clear();
                            bestGames.Add(gp);
                        }
                        else if(gp.Score == lowScore)
                        {
                            bestGames.Add(gp);
                        }
                    }
                }
                foreach (GamePlayed gp in bestGames)
                    finalGames.Add(gp);
            }

            TempData["Courses"] = courses;
            TempData["Pars"] = coursePar;

            return View(finalGames);
        }
    }
}
