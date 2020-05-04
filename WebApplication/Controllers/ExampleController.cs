using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ExampleController : Controller
    {

        public async Task<ViewResult> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return View(new string[] { $"Length: {length}" });
        }

        public ViewResult Indext()
        {

            bool FilterByPrice(Product p)
            {
                return (p?.Price ?? 0) >= 20;
            }

            Product[] productArray = {
                new Product {
                    Name= "Kayak",
                    Price = 275M
                },
                new Product {
                    Name= "Lifejacket",
                    Price = 48.95M
                },
                new Product {
                    Name= "Soccer ball",
                    Price =19.50M
                },
                new Product {
                    Name ="Corner flag",
                    Price = 34.95M
                }
            };


            Func<Product, bool> nameFilter = delegate (Product prod)
               {
                   return prod?.Name?[0] == 'S';
               };

            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
            nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();

            priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();


            return View("Index", new string[] {$"Total Price: {priceFilterTotal}",
            $"Name Total: {nameFilterTotal}"});
        }
    }
}
