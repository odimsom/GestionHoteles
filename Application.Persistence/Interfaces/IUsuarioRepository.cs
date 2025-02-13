
using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Repository;
using GestionHoteles.Domain.Result;

namespace GestionHoteles.Persistence.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, int>
    {
        Task<OperationResult> AutenticarUsuario(string correo, string contraseña);
        Task<OperationResult> CambiarContraseña(int idUsuario, string nuevaContraseña);
        Task<OperationResult> AsignarRol(int idUsuario, int idRol);
    }
}
