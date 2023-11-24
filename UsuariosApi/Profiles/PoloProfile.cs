using AutoMapper;
using UsuariosApi.Data.Dtos.RegionDto;

namespace UsuariosApi.Profiles;

public class PoloProfile : Profile 
{

    public PoloProfile() 
    {
        CreateMap<CreatePoloDto, Polo>();
    }
}
