

using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface IEstadoHabitacionRepository : IBaseRepository<EstadoHabitacion, int>
    {
        Task<OperationResult> ActualizarEstadoHabitacion(int idHabitacion, int nuevoEstado);
    }
}
