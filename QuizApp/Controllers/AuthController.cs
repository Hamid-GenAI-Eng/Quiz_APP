using Microsoft.AspNetCore.Mvc;
using QuizApp.DTOs;
using QuizApp.Helpers;
using QuizApp.Services;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtHelper _jwtHelper;

        public AuthController(AuthService authService, JwtHelper jwtHelper)
        {
            _authService = authService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(RegisterDto dto)
        {
            var user = await _authService.Register(dto);
            if (user == null)
                return BadRequest(new { message = "Email already exists." });

            return Ok(new { message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _authService.Authenticate(dto);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials." });

            var token = _jwtHelper.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
