using Fiotec.Boletos.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Fiotec.Boletos.Tests.Infrastructure.Data
{
    public class DapperContextTests
    {
        //[Fact]
        //public void Constructor_ShouldSetConnectionString()
        //{
        //    // Arrange
        //    var mockConfig = new Mock<IConfiguration>();
        //    var mockSection = new Mock<IConfigurationSection>();
        //    mockSection.Setup(s => s.Value).Returns("Server=localhost,1433;Database=Boletos;User Id=sa;Password=SenhaForte123!;TrustServerCertificate=True;");
        //    mockConfig.Setup(c => c.GetSection("ConnectionStrings:DefaultConnection")).Returns(mockSection.Object);
        //    mockConfig.Setup(c => c.GetConnectionString("DefaultConnection")).Returns("Server=localhost,1433;Database=Boletos;User Id=sa;Password=SenhaForte123!;TrustServerCertificate=True;");

        //    // Act
        //    var context = new DapperContext(mockConfig.Object);

        //    // Assert
        //    Assert.NotNull(context);
        //}

        //[Fact]
        //public void CreateConnection_ShouldReturnSqlConnectionWithCorrectConnectionString()
        //{
        //    // Arrange
        //    var expectedConnectionString = "Server=localhost,1433;Database=Boletos;User Id=sa;Password=SenhaForte123!;TrustServerCertificate=True;";
        //    var mockConfig = new Mock<IConfiguration>();
        //    mockConfig.Setup(c => c.GetConnectionString("DefaultConnection")).Returns(expectedConnectionString);
        //    var context = new DapperContext(mockConfig.Object);

        //    // Act
        //    using var connection = context.CreateConnection();

        //    // Assert
        //    Assert.IsType<SqlConnection>(connection);
        //    Assert.Equal(expectedConnectionString, connection.ConnectionString);
        //}
    }
}
