namespace PizzaPolis_01.DTOs
{
    public class PedidoInsertarDTO
    {
        public DateTime? FechaHoraCreacion { get; set; }
        public DateTime? FechaHoraEntrega { get; set; }
        public int Factura { get; set; }
        public int? Localidad { get; set; }
        public int? Detalle { get; set; }
    }
}
