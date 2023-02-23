using HamburgerApp.Business.Models.DTOs;
using HamburgerApp.Business.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Services.ExtraMaterialService
{
	public interface IExtraMaterialService
	{
		Task CreateExtra(AddExtraMaterialDTO addExtraMaterialDTO);
		Task<List<ListOfExtraMaterialVM>> GetExtras();
	}
}
