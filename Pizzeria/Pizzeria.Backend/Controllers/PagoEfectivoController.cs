using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Backend.Helpers;
using Pizzeria.Shared.DTOs;
using Pizzeria.Shared.Entities;
using Pizzeria.Shared.Enums;
using Pizzeria.Shared.Responses;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]//Autenticacion por token 

    public class PagoEfectivoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMailHelper _mailHelper;

        public PagoEfectivoController(DataContext context, IMailHelper mailHelper)
        {
            _context = context;
            _mailHelper = mailHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.PagoEfectivos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var pagoEfectivo = await _context.PagoEfectivos.FirstOrDefaultAsync(c => c.Id == id);
            if (pagoEfectivo == null)
            {
                return NotFound();
            }

            return Ok(pagoEfectivo);
        }
        [HttpGet("GetPayments/{usuarioId}")]
        public async Task<ActionResult> GetPayments(string usuarioId)
        {

            var query = await _context.PagoEfectivos
                .Where(pe => pe.Pedido.CedulaUsuario == usuarioId)
                .Select(pe => new PagosDTO
                {
                    FechaPago=pe.FechaPago.Value,
                    pedidoId = pe.IdPedido,
                    CostoTotal=pe.Pedido.CostoTotal,
                    Productos=pe.Pedido.Productos,
                    PromocionNombre= pe.Pedido.Promocion.nombre,
                    Estado = pe.Estado?"Pago exitoso":"Pago en proceso"
                }).ToListAsync();
            return Ok(query);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PagoEfectivo pagoEfectivo, string userId)
        {
            var _user = await _context.Users.FirstOrDefaultAsync(u => u.Cedula == userId);
            if (_user == null)
            {
                return NotFound();
            }
            _context.Add(pagoEfectivo);
            string msn = "Pago Realizado, se inicia proceso de confirmacion.";
            await _context.SaveChangesAsync();
            await SendEmailAsync(_user, msn);
            return Ok(pagoEfectivo);
        }

        private async Task<ActionResponse<string>> SendEmailAsync(User user, string msn)
        {
            return _mailHelper.SendMail(user.UserName, user.Email,
                $"Pizzeria - Importante  ",
                $"<h1>Pizzeria</h1>" +
                $"<p>{msn}</p>"
                );

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pagoEfectivo = await _context.PagoEfectivos.FirstOrDefaultAsync(c => c.Id == id);
            if (pagoEfectivo == null)
            {
                return NotFound();
            }

            _context.Remove(pagoEfectivo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(PagoEfectivo pagoEfectivo)
        {
            _context.Update(pagoEfectivo);
            await _context.SaveChangesAsync();
            return Ok(pagoEfectivo);
        }
    }
}