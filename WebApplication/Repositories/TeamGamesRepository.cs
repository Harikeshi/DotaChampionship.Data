using DotaChampionship.Data;
using DotaChampionship.Domain.Entities.Champ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public class TeamGamesRepository : IRepository<TeamGame>
    {
        private DotaChampionshipDbContext context;

        public TeamGamesRepository()
        {
            context = new DotaChampionshipDbContext();
        }

        public void Create(TeamGame item)
        {
            throw new NotImplementedException();
        }

        public TeamGame Delete(int id)
        {
            throw new NotImplementedException();
        }


        public TeamGame Get(int id)
        {
            return context.TeamGames.FirstOrDefault(tg => tg.Id == id);
        }

        public IEnumerable<TeamGame> GetAll()
        {
            return context.TeamGames;
        }

        public void Save(TeamGame teamGame)
        {
            throw new NotImplementedException();
        }

        public void Update(TeamGame item)
        {
            throw new NotImplementedException();
        }
    }
}
