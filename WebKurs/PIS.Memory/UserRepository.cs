namespace PIS.Memory
{
    using PIS;
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User(1,"Toog1","toog1@gmail.com","toog1"),
            new User(2,"Toog2","toog2@gmail.com","toog2"),
            new User(3,"Toog3","toog3@gmail.com","toog3"),
        };
        public void AddUser(string email, string  username, string password)
        {
            int userId = users.Count + 1 ;
            User user = new User(userId, email, username, password);
            users.Add(user);
        }

        public User GetUserById(int id)
        {
            return (User)users.Where(user => user.UserId == id);
        }

        public User GetUserByUsername(string userName)
        {
            return users.FirstOrDefault(user => user.UserName == userName);
        }

        public bool UsernameNotExist(string userName)
        {
            var newUser = users.FirstOrDefault(user => user.UserName == userName);
            return newUser == null;
        }

        public User GetUserByEmail(string email)
        {
            return users.FirstOrDefault(user => user.Email == email);
        }

        public bool UserEmailNotExist(string email)
        {
            var newUser = users.FirstOrDefault(user => user.Email == email);
            return newUser == null;
        }
    }
}
