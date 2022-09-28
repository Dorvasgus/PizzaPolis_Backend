using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class ClienteDTO
    {
        public string Nit { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Localidad { get; set; }

        public virtual LocalidadDTO LocalidadNavigation { get; set; } = null!;
        public virtual PersonaDTO? Persona { get; set; }
    }
}
