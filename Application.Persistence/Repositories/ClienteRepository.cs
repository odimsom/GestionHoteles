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
    }
}
