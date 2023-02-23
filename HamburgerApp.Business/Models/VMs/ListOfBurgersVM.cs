using HamburgerApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Models.VMs
{
    public class ListOfBurgersVM
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Size? Size { get; set; }
        public string? ImagePath { get; set; }
       
    }
}
