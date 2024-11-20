using Pizzeria.Backend.DTOs;
using Pizzeria.Shared.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace Pizzeria.Frontend.Services
{
    public class ReseñaService : IReseñaService
    {
        private readonly HttpClient _httpClient;
        public ReseñaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Obtiene todas las reseñas con sus respectivos clientes (ahora usando ReseñaClienteDTO)
        public async Task<List<ReseñaClienteDTO>> ObtenerReseñasConClientes()
        {
            // Obtenemos las reseñas desde la API
            var reseñas = await _httpClient.GetFromJsonAsync<List<ReseñaClienteDTO>>("api/reseña");
            // Solo en caso de que no haya reseñas, devolvemos una lista vacía
            return reseñas ?? new List<ReseñaClienteDTO>();
        }
        // Obtiene una reseña por su ID
        public async Task<ReseñaClienteDTO> ObtenerReseñaPorId(int id)
        {
            var reseña = await _httpClient.GetFromJsonAsync<ReseñaClienteDTO>($"api/reseña/{id}");
            return reseña;
        }
        // Crea una nueva reseña (usando ReseñaClienteDTO para incluir los datos del cliente)
        public async Task<ReseñaClienteDTO> CrearReseña(Reseña reseña)
        {
            var response = await _httpClient.PostAsJsonAsync("api/reseña", reseña);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReseñaClienteDTO>();
            }
            return null;
        }
        // Actualiza una reseña existente (usando ReseñaClienteDTO)
        public async Task ActualizarReseña(Reseña reseña)
        {
            await _httpClient.PutAsJsonAsync("api/reseña", reseña);
        }
        // Elimina una reseña por su ID
        public async Task EliminarReseña(int id)
        {
            await _httpClient.DeleteAsync($"api/reseña/{id}");
        }
    }
}
