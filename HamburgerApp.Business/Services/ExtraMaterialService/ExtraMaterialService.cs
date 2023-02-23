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

namespace HamburgerApp.Business.Services.ExtraMaterialService
{
	public class ExtraMaterialService : IExtraMaterialService
	{
		private readonly IMapper _mapper;
		private readonly IProductRepo _productRepo;
		public ExtraMaterialService(IMapper mapper, IProductRepo productRepo)
		{
			_mapper = mapper;
			_productRepo = productRepo;
		}

		public async Task CreateExtra(AddExtraMaterialDTO addExtraMaterialDTO)
		{
			var addExtra = _mapper.Map<Product>(addExtraMaterialDTO);
			await _productRepo.Add(addExtra);
		}

		public async Task<List<ListOfExtraMaterialVM>> GetExtras()//++
		{
			var extras = await _productRepo.GetFilteredList(
				select: x => new ListOfExtraMaterialVM
				{
					Id = x.Id,
					ProductName = x.ProductName,
					Price = x.Price,
				},
				where: x => ((x.Status == Status.Active || x.Status == Status.Modified) && x.Roles == Roles.Menu),
				orderBy: x => x.OrderBy(x => x.ProductName));

			return extras;
		}
	}
}
