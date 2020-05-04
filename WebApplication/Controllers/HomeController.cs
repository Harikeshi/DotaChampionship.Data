using DotaChampionship.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        DotaChampionshipDbContext _context = new DotaChampionshipDbContext();
        SimpleRepository repo = SimpleRepository.SharedRepository;



        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            repo.AddProduct(p);
            return RedirectToAction("Index");

        }

        public ViewResult Index()
        {

            //List<string> results = new List<string>();

            //foreach (var item in Product.GetProducts())
            //{
            //    string name = item?.Name??"<No Name>";
            //    decimal? price = item?.Price??0;
            //    string relatedName = item?.Related?.Name??"<None>";

            //    results.Add(string.Format("Name:{0}, Price:{1}, Related{2}", name, price,relatedName));
            //}

            return View(repo.Products.Where(p => p?.Price > 0));
        }
        public ViewResult GetPlayers()
        {

            List<string> players = new List<string>();

            foreach (var item in _context.Players)
            {
                players.Add(item.NickName);
            }
            return View(players);
        }
    }
}
