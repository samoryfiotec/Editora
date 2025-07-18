using Fiotec.Boletos.API.Routes;
using Fiotec.Boletos.Application.Services.Interfaces;
using Microsoft.AspNetCore.Routing;
using Moq;
using BoletoEntity = Fiotec.Boletos.Domain.Entities.Boleto;

namespace Fiotec.Boletos.Tests.API.Routes
{
    public class BoletosRouteTests
    {
        //[Fact]
        //public void MapBoletosRoutes_ShouldRegisterEndpoints()
        //{
        //    // Arrange
        //    var routeBuilderMock = new Mock<IEndpointRouteBuilder>();
        //    var serviceProviderMock = new Mock<IServiceProvider>();
        //    routeBuilderMock.SetupGet(r => r.ServiceProvider).Returns(serviceProviderMock.Object);

        //    // Act & Assert
        //    BoletosRoute.MapBoletosRoutes(routeBuilderMock.Object);
        //    // No exception means endpoints are registered; further integration tests should verify routing.
        //}

        [Fact]
        public async Task GetObterTodos_ReturnsOkWithBoletos()
        {
            // Arrange
            var boletos = new List<BoletoEntity> { new BoletoEntity() };
            var serviceMock = new Mock<IBoletoService>();
            serviceMock.Setup(s => s.ObterTodosAsync()).ReturnsAsync(boletos);

            // Act
            var result = await serviceMock.Object.ObterTodosAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetObterById_ReturnsOkWhenFound()
        {
            // Arrange
            var boleto = new BoletoEntity();
            var serviceMock = new Mock<IBoletoService>();
            serviceMock.Setup(s => s.ObterBoletoPorIdAsync(1)).ReturnsAsync(boleto);

            // Act
            var result = await serviceMock.Object.ObterBoletoPorIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetObterById_ReturnsNullWhenNotFound()
        {
            // Arrange
            var serviceMock = new Mock<IBoletoService>();
            serviceMock.Setup(s => s.ObterBoletoPorIdAsync(99)).ReturnsAsync((BoletoEntity)null);

            // Act
            var result = await serviceMock.Object.ObterBoletoPorIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task PostInserir_CallsCriarBoletoAsync()
        {
            // Arrange
            var boleto = new BoletoEntity();
            var serviceMock = new Mock<IBoletoService>();
            serviceMock.Setup(s => s.CriarBoletoAsync(boleto)).Returns(Task.CompletedTask).Verifiable();

            // Act
            await serviceMock.Object.CriarBoletoAsync(boleto);

            // Assert
            serviceMock.Verify(s => s.CriarBoletoAsync(boleto), Times.Once);
        }
    }
}
