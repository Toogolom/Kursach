namespace PIS.Models
{
    public class TourModel
    {
        public int TourId { get; set; }

        public string TourName { get; set; }

        public string TourDescription { get; set; }

        public double TourPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Dictionary<int, DateTime> AttractionDate { get; set; }

        public List<Attraction> Attractions { get; set; }
    }
}
