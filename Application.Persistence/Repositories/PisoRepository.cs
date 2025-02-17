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
    }
}
