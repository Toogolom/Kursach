namespace PIS.Interface
{
    public interface IUserRepository
    {
        public User GetUserById(int id);

        public void AddUser(string email, string username,string password);

        public User GetUserByUserName(string userName);
    }
}
