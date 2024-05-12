using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WarehouseManager.Interfaces;
using WarehouseManager.Models;

namespace WarehouseManager.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Product> getProductById(int id)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdProduct, Name, Description, Price FROM Product WHERE IdProduct = @IdProduct";
            cmd.Parameters.AddWithValue("@IdProduct", id);

            var dr = await cmd.ExecuteReaderAsync();

            if (!await dr.ReadAsync())
                return null;

            Product product = new Product()
            {
                IdProduct = (int)dr["IdProduct"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Price = (decimal)dr["Price"]
            };
            return product;
        }
    }
}
