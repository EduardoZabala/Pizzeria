using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pizzeria.Backend.Data;
using Pizzeria.Backend.Helpers;
using Pizzeria.Backend.Repositories.Interfaces;
using Pizzeria.Shared.DTOs;
using Pizzeria.Shared.Enums;
using Pizzeria.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("/api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IMailHelper _mailHelper;

        public AccountsController(IUsersRepository usersRepository, IConfiguration configuration, DataContext context, IMailHelper mailHelper)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _context = context;
            _mailHelper = mailHelper;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            User user = model;
            var result = await _usersRepository.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _usersRepository.AddUserToRoleAsync(user, user.UserType.ToString());
                //return Ok(BuildToken(user));
                var response = await SendConfirmationEmailAsync(user);
                if (response.WasSuccess)
                {
                    return NoContent();
                }

                return BadRequest(response.Message);
            }
            return BadRequest(result.Errors.FirstOrDefault());

        }
        private async Task<ActionResponse<string>> SendConfirmationEmailAsync(User user)
        {
            var myToken = await _usersRepository.GenerateEmailConfirmationTokenAsync(user);
            var tokenLink = Url.Action("ConfirmEmail", "accounts", new
            {
                userid = user.Id,
                token = myToken
            }, HttpContext.Request.Scheme, _configuration["Url Frontend"]);

            return _mailHelper.SendMail(user.UserName, "Pizzeria.Italiana.Med@gmail.com",
                $"Pizzeria- Confirmación de cuenta",
                $"<h1>Pizzeria - Confirmación de cuenta</h1>" +
                $"<p>Para habilitar el usuario, por favor hacer clic 'Confirmar Email':</p>" +
                $"<b><a href ={tokenLink}>Confirmar Email</a></b>");
        }

        [HttpGet]
        [Route("ManagerAccount")]
        public async Task<ActionResult> ManagerAccountAsync(string userId, bool Active)
        {

            var _user = await _usersRepository.GetUserAsync(new Guid(userId));
            if (_user == null)
            {
                return NotFound();
            }
            _user.EmailConfirmed = Active ? true : false;
            string msn = Active ? "Estimado usuario su cuenta ha sido activada" : "Estimado usuario su cuenta ha sido desactivada, " +
                "para mas informacion : Pizzeria.Italiana.Med@gmail.com";
            var result = await SendEmailAsync(_user, msn);
            if (result.WasSuccess)
            {
                _context.Update(_user);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest(result.Message);
        }
        private async Task<ActionResponse<string>> SendEmailAsync(User user, string msn)
        {
            return _mailHelper.SendMail(user.UserName, user.Email,
                $"Pizzeria - Importante  ",
                $"<h1>Pizzeria</h1>" +
                $"<p>{msn}</p>"
                );

        }

        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmailAsync(string userId, string token)
        {
            try
            {
                token = token.Replace(" ", "+");
                var user = await _usersRepository.GetUserAsync(new Guid(userId));
                if (user == null)
                {
                    return NotFound();
                }
                var result = await _usersRepository.ConfirmEmailAsync(user, token);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors.FirstOrDefault());
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NoContent();
            }

        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
        {
            var result = await _usersRepository.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _usersRepository.GetUsersAsync(model.Email);
                return Ok(BuildToken(user));
            }
            if (result.IsLockedOut)
            {
                return BadRequest("Ha superado el máximo número de intentos, su cuenta está bloqueada, intente de nuevo en 5 minutos.");
            }

            if (result.IsNotAllowed)
            {
                return BadRequest("El usuario no ha sido habilitado, debes de seguir las instrucciones del correo enviado para poder habilitar el usuario.");
            }


            return BadRequest("Email o contraseña incorrectos.");
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var _user = await _context.Users.FirstOrDefaultAsync(c => c.Cedula == id);
            if (_user == null)
            {
                return NotFound();
            }

            return Ok(_user);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        private TokenDTO BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email!),
                new(ClaimTypes.Role, user.UserType.ToString()),
                new("Cedula", user.Cedula.ToString()!),
                new("Phone", user.PhoneNumber.ToString()!),
                new("Address", user.Direccion.ToString()!)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }

}
