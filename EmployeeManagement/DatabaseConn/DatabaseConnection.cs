﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeManagement.DatabaseConn
{
    public class DatabaseConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("EmployeeDbConn");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
