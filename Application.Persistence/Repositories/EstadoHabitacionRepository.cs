using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GestionHoteles.Persistence.Repositories
{
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion, int>, IEstadoHabitacionRepository
    {
        private readonly GestionHotelesContext _context;
        private readonly ILogger<EstadoHabitacionRepository> _logger;
        private readonly IConfiguration _configuration;

        public EstadoHabitacionRepository(GestionHotelesContext context, ILogger<EstadoHabitacionRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "El logger no puede ser nulo.");
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "La configuración no puede ser nula.");
        }


        public override async Task<OperationResult> SaveEntityAsync(EstadoHabitacion entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };


            return await base.SaveEntityAsync(entity);
        }


        public override async Task<OperationResult> UpdateEntity(EstadoHabitacion entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };


            return await base.UpdateEntity(entity);
        }
    }
}
