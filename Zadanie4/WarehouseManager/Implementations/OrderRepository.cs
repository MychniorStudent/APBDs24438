using System.Data.SqlClient;
using WarehouseManager.Interfaces;
using WarehouseManager.Models;

namespace WarehouseManager.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> FulfillOrder(int orderId)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE [dbo].[Order] set FulfilledAt = @FulfillDate WHERE IdOrder = @IdOrder";
            cmd.Parameters.AddWithValue("@FulfillDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@IdOrder", orderId);

            try
            {
                var dr = await cmd.ExecuteReaderAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<Order> getOrderById(int id)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM Product WHERE IdOrder = @IdWarehouse";
            cmd.Parameters.AddWithValue("@IdWarehouse", id);

            var dr = await cmd.ExecuteReaderAsync();

            if (!await dr.ReadAsync())
                return null;

            Order order = new Order
            {
                IdOrder = (int)dr["IdOrder"],
                IdProduct = (int)dr["IdProduct"],
                Amount = (int)dr["Amount"],
                CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
            };

            return order;
        }

        public async Task<List<Order>> getOrdersWithSpecifiedProduct(int productId)
        {
            List<Order> ordersResult = new List<Order>();
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM [dbo].[Order] WHERE IdProduct = @IdProduct";
            cmd.Parameters.AddWithValue("@IdProduct", productId);

            var dr = await cmd.ExecuteReaderAsync();

            while(await dr.ReadAsync())
            {
                ordersResult.Add(new Order
                {
                    IdOrder = (int)dr["IdOrder"],
                    IdProduct = (int)dr["IdProduct"],
                    Amount = (int)dr["Amount"],
                    CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                });
            }

            return ordersResult;
        }
    }
}
