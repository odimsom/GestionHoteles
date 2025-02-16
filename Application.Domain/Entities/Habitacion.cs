﻿
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionHoteles.Domain.Entities
{
    public sealed class Habitacion : BaseEntity<int>
    {
        [Column("IdHabitacion")]
        [Key]
        public override int Id { get; set; }
        public string Numero { get; set; }
        public string? Detalle { get; set; }
        public double Precio { get; set; }
        public int IdEstadoHabitacion { get; set; }
        public int IdPiso { get; set; }
        public int IdCategoria { get; set; }



    }
}
