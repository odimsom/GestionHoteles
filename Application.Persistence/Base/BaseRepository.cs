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
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "El filtro no puede ser nulo.");

            return await Entity.AnyAsync(filter);
        }


        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var result = await Entity.ToListAsync();
            return result ?? new List<TEntity>(); 
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "El filtro no puede ser nulo.");

            var operationResult = new OperationResult();
            try
            {
                var data = await Entity.Where(filter).ToListAsync();
                operationResult.Data = data;
                operationResult.Success = data.Any();
                operationResult.Message = data.Any() ? "Datos obtenidos correctamente." : "No se encontraron datos.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = $"Error al obtener los datos: {ex.Message}";
            }

            return operationResult;
        }


        public virtual async Task<TEntity> GetEntityAsync(TType id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "El ID no puede ser nulo.");

            return await Entity.FindAsync(id);
        }


        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            var operationResult = new OperationResult();
            try
            {
                Entity.Add(entity);
                await _context.SaveChangesAsync();
                operationResult.Success = true;
                operationResult.Message = "Entidad guardada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = $"Error al guardar los datos: {ex.Message}";
            }

            return operationResult;
        }


        public virtual async Task<OperationResult> UpdateEntity(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            var operationResult = new OperationResult();
            try
            {
                Entity.Update(entity);
                await _context.SaveChangesAsync();
                operationResult.Success = true;
                operationResult.Message = "Entidad actualizada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = $"Error al actualizar los datos: {ex.Message}";
            }

            return operationResult;
        }


    }

}
