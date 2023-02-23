using HamburgerApp.Core.Entities.Abstract;
using HamburgerApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Entities.Abstract
{
    public interface IProduct
    {
        Guid Id { get; set; }
        string ProductName { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
        Roles Roles { get; set; }
        User User { get; set; }
        Status Status { get; set; }
        Size? Size { get; set; }
         string? ImagePath { get; set; }
        IFormFile UploadPath { get; set; }
    }
}
