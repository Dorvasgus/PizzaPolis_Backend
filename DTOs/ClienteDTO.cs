using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class ClienteDTO
    {
        public string Nit { get; set; }
        public int IdRol { get; set; }

        public virtual Persona IdClienteNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
