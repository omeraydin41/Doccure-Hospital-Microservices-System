using Doccure.IdentityService.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Doccure.IdentityService.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
