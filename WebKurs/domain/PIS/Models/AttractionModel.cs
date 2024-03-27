namespace PIS.Models
{
    public class AttractionModel
    {
        public int AttractionId { get; set; }

        public string AttractionName { get; set; }

        public string AttractionDescription { get; set; }

        public string AttractionPhotoUrl { get; set; }

        public int CityId { get; set; }

        public List<City> Cities { get; set; }
    }
}
