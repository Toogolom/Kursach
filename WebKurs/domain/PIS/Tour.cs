namespace PIS
{
	using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
	public class Tour
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TourId { get; set; }

		public string TourName { get; set; }

		public string TourDescription { get; set; }

        public string URL { get; set; }

        public double TourPrice { get; set; }


		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Dictionary<string, DateTime> AttractionDate { get; set; }

		public Tour(string name, string description, double price, DateTime startDate, DateTime endDate, Dictionary<string, DateTime> attractionDate, string url)
		{
			TourName = name;
			TourDescription = description;
			TourPrice = price;
			StartDate = startDate;
			EndDate = endDate;
			AttractionDate = attractionDate;
			URL = url;
        }
	}
}
