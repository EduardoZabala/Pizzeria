using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Backend.DTOs;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // Autenticación por token 
    public class ReseñaController : ControllerBase
    {
        private readonly DataContext _context;

        public ReseñaController(DataContext context)
        {
            _context = context;
        }

        // Obtiene todas las reseñas con la información del cliente
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var reseñas = await _context.Reseñas
                            .Include(r => r.Users) // Incluye la relación
                            .Select(r => new ReseñaClienteDTO
                            {
                                Id = r.Id,
                                FechaPublicacion = r.FechaPublicacion,
                                Calificacion = r.Calificacion,
                                Comentario = r.Comentario,
                                IdCliente = r.CedulaUsuario,
                                NombreCliente = r.Users.Nombre, // Datos de User
                                ApellidoCliente = r.Users.Apellido // Datos de User
                            })
                            .ToListAsync();


            if (reseñas == null || !reseñas.Any())
            {
                return NotFound("No se encontraron reseñas.");
            }

            return Ok(reseñas);
        }

        // Crea una nueva reseña
        [HttpPost]
        public async Task<IActionResult> PostAsync(Reseña reseña)
        {
            _context.Add(reseña);
            await _context.SaveChangesAsync();
            return Ok(reseña);
        }

        // Elimina una reseña por ID
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

        // Actualiza una reseña existente
        [HttpPut]
        public async Task<IActionResult> PutAsync(Reseña reseña)
        {
            _context.Update(reseña);
            await _context.SaveChangesAsync();
            return Ok(reseña);
        }
    }
}