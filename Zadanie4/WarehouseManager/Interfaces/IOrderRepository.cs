using WarehouseManager.Models;

namespace WarehouseManager.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> getOrderById(int id);
        Task<List<Order>> getOrdersWithSpecifiedProduct(int productId);
        Task<bool> FulfillOrder(int orderId);
    }
}
