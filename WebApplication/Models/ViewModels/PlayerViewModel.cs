using DotaChampionship.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PlayerViewModel
    {
        public Player Player { get; set; }
        public Personal Personal { get; set; }
        public Country Country { get; set; }
    }
}
