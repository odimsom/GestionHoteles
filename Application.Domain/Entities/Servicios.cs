
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHoteles.Domain.Entities
{
    public sealed class Servicios : BaseEntity<int>
    {
        [Column("IdServicio")]
        [Key]
        public override int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
