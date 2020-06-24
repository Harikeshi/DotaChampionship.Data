using DotaChampionship.Data;
using DotaChampionship.Domain.Entities.Champ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Repositories
{
    public class GamesRepository : IRepository<Game>
    {
        DotaChampionshipDbContext context;

        public GamesRepository()
        {
            context = new DotaChampionshipDbContext();
        }

        public IEnumerable<Game> GetAll()
        {
            return context.Games;        
        }

        public Game Get(int id) => context.Games.FirstOrDefault(g => g.Id == id);


        public void Create(Game item)
        {
            throw new NotImplementedException();
        }

        public void Update(Game item)
        {
            throw new NotImplementedException();
        }

        public Game Delete(int id)
        {
            Game game = context.Games
                .FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                context.TeamGames.RemoveRange(context.TeamGames.Where(t => t.GameId == id));
                context.Games.Remove(game);
                context.SaveChanges();
            }
            return game;
        }

        public void Save(Game game)
        {
            if (game.Id== 0)
            {
                context.Games.Add(game);
            }
            else
            {
                Game g= context.Games
                    .FirstOrDefault(g => g.Id== game.Id);
                if (g != null)
                {
                    g.Score1 = game.Score1;
                    g.Score2 = game.Score2;
                    g.TeamGames = game.TeamGames;
                    g.BeginTime = game.BeginTime;
                    g.EndTime = game.EndTime;
                    g.GameType = game.GameType;
                    g.Title = game.Title;
                }
            }
            context.SaveChanges();
        }
    }
}
