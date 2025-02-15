
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GestionHoteles.Persistence.Interfaces;
using GestionHoteles.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence.Repoositories
{
    public class ServicioRepository : BaseRepository<Servicios, int>, IServiciosRepository
    {
        private readonly GestionHotelesContext _context;
        private readonly ILogger<ServicioRepository> _loguer;
        private readonly IConfiguration _configuracion;

        public ServicioRepository(GestionHotelesContext context, ILogger<ServicioRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._context = context;
            this._loguer = loguer;
            this._configuracion = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public async Task<OperationResult> GetServiciosByCategoriaId(int categoriaId)
        {
            var result = new OperationResult();

            if (categoriaId <= 0)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "El ID de la categoría debe ser un valor positivo."
                };
            }
            try
            {
                var querys = await (from servicio in _context.Servicios
                                    join categoria in _context.Categorias on servicio.Id equals categoria.IdServicio
                                    where categoria.Id == categoriaId
                                    select new ServiciosCategoriaModel()
                                    {
                                        IdServicio = servicio.Id,
                                        FechaCreacion = servicio.FechaCreacion,
                                        Nombre = servicio.Nombre,
                                        Descripcion = servicio.Descripcion,
                                        IdCategoria = categoria.Id
                                    }).ToListAsync();

                if (querys == null || querys.Count == 0)
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "No se encontraron servicios para la categoría especificada."
                    };
                }

                result.Success = true;
                result.Data = querys;
            }
            catch (DbUpdateException dbEx)
            {
                result.Success = false;
                result.Message = "Error al acceder a la base de datos.";
                _loguer.LogError("Error en GetServiciosByCategoriaId (DB): {0}", dbEx.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuracion["ErrorServiciosRepository:GetServiciosCategoriaModel"] ?? "Ocurrió un error inesperado.";
                _loguer.LogError("Error en GetServiciosByCategoriaId: {0}", ex.ToString());
            }

            return result;
        }


        public override async Task<OperationResult> SaveEntityAsync(Servicios entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Nombre))
                return new OperationResult { Success = false, Message = "El nombre del servicio es obligatorio." };

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };

            return await base.SaveEntityAsync(entity);
        }
        public override async Task<OperationResult> UpdateEntity(Servicios entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Nombre))
                return new OperationResult { Success = false, Message = "El nombre del servicio es obligatorio." };

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };

            return await base.UpdateEntity(entity);
        }
    }
}
