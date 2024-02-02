using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Services.Usuario;

namespace UsuariosApi.Services.CharacterService
{
    public class CharacterService
    {
        private IMapper _mapper;
        private TokenService _tokenService;
        private readonly ICharacterRepository _characterRepository;
        private readonly UsuarioService _usuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<UsuariosApi.Models.Usuario> _userManager;
        private readonly ACDbContext _context; // Substitua MeuDbContext pelo nome real do seu DbContext

        public CharacterService(IMapper mapper, IHttpContextAccessor httpContextAccessor, ACDbContext context,
            UserManager<Models.Usuario> userManager, TokenService tokenService,
            ICharacterRepository characterRepository, UsuarioService usuarioService)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _characterRepository = characterRepository;
            _usuarioService = usuarioService;
        }

        public async Task<ApiResponse> CriaPersonagem(CreateCharacterDto dto)
        {
            try
            {
                var userId = _usuarioService.GetCurrentUserId();
                var usuario = _characterRepository.FindUserByIdAsync(userId);

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
                character.Thinkings = character.Thinkings;
                character.BirthPoloId = character.BirthPoloId;
                var polo = await _context.Polos.FirstOrDefaultAsync(x => x.Id == dto.BirthPoloId);
                var nonResidentialLocation = await _context.Locations
                    .Where(l => l.PoloId == character.BirthPoloId && l.TypeId != LocationType.Residencia)
                    .FirstOrDefaultAsync();
                if (nonResidentialLocation != null)
                {
                    character.CurrentLocationId = nonResidentialLocation.Id;
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Não foi possível encontrar uma localização não residencial no polo de nascimento"
                    };
                }

                character.TypeOfMagicId = character.TypeOfMagicId;
                character.WayOfMagicId = character.TypeOfMagicId == 1 ? null : 1;
                usuario.hasCharacter = true;


                _context.Characters.Add(character);


                await _context.SaveChangesAsync();
                //isto esta errado
                usuario.MainCharacterId = character.Id;
                await _context.SaveChangesAsync();

                return new ApiResponse { Success = true, Message = "Personagem criado com sucesso" };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Success = false, Message = ex.Message };
            }
        }

        public async Task<ApiResponse> GetCharacter(int id)
        {
            try
            {
                var character = await _context.Characters
                    .Include(c => c.CurrentLocation)
                    .ThenInclude(l => l.Polo) // Carrega a entidade Polo relacionada
                    .Include(w => w.WayOfMagic)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (character == null)
                {
                    return new ApiResponse { Success = false, Message = "Personagem não encontrado" };
                }

                var characterDto = _mapper.Map<GetCharacterDto>(character);
                characterDto.CurrentLocationName =
                    character.CurrentLocation.Name; // Mapeia o nome da localização para o DTO
                characterDto.CurrentLocationPoloName =
                    character.CurrentLocation.Polo.Name; // Mapeia o nome do polo para o DTO
                characterDto.WayOfMagicName =
                    character.WayOfMagic.Name;


                return new ApiResponse { Success = true, Message = "Personagem encontrado", Data = characterDto };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Success = false, Message = ex.Message };
            }
        }

        public async Task<ApiResponse> ChangeActiveCharacter(int newCharacterId)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue("id");
            var usuario = await _userManager.FindByIdAsync(userId);
            var character = await _context.Characters.FindAsync(newCharacterId);
            if (usuario == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Usuário não encontrado."
                };
            }

            bool isValidCharacter = VerifyCharacterOwner(usuario, character);
            if (!isValidCharacter)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Personagem inválido ou não pertence ao usuário."
                };
            }

            var changeDto = new JwtTokenDto
            {
                Email = usuario.Email,
                Id = usuario.Id.ToString(),
                Role = usuario.Role,
                ActiveCharacter = newCharacterId
            };

            string newToken = _tokenService.GenerateToken(changeDto);

            return new ApiResponse
            {
                Success = true,
                Message = "Personagem ativo alterado com sucesso.",
                Data = newToken
            };
        }

        public async Task<ApiResponse> VerifyCharOwner(int id)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue("id");
            if (userId == null)
            {
                return new ApiResponse { Success = false, Message = "Usuário não encontrado" };
            }

            var usuario = await _userManager.FindByIdAsync(userId);

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return new ApiResponse { Success = false, Message = "Personagem não encontrado" };
            }

            if (usuario == null)
            {
                return new ApiResponse { Success = false, Message = "Usuário não encontrado" };
            }

            var characters = await _context.Characters.Where(x => x.UsuarioId == userId).ToListAsync();


            if (!characters.Contains(character))
            {
                return new ApiResponse { Success = false, Message = "Este personagem não pertence a você" };
            }

            return new ApiResponse { Success = true, Message = "Este personagem pertence a você" };
        }

        public bool VerifyCharacterOwner(Models.Usuario usuario, Character character)
        {
            if (usuario == null)
            {
                return false;
            }

            var characters = _context.Characters.Where(x => x.UsuarioId == usuario.Id).ToList();

            if (!characters.Contains(character))
            {
                return false;
            }

            return true;
        }
    }
}