using DotaChampionship.Domain.Entities.Champ;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public byte[] Logo { get; set; }

        public Tournament Tournament { get; set; }
        public ICollection<Player> Players { get; set; }


    }
}
