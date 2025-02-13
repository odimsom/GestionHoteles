
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHoteles.Domain.Entities
{
    public sealed class EstadoHabitacion : BaseEntity<int>
    {
        [Column("IdEstadoHabitacion")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
