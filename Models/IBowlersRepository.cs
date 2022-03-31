using System;
using System.Linq;

namespace mission13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }


        void EditBowler(Bowler b);

        void DeleteBowler(Bowler b);

        void CreateBowler(Bowler b);

        void SaveBowler(Bowler b);

    }
}

