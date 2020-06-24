using DotaChampionship.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class TeamPlayers
    {
        public Team Team{ get; set; }
        public List<Player> Players { get; set; }
    }
}
