using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WarehouseManager.DTOs;
using WarehouseManager.Interfaces;
using WarehouseManager.Models;

namespace WarehouseManager.Implementations
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private IConfiguration _configuration;
        public WarehouseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> executeProcStuff(WarehouseActionDTO actionDTO)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "AddProductToWarehouse";
            cmd.Parameters.AddWithValue("@IdWarehouse", actionDTO.IdProduct);
            cmd.Parameters.AddWithValue("@IdWarehouse", actionDTO.IdWarehouse);
            cmd.Parameters.AddWithValue("@IdWarehouse", actionDTO.Amount);
            cmd.Parameters.AddWithValue("@IdWarehouse", actionDTO.CreatedAt);

            try
            {
                return (int)await cmd.ExecuteScalarAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<Warehouse> getWarehouseById(int id)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            await con.OpenAsync();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdWarehouse, Name, Address FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
            cmd.Parameters.AddWithValue("@IdWarehouse", id);

            var dr = await cmd.ExecuteReaderAsync();

            if ( !await dr.ReadAsync()) 
                return null;

            Warehouse warehouse = new Warehouse
            {
                IdWarehouse = (int)dr["IdWarehouse"],
                Name = dr["Name"].ToString(),
                Address = dr["Address"].ToString()
            };
            return warehouse;
        }
    }
}
