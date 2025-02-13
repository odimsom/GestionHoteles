
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface IRolUsuarioRepository : IBaseRepository<RolUsuario, int>
    {
        Task<OperationResult> AsignarPermisos(int idRol, List<int> permisos);
    }
}
