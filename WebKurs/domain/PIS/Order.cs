namespace PIS
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    public class Order
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

		public string UserId { get; set; }

		public double TotalPrice { get; set; }

		public List<string> TourId { get; set; }

		public DateTime DateOrder { get; set; }

		public Order (string userId, List<string> tourId, DateTime dateOrder, double totalPrice)
		{
			UserId = userId;
			TourId = tourId;
			DateOrder = dateOrder;
			TotalPrice = totalPrice;
		}
    }
}
