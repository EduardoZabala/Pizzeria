using Pizzeria.Backend.DTOs;
using Pizzeria.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Pizzeria.Frontend.Services
{
    public interface IReseñaService
    {
        // Modificar para devolver List<ReseñaClienteDTO> en lugar de List<Reseña>
        Task<List<ReseñaClienteDTO>> ObtenerReseñasConClientes();
        // Modificar para devolver ReseñaClienteDTO en lugar de Reseña
        Task<ReseñaClienteDTO> ObtenerReseñaPorId(int id);
        // Crear una reseña, devolviendo ReseñaClienteDTO
        Task<ReseñaClienteDTO> CrearReseña(Reseña reseña);
        // Actualizar una reseña
        Task ActualizarReseña(Reseña reseña);
        // Eliminar una reseña por su ID
        Task EliminarReseña(int id);
    }
}