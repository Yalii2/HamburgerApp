using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Services.OrderService
{
	public interface IOrderServices
	{
		Task CreateOrder(AddOrderDTO addOrderDTO);
		Task<List<ListOfOrderVM>> GetOrders();
	}
}
