using System;
using Microsoft.EntityFrameworkCore;

namespace mission13.Models
{
    public class BowlersDbContext : DbContext
    {
        public BowlersDbContext(DbContextOptions<BowlersDbContext> options) : base (options)
        {

        }


        public DbSet<Bowler> Bowlers { get; set; } // when recipe is bundled together in a set we make it plural

        public DbSet<Team> Teams { get; set; }

    }

}
