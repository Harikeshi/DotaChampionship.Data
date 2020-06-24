using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using DotaChampionship.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public string Score1 { get; set; }
        public string Score2 { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public GameType Type { get; set; }

    }
}
