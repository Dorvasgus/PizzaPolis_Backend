namespace PizzaPolis_01.DTOs
{
    public class UserToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiracion { get; set; }
    }
}
