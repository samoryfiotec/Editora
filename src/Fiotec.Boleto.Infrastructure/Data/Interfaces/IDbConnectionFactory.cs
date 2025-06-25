using System.Data;

namespace Fiotec.Boletos.Infrastructure.Data.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
