using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;

namespace Fiotec.Boletos.Application.Services
{
    public class FaturamentoService : IFaturamentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FaturamentoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CriarFaturamentoAsync(Faturamento faturamento)
        {
            if (faturamento == null)
                throw new ArgumentNullException(nameof(faturamento), "Faturamento não pode ser nulo.");
            await _unitOfWork.Faturamentos.InserirAsync(faturamento);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Faturamento>> ObterTodosFaturamentosAsync()
        {
            return await _unitOfWork.Faturamentos.ObterTodosAsync();
        }

        public async Task<Faturamento> ObterFaturamentoPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));
            return await _unitOfWork.Faturamentos.ObterPorId(id);
        }
    }
}
