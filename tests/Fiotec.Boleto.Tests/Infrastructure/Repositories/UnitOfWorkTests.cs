using System.Diagnostics.CodeAnalysis;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Data.Interfaces;
using Fiotec.Boletos.Infrastructure.Repositories;
using Fiotec.Boletos.Tests.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Fiotec.Boletos.Tests.Infrastructure.Repositories
{
    public class UnitOfWorkTests
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;

        public UnitOfWorkTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _connectionFactory = new TestDbConnectionFactory(_configuration["ConnectionStrings:DefaultConnection"]);
        }

        [Fact]
        public async Task CommitAsync_DevePersistirDados()
        {
            using var unitOfWork = new UnitOfWork(_connectionFactory);

            var novoFaturamento = new Faturamento
            {
                Data = DateTime.Today,
                Valor = 100,
                Cliente = new Cliente { Id = 1 }
            };

            await unitOfWork.Faturamentos.InserirAsync(novoFaturamento);
            await unitOfWork.CommitAsync();

            using var connection = _connectionFactory.CreateConnection();
            var resultado = await connection.QueryFirstOrDefaultAsync<Faturamento>(
                "SELECT * FROM Faturamento WHERE Valor = @Valor", new { Valor = 100 });

            Assert.NotNull(resultado);
        }

        [Fact]
        public async Task RollbackAsync_DeveDescartarDados()
        {
            using var unitOfWork = new UnitOfWork(_connectionFactory);

            var novoFaturamento = new Faturamento
            {
                Data = DateTime.Today,
                Valor = 999,
                Cliente = new Cliente { Id = 1 }
            };

            await unitOfWork.Faturamentos.InserirAsync(novoFaturamento);
            await unitOfWork.RollbackAsync();

            using var connection = _connectionFactory.CreateConnection();
            var resultado = await connection.QueryFirstOrDefaultAsync<Faturamento>(
                "SELECT * FROM Faturamento WHERE Valor = @Valor", new { Valor = 999 });

            Assert.Null(resultado);
        }
    }

}
