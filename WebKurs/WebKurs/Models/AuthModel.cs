namespace WebKurs.Models
{
    public class AuthModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Dictionary<string, string> Error { get; set; }

        public AuthModel()
        {
            Error = new Dictionary<string, string>
            {
                { "InvalidEmail", string.Empty },
                { "InvalidPassword", string.Empty },
            };
        }
    }
}
