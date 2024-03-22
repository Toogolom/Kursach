namespace PIS
{
    public class Attraction
    {
        public int AttractionId { get; }

        public string AttractionName { get; set; }

        public string AttractionDescription { get; set; }

        public string AttractionPhotoUrl { get; set; }

        public int CityId { get; set; }

        public Attraction(int attractionId, string attractionName, string attractionDescription, int cityId, string attractionPhotoUrl)
        {
            AttractionId = attractionId;
            AttractionName = attractionName;
            AttractionDescription = attractionDescription;
            CityId = cityId;
            AttractionPhotoUrl = attractionPhotoUrl;
        }
    }
}
