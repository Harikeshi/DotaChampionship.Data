using DotaChampionship.Data;
using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using System.Collections.Generic;

namespace WebApplication.Repositories
{
    public class SimpleRepository
    {

        private DotaChampionshipDbContext context;

        public SimpleRepository()
        {
            context = new DotaChampionshipDbContext();
        }

        public IEnumerable<Player> Players => context.Players;
        public IEnumerable<Game> Games => context.Games;
        public IEnumerable<Team> Teams => context.Teams;
        public IEnumerable<Country> Countries => context.Countries;
    }
}
