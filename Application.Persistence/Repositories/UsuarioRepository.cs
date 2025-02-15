
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Persistence.Repoositories
{
    public class UsuarioRepository : BaseRepository<Usuario,int>, IUsuarioRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<UsuarioRepository> _loguer;
        private readonly IConfiguration _configuration;

        public UsuarioRepository(GestionHotelesContext context, ILogger<UsuarioRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.NombreCompleto))
                return new OperationResult { Success = false, Message = "El nombre completo es obligatorio." };

            if (string.IsNullOrWhiteSpace(entity.Correo) || !entity.Correo.Contains("@"))
                return new OperationResult { Success = false, Message = "El correo debe ser válido." };

            if (entity.IdRolUsuario <= 0)
                return new OperationResult { Success = false, Message = "El ID del rol de usuario es obligatorio." };

            return await base.SaveEntityAsync(entity);
        }


        public override async Task<OperationResult> UpdateEntity(Usuario entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            if (string.IsNullOrWhiteSpace(entity.NombreCompleto))
                return new OperationResult { Success = false, Message = "El nombre completo es obligatorio." };

            if (string.IsNullOrWhiteSpace(entity.Correo) || !entity.Correo.Contains("@"))
                return new OperationResult { Success = false, Message = "El correo debe ser válido." };

            if (entity.IdRolUsuario <= 0)
                return new OperationResult { Success = false, Message = "El ID del rol de usuario es obligatorio." };

            return await base.UpdateEntity(entity);
        }

    }
}
