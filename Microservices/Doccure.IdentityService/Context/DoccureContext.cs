using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Doccure.IdentityService.Context
{
    public class DoccureContext : IdentityDbContext<AppUser>//<>  tıp guvenliği için IdentityDbContext kullanıyoruz. AppUser sınıfımızı burada belirtiyoruz.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MD57CH6;Database=DoccureIdentityDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
      

        /*
          IdentityDbContext İLE OLUŞAN TABLOLAR
        AspNetUsers      (Kullanıcı bilgilerinin tutulduğu tablo)
        AspNetRoles      (Rollerin tutulduğu tablo)
        AspNetUserRoles  (Kullanıcılar ve roller arasındaki ilişki tablosu)
        AspNetUserClaims (Kullanıcı yetki/tanım etiketleri)
        AspNetRoleClaims (Rol yetki/tanım etiketleri)
        AspNetUserLogins (Google, Facebook gibi dış giriş bilgileri)
        AspNetUserTokens (Şifre sıfırlama, 2FA gibi geçici tokenlar)
         */
    }
}
