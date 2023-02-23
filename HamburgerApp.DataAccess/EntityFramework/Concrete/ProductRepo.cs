using HamburgerApp.DataAccess.Abstract;
using HamburgerApp.DataAccess.EntityFramework.Context;
using HamburgerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.DataAccess.EntityFramework.Concrete
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(HamburgerAppDbContext hastaneDbContext) : base(hastaneDbContext)
        {
        }
    }
}
