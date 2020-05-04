using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain.Champ
{
    public class TeamGame
    {
        public int Id { get; set; }

        public string Score { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
