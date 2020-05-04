using DotaChampionship.Domain.Champ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain
{
    public class Country
    {
        public Country()
        {
            Players = new List<Player>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        public Tournament Tournament { get; set; }
        public ICollection<Player> Players { get; set; }


    }
}
