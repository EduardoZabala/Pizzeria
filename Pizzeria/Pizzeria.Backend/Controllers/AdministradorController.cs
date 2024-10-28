using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly DataContext _context;

        public AdministradorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Administradores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var administrador = await _context.Administradores.FirstOrDefaultAsync(c => c.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Administrador administrador)
        {
            _context.Add(administrador);
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var administrador = await _context.Administradores.FirstOrDefaultAsync(c => c.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Remove(administrador);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Administrador administrador)
        {
            _context.Update(administrador);
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }
    }
}
   