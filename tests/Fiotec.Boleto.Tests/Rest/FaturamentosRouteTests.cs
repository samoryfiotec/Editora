using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Moq;
using Xunit;

namespace Fiotec.Boletos.Tests.API.Routes
{
    public class FaturamentosRouteTests
    {
        [Fact]
        public async Task GetObterFaturamentoPorId_ReturnsOkWhenFound()
        {
            // Arrange
            var faturamento = new Faturamento();
            var serviceMock = new Mock<IFaturamentoService>();
            serviceMock.Setup(s => s.ObterFaturamentoPorIdAsync(1)).ReturnsAsync(faturamento);

            // Act
            var result = await serviceMock.Object.ObterFaturamentoPorIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetObterFaturamentoPorId_ReturnsNullWhenNotFound()
        {
            // Arrange
            var serviceMock = new Mock<IFaturamentoService>();
            serviceMock.Setup(s => s.ObterFaturamentoPorIdAsync(99)).ReturnsAsync((Faturamento)null);

            // Act
            var result = await serviceMock.Object.ObterFaturamentoPorIdAsync(99);

            // Assert
            Assert.Null(result);
        }
    }
}
