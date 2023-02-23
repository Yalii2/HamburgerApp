using HamburgerApp.Core.Entities.Abstract;
using HamburgerApp.Core.Enums;
using HamburgerApp.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Entities.Concrete
{
    public class Product : IProduct, IBaseEntity
    {
        public Guid Id { get ; set; }
        public string ProductName { get ; set; }
        public decimal Price { get ; set; }
        public int Quantity { get ; set; }
        public Roles Roles { get ; set; }
        public User User { get ; set; }
        public Status Status { get ; set; }
        public Size? Size { get ; set; }
        public DateTime CreatedTime { get ; set; }
        public DateTime? DeletedTime { get ; set; }
        public DateTime? UpdatedTime { get ; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile UploadPath { get; set; }
        //Bire çok  bağlantı için order ıd verdik 
        public Guid? OrderID { get; set; }
        public Order Order { get; set; }
    }
}
