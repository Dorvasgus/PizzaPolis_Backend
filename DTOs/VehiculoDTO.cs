using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class VehiculoDTO
    {
        public string? Patente { get; set; }
        public string? Modelo { get; set; }

        public VehiculoDTO(string? modelo)
        {
            Modelo = modelo;
        }

        public int TipoVehiculo { get; set; }
        public string? Licencia { get; set; }

        public virtual TipoVehiculoDTO TipoVehiculoNavigation { get; set; }
    }
}
