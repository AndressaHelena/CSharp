using CadastroApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace CadastroApi.Repository
{
    public class PessoaRepository
    {
        public IList<Pessoa> Listar()
        {
            IList<Pessoa> lista = new List<Pessoa>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPESSOA, NOMEPESSOA, ADDRESSPESSOA FROM CADASTRO ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    Pessoa pessoa = new();
                    pessoa.IdPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.NomePessoa = dataReader["NOMEPESSOA"].ToString();
                    pessoa.AddressPessoa = dataReader["ADDRESSPESSOA"].ToString();

                    // Adiciona o modelo da lista
                    lista.Add(pessoa);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;
        }

        public Pessoa Consultar(int id)
        {

            Pessoa pessoa = new();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPESSOA, NOMEPESSOA, ADDRESSPESSOA FROM CADASTRO WHERE IDPESSOA = @IDPESSOA ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@idpessoa", SqlDbType.Int);
                command.Parameters["@idpessoa"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    pessoa.IdPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.NomePessoa = dataReader["NOMEPESSOA"].ToString();
                    pessoa.AddressPessoa = dataReader["ADDRESSPESSOA"].ToString();
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return pessoa;
        }

        public void Inserir(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO CADASTRO ( NOMEPESSOA, ADDRESSPESSOA ) VALUES ( @nomepessoa, @addresspessoa ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@idpessoa", SqlDbType.Int);
                command.Parameters["@idpessoa"].Value = pessoa.IdPessoa;

                command.Parameters.Add("@nomepessoa", SqlDbType.Text);
                command.Parameters["@nomepessoa"].Value = pessoa.NomePessoa;

                command.Parameters.Add("@addresspessoa", SqlDbType.Text);
                command.Parameters["@addresspessoa"].Value = pessoa.AddressPessoa;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE CADASTRO SET NOMEPESSOA = @nomepessoa, ADDRESSPESSOA = @addresspessoa WHERE IDPESSOA = @idpessoa  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@idpessoa", SqlDbType.Int);
                command.Parameters["@idpessoa"].Value = pessoa.IdPessoa;

                command.Parameters.Add("@nomepessoa", SqlDbType.Text);
                command.Parameters["@nomepessoa"].Value = pessoa.NomePessoa;

                command.Parameters.Add("@addresspessoa", SqlDbType.Text);
                command.Parameters["@addresspessoa"].Value = pessoa.AddressPessoa;


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
                    "DELETE CADASTRO WHERE IDPESSOA = @idpessoa  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@idpessoa", SqlDbType.Int);
                command.Parameters["@idpessoa"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
