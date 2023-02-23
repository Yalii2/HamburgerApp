using HamburgerApp.Core.Entities.Abstract;
using HamburgerApp.Core.Enums;
using HamburgerApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.Entities.Concrete
{
	public class Order : IOrder, IBaseEntity
	{
		public Guid Id { get; set; }
		public bool Available { get; set; }
		public decimal TotalPrice { get; set; }
		public User User { get; set; }
		public Status Status { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? DeletedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
		//bire çok bağlantı için liste tutulur
		public List<Product> Products { get; set; }


		public Order()
		{
			Products = new List<Product>();
		}
	}
}
