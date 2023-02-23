using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Services.HamburgerMenuService
{
    public interface IHamburgerMenuService
    {
        Task CreateHamburgerMenu(AddBurgerMenuDTO addBurgerMenuDTO);
        Task<List<ListOfBurgersVM>> GetHamburgers();
        //Task<UpdateAdminDTO> GetAdmin(Guid id);
        //Task UpdateAdmin(UpdateAdminDTO updateManagerDTO);
        //Task DeleteAdmin(Guid id);
    }
}
