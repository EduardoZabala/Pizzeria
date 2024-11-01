using Microsoft.AspNetCore.Identity;
using Pizzeria.Shared.Entities;
using Pizzeria.Shared.Enums;

namespace Pizzeria.Backend.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUsersAsync(string email);

        Task<IdentityResult> AddUserAsync(User Usuarios, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User Usuarios, string roleName);

        Task<bool> IsUserInRoleAsync(User Usuarios, string roleName);
    }

}
