using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Services.OrderService;
using HamburgerApp.Core.Enums;
using HamburgerApp.DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamburgerApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{
		private readonly IOrderServices _orderServices;
		private readonly HamburgerAppDbContext db;
		public OrderController(IOrderServices orderServices, HamburgerAppDbContext hamburgerAppDbContext)
		{
			_orderServices = orderServices;
			db = hamburgerAppDbContext;
		}

		public IActionResult Index()
		{
			ViewBag.Order = db.Orders.ToList();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddOrder(AddOrderDTO addOrderDTO)
		{
			if (ModelState.IsValid)
			{
				ViewBag.Orders=db.Orders.ToListAsync();
				ViewBag.TotalPrice = db.Products.Sum(x => x.Price);
				await _orderServices.CreateOrder(addOrderDTO);
				return RedirectToAction("Index");
			}
			return View(addOrderDTO);
		}

	}
}
