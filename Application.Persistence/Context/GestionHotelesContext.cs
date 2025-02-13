using GestionHoteles.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GestionHoteles.Persistence.Context
{
    public class GestionHotelesContext : DbContext
    {
        public GestionHotelesContext(DbContextOptions<GestionHotelesContext> option) : base(option)
        {
             
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitacions { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Piso> Pisos { get; set; }
        public DbSet<Recepcion> Recepcions { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
