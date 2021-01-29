﻿
using Microsoft.EntityFrameworkCore;
using MyTask.DataAccess.Models.Models;

namespace MyTask.DataAccess.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-06HJETK\\SQLEXPRESS;Database=productsdb;Trusted_Connection=True;");
        //}

        //public DbSet<Product> Cars { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
