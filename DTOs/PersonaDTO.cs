using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class PersonaDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroIdentidad { get; set; }
        public long Rol { get; set; }
        public int Telefono { get; set; }

        public virtual Funcionario IdPersonaNavigation { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
