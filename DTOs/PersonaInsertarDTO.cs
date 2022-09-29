using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class PersonaInsertarDTO
    {
        
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroIdentidad { get; set; }
        public long Rol { get; set; }
        public int Telefono { get; set; }
    }
}
