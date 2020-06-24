using DotaChampionship.Data;
using DotaChampionship.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public class PlayersRepository : IRepository<Player>
    {

        DotaChampionshipDbContext context;

        public PlayersRepository()
        {
            context = new DotaChampionshipDbContext();
        }

        public void Create(Player item)
        {
            throw new NotImplementedException();
        }
      
        public Player Get(int id) => context.Players.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Player> GetAll() => context.Players;

        public void Update(Player item)
        {
            throw new NotImplementedException();
        }

        public void Save(Player player)
        {
            if (player.Id == 0)
            {
                context.Players.Add(player);
            }
            else
            {
                Player dbEntry = context.Players
                    .FirstOrDefault(p => p.Id == player.Id);
                if (dbEntry != null)
                {
                    dbEntry.NickName = player.NickName;
                    dbEntry.Description = player.Description;
                    dbEntry.CountryId = player.CountryId;
                    dbEntry.TeamId = player.TeamId;
                    dbEntry.Role= player.Role;
                    dbEntry.PersonalInformation= player.PersonalInformation;


                }
            }
            context.SaveChanges();
        }

        public Player Delete(int Id)
        {
            Player dbEntry = context.Players
                .FirstOrDefault(p => p.Id== Id);
            if (dbEntry != null)
            {
                context.Players.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
