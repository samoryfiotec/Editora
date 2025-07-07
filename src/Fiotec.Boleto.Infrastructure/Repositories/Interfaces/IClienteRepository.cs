using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Infrastructure.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task AtualizarClienteAsync(Cliente entity);
    }
}
