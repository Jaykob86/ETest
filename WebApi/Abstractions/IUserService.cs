using WebApi.Models;

namespace WebApi.Abstractions
{
    public interface IUserService
    {
        UserDto Register(UserRegistration registration);
        UserDto SignIn(UserCredentials credentials);
        bool DoesUserWithEmailExist(string email);
    }
}
