using DotaChampionship.Domain;
using DotaChampionship.Domain.Champ;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Data
{
    public class DotaChampionshipDbContext : DbContext
    {

        //public DotaChampionshipDbContext(DbContextOptions<DotaChampionshipDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = DESKTOP-DGJ2KKT; Database = DotaChampionatship; Trusted_Connection = True; "
                );
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Commentator> Commentators { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TeamGame> TeamGames { get; set; }


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
            g.TeamGames = game.TeamGames;
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

            TeamGames.RemoveRange(TeamGames.Where(tg => tg.GameId == game.Id));
            SaveChanges();


        }


    }
}
