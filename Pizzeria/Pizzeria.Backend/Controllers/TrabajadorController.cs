using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajadorController : ControllerBase
    {
        private readonly DataContext _context;

        public TrabajadorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Trabajadores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var trabajador = await _context.Trabajadores.FirstOrDefaultAsync(c => c.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Trabajador trabajador)
        {
            _context.Add(trabajador);
            await _context.SaveChangesAsync();
            return Ok(trabajador);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var trabajador = await _context.Trabajadores.FirstOrDefaultAsync(c => c.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            _context.Remove(trabajador);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Trabajador trabajador)
        {
            _context.Update(trabajador);
            await _context.SaveChangesAsync();
            return Ok(trabajador);
        }
    }
}
