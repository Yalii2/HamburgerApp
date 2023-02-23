using AutoMapper;
using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using HamburgerApp.DataAccess.Abstract;
using HamburgerApp.DataAccess.EntityFramework.Concrete;
using HamburgerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Services.OrderService
{
	public class OrderServices : IOrderServices
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepo _orderRepo;
		public OrderServices(IMapper mapper, IOrderRepo orderRepo)
		{
			_mapper = mapper;
			_orderRepo = orderRepo;
		}

		public async Task CreateOrder(AddOrderDTO addOrderDTO)
		{
			var addOrder = _mapper.Map<Order>(addOrderDTO);
			await _orderRepo.Add(addOrder);
		}

		public async Task<List<ListOfOrderVM>> GetOrders()//++
		{
			var orders = await _orderRepo.GetFilteredList(
				select: x => new ListOfOrderVM
				{
					Id = x.Id,
					TotalPrice = x.TotalPrice,
					CreatedTime = x.CreatedTime
				},
				where: default,
				orderBy: x => x.OrderBy(x => x.CreatedTime));

			return orders;
		}
	}
}
