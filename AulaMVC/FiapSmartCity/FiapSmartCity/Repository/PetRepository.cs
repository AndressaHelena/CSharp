using FiapSmartCity.Models;
using System.Data;
using System.Data.SqlClient;

namespace FiapSmartCity.Repository
{
    public class PetRepository
    {
        public IList<Pet> Listar()
        {
            IList<Pet> lista = new List<Pet>();
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPET, NOMEPET FROM PET  ";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    // Recupera os dados
                    Pet pet = new Pet();
                    pet.IdPet = Convert.ToInt32(dataReader["IDPET"]);
                    pet.NomePet = dataReader["NOMEPET"].ToString();

                    // Adiciona o modelo da lista
                    lista.Add(pet);
                }
                connection.Close();
            } // Finaliza o objeto connection
            // Retorna a lista
            return lista;
        }
        public Pet Consultar(int id)
        {
            Pet pet = new Pet();

            //a conexão não muda
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPET, NOMEPET FROM PET WHERE IDPET = @IDPET ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@idpet", SqlDbType.Int);
                command.Parameters["@idpet"].Value = id;
                connection.Open();//ABRIR CONEXÃO


                SqlDataReader dataReader = command.ExecuteReader();//EXECUTA COMANDO


                while (dataReader.Read())
                {
                    // Recupera os dados
                    pet.IdPet = Convert.ToInt32(dataReader["IDPET"]);
                    pet.NomePet = dataReader["NOMEPET"].ToString();
                }
                connection.Close();
            } // Finaliza o objeto connection

            // Retorna a lista para view
            return pet;
        }
        public void Inserir(Pet pet)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PET (  NOMEPET ) VALUES ( @nomepet ) ";

                SqlCommand command = new SqlCommand(query, connection);
                // Adicionando o valor ao comando
                command.Parameters.Add("@nomepet", SqlDbType.Text);
                command.Parameters["@nomepet"].Value = pet.NomePet;
                
                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Alterar(Pet pet)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PET SET NOMEPET = @nomepet WHERE IDPET = @idpet  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                
                command.Parameters.Add("@idpet", SqlDbType.Int);
                command.Parameters["@idpet"].Value = pet.IdPet;

                command.Parameters.Add("@nomepet", SqlDbType.Text);
                command.Parameters["@nomepet"].Value = pet.NomePet;
                

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PET WHERE IDPET = @idpet  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@idpet", SqlDbType.Int);
                command.Parameters["@idpet"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}