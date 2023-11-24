using AutoMapper;
using UsuariosApi.Data.Dtos.CharacterDto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class NameProfile : Profile
{

    public NameProfile() 
    {
        CreateMap<CreateNameDto, Name>();
    }
}