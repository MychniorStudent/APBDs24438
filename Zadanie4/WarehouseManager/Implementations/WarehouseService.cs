using WarehouseManager.DTOs;
using WarehouseManager.Interfaces;
using WarehouseManager.Models;

namespace WarehouseManager.Implementations
{
    public class WarehouseService : IWarehouseService
    {
        IProductRepository _productRepository;
        IWarehouseRepository _warehouseRepository;
        IOrderRepository _orderRepository;
        IProduct_WarehouseRepository _product_WarehouseRepository;
        public WarehouseService(IProductRepository productRepository,
            IWarehouseRepository warehouseRepository,
            IOrderRepository orderRepository,
            IProduct_WarehouseRepository product_WarehouseRepository)
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _orderRepository = orderRepository;
            _product_WarehouseRepository = product_WarehouseRepository;
        }
        //Główny scenariusz
        public async Task<int> doStuff(WarehouseActionDTO input)
        {
            //1. sprawdzenie amount z żądania
            if (input.Amount < 1)
                return -1;


            //1. sprawdzenie czy produkt istnieje
            Product product = await _productRepository.getProductById(input.IdProduct);
            if (product == null)
                return -1;

            //1. sprawdzenie czy magazyn istnieje
            Warehouse warehouse = await _warehouseRepository.getWarehouseById(input.IdWarehouse);
            if (warehouse == null)
                return -1;


            //2. Sprawdzamy czy istnieje zamówienie na dany produkt z odpowiednią ilością, oraz takie które nie zostało zakończone
            Order order = (await _orderRepository.getOrdersWithSpecifiedProduct(product.IdProduct))
                            .Where(x=>x.Amount == input.Amount && x.CreatedAt <= input.CreatedAt).FirstOrDefault(x=>x.FulfiledAt == null);
            if (order == null)
                return -1;


            //3. Sprawdzamy w Product_Warehouse czy nie zostało wcześniej przypadkiem zrealizowane
            if(await _product_WarehouseRepository.checkIfOrderExistInProduct_Warehouse(order.IdOrder))
                return -1;

            //4. Aktualizujemy kolumnę FulfilledAt zamówienia
            await _orderRepository.FulfillOrder(order.IdOrder);

            //5. Dodajemy rekord do tabeli Product_Warehouse
            Product_Warehouse recordToAdd = new Product_Warehouse { 
                IdOrder = order.IdOrder,
                IdWarehouse = warehouse.IdWarehouse,
                IdProduct = product.IdProduct,
                Amount = input.Amount,
                Price = (decimal)(input.Amount * product.Price),
                CreatedAt = DateTime.UtcNow
            };
            int resultId =  await _product_WarehouseRepository.AddProduct_Warehouse(recordToAdd);

            return resultId;
        }

        public async Task<int> doStuffUsingProc(WarehouseActionDTO input)
        {
            return await _warehouseRepository.executeProcStuff(input);
        }
    }
}
