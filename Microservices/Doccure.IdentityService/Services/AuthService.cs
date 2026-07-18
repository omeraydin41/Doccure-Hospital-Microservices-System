using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity;

namespace Doccure.IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        // UserManager servisini constructor üzerinden enjekte ediyoruz
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<bool> LoginAsync(LoginDto dto)
        {
            // 1. Kullanıcıyı email adresine göre veritabanından buluyoruz
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return false; // Kullanıcı bulunamadı
            }

            // 2. Bulunan kullanıcının UserName bilgisini kullanarak giriş yapıyoruz
            var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, false);

            return result.Succeeded;
        }




        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            var user = new AppUser()
            {
                UserName = dto.UserName,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                City = dto.City
            };

            // Doğrudan result nesnesini dönüyoruz, böylece hatalar kaybolmuyor
            var result = await _userManager.CreateAsync(user, dto.Password);
            return result;
        }
    }
}
