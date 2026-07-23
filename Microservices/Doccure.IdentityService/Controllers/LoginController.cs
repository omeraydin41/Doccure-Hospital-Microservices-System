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
            var token = await _authService.LoginAsync(dto);//LoginAsync methodundan gelen user ile dto yu eşledik .dto endpointten geliyor 
            if (token==null)
                return Unauthorized("emial veya şifre hatalı");
            return Ok(new {token});//başarılı ise geriye token değerini dön 
        }

    }
}
