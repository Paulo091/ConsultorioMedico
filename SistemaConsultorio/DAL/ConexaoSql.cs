using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaConsultorio.DAL
{
    public class ConexaoSql
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;
        
        public ConexaoSql(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Consultorio");
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public DataTable ExecuteReader(string query)
        {
            DataTable dataTable = null;
            using (_sqlConnection)
            {
                _sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, _sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable = new DataTable();
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }
    }
}
