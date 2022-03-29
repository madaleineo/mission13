using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission13.Models;

namespace mission13.Controllers
{
    public class HomeController : Controller
    {

        private BowlersDbContext repo { get; set; }


        public HomeController(BowlersDbContext temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            var blah = repo.Bowlers
                .Include("Team")
                //.FromSqlRaw("SELECT * FROM Bowlers WHERE BowlerFirstName LIKE 'A%'")
                .ToList(); //built data set and sent it to a list

            return View(blah);
        }

    }
}
