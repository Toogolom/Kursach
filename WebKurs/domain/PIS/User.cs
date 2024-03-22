namespace PIS
{
    public class User
    {
        public int UserId { get;}

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public User(int userId, string userName, string email, string password, bool isAdmin)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
