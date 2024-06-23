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
        private readonly string dbadress = "";
        public DBRepository(IConfiguration configuration)
        {
               _configuration = configuration;
                dbadress = _configuration.GetConnectionString("pjatkowaded");
        }
        public List<Animal> GetAllAnimals()
        {
            List<Animal> result = new List<Animal>();
            string queryString ="SELECT * FROM dbo.Animal;";
            using (SqlConnection connection = new SqlConnection(dbadress))
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
                string queryString = "SELECT * FROM dbo.Animal WHERE IDAnimal = @Id;";
                using (SqlConnection connection = new SqlConnection(dbadress))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);
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
            string queryString = String.Format("UPDATE dbo.Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IDAnimal = @id",
                newAnimal.Name,
                newAnimal.Description,
                newAnimal.Category,
                newAnimal.Area,
                id);
            using (SqlConnection connection = new SqlConnection(dbadress))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Name", newAnimal.Name);
                    command.Parameters.AddWithValue("@Description", newAnimal.Description);
                    command.Parameters.AddWithValue("@Category", newAnimal.Category);
                    command.Parameters.AddWithValue("@Area", newAnimal.Area);
                    command.Parameters.AddWithValue("@id", id);
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
                string queryString = "delete FROM dbo.Animal WHERE IDAnimal = @id";
                using (SqlConnection connection = new SqlConnection(dbadress))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);
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
                string queryString = "INSERT INTO dbo.Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area);";
                using (SqlConnection connection = new SqlConnection(dbadress))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Name", animal.Name);
                    command.Parameters.AddWithValue("@Description", animal.Description);
                    command.Parameters.AddWithValue("@Category", animal.Category);
                    command.Parameters.AddWithValue("@Area", animal.Area);
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
