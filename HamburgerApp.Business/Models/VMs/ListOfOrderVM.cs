using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Models.VMs
{
	public class ListOfOrderVM
	{
		public Guid Id { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreatedTime { get; set; }
	}
}
