namespace PizzaPolis_01.DTOs
{
    public class FacturaInsertarDTO
    {
        public DateTime? FechaHoraEmision { get; set; }
        public string Detalle { get; set; }
        public string EstadodelPedido { get; set; }
        public string Nit { get; set; }
        public int? IdPedido { get; set; }
    }
}
