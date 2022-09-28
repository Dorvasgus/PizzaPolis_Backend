using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class PersonaDTO
    {
        public PersonaDTO()
        {
            Pedidos = new HashSet<PedidoDTO>();
        }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NumeroIdentidad { get; set; } = null!;
        public int Rol { get; set; }
        public int Telefono { get; set; }

        public virtual ClienteDTO IdPersonaNavigation { get; set; } = null!;
        public virtual FuncionarioDTO RolNavigation { get; set; } = null!;
        public virtual ICollection<PedidoDTO> Pedidos { get; set; }
    }
}
