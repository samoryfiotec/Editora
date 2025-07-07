using System.Data;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;

namespace Fiotec.Boletos.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public ClienteRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public Task AtualizarClienteAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente?> ObterPorId(int id)
        {
            string sql = "SELECT * FROM Cliente WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id }, _transaction);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            string sql = "SELECT * FROM Cliente";
            return await _connection.QueryAsync<Cliente>(sql, transaction: _transaction);
        }
    }
}
