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

    public class PagoEfectivoController : ControllerBase
    {
        private readonly DataContext _context;

        public PagoEfectivoController(DataContext context)
        {
            _context = context;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync(PagoEfectivo pagoEfectivo)
        {
            _context.Add(pagoEfectivo);
            await _context.SaveChangesAsync();
            return Ok(pagoEfectivo);
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