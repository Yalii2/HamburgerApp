using HamburgerApp.Core.DataAccess.Abstract;
using HamburgerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.DataAccess.Abstract
{
    public interface IProductRepo: IBaseRepo<Product>
    {
    }
}
