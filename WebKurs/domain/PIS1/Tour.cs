namespace PIS
{
	public class Tour
	{
		public int TourId { get; }

		public string TourName { get; }

		public string TourDescription { get; }

		public double TourPrice { get; }

		public Tour(int id, string name, string description, double price)
		{
			TourId = id;
			TourName = name;
			TourDescription = description;
			TourPrice = price;
		}
	}
}
