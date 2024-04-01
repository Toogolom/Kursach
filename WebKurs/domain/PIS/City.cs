﻿namespace PIS
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CityId { get; set; }

        public string CityName { get; set; }

        public string CityDescription { get; set; }

        public string PhotoUrl { get; set; }

        public City(string cityName, string cityDescription, string photoUrl)
        {
            CityName = cityName;
            CityDescription = cityDescription;
            PhotoUrl = photoUrl;
        }
    }
}
