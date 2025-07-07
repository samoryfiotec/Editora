using System.Data;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;

namespace Fiotec.Boletos.Infrastructure.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public BoletoRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<Boleto?> ObterPorId(int id)
        {
            string sql = "SELECT * FROM Boleto WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Boleto>(sql, new { Id = id }, _transaction);
        }

        public async Task<IEnumerable<Boleto>> ObterTodosAsync()
        {
            string sql = @"
                SELECT 
                    b.Id, b.Numero, b.Valor, b.Vencimento, b.status_id, b.faturamento_id,
                    s.Id AS StatusId, s.Descricao,                    
                    f.Id AS FaturamentoId, f.Data, f.Valor
                FROM Boleto b
                INNER JOIN Status s ON b.status_id = s.Id
                INNER JOIN Faturamento f ON b.faturamento_id = f.Id";

            var boletos = await _connection.QueryAsync<Boleto, Status, Faturamento, Boleto>(
                sql,
                (boleto, status, faturamento) =>
                {
                    boleto.Status = status;
                    boleto.Faturamento = faturamento;
                    return boleto;
                },
                transaction: _transaction,
                splitOn: "StatusId,FaturamentoId"
            );

            return boletos;
        }

        public Task InserirAsync(Boleto entity)
        {
            const string sql = "INSERT INTO Boleto (Numero, Valor, Vencimento, StatusId, EmissorId, FaturamentoId) " +
                               "VALUES (@Numero, @Valor, @Vencimento, @StatusId, @EmissorId, @FaturamentoId)";
            return _connection.ExecuteAsync(sql, new
            {
                entity.Numero,
                entity.Valor,
                entity.Vencimento,
                entity.StatusId,
                EmissorId = entity.Emissor.Id,
                FaturamentoId = entity.Faturamento.Id
            }, _transaction);
        }
    }
}
