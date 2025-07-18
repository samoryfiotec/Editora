using System.Data;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fiotec.Boletos.Infrastructure.Repositories
{
    public class FaturamentoRepository : IFaturamentoRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        private readonly ILogger<BoletoRepository> _logger;

        public FaturamentoRepository(IDbConnection connection, IDbTransaction transaction, ILogger<BoletoRepository> logger)
        {
            _connection = connection;
            _transaction = transaction;
            _logger = logger;
        }

        public Task<Faturamento?> ObterPorId(int id)
        {
            string sql = "SELECT * FROM Faturamento WHERE Id = @Id";
            return _connection.QueryFirstOrDefaultAsync<Faturamento>(sql, new { Id = id }, _transaction);
        }

        public Task<IEnumerable<Faturamento>> ObterTodosAsync()
        {
            string sql = "SELECT * FROM Faturamento";
            return _connection.QueryAsync<Faturamento>(sql, transaction: _transaction);
        }

        public Task InserirAsync(Faturamento entity)
        {
            const string sql = "INSERT INTO Faturamento (Data, Valor, Cliente_id) VALUES (@Data, @Valor, @ClienteId)";
            return _connection.ExecuteAsync(sql, new
            {
                Data = entity.Data,
                Valor = entity.Valor,
                ClienteId = entity.Cliente.Id
            }, _transaction);
        }

        public Task AtualizarFaturamentoAsync(Faturamento entity)
        {
            string sql = "UPDATE Faturamento SET Data = @Data, Valor = @Valor, Cliente_id = @ClienteId WHERE Id = @Id";
            return _connection.ExecuteAsync(sql, new
            {
                entity.Id,
                entity.Data,
                entity.Valor,
                ClienteId = entity.Cliente.Id
            }, _transaction);
        }
    }
}
