using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class VehiculoDTO
    {
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public int TipoVehiculo { get; set; }
        public string Licencia { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual TipoVehiculo TipoVehiculoNavigation { get; set; }
    }
}
