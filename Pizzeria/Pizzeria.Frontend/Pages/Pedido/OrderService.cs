using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Pizzeria.Frontend.Repositories;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Frontend.Services
{
    
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IRepository _repository;


        public OrderService(HttpClient httpClient, IRepository repository)
        {
            _httpClient = httpClient;
            _repository = repository;
        }
        // Obtiene una lista de todos los pedidos
        public async Task<List<Pedido>> ObtenerPedidosAsync()
        {
            var pedidos = await _httpClient.GetFromJsonAsync<List<Pedido>>("api/Pedido");
            return pedidos ?? new List<Pedido>();
        }
        // Obtiene un pedido por su ID
        public async Task<Pedido?> ObtenerPedidoPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Pedido>($"api/Pedido/{id}");
        }

        // método para obtener el ID del cliente por número de pedido
        public async Task<string?> ObtenerIdClientePorNumeroPedidoAsync(int numeroPedido)
        {
            try
            {
                // Intentar obtener el ID del cliente desde el servidor
                var response = await _httpClient.GetAsync($"api/Pedido/{numeroPedido}/cliente");
                // Si no es exitoso, manejar el error
                if (!response.IsSuccessStatusCode)
                {
                    return null; // Devuelve null si no se encuentra el pedido
                }
                // Si es exitoso, deserializar el resultado
                var valr = await response.Content.ReadFromJsonAsync<int?>();
                return valr.Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el ID del cliente: {ex.Message}");
                return null; // Manejo genérico de excepciones
            }
        }
    }
}