namespace PizzaPolis_01.DTOs
{
    public class UsuarioCreacionDTO
    {
       
        public string Nombre { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdRol { get; set; }
       
    }
}
