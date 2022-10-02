using AutoMapper;
using PizzaPolis_01.DTOs;
using PizzaPolis_01.Models;

namespace PizzaPolis_01.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // mapeo general para las personas

            CreateMap<Persona, PersonaDTO>();
            // mapeo general para las vehiculo

            CreateMap<Vehiculo, VehiculoDTO>();
            CreateMap<Cliente, ClienteDTO>();

            CreateMap<Rol, RolDTO>();
            //mapeo InsertarRolDTO, Rol
            CreateMap<PutRol, Rol>();
            CreateMap<PutLocalidadDTO, Localidad>();
            CreateMap<PutTipoVDTO, TipoVehiculo>();
            CreateMap<PutVehiculoDTO, Vehiculo>();
            CreateMap < PutPedido, Pedido > ();
            CreateMap<PutPersonaDTO, Persona> ();
            CreateMap<PutCliente, Cliente>();
            CreateMap<PutFacturaDTO, Factura>();
            CreateMap<PutFuncionarioDTO, Funcionario>();
            CreateMap<PutProducto, Productos>();
            CreateMap<PutUsuario, Usuario>();
            CreateMap<ActualizarClienteDTO, Cliente>();
            CreateMap<Funcionario, FuncionarioDTO>();
            CreateMap<UsuarioCreacionDTO, Usuario>();

            CreateMap<InsertarProductoDTO, Productos>();
            CreateMap<InsertarVehiculoDTO,Vehiculo> ();
            CreateMap<FacturaInsertarDTO, Factura> ();
            CreateMap<PedidoInsertarDTO, Pedido> ();
            CreateMap<InsertarVehiculoDTO, Funcionario> ();

            CreateMap<LocalidadInsertarDTO, Localidad>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Pedido, PedidoDTO>();
            CreateMap<Factura, FacturaDTO>();


            CreateMap<ClienteInsertarDTO, Cliente>();
        }
    }
}
