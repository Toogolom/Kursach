namespace PIS
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;


	public class Order
	{
		public int OrderId { get; }

		public int UserId { get; }

		public List<int> TourId { get; }

		public DateTime DateOrder { get; }

		public Order (int orderId, int userId, List<int> tourId, DateTime dateOrder)
		{
			OrderId = orderId;
			UserId = userId;
			TourId = tourId;
			DateOrder = dateOrder;
		}
	}
}
