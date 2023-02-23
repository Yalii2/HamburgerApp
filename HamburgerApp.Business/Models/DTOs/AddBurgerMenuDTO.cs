using HamburgerApp.Business.Extension;
using HamburgerApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Models.DTOs
{
    public class AddBurgerMenuDTO
    {
        public Guid Id => Guid.NewGuid();
        [Required(ErrorMessage = "Cannot be Empty")]
        [MaxLength(50,ErrorMessage = "You Cannot Enter More Than 50 Characters")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Cannot be Empty")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public decimal Price { get; set; }
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public int Quantity { get; set; }
        public Roles Roles => Roles.Menu;
        public User User => User.Admin;
        public Status Status => Status.Active;
        public DateTime CreatedTime => DateTime.Now;
        public Size? Size => Core.Enums.Size.Standard;
        public string? ImagePath { get; set; }
        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
    }
}
