

using GestionHoteles.Domain.Entities;
using GestionHoteles.Persistence.Base;
using GestionHoteles.Persistence.Context;
using GestionHoteles.Persistence.Interfaces;

namespace GestionHoteles.Persistence.Repositories
{
    public class CategoriaRepository(GestionHotelesContext context) : BaseRepository<Categoria, int>(context), ICategoriaRepository
    {

    }
}
