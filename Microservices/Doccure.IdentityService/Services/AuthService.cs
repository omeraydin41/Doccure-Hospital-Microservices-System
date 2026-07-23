using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Doccure.IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        // UserManager servisini constructor üzerinden enjekte ediyoruz
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        

        public async Task<string?> LoginAsync(LoginDto dto)//bool dan strıng olarak guncellenen interface methodu implemente edildi 
        {

            var user = await _userManager.FindByEmailAsync(dto.Email);//email değeri alındı 

            if (user == null)//kontrol edildi 
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            //result değerini identity methodundan CheckPasswordSignInAsync kontrol edildi , user değeri şifre ve hesap yanlış girişte kitlenmeemsi için false değeri alındı 

            if (!result.Succeeded)//başarılı değilse null 
                return null;

            return await GenerateToken(user);//başarılı ise token üretildi 
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            // appsettings.json içerisindeki Jwt ayarları alındı.
            var jwtSettings = _configuration.GetSection("Jwt");

            // Kullanıcının sahip olduğu roller veritabanından getirildi.
            var roles = await _userManager.GetRolesAsync(user);

            // Token içerisine eklenecek kullanıcı bilgileri (Claim) oluşturuldu.
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id), // Kullanıcının benzersiz ID bilgisi eklendi.
                 new Claim(ClaimTypes.Email, user.Email ?? ""), // Kullanıcının e-posta bilgisi eklendi.
                 new Claim("name", user.Name ?? ""), // Kullanıcının adı eklendi.
                 new Claim("surname", user.Surname ?? "") // Kullanıcının soyadı eklendi.
            };

            // Kullanıcının tüm rolleri token içerisine eklendi.
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // Her rol ayrı bir Role Claim olarak eklendi.
            }

            // Gizli anahtardan (Secret Key) simetrik güvenlik anahtarı oluşturuldu.
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
            );

            // Token'ın HmacSha256 algoritması ile imzalanacağı belirtildi.
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            // JWT Token oluşturuldu.
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"], // Token'ı oluşturan uygulama belirtildi.
                audience: jwtSettings["Audience"], // Token'ı kullanacak istemci belirtildi.
                claims: claims, // Token içerisine kullanıcı bilgileri eklendi.
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(jwtSettings["ExpireMinutes"]!)
                ), // Token'ın sona erme süresi ayarlandı.
                signingCredentials: credentials // Token güvenli anahtar ile imzalandı.
            );

            // Oluşturulan JWT Token string formatına çevrilip geri döndürüldü.
            return new JwtSecurityTokenHandler().WriteToken(token);
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
