using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class TipoVehiculoDTO
    {
        public TipoVehiculoDTO()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string Nombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
