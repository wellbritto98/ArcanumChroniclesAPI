using AutoMapper;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class CharacterProfile : Profile
    {

        public CharacterProfile() 
        {
            CreateMap<CreateCharacterDto, Character>();
        }
    }
}
