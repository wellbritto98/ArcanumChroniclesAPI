using AutoMapper;
using System.Security.Claims;
using UsuariosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Services.CharacterService
{


    public class CharacterService
    {
        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ACDbContext _context; // Substitua MeuDbContext pelo nome real do seu DbContext

        public CharacterService(IMapper mapper, IHttpContextAccessor httpContextAccessor, ACDbContext context)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<ResultadoOperacao> CriaPersonagem(CreateCharacterDto dto)
        {
            try
            {
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue("id");
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

                _context.Characters.Add(character);


                await _context.SaveChangesAsync();

                return new ResultadoOperacao(true, "Personagem criado com sucesso.");
            }
            catch (Exception ex)
            {
                return new ResultadoOperacao(false, "Erro ao criar personagem: " + ex.Message);
            }
        }
    }


    public class ResultadoOperacao
    {
        public bool Sucesso { get; }
        public string Mensagem { get; }

        public ResultadoOperacao(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}

