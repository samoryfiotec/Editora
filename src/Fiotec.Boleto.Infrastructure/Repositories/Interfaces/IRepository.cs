namespace Fiotec.Boletos.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> ObterPorId(int id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task InserirAsync(T entity);               
    }

}
