using Microsoft.EntityFrameworkCore;
using MyEfCore.Model;
using MyEfCore.Model.HomeWork_School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.MyContext
{
    public class Context : DbContext
    {
        //public DbSet<Country> Country { get; set; }
        //public DbSet<Stars> Stars { get; set; }
        //public DbSet<City> City { get; set; }
        //public DbSet<IdentityCard> IdentityCard { get; set; }
        //public DbSet<Person> Person { get; set; }

        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Program.config["db"]);
            optionsBuilder.UseSqlServer("Server=LERA;Database=EFdb;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }
}
