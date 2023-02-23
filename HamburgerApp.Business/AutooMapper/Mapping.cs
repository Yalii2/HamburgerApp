using AutoMapper;
using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using HamburgerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.AutooMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product,AddBurgerMenuDTO>().ReverseMap();
            CreateMap<Product,AddExtraMaterialDTO>().ReverseMap();
            CreateMap<Product,ListOfBurgersVM>().ReverseMap();
            CreateMap<Product,ListOfExtraMaterialVM>().ReverseMap();
            CreateMap<AddExtraMaterialDTO,ListOfExtraMaterialVM>().ReverseMap();
            CreateMap<Order,AddOrderDTO>().ReverseMap();
            CreateMap<Order,ListOfOrderVM>().ReverseMap();
            CreateMap<AddOrderDTO,ListOfOrderVM>().ReverseMap();
        }
    }
}
