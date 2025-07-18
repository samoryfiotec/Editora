using System.Data;
using Dapper;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fiotec.Boletos.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        private readonly ILogger<BoletoRepository> _logger;

        public ClienteRepository(IDbConnection connection, IDbTransaction transaction, ILogger<BoletoRepository> logger)
        {
            _connection = connection;
            _transaction = transaction;
            _logger = logger;
        }

        public async Task AtualizarClienteAsync(Cliente entity)
        {
            string sql = @"UPDATE Cliente 
                           SET Nome = @Nome, 
                               Cpf = @Cpf, 
                               Email = @Email, 
                               Telefone = @Telefone, 
                               EnderecoId = @EnderecoId
                           WHERE Id = @Id";

            try
            {
                await _connection.ExecuteAsync(sql, new
                {
                    Id = entity.Id,
                    Nome = entity.Nome,
                    Cpf = entity.Cpf,
                    Email = entity.Email,
                    Telefone = entity.Telefone,
                    EnderecoId = entity.Endereco.Id
                }, _transaction);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Deu erro ao atualizar!");
                throw;
            }

            
        }

        public async Task InserirAsync(Cliente entity)
        {
            string sql = @"INSERT INTO Cliente (Nome, Cpf, Email, Telefone, EnderecoId)
                           VALUES (@Nome, @Cpf, @Email, @Telefone, @EnderecoId);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
            try
            {
                var id = await _connection.QuerySingleAsync<int>(sql, new
                {
                    Nome = entity.Nome,
                    Cpf = entity.Cpf,
                    Email = entity.Email,
                    Telefone = entity.Telefone,
                    EnderecoId = entity.Endereco.Id
                }, _transaction);

                entity.Id = id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar cliente com ID {ClienteId}", id);
                throw;
            }
        }

        public async Task<Cliente?> ObterPorId(int id)
        {
            try
            {
                _logger.LogInformation("Buscando boleto com ID {BoletoId}", id);
                string sql = "SELECT * FROM Cliente WHERE Id = @Id";
                var cliente = await _connection.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id }, _transaction);
                if (cliente == null)
                {
                    _logger.LogWarning("Nenhum cliente encontrado com ID {ClienteId}", id);
                }
                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar cliente com ID {ClienteId}", id);
                throw;
            }            
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            try
            {
                string sql = "SELECT * FROM Cliente";
                var clientes =  await _connection.QueryAsync<Cliente>(sql, transaction: _transaction);
                if(clientes == null)
                {
                    _logger.LogWarning("Nenhum cliente retornado!");
                }
                return clientes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar clientes!'");
                throw;
            }
            
        }
    }
}
