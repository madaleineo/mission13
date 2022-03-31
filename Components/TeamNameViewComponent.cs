using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mission13.Models;

namespace mission13.Components
{
    public class TeamNameViewComponent : ViewComponent
    {

        private IBowlersRepository repo { get; set; }


        public TeamNameViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeamName = RouteData?.Values["teamName"];

            var teamName = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teamName);
        }
    }
}
