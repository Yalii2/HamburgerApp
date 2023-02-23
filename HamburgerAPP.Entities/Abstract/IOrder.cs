using HamburgerApp.Core.Enums;
using HamburgerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Entities.Abstract
{
    public interface IOrder
    {
        Guid Id { get; set; }
        User User { get; set; }
        decimal TotalPrice { get; set; }
        bool Available { get; set; }
       

    }
}
