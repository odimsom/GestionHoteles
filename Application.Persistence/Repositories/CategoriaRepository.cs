﻿

using GestionHoteles.Domain.Base;
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GestionHoteles.Persistence.Repoositories
{
    public class CategoriaRepository : BaseRepository<Categoria, int>, ICategoriaRepository
    {
        private readonly GestionHotelesContext _contex;
        private readonly ILogger<CategoriaRepository> _loguer;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(GestionHotelesContext context, ILogger<CategoriaRepository> loguer,IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override Task<OperationResult> SaveEntityAsync(Categoria entity) 
        {
            //Validar//


            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntity(Categoria entity) 
        {
            return base.UpdateEntity(entity);
        }
    }
}
