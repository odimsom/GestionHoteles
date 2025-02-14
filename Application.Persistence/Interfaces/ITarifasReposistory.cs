
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface ITarifasReposistory : IBaseRepository<Tarifas, int>
    {
        //Task<OperationResult> AsignarTarifaAHabitacion(int idHabitacion, int idTarifa);
    }
}
