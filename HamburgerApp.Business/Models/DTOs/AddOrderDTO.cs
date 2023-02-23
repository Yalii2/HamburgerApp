using HamburgerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Business.Models.DTOs
{
	public class AddOrderDTO
	{
		public decimal TotalPrice { get; set; }
		public bool Available => true;
		public DateTime CreatedTime => DateTime.Now;
		//ADDORDERDTO.PRODUCTS.WHERE(X=>X.NAME==).COUNT();
		//QUATİTY.ROLS.MENU.SUM(NAME)
		//public Product Quantity { get; set; }
		//public List<Product> Products { get; set; }
	}
}
