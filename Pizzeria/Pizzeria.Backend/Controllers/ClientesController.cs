using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }
    }
}