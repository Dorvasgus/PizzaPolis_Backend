namespace PizzaPolis_01.DTOs
{
    public class PutProducto
    {
       // public int Id { get; set; }
        public string NombreProd { get; set; } = null!;
        public string DetalleProd { get; set; } = null!;
        public double PrecioProd { get; set; }
    }
}

