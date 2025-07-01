using ServiceReference;

namespace Fiotec.Boletos.Infrastructure.SAP.Interface
{
    public interface ISapService
    {
        Task<Retorno_Lista_Clientes> ObterCliente(string codigo);
    }
}
