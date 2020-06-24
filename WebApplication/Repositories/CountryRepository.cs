using DotaChampionship.Data;
using DotaChampionship.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public class CountryRepository : IRepository<Country>
    {

        private DotaChampionshipDbContext _context;

        public CountryRepository()
        {
            _context = new DotaChampionshipDbContext();
        }

        public void Create(Country item)
        {
            throw new NotImplementedException();
        }

        public Country Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Countries;
        }

        public void Save(Country item)
        {
            throw new NotImplementedException();
        }

        public void Update(Country item)
        {
            throw new NotImplementedException();
        }
    }
}
