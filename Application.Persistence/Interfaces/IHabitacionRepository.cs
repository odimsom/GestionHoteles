

using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion, int>
    {
        //Task<OperationResult> ConsultarDisponibilidad(int idHabitacion, DateTime fechaInicio, DateTime fechaFin);
        //Task<OperationResult> AsignarCategoria(int idHabitacion, int idCategoria);
    }
}
