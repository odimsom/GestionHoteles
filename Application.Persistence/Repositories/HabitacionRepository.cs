using GestionHoteles.Domain.Base;
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;


namespace Application.Persistence.Repoositories
{
    public class HabitacionRepository : BaseRepository<Habitacion, int>, IHabitacionRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<HabitacionRepository> _loguer;
        private readonly IConfiguration _configuration;

        public HabitacionRepository(GestionHotelesContext context, ILogger<HabitacionRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Numero))
                return new OperationResult { Success = false, Message = "El número de habitación es obligatorio." };

            if (entity.Precio <= 0)
                return new OperationResult { Success = false, Message = "El precio debe ser mayor a 0." };

            return await base.SaveEntityAsync(entity);
        }

        public override async Task<OperationResult> UpdateEntity(Habitacion entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Numero))
                return new OperationResult { Success = false, Message = "El número de habitación es obligatorio." };

            if (entity.Precio <= 0)
                return new OperationResult { Success = false, Message = "El precio debe ser mayor a 0." };

            return await base.UpdateEntity(entity);
        }

    }
}
