using DotaChampionship.Data;
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
    public class HomeController : Controller
    {
        private SimpleRepository repository;

        public HomeController()
        {
            repository = new SimpleRepository();
        }


        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {

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
            return View(repository.Teams);

        }     
    }
}
