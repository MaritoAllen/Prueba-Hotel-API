using Microsoft.AspNetCore.Mvc;
using PruebaHotel.Interfaces;
using PruebaHotel.Models;
using PruebaHotel.Services;

namespace PruebaHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IDataAccesHotelService _dataAccessPedidosService;

        public HotelController(IDataAccesHotelService dataAccessPedidosService)
        {
            _dataAccessPedidosService = dataAccessPedidosService;
        }

        [HttpGet]
        [Route("Habitaciones")]
        public async Task<IActionResult> GetHabitaciones(int paginaActual = 1, int tamanoPagina = 20)
        {
            var pedidos = await _dataAccessPedidosService.GetHabitaciones(paginaActual, tamanoPagina);
            return Ok(pedidos);
        }

        [HttpPost]
        [Route("Reserva")]
        public async Task<IActionResult> PostReserva([FromBody] Reservas reserva)
        {
            if (reserva == null)
            {
                return BadRequest("Los datos de la reserva son inválidos.");
            }

            var result = await _dataAccessPedidosService.CreateReserva(reserva);

            if(!result)
            {
                return BadRequest("No se pudo crear la reserva.");
            }

            return Ok("Reserva creada exitosamente");
        }
    }
}
