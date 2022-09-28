using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class FuncionarioDTO
    {
        public FuncionarioDTO()
        {
            Personas = new HashSet<PersonaDTO>();
        }

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int Vehiculo { get; set; }

        public virtual VehiculoDTO VehiculoNavigation { get; set; } = null!;
        public virtual ICollection<PersonaDTO> Personas { get; set; }
    }
}
