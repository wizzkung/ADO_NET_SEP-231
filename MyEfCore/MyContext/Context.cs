using Microsoft.EntityFrameworkCore;
using MyEfCore.Model;
using MyEfCore.Model.HomeWork_School;
using MyEfCore.Model.ManyToMany;
using MyEfCore.Model.OneToOne;
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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salary { get; set; }

        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Program.config["db"]);
            optionsBuilder.UseSqlServer("Server=LERA;Database=EFdb;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.order_id, od.product_id }); // Составной ключ

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order) // Связь с таблицей Order
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.order_id);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Product) // Связь с таблицей Product
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.product_id);
        }

    }
}
