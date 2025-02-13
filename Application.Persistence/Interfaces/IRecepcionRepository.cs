

using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion, int>
    {
        Task<OperationResult> RegistrarEntradaCliente(int idCliente, int idHabitacion);
        Task<OperationResult> RegistrarSalidaCliente(int idCliente, int idHabitacion);
    }
}
