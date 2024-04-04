namespace PIS
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class Email
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmailId { get; set; }

        public string EmailFrom { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Email(string emailFrom, string text, DateTime date)
        {
            EmailFrom = emailFrom;
            Text = text;
            Date = date;
        }
    }
}
