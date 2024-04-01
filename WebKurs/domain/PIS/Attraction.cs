using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PIS
{
    public class Attraction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AttractionId { get; set; }

        public string AttractionName { get; set; }

        public string AttractionDescription { get; set; }

        public string AttractionPhotoUrl { get; set; }

        public string CityId { get; set; }

        public Attraction(string attractionName, string attractionDescription, string cityId, string attractionPhotoUrl)
        {
            AttractionName = attractionName;
            AttractionDescription = attractionDescription;
            CityId = cityId;
            AttractionPhotoUrl = attractionPhotoUrl;
        }
    }
}
