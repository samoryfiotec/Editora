using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Infrastructure.Repositories.Interfaces
{
    public interface IFaturamentoRepository : IRepository<Faturamento>
    {
        Task AtualizarFaturamentoAsync(Faturamento entity);
    }
}
