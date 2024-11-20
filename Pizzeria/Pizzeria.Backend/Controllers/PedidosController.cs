using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]//Autenticacion por token 

    public class PedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Pedidos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }
        [HttpGet("{numeroPedido}/cliente")]
        public async Task<IActionResult> ObtenerIdClientePorNumeroPedido(int numeroPedido)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == numeroPedido);
            if (pedido == null)
            {
                return NotFound("No se encontró un pedido con ese número."); // Devuelve 404 con mensaje
            }
            return Ok(pedido.CedulaUsuario); // Devuelve el ID del cliente
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Pedido pedido)
        {
            _context.Update(pedido);
            await _context.SaveChangesAsync();
            return Ok(pedido);
        }
    }
}