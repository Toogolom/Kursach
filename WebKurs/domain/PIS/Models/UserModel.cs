﻿namespace WebKurs.Models
{
    public class UserModel
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Dictionary<string, string> Error { get; set; } = new Dictionary<string, string>();
    }
}
