using System;
using System.Linq;

namespace mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;


        public void EditBowler(Bowler b)
        {
            _context.Update(b);
        }

        public void SaveBowler(Bowler b)
        {
            _context.SaveChanges();
        }

        public void CreateBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }



    }
}
