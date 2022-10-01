namespace PizzaPolis_01.DTOs
{
    public class PutFacturaDTO
    {

        //public int IdFactura { get; set; }
        public DateTime? FechaHoraEmision { get; set; }
        public string Detalle { get; set; } = null!;
        public string EstadodelPedido { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public int? IdPedido { get; set; }
    }
}
