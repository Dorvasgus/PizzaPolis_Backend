namespace PizzaPolis_01.DTOs
{
    public class PutUsuario
    {
        //public int Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int IdRol { get; set; }
        public bool Estado { get; set; }
    }
}
