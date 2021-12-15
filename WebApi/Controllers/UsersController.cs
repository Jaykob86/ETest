using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> SignUp(UserRegistration registration)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(_userService.DoesUserWithEmailExist(registration.Email))
            {
                return BadRequest($"User with email {registration.Email} already exists. Please sign in.");
            }
            var user = _userService.Register(registration);
            return Ok(user);
        }

        [HttpPost("Login")]
        public ActionResult<bool> Login(UserCredentials credentials)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var isSuccess = _userService.SignIn(credentials);
            return isSuccess == true 
                ? Ok(true) 
                : BadRequest("Login failed");
        }
    }
}