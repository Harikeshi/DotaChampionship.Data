using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotaChampionship.Data;
using DotaChampionship.Domain;
using DotaChampionship.Domain.Entities.Champ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Models;
using WebApplication.Repositories;
using Microsoft.AspNetCore.Identity;

namespace WebApplication
{
    public class Startup
    {

        public Startup(IConfiguration config) => Configuration = config;

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddTransient<IRepository<Team>, TeamsRepository>();
            services.AddTransient<IRepository<Player>, PlayersRepository>();
            services.AddTransient<IRepository<Game>, GamesRepository>();
            services.AddTransient<IRepository<TeamGame>, TeamGamesRepository>();
            services.AddTransient<IRepository<Personal>, PersonalsRepository>();
            services.AddTransient<IRepository<Country>, CountryRepository>();
            services.AddTransient<SimpleRepository>();


            services.AddTransient<AppIdentityDbContext>();


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=Index}/{id?}");
            });
            //Добавить все данные приложения           

            IdentitySeedData.EnsurePopulated(app);

        }
    }
}
