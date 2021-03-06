﻿using DotaChampionship.Domain.Entities.Champ;
using DotaChampionship.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain.Entities.Champ
{
    public class Game
    {

        public Game()
        {
            Commentators = new List<Commentator>();
            TeamGames = new List<TeamGame>();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public string Score1 { get; set; }
        public string Score2 { get; set; }

        public GameType GameType { get; set; }

        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        


        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public ICollection<TeamGame> TeamGames { get; set; }
        public ICollection<Commentator> Commentators { get; set; }

    }
}
