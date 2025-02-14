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
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion, int>, IEstadoHabitacionRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<EstadoHabitacionRepository> _loguer;
        private readonly IConfiguration _configuration;

        public EstadoHabitacionRepository(GestionHotelesContext context, ILogger<EstadoHabitacionRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }


        public override Task<OperationResult> SaveEntityAsync(EstadoHabitacion entity)
        {
            //agregar las validaciones//


            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntity(EstadoHabitacion entity)
        {
            return base.UpdateEntity(entity);
        }
    }
}
