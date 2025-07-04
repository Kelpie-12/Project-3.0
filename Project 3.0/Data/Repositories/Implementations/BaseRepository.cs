﻿using System.Data.SqlClient;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class BaseRepository
    {
        private static readonly string DEFAULT_CONNECTION_STRING = "Default";
        private readonly string _connectionSttring;
        public BaseRepository(IConfiguration configuration)
        {
            string? defaultConnectionString = configuration.GetConnectionString(DEFAULT_CONNECTION_STRING);
            if (defaultConnectionString == null)
            {
                throw new Exception("Ошибка с строкой подключения");
            }
            _connectionSttring = defaultConnectionString;
        }
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionSttring);
        }
    }
}
