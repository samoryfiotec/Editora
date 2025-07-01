using System.Data;
using Fiotec.Boletos.Infrastructure.Data;
using Fiotec.Boletos.Infrastructure.Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Fiotec.Boletos.Tests.Infrastructure.Data
{
    public class DapperContextTests
    {
        [Fact]
        public void Construtor_DeveDefinirStringDeConexao()
        {
            // Arrange
            var mockConfig = new Mock<IConfiguration>();
            var mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(s => s["DefaultConnection"])
                .Returns("Server=.;Database=TestDb;Trusted_Connection=True;");
            mockConfig.Setup(c => c.GetSection("ConnectionStrings"))
                .Returns(mockSection.Object);

            // Act
            var context = new DapperContext(mockConfig.Object);

            // Assert
            using var conn = context.CreateConnection();
            Assert.IsType<SqlConnection>(conn);
            Assert.Equal("Server=.;Database=TestDb;Trusted_Connection=True;", conn.ConnectionString);
        }

        [Fact]
        public void CriarConexao_DeveRetornarSqlConnection()
        {
            // Arrange
            var mockConfig = new Mock<IConfiguration>();
            var mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(s => s["DefaultConnection"])
                .Returns("Data Source=localhost;Initial Catalog=TestDb;Integrated Security=True;");
            mockConfig.Setup(c => c.GetSection("ConnectionStrings"))
                .Returns(mockSection.Object);

            var context = new DapperContext(mockConfig.Object);

            // Act
            using var connection = context.CreateConnection();

            // Assert
            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);
            Assert.Equal("Data Source=localhost;Initial Catalog=TestDb;Integrated Security=True;", connection.ConnectionString);
        }
    }
}
