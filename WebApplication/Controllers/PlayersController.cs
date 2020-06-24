using DotaChampionship.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class PlayersController : Controller
    {

        //Игроки команды для частичного представления

        IRepository<Player> _players;
        IRepository<Personal> _personals;
        IRepository<Country> _countries;
        IRepository<Team> _teams;

        public PlayersController(IRepository<Player> players,
            IRepository<Personal> personals, IRepository<Country> countries,IRepository<Team>teams)
        {
            _teams = teams;
            _players = players;
            _personals = personals;
            _countries = countries;
        }

        public ViewResult GetAllPlayers()
        {
            
            return View(_players.GetAll());
        }

        public ViewResult GetPlayer(int id)
        {
            var player = _players.Get(id);
            var country = _countries.Get(player.CountryId);
            var personal = _personals.Get(id);

            var team = _teams.Get(player.TeamId);

            ViewBag.Team = team.Name.ToString();

            PlayerViewModel model = new PlayerViewModel
            {
                Player = player,
                Personal = personal,
                Country = country

            };

            return View(model);
        }

       


    }
}
