using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task CriarClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente> ObterPorIdAsync(int id);
        Task<int> AtualizarClienteAsync(Cliente cliente);
    }
}
