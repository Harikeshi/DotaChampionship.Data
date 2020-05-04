using DotaChampionship.Domain.Champ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
            //TeamGames = new List<TeamGame>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public string Url { get; set; }

        //public ICollection<TeamGame> TeamGames { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}
