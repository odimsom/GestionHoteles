
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
    }
}
