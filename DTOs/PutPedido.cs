namespace PizzaPolis_01.DTOs
{
    public class PutPedido
    {
        //public int IdPedido { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime? FechaHoraCreacion { get; set; }
        public DateTime? FechaHoraEntrega { get; set; }
        public int IdCliente { get; set; }
        public int Factura { get; set; }
        public int? Localidad { get; set; }
        public int? Detalle { get; set; }
    }
}
