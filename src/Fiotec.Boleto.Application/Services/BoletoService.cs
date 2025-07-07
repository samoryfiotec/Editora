using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;

namespace Fiotec.Boletos.Application.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BoletoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CriarBoletoAsync(Boleto boleto)
        {
            return _unitOfWork.Boletos.InserirAsync(boleto);
        }

        public async Task<Boleto> ObterBoletoPorIdAsync(int id)
        {
            return await _unitOfWork.Boletos.ObterPorId(id);
        }

        public async Task<IEnumerable<Boleto>> ObterTodosAsync()
        {
            return await _unitOfWork.Boletos.ObterTodosAsync();
        }
    }
}
