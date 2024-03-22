namespace PIS
{
	using System;
	using System.Collections.Generic;

	public class Order
	{
		public int OrderId { get; }

		public int UserId { get; set; }

		public List<int> TourId { get; set; }

		public DateTime DateOrder { get; set; }

		public Order (int userId, List<int> tourId, DateTime dateOrder)
		{
			UserId = userId;
			TourId = tourId;
			DateOrder = dateOrder;
		}

        public Order(int orderId, int userId, List<int> tourId, DateTime dateOrder)
        {
			OrderId = orderId;
            UserId = userId;
            TourId = tourId;
            DateOrder = dateOrder;
        }
    }
}
