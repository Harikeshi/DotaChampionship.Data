using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.ViewModels;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class TeamsController : Controller
    {
        IRepository<Team> _teams;
        IRepository<Player> _players;
        IRepository<Game> _games;
        IRepository<TeamGame> _teamGame;


        public TeamsController(IRepository<Team> teams, IRepository<Player> players
            , IRepository<Game> game, IRepository<TeamGame> teamGame)
        {
            _games = game;
            _teamGame = teamGame;
            _teams = teams;
            _players = players;
        }

        public List<TeamWin> GetTeamWins(List<Team> teams)
        {
            List<TeamWin> tw = new List<TeamWin>();


            int count = 0;
            int temp = 0;
            foreach (var item in teams)
            {

                TeamWin team = new TeamWin();
                team.Teams = item;
                var games = _teamGame.GetAll().Where(t => t.TeamId == item.Id).ToList();
                for (int i = 0; i < games.Count; i++)
                {
                    var team1 = _teamGame.GetAll().Where((t => t.GameId == games[i].GameId && t.TeamId == item.Id)).FirstOrDefault();

                    var team2 = _teamGame.GetAll().Where((t => t.GameId == games[i].GameId && t.TeamId != item.Id)).FirstOrDefault();
                    if (Convert.ToInt32(team1.Score) > Convert.ToInt32(team2.Score))
                    {
                        count++;
                    }
                    if (Convert.ToInt32(team1.Score) == Convert.ToInt32(team2.Score))
                    {
                        temp++;
                    }
                }
                team.None = temp;
                team.Score = count;
                count = 0;
                temp = 0;
                tw.Add(team);
            }
            return tw;
        }


        public ViewResult GetTeams(int id)
        {
            List<TeamWin> tw = new List<TeamWin>();


            //вывод команд
            if (id == 10)
            {
                ViewBag.Country = "Китая";
                //выбрать команду и по ней посчитать все победы
                List<Team> teams = _teams.GetAll().Where(t => t.CountryId == 10).ToList();

                tw = GetTeamWins(teams);

            }
            if (id == 29)
            {
                ViewBag.Country = "Европы";

                List<Team> teams = _teams.GetAll().Where(t => t.CountryId == 29).ToList();
                tw = GetTeamWins(teams);

            }
            if (id == 3)
            {
                ViewBag.Country = "США";

                List<Team> teams = _teams.GetAll().Where(t => t.CountryId == 3).ToList();

                tw = GetTeamWins(teams);

            }
            if (id == 17)
            {
                ViewBag.Country = "России";
                List<Team> teams = _teams.GetAll().Where(t => t.CountryId == 17).ToList();

                tw = GetTeamWins(teams);

            }

            return View(tw);
        }

        public ViewResult GetTeam(int id)
        {
            TeamPlayers tp = new TeamPlayers();
            Team t = _teams.Get(id);
            List<Player> ps = _players.GetAll().Where(p => p.TeamId == id).ToList();

            tp.Players = ps;
            tp.Team = t;
            return View(tp);
        }


    }
}
