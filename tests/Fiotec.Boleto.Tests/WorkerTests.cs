using Fiotec.Boletos.ConsultaAtiva;
using Microsoft.Extensions.Logging;
using Moq;

namespace Fiotec.Boletos.Tests
{
    public class WorkerTests
    {
        [Fact]
        public async Task ExecuteAsync_LogStartExecucaoLaco()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Worker>>();
            var worker = new Worker(loggerMock.Object);

            using var cts = new CancellationTokenSource();
            cts.CancelAfter(150); // Cancela após um curto atraso

            // Act
            await worker.StartAsync(cts.Token);

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Worker iniciado em")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);

            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Worker rodando em")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.AtLeastOnce);
        }
    }
}
