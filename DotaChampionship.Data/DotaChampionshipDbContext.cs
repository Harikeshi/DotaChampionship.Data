using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using Microsoft.EntityFrameworkCore;

namespace DotaChampionship.Data
{
    public class DotaChampionshipDbContext : DbContext
    {

        //public DotaChampionshipDbContext(DbContextOptions<DotaChampionshipDbContext> options) : base(options)
        //{

        //}

        public DotaChampionshipDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = DESKTOP-DGJ2KKT; Database = DotaChampionatship; Trusted_Connection = True; "
                );
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<TeamGame> TeamGames { get; set; }
        public DbSet<Commentator> Commentators { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }


        public Game GetGame(int id) => Games.Find(id);


        public void AddPlayer(Player player)
        {
            Players.Add(player);
            SaveChanges();

        }

        public void UpdateGame(Game game)
        {
            Game g = GetGame(game.Id);
            g.BeginTime = game.BeginTime;
            g.EndTime = game.EndTime;
            g.GameType = game.GameType;
            g.Title = game.Title;
            g.Score1 = game.Score1;
            g.Score2 = game.Score2;

            SaveChanges();

        }


        public void DeleteGame(Player player)
        {
            Players.Remove(player);
            SaveChanges();
        }

        public void DeleteGame(Game game)
        {

            SaveChanges();

        }


    }
}
