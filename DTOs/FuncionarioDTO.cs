using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class FuncionarioDTO
    {
        public string Correo { get; set; }
        public int IdUsuario { get; set; }
        public int? Vehiculo { get; set; }
        public int IdRol { get; set; }
        public virtual PersonaDTO Persona { get; set; }
        public virtual VehiculoDTO VehiculoDTO { get; set; }
    }
}
