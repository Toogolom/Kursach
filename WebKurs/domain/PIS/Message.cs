namespace PIS
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MessageId { get; set; }

        public string Username { get; set; }

        public string Text { get; set; }

        public HashSet<string> Like { get; set; }

        public HashSet<string> Dislike { get; set; }

        public List<Message> Comments { get; set; }

        public DateTime Date { get; set; }

        public Message (string username, string text, DateTime date)
        {
            Username = username;
            Text = text;
            Like = new HashSet<string>();
            Dislike = new HashSet<string>();
            Comments = new List<Message>();
            Date = date;
        }
    }
}
