using AutoMapper;
using UsuariosApi.Data.Dtos.TypeOfMagicDto;

namespace UsuariosApi.Profiles;

public class TypeOfMagicProfile : Profile
{
    public TypeOfMagicProfile()
    {
        CreateMap<CreateTypeOfMagicDto, TypeOfMagic>();
        CreateMap<UpdateTypeOfMagicDto, TypeOfMagic>();
    }
    
}