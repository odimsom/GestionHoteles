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
    public class RolUsuarioRepository : BaseRepository<RolUsuario, int>, IRolUsuarioRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<RolUsuarioRepository> _loguer;
        private readonly IConfiguration _configuration;

        public RolUsuarioRepository(GestionHotelesContext context, ILogger<RolUsuarioRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(RolUsuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };

            return await base.SaveEntityAsync(entity);
        }


        public override async Task<OperationResult> UpdateEntity(RolUsuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripción es obligatoria." };

            return await base.UpdateEntity(entity);
        }

    }
}
