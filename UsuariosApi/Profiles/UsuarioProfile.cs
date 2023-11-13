using AutoMapper;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {

        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
