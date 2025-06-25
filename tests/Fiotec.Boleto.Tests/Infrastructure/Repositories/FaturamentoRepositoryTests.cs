using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Fiotec.Boletos.Tests.Infrastructure.Repositories
{
    //public class FaturamentoRepositoryTests
    //{
    //    private readonly Mock<IDbConnection> _connectionMock;
    //    private readonly FaturamentoRepository _repository;

    //    public FaturamentoRepositoryTests()
    //    {
    //        _connectionMock = new Mock<IDbConnection>();
    //        _repository = new FaturamentoRepository(_connectionMock.Object);
    //    }

    //    [Fact]
    //    public async Task GetByIdAsync_ShouldReturnFaturamento_WhenExists()
    //    {
    //        // Arrange
    //        var faturamento = new Faturamento
    //        {
    //            Id = 1,
    //            Data = DateTime.Today,
    //            Valor = 100.0m,
    //            Cliente = new Cliente { Id = 2 }
    //        };
    //        _connectionMock
    //            .SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<Faturamento>(
    //                It.IsAny<string>(),
    //                It.IsAny<object>(),
    //                null, null, null))
    //            .ReturnsAsync(faturamento);

    //        // Act
    //        var result = await _repository.GetByIdAsync(1);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(1, result.Id);
    //    }

    //    [Fact]
    //    public async Task GetAllAsync_ShouldReturnAllFaturamentos()
    //    {
    //        // Arrange
    //        var faturamentos = new List<Faturamento>
    //        {
    //            new Faturamento { Id = 1, Data = DateTime.Today, Valor = 100, Cliente = new Cliente { Id = 1 } },
    //            new Faturamento { Id = 2, Data = DateTime.Today, Valor = 200, Cliente = new Cliente { Id = 2 } }
    //        };
    //        _connectionMock
    //            .SetupDapperAsync(c => c.QueryAsync<Faturamento>(
    //                It.IsAny<string>(),
    //                null, null, null, null))
    //            .ReturnsAsync(faturamentos);

    //        // Act
    //        var result = await _repository.GetAllAsync();

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.Collection(result,
    //            f => Assert.Equal(1, f.Id),
    //            f => Assert.Equal(2, f.Id));
    //    }

    //    //[Fact]
    //    //public async Task AddAsync_ShouldCallExecuteAsync()
    //    //{
    //    //    // Arrange
    //    //    var faturamento = new Faturamento
    //    //    {
    //    //        Data = DateTime.Today,
    //    //        Valor = 150.0m,
    //    //        Cliente = new Cliente { Id = 3 }
    //    //    };
    //    //    _connectionMock
    //    //        .SetupDapperAsync(c => c.ExecuteAsync(
    //    //            It.IsAny<string>(),
    //    //            It.IsAny<object>(),
    //    //            null, null, null))
    //    //        .ReturnsAsync(1);

    //    //    // Act
    //    //    await _repository.AddAsync(faturamento);

    //    //    // Assert
    //    //    _connectionMock.VerifyDapper(c => c.ExecuteAsync(
    //    //        It.IsAny<string>(),
    //    //        It.IsAny<object>(),
    //    //        null, null, null), Times.Once);
    //    //}

    //    [Fact]
    //    public async Task UpdateAsync_ShouldCallExecuteAsync()
    //    {
    //        // Arrange
    //        var faturamento = new Faturamento
    //        {
    //            Id = 5,
    //            Data = DateTime.Today,
    //            Valor = 200.0m,
    //            Cliente = new Cliente { Id = 4 }
    //        };
    //        _connectionMock
    //            .SetupDapperAsync(c => c.ExecuteAsync(
    //                It.IsAny<string>(),
    //                It.IsAny<object>(),
    //                null, null, null))
    //            .ReturnsAsync(1);

    //        // Act
    //        await _repository.UpdateAsync(faturamento);

    //        // Assert
    //        _connectionMock.VerifyDapper(c => c.ExecuteAsync(
    //            It.IsAny<string>(),
    //            It.IsAny<object>(),
    //            null, null, null), Times.AtMostOnce);
    //    }

    //    [Fact]
    //    public async Task DeleteAsync_ShouldCallExecuteAsync()
    //    {
    //        // Arrange
    //        int id = 10;
    //        _connectionMock
    //            .SetupDapperAsync(c => c.ExecuteAsync(
    //                It.IsAny<string>(),
    //                It.IsAny<object>(),
    //                null, null, null))
    //            .ReturnsAsync(1);

    //        // Act
    //        await _repository.DeleteAsync(id);

    //        // Assert
    //        _connectionMock.VerifyDapper(c => c.ExecuteAsync(
    //            It.IsAny<string>(),
    //            It.IsAny<object>(),
    //            null, null, null), Times.AtMostOnce);
    //    }
    //}

    //// Fix for CS0308: Replace 'ISetup' with the correct generic interface 'ISetup<TMock, TResult>' from Moq.
    //public static class MoqDapperExtensions
    //{
    //    public static ISetup<IDbConnection, Task<T>> SetupDapperAsync<T>(
    //        this Mock<IDbConnection> mock,
    //        Expression<Func<IDbConnection, Task<T>>> expression)
    //    {
    //        return mock.Setup(expression);
    //    }

    //    public static void VerifyDapper<T>(
    //        this Mock<IDbConnection> mock,
    //        Expression<Func<IDbConnection, Task<T>>> expression,
    //        Times times)
    //    {
    //        mock.Verify(expression, times);
    //    }
    //}
}
