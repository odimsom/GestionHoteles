
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionHoteles.Domain.Entities
{
    public sealed class RolUsuario : BaseEntity<int>
    {
        [Column("IdRolUsuario")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
