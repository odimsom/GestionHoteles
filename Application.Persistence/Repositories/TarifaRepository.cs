
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Application.Persistence.Repoositories
{
    public class TarifaRepository : BaseRepository<Tarifas, int>, ITarifasReposistory
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<TarifaRepository> _loguer;
        private readonly IConfiguration _configuration;

        public TarifaRepository(GestionHotelesContext context, ILogger<TarifaRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Tarifas entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (entity.IdHabitacion <= 0)
                return new OperationResult { Success = false, Message = "El ID de la habitación es obligatorio." };

            if (entity.FechaInicio >= entity.FechaFin)
                return new OperationResult { Success = false, Message = "La fecha de inicio debe ser menor que la fecha de fin." };

            if (entity.PrecioPorNoche <= 0)
                return new OperationResult { Success = false, Message = "El precio por noche debe ser mayor a 0." };

            return await base.SaveEntityAsync(entity);
        }

        public override async Task<OperationResult> UpdateEntity(Tarifas entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (entity.IdHabitacion <= 0)
                return new OperationResult { Success = false, Message = "El ID de la habitación es obligatorio." };

            if (entity.FechaInicio >= entity.FechaFin)
                return new OperationResult { Success = false, Message = "La fecha de inicio debe ser menor que la fecha de fin." };

            if (entity.PrecioPorNoche <= 0)
                return new OperationResult { Success = false, Message = "El precio por noche debe ser mayor a 0." };

            return await base.UpdateEntity(entity);
        }

    }
}
