using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReseñaController : ControllerBase
    {
        private readonly DataContext _context;

        public ReseñaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Reseñas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var reseña = await _context.Reseñas.FirstOrDefaultAsync(c => c.Id == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return Ok(reseña);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Reseña reseña)
        {
            _context.Add(reseña);
            await _context.SaveChangesAsync();
            return Ok(reseña);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var reseña = await _context.Reseñas.FirstOrDefaultAsync(c => c.Id == id);
            if (reseña == null)
            {
                return NotFound();
            }

            _context.Remove(reseña);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Reseña reseña)
        {
            _context.Update(reseña);
            await _context.SaveChangesAsync();
            return Ok(reseña);
        }
    }
}
