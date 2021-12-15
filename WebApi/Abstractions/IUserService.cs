using WebApi.Models;

namespace WebApi.Abstractions
{
    public interface IUserService
    {
        User Register(UserRegistration registration);
        bool SignIn(UserCredentials credentials);
        bool DoesUserWithEmailExist(string email);
    }
}
