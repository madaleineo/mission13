using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission13.Models;
using mission13.Models.ViewModels;

namespace mission13.Controllers
{
    public class HomeController : Controller
    {

        private IBowlersRepository repo { get; set; }


        public HomeController(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string teamName, int pageNum = 1)
        {

            int numResults = 20;

            var b = new BowlersViewModel
            {
                Bowlers = repo.Bowlers
                .Include("Team")
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .OrderBy(b => b.BowlerID)
                .Skip((pageNum - 1) * numResults)
                .Take(numResults),

                PageInfo = new PageInfo
                {
                    TotalNumBowlers =
                        (teamName == null
                            ? repo.Bowlers.Count()
                            : repo.Bowlers.Where(x => x.Team.TeamName == teamName).Count()),
                    BowlersPerPage = numResults,
                    CurrentPage = pageNum,
                }
            };

            ViewData["TeamName"] = teamName;

            //var blah = repo.Bowlers
            //    .Include("Team")
            //    .Where(x => x.Team.TeamName == teamName || teamName == null)
            //    //.FromSqlRaw("SELECT * FROM Bowlers WHERE BowlerFirstName LIKE 'A%'")
            //    .ToList(); //built data set and sent it to a list

            return View(b);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = repo.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler bowler)
        {
            ViewBag.Teams = repo.Teams.ToList();

            if (ModelState.IsValid)
            {
                repo.CreateBowler(bowler);
                repo.SaveBowler(bowler);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditBowler(int id)
        {
            ViewBag.Teams = repo.Teams.ToList();

            var editBowler = repo.Bowlers.Single(x => x.BowlerID == id);
            return View("EditBowler", editBowler);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler bowler)
        {
            ViewBag.Teams = repo.Teams.ToList();

            if (ModelState.IsValid)
            {
                repo.EditBowler(bowler);
                repo.SaveBowler(bowler);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteBowler(int id)
        {

            var deleteBowler = repo.Bowlers.Single(x => x.BowlerID == id);
            return View(deleteBowler);
        }

        [HttpPost]
        public IActionResult DeleteBowler(Bowler bowler)
        {

            repo.DeleteBowler(bowler);
            return RedirectToAction("Index");
        }

    }

}