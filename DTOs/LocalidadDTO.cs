using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class LocalidadDTO
    {
        

        public int IdLocalidad { get; set; }
        public string Calle { get; set; }
        public string Barrio { get; set; }
        public string Zona { get; set; }
        public virtual PersonaDTO Persona { get; set; }

    }
}
