namespace PruebaHotel.Models
{
    public class Reservas
    {
        public int ID { get; set; }
        public int IDHabitacion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public string observaciones { get; set; }
        public string cliente { get; set; }
    }
    public class Habitaciones
    {
        public int ID { get; set; }
        public int IDTipo { get; set; }
        public string ?Comentarios { get; set; }
        public string Precio { get; set; }
        public int Disponible { get; set; }
    }
}
