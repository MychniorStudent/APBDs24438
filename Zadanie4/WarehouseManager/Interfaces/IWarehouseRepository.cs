using WarehouseManager.DTOs;
using WarehouseManager.Models;

namespace WarehouseManager.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<Warehouse> getWarehouseById(int id);
        Task<int> executeProcStuff(WarehouseActionDTO actionDTO);
    }
}
