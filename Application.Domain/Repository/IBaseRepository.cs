using GestionHoteles.Domain.Result;
using System.Linq.Expressions;

namespace GestionHoteles.Domain.Repository
{
    /// <summary>
    /// Interfaz que deben heredar todos los repositorios.
    /// </summary>
    /// <typeparam name="TEntity">entidad que debe ser un clase</typeparam>
    /// <typeparam name="Ttype">tipo de dato de esta clase</typeparam>
    public interface IBaseRepository<TEntity,Ttype> where TEntity : class
    {
        Task<TEntity> GetEntityAsync(Ttype id);
        Task<OperationResult> UpdateEntity(TEntity entity);
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    }
}
