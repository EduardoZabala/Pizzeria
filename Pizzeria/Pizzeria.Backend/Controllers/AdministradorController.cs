using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Backend.Data;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Backend.Controllers
{
    [ApiController]//Etiqueta que indica que tipo de controlador de una API
    [Route("/api/administradores")]//ruta de la api turnos y como saldra en la url
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //para no consumir el controlador sin token

    public class AdministradorController : ControllerBase
    {
        private readonly DataContext _context;//Es un constructor que se encarga de inicializar la base de datos
        /*Este es un pequeño constructor que se hace para cada
          controlador  
         */
        public AdministradorController(DataContext context)
        {
            _context = context;
        }
        //Metodo Get Lista
        [HttpGet]// Etiqueta que equivale a Create
        public async Task<ActionResult> Get()
        {  
            return Ok(await _context.Administradorees.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Post(Administrador administrador)
        {
            _context.Add(administrador);
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }
        // Metodo Get-por Id 
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var administrador = await _context.Administradorees.FirstOrDefaultAsync(x => x.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }
            return Ok(administrador);
        }
        //Metodo Put (update), Actualiza un registro
        [HttpPut]
        public async Task<ActionResult> Put(Administrador administrador)
        {
            _context.Update(administrador);
            await _context.SaveChangesAsync();
            return Ok(administrador);
        }
        //Metodo delete (Delete), Elimina un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Administradorees.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }//fin clase
}
