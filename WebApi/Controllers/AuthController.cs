using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public ActionResult<User> SignUp(UserRegistration registration)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var user = _userService.Register(registration);
            return Ok(user);
        }

        [HttpPost("SignIn")]
        public ActionResult<bool> SignIn(UserCredentials credentials)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var isSuccess = _userService.SignIn(credentials);
            return isSuccess == true 
                ? Ok(true) 
                : BadRequest();
        }
    }
}