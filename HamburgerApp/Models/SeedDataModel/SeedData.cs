using HamburgerApp.Core.Enums;
using HamburgerApp.DataAccess.EntityFramework.Context;
using HamburgerApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HamburgerApp.Models.SeedDataModel
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HamburgerAppDbContext>();
            dbContext.Database.Migrate();
            if (dbContext.Products.Count() == 0)
            {
                dbContext.Products.Add(new Product()
                { ProductName = "CheeseBurger(140 gr)", Price = 81, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Menu });
                dbContext.Products.Add(new Product()
                { ProductName = "Konya Küflüsü (140gr)", Price = 87, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Menu });
                dbContext.Products.Add(new Product()
                { ProductName = "Aioli Burger (140 gr)", Price = 87, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Menu });
                dbContext.Products.Add(new Product()
                { ProductName = "Mush Burger (140gr)", Price = 89, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Menu });
                dbContext.Products.Add(new Product()
                { ProductName = "Vişne Tulum (140gr)", Price = 89, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Menu });
                dbContext.Products.Add(new Product()
                { ProductName = "Ranch Sos", Price = 5, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Extra });
                dbContext.Products.Add(new Product()
                { ProductName = "Hardal Sos", Price = 3, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Extra });
                dbContext.Products.Add(new Product()
                { ProductName = "Barbekü Sos", Price = 5, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Extra });
                dbContext.Products.Add(new Product()
                { ProductName = "Acı Sos", Price = 3, Status = Status.Active, CreatedTime = DateTime.Now, Roles = Roles.Extra });
            }
            dbContext.SaveChanges();
        }
    }
}
