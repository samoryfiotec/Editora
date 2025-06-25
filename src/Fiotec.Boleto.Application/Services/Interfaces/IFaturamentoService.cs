using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Application.Services.Interfaces
{
    public interface IFaturamentoService
    {
        Task CriarFaturamentoAsync(Faturamento faturamento);
        Task<IEnumerable<Faturamento>> ObterTodosFaturamentosAsync();
        Task<Faturamento> ObterFaturamentoPorIdAsync(int id);
    }
}
