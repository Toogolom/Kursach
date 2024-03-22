namespace PIS
{
	public class Tour
	{
		public int TourId { get; }

		public string TourName { get; set; }

		public string TourDescription { get; set; }

		public double TourPrice { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Dictionary<int, DateTime> AttractionDate { get; set; }

		public Tour(int id, string name, string description, double price, DateTime startDate, DateTime endDate, Dictionary<int, DateTime> attractionDate)
		{
			TourId = id;
			TourName = name;
			TourDescription = description;
			TourPrice = price;
			StartDate = startDate;
			EndDate = endDate;
			AttractionDate = attractionDate;
        }
	}
}
