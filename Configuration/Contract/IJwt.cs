using PizzaPolis_01.DTOs;

namespace PizzaPolis_01.Configuration.Contract
{
    public interface IJwt
    {
        string creartoken(UsuarioDTO usuario);
    }
}
