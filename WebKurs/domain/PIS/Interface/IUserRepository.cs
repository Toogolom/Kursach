namespace PIS.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetUserByIdAsync(string id);

        public Task AddUserAsync(string email, string username, string password);

        public Task<User> GetUserByUsernameAsync(string userName);

        public Task<List<User>> GetUsersByPartUsernameAsync(string partName);

        public Task<bool> UserEmailNotExistAsync(string email);

        public Task<bool> UpdatePassword(string password, string email);

        public Task<User> GetUserByEmailAsync(string email);

        public Task<bool> UpdateUser(string email, string username);

        public Task<List<User>> GetAllUsersAsync();

        public Task DeleteUserAsync(string id);

        public Task<string> GetUsernameByEmailAsync(string email);

        public Task<bool> UsernameNotExistAsync(string userName);
    }
}
