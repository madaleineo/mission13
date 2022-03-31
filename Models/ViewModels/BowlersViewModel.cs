using System;
using System.Linq;
namespace mission13.Models.ViewModels
{
    public class BowlersViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
        public IQueryable<Team> Teams { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
