using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace GestionHoteles.Persistence.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente, int>, IClienteRepository
    {
        private readonly GestionHotelesContext _context;
        private readonly ILogger<ClienteRepository> _logger;
        private readonly IConfiguration _configuration;

        public ClienteRepository(GestionHotelesContext context, ILogger<ClienteRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "El logger no puede ser nulo.");
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "La configuración no puede ser nula.");
        }

        public override async Task<OperationResult> SaveEntityAsync(Cliente entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            var validationErrors = ValidateCliente(entity);
            if (validationErrors.Count > 0)
                return new OperationResult { Success = false, Message = string.Join(" | ", validationErrors) };

            return await base.SaveEntityAsync(entity);
        }

        public override async Task<OperationResult> UpdateEntity(Cliente entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            var validationErrors = ValidateCliente(entity);
            if (validationErrors.Count > 0)
                return new OperationResult { Success = false, Message = string.Join(" | ", validationErrors) };

            return await base.UpdateEntity(entity);
        }

        private List<string> ValidateCliente(Cliente entity)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(entity.TipoDocumento) || entity.TipoDocumento.Length > 20)
                errors.Add("El tipo de documento es obligatorio y no debe exceder los 20 caracteres.");

            if (string.IsNullOrWhiteSpace(entity.Documento) || entity.Documento.Length > 15)
                errors.Add("El documento es obligatorio y no debe exceder los 15 caracteres.");

            if (string.IsNullOrWhiteSpace(entity.NombreCompleto) || entity.NombreCompleto.Length > 100)
                errors.Add("El nombre completo es obligatorio y no debe exceder los 100 caracteres.");

            if (string.IsNullOrWhiteSpace(entity.Correo) || !new EmailAddressAttribute().IsValid(entity.Correo))
                errors.Add("El correo es obligatorio y debe tener un formato válido.");

            return errors;
        }
    }
}
