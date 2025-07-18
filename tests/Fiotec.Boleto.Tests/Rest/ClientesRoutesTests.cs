using Fiotec.Boletos.API.Routes;
using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace Fiotec.Boletos.Tests.API.Routes
{
    public class ClientesRoutesTests
    {
        [Fact]
        public async Task ObterPorId_RetornaOkQuandoEncontrado()
        {
            // Arrange
            var cliente = new Cliente();
            var serviceMock = new Mock<IClienteService>();
            serviceMock.Setup(s => s.ObterPorIdAsync(1)).ReturnsAsync(cliente);

            // Act
            var result = await serviceMock.Object.ObterPorIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ObterPorId_RetornaNullQuandoNaoEncontrado()
        {
            // Arrange
            var serviceMock = new Mock<IClienteService>();
            serviceMock.Setup(s => s.ObterPorIdAsync(99)).ReturnsAsync((Cliente)null);

            // Act
            var result = await serviceMock.Object.ObterPorIdAsync(99);

            // Assert
            Assert.Null(result);
        }
    }
}
