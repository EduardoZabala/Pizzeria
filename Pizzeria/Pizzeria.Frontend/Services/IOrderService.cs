using Pizzeria.Shared.Entities;
namespace Pizzeria.Frontend.Services
{
    public interface IOrderService
    {
        Task<List<Pedido>> ObtenerPedidosAsync();
        Task<Pedido?> ObtenerPedidoPorIdAsync(int id);
        Task<string?> ObtenerIdClientePorNumeroPedidoAsync(int numeroPedido); // Nuevo método agregado
    }
}
