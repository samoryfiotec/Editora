using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories;
using Moq;
using Moq.Dapper;
using Xunit;

namespace Fiotec.Boletos.Tests.Infrastructure.Repositories
{
    public class FaturamentoRepositoryTests
    {
        private readonly Mock<IDbConnection> _mockConnection;
        private readonly Mock<IDbTransaction> _mockTransaction;
        private readonly FaturamentoRepository _repository;

        public FaturamentoRepositoryTests()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockTransaction = new Mock<IDbTransaction>();
            _repository = new FaturamentoRepository(_mockConnection.Object, null);
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarFaturamento_QuandoEncontrado()
        {
            // Arrange
            var expected = new Faturamento
            {
                Id = 1,
                Data = DateTime.Today,
                Valor = 100.0m,
                Cliente = new Cliente()
            };

            _mockConnection
                .SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<Faturamento>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    _mockTransaction.Object,
                    null,
                    null))
                .ReturnsAsync(expected);

            // Act
            var result = await _repository.ObterPorId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Data, result.Data);
            Assert.Equal(expected.Valor, result.Valor);
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarNull_QuandoNaoEncontrado()
        {
            // Arrange
            _mockConnection
                .SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<Faturamento>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    _mockTransaction.Object,
                    null,
                    null))
                .ReturnsAsync((Faturamento)null);

            // Act
            var result = await _repository.ObterPorId(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ObterTodosAsync_DeveRetornarTodosFaturamentos()
        {
            // Arrange
            var expected = new List<Faturamento>
            {
                new Faturamento { Id = 1, Data = DateTime.Today, Valor = 100, Cliente = new Cliente() },
                new Faturamento { Id = 2, Data = DateTime.Today.AddDays(-1), Valor = 200, Cliente = new Cliente() }
            };

            _mockConnection
                .SetupDapperAsync(c => c.QueryAsync<Faturamento>(
                    It.IsAny<string>(),
                    null,
                    _mockTransaction.Object,
                    null,
                    null))
                .ReturnsAsync(expected);

            // Act
            var result = await _repository.ObterTodosAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result,
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(2, item.Id));
        }       
    }
}
