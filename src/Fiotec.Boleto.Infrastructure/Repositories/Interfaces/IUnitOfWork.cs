namespace Fiotec.Boletos.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFaturamentoRepository Faturamentos { get; }        
        Task CommitAsync();
        Task RollbackAsync();
    }
}
