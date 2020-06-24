using DotaChampionship.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
    public class TeamWin
    {
        public Team Teams { get; set; }
        public int Score { get; set; }
        public int None { get; set; }
    }
}
