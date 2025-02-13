
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionHoteles.Domain.Entities
{
    public sealed class Piso : BaseEntity<int>
    {
        [Column("IdPiso")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }

    }
}
