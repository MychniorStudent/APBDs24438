using System.Data.SqlClient;
using WarehouseManager.Interfaces;
using WarehouseManager.Models;

namespace WarehouseManager.Implementations
{
    public class Product_WarehouseRepository : IProduct_WarehouseRepository
    {
        private IConfiguration _configuration;
        public Product_WarehouseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> AddProduct_Warehouse(Product_Warehouse product)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                "VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt) ;SELECT SCOPE_IDENTITY();";
            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@IdWarehouse", product.IdWarehouse);
            cmd.Parameters.AddWithValue("@IdProduct", product.IdProduct);
            cmd.Parameters.AddWithValue("@IdOrder", product.IdOrder);
            cmd.Parameters.AddWithValue("@Amount", product.Amount);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            int added;
            try
            {
                added = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return -1;
            }
            return added;
        }

        public async Task<bool> checkIfOrderExistInProduct_Warehouse(int orderId)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdOrder FROM Product_Warehouse WHERE IdOrder = @IdOrder";
            cmd.Parameters.AddWithValue("@IdOrder", orderId);

            var dr = await cmd.ExecuteReaderAsync();

            if (!await dr.ReadAsync())
                return false;

            return true;
        }

        public Product_Warehouse GetProduct_WarehouseById(int id)
        {
            throw new NotImplementedException();
        }

        public Product_Warehouse GetProduct_WarehouseByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
