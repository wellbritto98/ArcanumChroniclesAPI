using AutoMapper;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CreateCharacterDto, Character>();
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dest => dest.CurrentLocationName, opt => opt.MapFrom(src => src.CurrentLocation.Name))
                .ForMember(dest => dest.CurrentLocationPoloName,
                    opt => opt.MapFrom(src => src.CurrentLocation.Polo.Name))
                .ForMember(dest => dest.WayOfMagicName, opt => opt.MapFrom(src => src.WayOfMagic.Name));
        }
    }
}