using WarehouseManager.Models;

namespace WarehouseManager.Interfaces
{
    public interface IProduct_WarehouseRepository
    {
        Product_Warehouse GetProduct_WarehouseById(int id);
        Product_Warehouse GetProduct_WarehouseByOrderId(int orderId);
        Task<int> AddProduct_Warehouse(Product_Warehouse product);
        Task<bool> checkIfOrderExistInProduct_Warehouse(int orderId);
    }
}
