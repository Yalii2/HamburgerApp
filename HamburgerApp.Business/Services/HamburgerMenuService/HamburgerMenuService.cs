using AutoMapper;
using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using HamburgerApp.Core.Enums;
using HamburgerApp.DataAccess.Abstract;
using HamburgerApp.Entities.Concrete;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HamburgerApp.Business.Services.HamburgerMenuService
{
    public class HamburgerMenuService : IHamburgerMenuService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        public HamburgerMenuService(IMapper mapper, IProductRepo productRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public async Task CreateHamburgerMenu(AddBurgerMenuDTO addBurgerMenuDTO)
        {
            var addHamburger = _mapper.Map<Product>(addBurgerMenuDTO);

            if (addBurgerMenuDTO.UploadPath != null)
            {
                var stream = addBurgerMenuDTO.UploadPath.OpenReadStream();
                using var image = Image.Load(stream);
                //Dosyayı yolunu okuduk
                image.Mutate(x => x.Resize(600, 560));//Resim boyutu ayarladık
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");

				addHamburger.ImagePath = ($"/images/{guid}.jpg");
                await _productRepo.Add(addHamburger);
            }
            else
            {
                addHamburger.ImagePath = ($"/images/default.jpeg");
                await _productRepo.Add(addHamburger);
            }
        }

        public async Task<List<ListOfBurgersVM>> GetHamburgers()//++
        {
            var menus = await _productRepo.GetFilteredList(
                select: x => new ListOfBurgersVM
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    ImagePath = x.ImagePath,
                },
                where: x => ((x.Status == Status.Active || x.Status == Status.Modified) && x.Roles == Roles.Menu),
                orderBy: x => x.OrderBy(x => x.ProductName));

            return menus;
        }
    }
}
