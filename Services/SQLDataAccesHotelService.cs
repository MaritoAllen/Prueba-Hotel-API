using Microsoft.EntityFrameworkCore;
using PruebaHotel.Interfaces;
using PruebaHotel.Context;
using PruebaHotel.Models;

namespace PruebaHotel.Services
{
    public class SQLDataAccesHotelService : IDataAccesHotelService
    {
        private readonly HotelContext _dbContext;

        public SQLDataAccesHotelService(HotelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Habitaciones>> GetHabitaciones(int paginaActual, int tamanoPagina)
        {
            int registrosPorSaltar = (paginaActual - 1) * tamanoPagina;

            return await _dbContext.Habitaciones
                .OrderBy(p => p.ID) // Ordena según el criterio que desees, en este caso, uso ID para un ejemplo simple.
                .Skip(registrosPorSaltar)
                .Take(tamanoPagina)
                .ToListAsync();
        }
        public async Task<IEnumerable<Reservas>> GetReservas(int paginaActual, int tamanoPagina)
        {
            int registrosPorSaltar = (paginaActual - 1) * tamanoPagina;

            return await _dbContext.Reservas
                .OrderBy(p => p.ID) // Ordena según el criterio que desees, en este caso, uso ID para un ejemplo simple.
                .Skip(registrosPorSaltar)
                .Take(tamanoPagina)
                .ToListAsync();
        }
        public async Task<Habitaciones?> GetHabitacionesByID(int? id)
        {
            if (id == null) return null;

            return await _dbContext.Habitaciones.FindAsync(id);
        }
        public async Task<Reservas?> GetReservaByID(int? id)
        {
            if (id == null) return null;

            return await _dbContext.Reservas.FindAsync(id);
        }
        public async Task<bool> CreateReserva(Reservas ?reserva)
        {
            if (reserva == null) return false;

            _dbContext.Reservas.Add(reserva);

            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteReserva(int? id)
        {
            if (id == null) return false;

            var reserva = await GetReservaByID(id);

            if (reserva == null) return false;

            _dbContext.Reservas.Remove(reserva);

            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateReserva(int? id)
        {
            if (id == null) return false;

            var reserva = GetReservaByID(id);

            if (reserva == null) return false;

            _dbContext.Entry(reserva).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
