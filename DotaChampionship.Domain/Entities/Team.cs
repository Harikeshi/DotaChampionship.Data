using DotaChampionship.Domain.Entities.Champ;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotaChampionship.Domain
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
            TeamGames = new List<TeamGame>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }


        public int Year { get; set; }

        public string Logo { get; set; }

        public ICollection<TeamGame> TeamGames { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}
