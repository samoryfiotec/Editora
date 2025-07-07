using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;

namespace Fiotec.Boletos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AtualizarClienteAsync(Cliente cliente)
        {
            var a = await _unitOfWork.Clientes.ObterPorId(cliente.Id);
            return a.Id;
        }

        public async Task CriarClienteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> ObterPorIdAsync(int id)
        {
            return await _unitOfWork.Clientes.ObterPorId(id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _unitOfWork.Clientes.ObterTodosAsync();
        }
    }
}
