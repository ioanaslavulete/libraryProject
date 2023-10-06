using System;
using System.Collections.Generic;
using System.Text;
using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { 
            this.EnsureSeedData();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Library");
        }

    }
}
