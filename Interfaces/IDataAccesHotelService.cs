using PruebaHotel.Models;

namespace PruebaHotel.Interfaces
{
    public interface IDataAccesHotelService
    {
        Task<IEnumerable<Habitaciones>> GetHabitaciones(int paginaActual, int tamanoPagina);
        Task<IEnumerable<Reservas>> GetReservas(int paginaActual, int tamanoPagina);
        Task<Reservas?> GetReservaByID(int? id);
        Task<Habitaciones?> GetHabitacionesByID(int? id);
        Task<bool> CreateReserva(Reservas? reserva);
        Task<bool> UpdateReserva(int? id);
        Task<bool> DeleteReserva(int? id);
    }
}
