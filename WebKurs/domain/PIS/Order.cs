namespace PIS
{
	using System;
	using System.Collections.Generic;

	public class Order
	{
		public int OrderId { get; }

		public int UserId { get; }

		public List<int> TourId { get; }

		public DateTime DateOrder { get; }

		public Order (int userId, List<int> tourId, DateTime dateOrder)
		{
			UserId = userId;
			TourId = tourId;
			DateOrder = dateOrder;
		}

        public Order(int OrderId, int userId, List<int> tourId, DateTime dateOrder)
        {
            UserId = userId;
            TourId = tourId;
            DateOrder = dateOrder;
        }
    }
}
