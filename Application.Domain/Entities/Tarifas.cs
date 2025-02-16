﻿
using GestionHoteles.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionHoteles.Domain.Entities
{
    public sealed class Tarifas : BaseEntity<int>
    {
        [Column("IdTarifa")]
        [Key]
        public override int Id { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double PrecioPorNoche { get; set; }
        public int Descuento { get; set; }
        public string Descripcion { get; set; }
    }
}
