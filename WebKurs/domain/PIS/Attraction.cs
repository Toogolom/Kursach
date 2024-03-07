namespace PIS
{
    public class Attraction
    {
        public int AttractionId { get; }

        public string AttractionName { get; }

        public string AttractionDescription { get; }

        public string AttractionPhotoUrl { get; }

        public int CityId { get; }

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
