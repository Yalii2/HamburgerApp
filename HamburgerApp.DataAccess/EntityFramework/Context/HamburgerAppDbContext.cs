using HamburgerApp.DataAccess.EntityFramework.Mapping;
using HamburgerApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.DataAccess.EntityFramework.Context
{
    public class HamburgerAppDbContext :DbContext
    {
        public HamburgerAppDbContext(DbContextOptions<HamburgerAppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping())
                .ApplyConfiguration(new OrderMapping());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
