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
        public ActionResult<UserDto> SignUp(UserRegistration registration)
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
        public ActionResult<UserDto> Login(UserCredentials credentials)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _userService.SignIn(credentials);
            return user != null
                ? Ok(user) 
                : Unauthorized("Login failed");
        }
    }
}