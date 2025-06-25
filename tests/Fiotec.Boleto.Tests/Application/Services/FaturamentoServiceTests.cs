using Fiotec.Boletos.Application.Services;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;
using Moq;

namespace Fiotec.Boleto.Tests.Application.Services
{
    public class FaturamentoServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IFaturamentoRepository> _faturamentoRepoMock;
        private readonly FaturamentoService _service;

        public FaturamentoServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _faturamentoRepoMock = new Mock<IFaturamentoRepository>();
            _unitOfWorkMock.SetupGet(u => u.Faturamentos).Returns(_faturamentoRepoMock.Object);
            _service = new FaturamentoService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task CriarFaturamentoAsync_DeveAdicionarEFazerCommit()
        {
            // Arrange
            var cliente = new Cliente();
            var faturamento = new Faturamento(DateTime.Now, 100m, cliente);

            // Act
            await _service.CriarFaturamentoAsync(faturamento);

            // Assert
            _faturamentoRepoMock.Verify(r => r.InserirAsync(faturamento), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task CriarFaturamentoAsync_FaturamentoNulo_DeveLancarArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CriarFaturamentoAsync(null));
        }

        [Fact]
        public async Task ObterTodosFaturamentosAsync_DeveRetornarTodosFaturamentos()
        {
            // Arrange
            var lista = new List<Faturamento> { new Faturamento(), new Faturamento() };
            _faturamentoRepoMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(lista);

            // Act
            var result = await _service.ObterTodosFaturamentosAsync();

            // Assert
            Assert.Equal(lista, result);
        }

        [Fact]
        public async Task ObterFaturamentoPorIdAsync_IdValido_DeveRetornarFaturamento()
        {
            // Arrange
            var faturamento = new Faturamento();
            _faturamentoRepoMock.Setup(r => r.ObterPorId(1)).ReturnsAsync(faturamento);

            // Act
            var result = await _service.ObterFaturamentoPorIdAsync(1);

            // Assert
            Assert.Equal(faturamento, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ObterFaturamentoPorIdAsync_IdInvalido_DeveLancarArgumentException(int id)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ObterFaturamentoPorIdAsync(id));
        }
    }
}
