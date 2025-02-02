using Microsoft.EntityFrameworkCore;
using MyEfCore.Model;
using MyEfCore.Model.HomeWork_School;
using MyEfCore.Model.ManyToMany;
using MyEfCore.Model.OneToOne;
using MyEfCore.Models;
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

        //public DbSet<Student> students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Subject> Subjects { get; set; }

        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Salary> Salary { get; set; }

        //public DbSet<Products> Products { get; set; }
        //public DbSet<Orders> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }

        //public virtual DbSet<Book> Book { get; set; } = null!;
        //public virtual DbSet<BookCategory> BookCategory { get; set; } = null!;
        //public virtual DbSet<Category> Category { get; set; } = null!;

        //public DbSet<Parent> Parent { get; set; }
        //public DbSet<Child> Child { get; set; }
        public DbSet<BMW> BMW { get; set; } 
        public DbSet<BmwModels> BmwModels { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Program.config["db"]);
            optionsBuilder.UseLazyLoadingProxies();// работает только при условии что навигационные поля виртуальные
            optionsBuilder.UseSqlServer("Server=LERA;Database=ado;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderDetails>()
        //        .HasKey(od => new { od.order_id, od.product_id }); // Составной ключ

        //    modelBuilder.Entity<OrderDetails>()
        //        .HasOne(od => od.Order) // Связь с таблицей Order
        //        .WithMany(o => o.OrderDetails)
        //        .HasForeignKey(od => od.order_id);

        //    modelBuilder.Entity<OrderDetails>()
        //        .HasOne(od => od.Product) // Связь с таблицей Product
        //        .WithMany(p => p.OrderDetails)
        //        .HasForeignKey(od => od.product_id);
        //}

    }
}


/*
dotnet ef dbcontext scaffold "Server=LERA;Database=ado;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -o Models -t Book -t Category -t BookCategory
 Scaffold-DbContext "Server=LERA;Database=ado;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -Tables Book, Category, BookCategory -OutputDir Models 

 */