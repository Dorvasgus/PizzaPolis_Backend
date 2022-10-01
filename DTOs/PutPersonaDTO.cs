namespace PizzaPolis_01.DTOs
{
    public class PutPersonaDTO
    {
        //public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NumeroIdentidad { get; set; } = null!;
        public long Rol { get; set; }
        public int Telefono { get; set; }
    }
}
