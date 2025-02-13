
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHoteles.Domain.Entities
{
    public sealed class Categoria : BaseEntity<int>
    {
        [Column("IdCategoria")]
        [Key]
        public override int Id { get ; set ; }
        public string Descripcion { get; set; }

        public int IdServicio { get; set; }
    }
}
