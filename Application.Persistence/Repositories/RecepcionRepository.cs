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
    public class RecepcionRepository : BaseRepository<Recepcion, int>, IRecepcionRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<RecepcionRepository> _loguer;
        private readonly IConfiguration _configuration;

        public RecepcionRepository(GestionHotelesContext context, ILogger<RecepcionRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Recepcion entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (entity.IdCliente <= 0)
                return new OperationResult { Success = false, Message = "El ID del cliente es obligatorio." };

            if (entity.IdHabitacion <= 0)
                return new OperationResult { Success = false, Message = "El ID de la habitación es obligatorio." };

            if (entity.FechaEntrada >= entity.FechaSalida)
                return new OperationResult { Success = false, Message = "La fecha de entrada debe ser menor que la de salida." };

            return await base.SaveEntityAsync(entity);
        }


        public override async Task<OperationResult> UpdateEntity(Recepcion entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (entity.IdCliente <= 0)
                return new OperationResult { Success = false, Message = "El ID del cliente es obligatorio." };

            if (entity.IdHabitacion <= 0)
                return new OperationResult { Success = false, Message = "El ID de la habitación es obligatorio." };

            if (entity.FechaEntrada >= entity.FechaSalida)
                return new OperationResult { Success = false, Message = "La fecha de entrada debe ser menor que la de salida." };

            return await base.UpdateEntity(entity);
        }

    }
}
