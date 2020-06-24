using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IRepository<Player> Players;
        IRepository<Game> Games;
        IRepository<TeamGame> TeamGames;
        IRepository<Team> Teams;

        public AdminController(IRepository<Player> players,
            IRepository<Game> games, IRepository<TeamGame> teamGames, IRepository<Team> teams)
        {
            Teams = teams;
            Games = games;
            TeamGames = teamGames;
            Players = players;
        }

        public IActionResult Index()
        {
            List<GameViewModel> gvm = new List<GameViewModel>();
            foreach (var game in Games.GetAll())
            {
                List<TeamGame> tg = TeamGames.GetAll().Where(g => g.GameId == game.Id).ToList();

                Team t1 = Teams.Get(tg[0].TeamId);
                Team t2 = Teams.Get(tg[1].TeamId);

                gvm.Add(new GameViewModel
                {
                    GameId = game.Id,
                    Team1 = t1,
                    Team2 = t2,
                    Score1 = tg[0].Score,
                    Score2 = tg[1].Score,
                    Start = game.BeginTime,
                    End = game.EndTime,
                    Type = game.GameType
                });

            }

            return View(gvm);
        }

        public IActionResult EditGame(int GameId)
        {

            Game game = Games.Get(GameId);
            List<TeamGame> tg = TeamGames.GetAll().Where(g => g.GameId == GameId).ToList();


            Team t1 = Teams.Get(tg[0].TeamId);
            Team t2 = Teams.Get(tg[1].TeamId);

            //id viewmodel
            GameViewModel gvm = new GameViewModel
            {
                GameId = game.Id,
                Team1 = t1,
                Team2 = t2,
                Score1 = tg[0].Score,
                Score2 = tg[1].Score,
                Start = game.BeginTime,
                End = game.EndTime,
                Type = game.GameType
            };

            return View(gvm);
        }
        [HttpPost]
        public IActionResult EditGame(GameViewModel gameViewModel)
        {
            if (ModelState.IsValid)
            {
                Games.Save(new Game
                {
                    TeamGames = new List<TeamGame>
                    {
                        new TeamGame
                        {
                            Team=gameViewModel.Team1,
                            Score=gameViewModel.Score1
                        },
                        new TeamGame
                        {
                            Team=gameViewModel.Team2,
                            Score=gameViewModel.Score2
                        }
                    },
                    Score1 = gameViewModel.Score1,
                    Score2 = gameViewModel.Score2,
                    BeginTime = gameViewModel.Start,
                    EndTime = gameViewModel.End,
                    GameType = gameViewModel.Type,
                    Title = gameViewModel.Team1.Name + " VS " + gameViewModel.Team2.Name
                });
                TempData["message"] = $"{Games.Get(gameViewModel.GameId).Title} сохранена!";
                return RedirectToAction("Index");
            }
            return View(gameViewModel);
        }




        //[HttpPost]
        public ViewResult CreateGame()
        {
            return View("EditGame", new GameViewModel());//???
        }

        [HttpPost]
        public IActionResult DeleteGame(int id)
        {
            Game deleted = Games.Delete(id);
            if (deleted != null)
            {
                TempData["message"] = $"{deleted.Title} удалена!";
            }
            return RedirectToAction("Index");
        }

    }
}
