using Microsoft.AspNetCore.Identity;
using Pizzeria.Shared.DTOs;
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
        
        //Agregamos DTO
        Task<bool> IsUserInRoleAsync(User Usuarios, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

        //Confirmacion de correo
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserAsync(Guid userId);

    }

}
