using AutoMapper;
using UsuariosApi.Data.Dtos.CharacterDto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class SurnameProfile : Profile
{

    public SurnameProfile() 
    {
        CreateMap<CreateSurnameDto, Surname>();
    }
}