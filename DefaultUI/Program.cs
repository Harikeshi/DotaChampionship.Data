using DotaChampionship.Data;
using System;
using System.Linq;

namespace DefaultUI
{
    class Program
    {
        private static DotaChampionshipDbContext _context = new DotaChampionshipDbContext();
        static void Main(string[] args)
        {
            GetWins(2);
            GetPlayer(22);
        }

        private static void GetWins(int teamId)
        {

            var games = _context.TeamGames.Where(t => t.TeamId == teamId).ToList();

            for (int i = 0; i < games.Count; i++)
            {
                var team1 = _context.TeamGames.Where((t => t.GameId == games[i].GameId && t.TeamId == teamId)).FirstOrDefault();

                var team2 = _context.TeamGames.Where((t => t.GameId == games[i].GameId && t.TeamId != teamId)).FirstOrDefault();


                if (Convert.ToInt32(team1.Score) > Convert.ToInt32(team2.Score))
                {
                    var game = _context.Games.Where(g => g.Id == games[0].GameId).FirstOrDefault();
                    Console.WriteLine($"{_context.Teams.Where(t => t.Id == team1.TeamId).FirstOrDefault().Name}:{team1.Score} - {team2.Score}:{_context.Teams.Where(t => t.Id == team2.TeamId).FirstOrDefault().Name} ");
                }

            }
        }

        private static void GetPlayer(int id)
        {

            var p = _context.Players.Where(p => p.Id == id).FirstOrDefault();
            Console.WriteLine(p.NickName);
            var pers = _context.Personals.Where(p => p.PlayerId == id).FirstOrDefault();
            Console.WriteLine($"{ pers.FirstName} { pers.LastName}");

        }

        //Добавить игрока




    }
}
