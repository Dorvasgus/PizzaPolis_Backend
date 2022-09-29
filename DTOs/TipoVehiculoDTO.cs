using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class TipoVehiculoDTO
    {
        public TipoVehiculoDTO()
        {
            Vehiculo = new HashSet<VehiculoDTO>();
        }

        public string Nombre { get; set; }

        public virtual ICollection<VehiculoDTO> Vehiculo { get; set; }
    }
}
