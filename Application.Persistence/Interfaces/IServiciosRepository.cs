

using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface IServiciosRepository : IBaseRepository<Servicios, int>
    {
        //Task<OperationResult> AsignarServicioAHabitacion(int idHabitacion, int idServicio);
        Task<OperationResult> GetServiciosByCategoriaId(int CategoriaId);
    }
}
