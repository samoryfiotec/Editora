namespace Fiotec.Boletos.ConsultaAtiva
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker iniciado em: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker rodando em: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken); // Espera 10 segundos
            }
        }
    }
}
