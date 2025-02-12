﻿



using Application.Domain.Base;
using System.Linq.Expressions;

namespace Application.Domain.Repository
{
    //Interfaz que deben heredar todos los repositorios.
    public interface IBaseRepository<TEntity,Ttype> where TEntity : class
    {
        Task<TEntity> GetEntityAsync(Ttype id);
        Task UpdateEntity(TEntity entity);
        Task DeleteEntityAsync(TEntity entity);
        Task SaveEntityAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();

        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> ExistisAsync(Expression<Func<TEntity, bool>> filter);

    }
}
