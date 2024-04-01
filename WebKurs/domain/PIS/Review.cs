namespace PIS
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using System;

    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReviewId { get; set; }

        public string Username { get; set; }

        public string ReviewText { get; set; }

        public string TourId { get; set; }

        public Review (string username, string reviewText, string tourId)
        {
            Username = username;
            ReviewText = reviewText;
            TourId = tourId;
        }
    }
}
