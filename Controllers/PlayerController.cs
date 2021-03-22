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
        private DiscGolfContext context { get; set; }

        public PlayerController(DiscGolfContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
