using Doccure.IdentityService.Dtos;

namespace Doccure.IdentityService.Services.RoleServices
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(CreateRoleDto dto);//bool : rol true false olacak //CreateRoleDto classının turunde olacak 
    }
}
