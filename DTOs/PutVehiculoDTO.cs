namespace PizzaPolis_01.DTOs
{
    public class PutVehiculoDTO
    {
        //public int IdVehiculo { get; set; }
        public string Patente { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int TipoVehiculo { get; set; }
        public string Licencia { get; set; } = null!;
        public int? IdRol { get; set; }
    }
}
