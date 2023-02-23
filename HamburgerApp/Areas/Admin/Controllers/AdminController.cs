using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using HamburgerApp.Business.Services.ExtraMaterialService;
using HamburgerApp.Business.Services.HamburgerMenuService;
using HamburgerApp.Core.Enums;
using HamburgerApp.DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace HamburgerApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminController : Controller
	{
		private readonly IHamburgerMenuService _hamburgerMenuService;//SİNGLETON ÖRNEĞİ 
		private readonly IExtraMaterialService _extraMaterialService;//SİNGLETON ÖRNEĞİ 
		private readonly HamburgerAppDbContext db;
		public AdminController(IHamburgerMenuService hamburgerMenuService, HamburgerAppDbContext hamburgerAppDbContext, IExtraMaterialService extraMaterialService)
		{
			_extraMaterialService = extraMaterialService;
			_hamburgerMenuService = hamburgerMenuService;
			db = hamburgerAppDbContext;
		}
		[HttpGet]
		public async Task<IActionResult> AddHamburgerMenu()
		{
			ViewBag.Menu = db.Products.Where(p => p.Roles == Roles.Menu).ToList();
			ViewBag.Extra = db.Products.Where(p => p.Roles == Roles.Extra).ToList();
			//ViewBag.Menu = _hamburgerMenuService.GetHamburgers(); 
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddHamburgerMenu(AddBurgerMenuDTO addBurgerMenuDTO)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:7230/");
				var responseTask = client.PostAsJsonAsync<AddBurgerMenuDTO>("Admin/Admin/GetHamburgerMenu", addBurgerMenuDTO);
				responseTask.Wait();
				var resultTask = responseTask.Result;
				if (responseTask.IsCompletedSuccessfully)
				{
					await _hamburgerMenuService.CreateHamburgerMenu(addBurgerMenuDTO);
					return RedirectToAction("AddHamburgerMenu");
				}
				else
				{
					return View(addBurgerMenuDTO);
				}
			}
		}
		
		[HttpPost]
		public async Task<IActionResult> AddExtraMaterial(AddExtraMaterialDTO addExtraMaterialDTO)
		{
			if (ModelState.IsValid)
			{
				await _extraMaterialService.CreateExtra(addExtraMaterialDTO);
				return RedirectToAction("AddHamburgerMenu");
			}
			return View(addExtraMaterialDTO);
		}
		
       
    }
}

