using Microsoft.EntityFrameworkCore;
using MyEfCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.MyContext
{
    public class Context : DbContext
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<Stars> Stars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Program.config["db"]);
            optionsBuilder.UseSqlServer("Server=LERA;Database=EFdb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
