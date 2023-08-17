using Microsoft.EntityFrameworkCore;
using PruebaHotel.Models;

namespace PruebaHotel.Context
{
    public class HotelContext : DbContext
    {
        // Constructor que recibe las opciones de configuración del contexto.
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
    }
}
