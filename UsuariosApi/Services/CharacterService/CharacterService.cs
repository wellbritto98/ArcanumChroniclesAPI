using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Services.CharacterService
{


    public class CharacterService
    {
        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<UsuariosApi.Models.Usuario> _userManager;
        private readonly ACDbContext _context; // Substitua MeuDbContext pelo nome real do seu DbContext

        public CharacterService(IMapper mapper, IHttpContextAccessor httpContextAccessor, ACDbContext context, UserManager<Models.Usuario> userManager)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResponse> CriaPersonagem(CreateCharacterDto dto)
        {
            try
            {
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue("id");
                var usuario = await _userManager.FindByIdAsync(userId);
                Character character = _mapper.Map<Character>(dto);

                character.Name = character.Name;
                character.Surname = character.Surname;
                character.UsuarioId = userId;
                character.Gender = character.Gender;
                character.BirthDate = DateTime.UtcNow;
                character.FatherBackgroundId = character.FatherBackgroundId;
                character.MotherBackgroundId = character.MotherBackgroundId;
                character.ChildhoodBackgroundId = character.ChildhoodBackgroundId;
                character.CharacterAvatarUrl = character.CharacterAvatarUrl;
                character.BirthPoloId = character.BirthPoloId;
                character.CurrentLocationId = character.BirthPoloId == 1 ? 1 : character.BirthPoloId == 2 ? 3 : 0;
                character.TypeOfMagicId = character.TypeOfMagicId;
                character.WayOfMagicId = character.TypeOfMagicId == 1 ? null : 1;
                usuario.hasCharacter = true;

                _context.Characters.Add(character);


                await _context.SaveChangesAsync();

                return new ApiResponse { Success = true, Message = "Personagem criado com sucesso" };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Success = false, Message = ex.Message };
            }
        }
    }



}

