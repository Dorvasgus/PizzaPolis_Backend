namespace PizzaPolis_01.DTOs
{
    public class PutFuncionarioDTO
    {
        //public int IdFuncionario { get; set; }
        public string Correo { get; set; } = null!;
        public int IdUsuario { get; set; }
        public int? Vehiculo { get; set; }
        public int IdRol { get; set; }
    }
}
