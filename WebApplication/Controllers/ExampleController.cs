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

        //public ActionResult Index()
        //{

        //    //// Создание конфигурации сопоставления
        //    //var config = new MapperConfiguration(cfg => cfg.CreateMap<Player, PlayerModel>());
        //    //// Настройка AutoMapper
        //    //var mapper = new Mapper(config);
        //    //// сопоставление
        //    //var users = mapper.Map<List<PlayerModel>>(repo.GetAll());
        //    return View(repo.GetAll());
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(CreateUserViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Настройка конфигурации AutoMapper
        //        var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUserViewModel, User>()
        //            .ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
        //            .ForMember("Email", opt => opt.MapFrom(src => src.Login)));
        //        var mapper = new Mapper(config);
        //        // Выполняем сопоставление
        //        User user = mapper.Map<CreateUserViewModel, User>(model);
        //        repo.Create(user);
        //        repo.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return HttpNotFound();
        //    // Настройка конфигурации AutoMapper
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<User, EditUserViewModel>()
        //            .ForMember("Login", opt => opt.MapFrom(src => src.Email)));
        //    var mapper = new Mapper(config);
        //    // Выполняем сопоставление
        //    EditUserViewModel user = mapper.Map<User, EditUserViewModel>(repo.Get(id.Value));
        //    return View(user);
        //}
        //[HttpPost]
        //public ActionResult Edit(EditUserViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Настройка конфигурации AutoMapper
        //        var config = new MapperConfiguration(cfg => cfg.CreateMap<EditUserViewModel, User>()
        //            .ForMember("Email", opt => opt.MapFrom(src => src.Login)));
        //        var mapper = new Mapper(config);
        //        // Выполняем сопоставление
        //        User user = mapper.Map<EditUserViewModel, User>(model);
        //        repo.Update(user);
        //        repo.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

    }
}
