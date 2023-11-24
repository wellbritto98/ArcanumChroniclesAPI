using AutoMapper;
using UsuariosApi.Data.Dtos.BackgroundDto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class FatherBackgroundProfile : Profile
{
    public FatherBackgroundProfile()
    {
        CreateMap<CreateFatherBackgroundDto, FatherBackground>();
    }
}