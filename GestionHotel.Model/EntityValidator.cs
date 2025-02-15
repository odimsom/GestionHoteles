using GestionHoteles.Domain.Entities;
using GestionHoteles.Domain.Result;

namespace GestionHotel
{
    public static class EntityValidator
    {
        public static OperationResult ValidateCategoria(Categoria entity)
        {
            var result = new OperationResult { Success = true };

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripción no puede estar vacía.";
                return result;
            }

            if (entity.Descripcion.Length > 50)
            {
                result.Success = false;
                result.Message = "La descripción no puede tener más de 50 caracteres.";
                return result;
            }

            return result;
        }

        public static OperationResult ValidateEstadoHabitacion(EstadoHabitacion entity)
        {
            var result = new OperationResult { Success = true };

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripción no puede estar vacía.";
                return result;
            }

            return result;
        }
    }
}
