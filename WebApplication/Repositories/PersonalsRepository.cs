using DotaChampionship.Data;
using DotaChampionship.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public class PersonalsRepository : IRepository<Personal>
    {
        private DotaChampionshipDbContext context;

        public PersonalsRepository()
        {
            context = new DotaChampionshipDbContext();
        }

        public void Create(Personal item)
        {
            throw new NotImplementedException();
        }

        public Personal Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Personal Get(int id)
        {
            return context.Personals.FirstOrDefault(p => p.PlayerId == id);
        }

        public IEnumerable<Personal> GetAll()
        {
            return context.Personals;
        }

        public void Save(Personal item)
        {
            throw new NotImplementedException();
        }

        public void Update(Personal item)
        {
            throw new NotImplementedException();
        }
    }
}
