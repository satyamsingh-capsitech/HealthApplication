using HealthApplication.Model;
using HealthApplication.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HealthApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServices _loginService;
        public LoginController(LoginServices loginService)
        {
            _loginService = loginService;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<List<LoginModel>>> Get()
        {
            var users = await _loginService.GetAllLoginAsync();
            return Ok(users);
        }
        // POST
        [HttpPost]
        public async Task<ActionResult> Create(LoginModel login)
        {
            await _loginService.CreateLoginAsync(login);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginModel>> Login([FromBody] LoginModel login)
        {
            var user = await _loginService.ValidateUserAsync(login.UserName, login.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Optionally
            var loginResponse = new LoginModel
            {
                UserName = user.UserName,
            };

            return Ok(loginResponse);
        }
    }
}


