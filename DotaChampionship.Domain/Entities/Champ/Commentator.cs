using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain.Entities.Champ
{
    public class Commentator
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }


    }
}
