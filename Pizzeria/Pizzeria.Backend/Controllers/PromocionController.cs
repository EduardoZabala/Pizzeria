using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocionController : ControllerBase
    {
        private readonly DataContext _context;

        public PromocionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Promociones.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Promociones.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Promocion promocion)
        {
            _context.Add(promocion);
            await _context.SaveChangesAsync();
            return Ok(promocion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var promocion = await _context.Promociones.FirstOrDefaultAsync(c => c.Id == id);
            if (promocion == null)
            {
                return NotFound();
            }

            _context.Remove(promocion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Promocion promocion)
        {
            _context.Update(promocion);
            await _context.SaveChangesAsync();
            return Ok(promocion);
        }
    }
}
