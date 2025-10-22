using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class BaseRepository
    {
     
        private static readonly string DEFAULT_DB_CONNECTION_STRING = "Default";
        //private static readonly string DEFAULT_API_CONNECTION_STRING = "DefaultAPI";
        private readonly string _connectionSttring;
        //private readonly IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration)
        {
            string? defaultConnectionString = configuration.GetConnectionString(DEFAULT_DB_CONNECTION_STRING);
            if (defaultConnectionString == null)
            {
                throw new Exception("Ошибка с строкой подключения");
            }
            _connectionSttring = defaultConnectionString;
            //_configuration = configuration;
        }
        //protected string CreateAPIConnection()
        //{
        //    return _configuration.GetConnectionString(DEFAULT_API_CONNECTION_STRING);
        //}
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionSttring);
        }
    }
}
