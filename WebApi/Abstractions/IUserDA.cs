using WebApi.Models;

namespace WebApi.Abstractions
{
    public interface IUserDA
    {
        public IReadOnlyCollection<User> GetUsers();
        public User FindUser(string email);
        public User CreateUser(User user);
    }
}
