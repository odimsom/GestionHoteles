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
    public class PisoRepository : BaseRepository<Piso, int>, IPisoRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<PisoRepository> _loguer;
        private readonly IConfiguration _configuration;

        public PisoRepository(GestionHotelesContext context, ILogger<PisoRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };

            return await base.SaveEntityAsync(entity);
        }


        public override async Task<OperationResult> UpdateEntity(Piso entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };

            return await base.UpdateEntity(entity);
        }

    }
}
