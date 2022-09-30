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
            CreateMap<InsertarRolDTO, Rol>();
            CreateMap<ActualizarClienteDTO, Cliente>();
            CreateMap<Funcionario, FuncionarioDTO>();
            CreateMap<UsuarioCreacionDTO, Usuario>();
            CreateMap<LocalidadInsertarDTO, Localidad>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Pedido, PedidoDTO>();
            CreateMap<Factura, FacturaDTO>();


            CreateMap<ClienteInsertarDTO, Cliente>();
        }
    }
}
