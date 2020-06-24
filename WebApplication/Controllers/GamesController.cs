using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using DotaChampionship.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class GamesController : Controller
    {
        private IRepository<Game> _games;
        private IRepository<TeamGame> _teamGames;
        private IRepository<Team> _teams;

        public GamesController(IRepository<Game> games,
            IRepository<TeamGame> teamGames, IRepository<Team> teams)
        {
            _games = games; _teamGames = teamGames; _teams = teams;
        }

        public IActionResult GetGame(int id)
        {
            var game = _games.Get(id);
            var games = _teamGames.GetAll().Where(g => g.GameId == id).ToList();
            var team1 = _teams.Get(games[0].TeamId);
            var team2 = _teams.Get(games[1].TeamId);



            GameViewModel gv = new GameViewModel
            {
                GameId = game.Id,
                Start = game.BeginTime,
                Team1 = team1,
                Team2 = team2,
                Score1 = games[0].Score,
                Score2 = games[1].Score
            };
            return View(gv);
        }


        public IActionResult GetGroupGames(int id)
        {


            var type = (GameType)id;

            ViewBag.Type = GetGameType(type).ToString();

            var games = _games.GetAll()
                .Where(g => g.GameType == type).ToList();

            List<GameViewModel> gv = new List<GameViewModel>();

            for (int i = 0; i < games.Count; i++)
            {
                GameViewModel gg = new GameViewModel();
                gg.GameId = games[i].Id;
                gg.Start = games[i].BeginTime;
                gg.End = games[i].EndTime;

                var temp = _teamGames.GetAll().Where(t =>
                t.GameId == games[i].Id).ToList();
                if (temp != null)
                {
                    gg.Team1 = _teams.Get(temp[0].TeamId);
                    gg.Score1 = temp[0].Score;
                    gg.Team2 = _teams.Get(temp[1].TeamId);
                    gg.Score2 = temp[1].Score;
                }
                gv.Add(gg);
            }
            return View(gv);
        }

        public IActionResult GetTeamGames(int id)
        {
            var tgs = _teamGames.GetAll();
            var tg = tgs.Where(t => t.Id == id).ToList();


            List<GameViewModel> gv = new List<GameViewModel>();

            for (int i = 0; i < tg.Count; i++)
            {
                GameViewModel gg = new GameViewModel();
                int j = tg[i].GameId;
                var game = _games.Get(j);
                gg.GameId = game.Id;
                gg.Start = game.BeginTime;
                gg.End = game.EndTime;

                var temp = tgs.Where(t => t.GameId == j).ToList();

                gg.Team1 = _teams.Get(temp[0].TeamId);
                gg.Score1 = temp[0].Score;

                gg.Team2 = _teams.Get(temp[1].TeamId);
                gg.Score2 = temp[1].Score;

                gv.Add(gg);
            }

            return View(gv);
        }

        public string GetGameType(GameType type)
        {
            string str = string.Empty;
            switch (type)
            {
                case GameType.GroupA:
                    str = "Группа А";
                    break;
                case GameType.GroupB:
                    str = "Группа Б";
                    break;
                case GameType.GroupStage:
                    break;
                case GameType.Stage1:
                    str = "Раунд 1";
                    break;
                case GameType.Stage2:
                    str = "Раунд 2";
                    break;
                case GameType.Stage3:
                    str = "Раунд 3";
                    break;
                case GameType.Stage4:
                    str = "Раунд 4";
                    break;
                case GameType.QuarterFinal:
                    str = "Четвертьфинал";
                    break;
                case GameType.HightSemifinal:
                    str = "Полуфинал";
                    break;
                case GameType.LowSemifinal:
                    str = "Полуфинал нижней сетки";
                    break;
                case GameType.HightFinal:
                    str = "Финал верхней сетки";
                    break;
                case GameType.LowFinal:
                    str = "Финал нижней сетки";
                    break;
                case GameType.SuperFinal:
                    str = "Гранд-финал";
                    break;
                default:
                    break;
            }
            return str;
        }




    }
}
