using WarehouseManager.Models;

namespace WarehouseManager.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> getProductById(int id);
    }
}
