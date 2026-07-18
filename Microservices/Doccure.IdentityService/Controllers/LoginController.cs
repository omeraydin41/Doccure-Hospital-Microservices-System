using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService loginService)
        {
            _authService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (!result)
                return BadRequest("emial veya şifre hatalı.");

            return Ok("giriş başarılı.");
        }

    }
}
