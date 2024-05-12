using WarehouseManager.DTOs;

namespace WarehouseManager.Interfaces
{
    public interface IWarehouseService
    {
        Task<int> doStuff(WarehouseActionDTO input);
        Task<int> doStuffUsingProc(WarehouseActionDTO input);
    }
}
