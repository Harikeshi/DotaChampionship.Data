using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Data
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = DESKTOP-DGJ2KKT; Database = IdentityDataBase; Trusted_Connection = True; "
                );
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
