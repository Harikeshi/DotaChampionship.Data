using DotaChampionship.Data;
using DotaChampionship.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public class TeamsRepository : IRepository<Team>
    {
        private DotaChampionshipDbContext context;

        public TeamsRepository()
        {
            context = new DotaChampionshipDbContext();
        }

        public void Create(Team item)
        {
            throw new NotImplementedException();
        }

        public Team Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Team Get(int id)
        {
            return context.Teams.FirstOrDefault(t=>t.Id==id);
        }

        public IEnumerable<Team> GetAll(int id)
        {
            return context.Teams.Where(t=>t.Country.Id==id).ToList();
        }

        public IEnumerable<Team> GetAll()
        {
            return context.Teams;
        }

        public void Save(Team item)
        {
            throw new NotImplementedException();
        }

        public void Update(Team item)
        {
            throw new NotImplementedException();
        }
    }
}
