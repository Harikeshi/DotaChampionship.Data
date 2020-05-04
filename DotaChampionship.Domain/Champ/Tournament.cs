using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain.Champ
{
    public class Tournament
    {
        public int Id { get; set; }




        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int YearId { get; set; }
        public Year Year { get; set; }

        public int ResultId { get; set; }
        public Result Result { get; set; }


        public ICollection<Game> Games { get; set; }
    }
}
