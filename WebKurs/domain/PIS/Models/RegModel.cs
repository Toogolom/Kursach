namespace WebKurs.Models
{
    public class RegModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Error { get; set; }

        public RegModel()
        {
            Error = new Dictionary<string, string>
            {
                { "InvalidEmail", string.Empty }, 
                { "InvalidUsername", string.Empty },
                { "InvalidPassword", string.Empty },
                { "EmailTaken", string.Empty },
                { "Empty", string.Empty },
            };
        }
    }
}
