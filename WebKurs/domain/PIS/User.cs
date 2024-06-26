﻿namespace PIS
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public User(string username, string email, string password, bool isAdmin)
        {
            Username = username;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
