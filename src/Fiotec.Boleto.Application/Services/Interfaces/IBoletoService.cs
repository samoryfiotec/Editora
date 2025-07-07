using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Application.Services.Interfaces
{
    public interface IBoletoService
    {
        Task CriarBoletoAsync(Boleto boleto);
        Task<IEnumerable<Boleto>> ObterTodosAsync();
        Task<Boleto> ObterBoletoPorIdAsync(int id);
    }
}
