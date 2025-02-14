using GestionHoteles.Domain.Result;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionHoteles.Persistence.Base
{
    public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : class
    {
        private readonly GestionHotelesContext _context;
        private DbSet<TEntity> Entity { get; set; }
        private OperationResult OperationResult { get; set; }

        protected BaseRepository(GestionHotelesContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
            OperationResult = new OperationResult();
        }

        public virtual async Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entity.AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            try{
                var data = Entity.Where(filter).ToListAsync();
                OperationResult.Data = data;
            }catch(Exception)
            {
                OperationResult.Success = false;
                OperationResult.Message = "error al optener los datos";
            }
            return OperationResult;
        }

        public virtual async Task<TEntity> GetEntityAsync(TType id)
        {
                return await Entity.FindAsync(id); 
        }

        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            try
            {
                Entity.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch(Exception) 
            {
                OperationResult.Success = false;
                OperationResult.Message = "Ocurio un error guardadndo los datos";
            }

            return OperationResult;
        }

        public virtual async Task<OperationResult> UpdateEntity(TEntity entity)
        {
            try
            {
                Entity.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                OperationResult.Success = false;
                OperationResult.Message = "Ocurio un error guardadndo los datos";
            }
            return OperationResult;
        }

    }

}
