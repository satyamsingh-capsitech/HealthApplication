
using HealthApplication.Model;
using HealthApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HealthApplication.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServices _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(LoginServices loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
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

        // POST for login api
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginModel>> Login([FromBody] LoginModel login)
        {
            var user = await _loginService.ValidateUserAsync(login.UserName, login.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            //  token
            var token = GenerateJwtToken(user);

           
            return Ok(new { UserName = user.UserName, Token = token });
        }

        // JWT Token
        private string GenerateJwtToken(LoginModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("id", user.Id.ToString()),
                    new System.Security.Claims.Claim("username", user.UserName),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
