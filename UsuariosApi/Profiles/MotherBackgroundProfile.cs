using AutoMapper;
using UsuariosApi.Data.Dtos.BackgroundDto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class MotherBackgroundProfile : Profile
{
    
    public MotherBackgroundProfile() 
    {
        CreateMap<CreateMotherBackgroundDto, MotherBackground>();
    }
}