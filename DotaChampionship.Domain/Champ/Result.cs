using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain.Champ
{
    public class Result
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }

        public decimal FirstPrice { get; set; }
        public decimal SecondPrice { get; set; }
        public decimal ThirdPrice { get; set; }
        
        public Tournament Tournament { get; set; }

    }
}
