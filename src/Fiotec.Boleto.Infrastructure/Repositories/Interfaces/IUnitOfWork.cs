namespace Fiotec.Boletos.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFaturamentoRepository Faturamentos { get; }            
        IClienteRepository Clientes { get; }
        IBoletoRepository Boletos { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
