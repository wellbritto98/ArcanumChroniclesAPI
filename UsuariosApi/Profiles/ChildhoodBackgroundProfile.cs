using AutoMapper;
using UsuariosApi.Data.Dtos.BackgroundDto;

namespace UsuariosApi.Profiles;

public class ChildhoodBackgroundProfile : Profile
{
    
    public ChildhoodBackgroundProfile() 
    {
        CreateMap<CreateChildhoodBackgroundDto, ChildhoodBackground>();
    }
}