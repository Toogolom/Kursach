namespace PIS.Interface
{
    public interface IUserRepository
    {
        public User GetUserById(int id);

        public void AddUser(string email, string username,string password);

        public User GetUserByUsername(string userName);

        public bool UserEmailNotExist(string email);

        public User GetUserByEmail(string email);

        public string GetUsernameByEmail(string email);

        public bool UsernameNotExist(string userName);
    }
}
