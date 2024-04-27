using AnimalManager.Interfaces;
using AnimalManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;

namespace AnimalManager.Services
{
    //"Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24438;Integrated Security=True"
    public class DBRepository : IDBRepository
    {
        private IConfiguration _configuration;
        public DBRepository(IConfiguration configuration)
        {
               _configuration = configuration;
        }
        public List<Animal> GetAllAnimals()
        {
            List<Animal> result = new List<Animal>();
            string queryString ="SELECT * FROM dbo.Animal;";
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("mssqldb")))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                            reader[0], reader[1]));
                        result.Add(new Animal()
                        {
                            IdAnimal = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Category = reader.GetString(3),
                            Area = reader.GetString(4),
                        });
                    }
                }
            }
            return result;
        }

        public Animal GetAnimalById(int id)
        {
            try { 
                string queryString = String.Format("SELECT * FROM dbo.Animal WHERE IDAnimal = {0};",id);
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("mssqldb")))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Animal()
                            {
                                IdAnimal = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Category = reader.GetString(3),
                                Area = reader.GetString(4),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public bool UpdateAnimal(int id, Animal animal, Animal oldAnimal) 
        {
            try { 
            Animal newAnimal = new Animal()
            {
                Name = !animal.Name.IsNullOrEmpty() ? animal.Name : oldAnimal.Name ,
                Description = !animal.Description.IsNullOrEmpty() ? animal.Description : oldAnimal.Description,
                Category = !animal.Category.IsNullOrEmpty() ? animal.Category : oldAnimal.Category,
                Area = !animal.Area.IsNullOrEmpty() ? animal.Area : oldAnimal.Area,
            };
            string queryString = String.Format("UPDATE dbo.Animal SET Name = \'{0}\', Description = \'{1}\', Category = \'{2}\', Area = \'{3}\' WHERE IDAnimal = {4}",
                newAnimal.Name,
                newAnimal.Description,
                newAnimal.Category,
                newAnimal.Area,
                id);
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("mssqldb")))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool DeleteAnimal(int id)
        {
            try
            {
                string queryString = String.Format("delete FROM dbo.Animal WHERE IDAnimal = {0};", id);
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("mssqldb")))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool AddAnimal(Animal animal)
        {

            try
            {
                string queryString = String.Format("INSERT INTO dbo.Animal (Name, Description, Category, Area) VALUES ('{0}', '{1}', '{2}', '{3}');", 
                    animal.Name, animal.Description, animal.Category, animal.Area);
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("mssqldb")))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
