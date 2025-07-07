using System.Data;
using Fiotec.Boletos.Infrastructure.Data.Interfaces;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;

namespace Fiotec.Boletos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        public IFaturamentoRepository Faturamentos { get; }
        public IClienteRepository Clientes { get;  }
        public IBoletoRepository Boletos { get; }

        public UnitOfWork(IDbConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            Faturamentos = new FaturamentoRepository(_connection, _transaction);
            Clientes = new ClienteRepository(_connection, _transaction);
            Boletos = new BoletoRepository(_connection, _transaction);

        }

        public async Task CommitAsync()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _connection?.Close();
                _connection?.Dispose();
            }

            await Task.CompletedTask;
        }

        public async Task RollbackAsync()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _connection?.Close();
                _connection?.Dispose();
            }

            await Task.CompletedTask;
        }


        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
