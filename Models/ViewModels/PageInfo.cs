using System;

namespace mission13.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBowlers { get; set; }

        public int BowlersPerPage { get; set; }

        public int CurrentPage { get; set; }

        //figure out how many pages are needed

        public int TotalPages => (int)Math.Ceiling((double)TotalNumBowlers / BowlersPerPage);
    }
}