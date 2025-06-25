using System.Data;
using Fiotec.Boletos.Infrastructure.Data.Interfaces;
using Microsoft.Data.SqlClient;

namespace Fiotec.Boletos.Tests.Infrastructure.Data
{
    public class TestDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public TestDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
