using System.Data;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fiotec.Boletos.Infrastructure.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        private readonly ILogger<BoletoRepository> _logger;

        public BoletoRepository(IDbConnection connection, IDbTransaction transaction, ILogger<BoletoRepository> logger)
        {
            _connection = connection;
            _transaction = transaction;
            _logger = logger;
        }

        public async Task<Boleto?> ObterPorId(int id)
        {
            try
            {
                _logger.LogInformation("Buscando boleto com ID {BoletoId}", id);
                string sql = "SELECT * FROM Boleto WHERE Id = @Id";
                var boleto = await _connection.QueryFirstOrDefaultAsync<Boleto>(sql, new { Id = id }, _transaction);
                if (boleto == null)
                {
                    _logger.LogWarning("Nenhum boleto encontrado com ID {BoletoId}", id);
                }
                return boleto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar boleto com ID {BoletoId}", id);
                throw;
            }            
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
