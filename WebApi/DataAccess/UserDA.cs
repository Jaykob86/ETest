using WebApi.Abstractions;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class UserDA : IUserDA
    {
        private readonly AppDbContext _context;
        public UserDA(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User FindUser(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }


}
