using BillGeneratorTask.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillGeneratorTask.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategores { get; set; }
        public DbSet<BillGenerator> BillGenerators { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().Property(x => x.Price).HasColumnType("decimal(10,2)")
            .IsRequired(true);

        }
    }
}
