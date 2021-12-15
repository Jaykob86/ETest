using WebApi.Abstractions;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDA _userDA;

        public UserService(IUserDA userDA)
        {
            _userDA = userDA;
        }

        public User Register(UserRegistration registration)
        {
            var newUser = new User
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.Email,
                Birthday = registration.Birthday,
                Password = registration.Password,
                Created = DateTime.UtcNow,
            };

            return _userDA.CreateUser(newUser);
        }

        public bool SignIn(UserCredentials credentials)
        {
            var match = _userDA.FindUser(credentials.Email);

            if (match?.Password == credentials.Password)
            {
                return true;
            }

            return false;
        }

        public bool DoesUserWithEmailExist(string email)
        {
            return _userDA.FindUser(email) != null;
        }
    }
}
