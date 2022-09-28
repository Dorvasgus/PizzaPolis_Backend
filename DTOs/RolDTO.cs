using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class RolDTO
    {
        public RolDTO()
        {
            Cliente = new HashSet<Cliente>();
            Funcionario = new HashSet<Funcionario>();
            Usuario = new HashSet<Usuario>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdRol { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Funcionario> Funcionario { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
