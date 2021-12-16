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

        public UserDto Register(UserRegistration registration)
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

            var user = _userDA.CreateUser(newUser);

            return TranslateToDto(user);
        }

        public UserDto SignIn(UserCredentials credentials)
        {
            var match = _userDA.FindUser(credentials.Email);

            if (match?.Password == credentials.Password)
            {
                return TranslateToDto(match);
            }

            return null;
        }

        public bool DoesUserWithEmailExist(string email)
        {
            return _userDA.FindUser(email) != null;
        }

        private UserDto TranslateToDto(User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday
            };
        }
    }
}
