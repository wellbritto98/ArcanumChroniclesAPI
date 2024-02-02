using System.Security.Claims;
using UsuariosApi.Data;

namespace UsuariosApi.Repository;

public class CharacterRepository : ICharacterRepository
{
    private readonly ACDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterRepository(ACDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Character> FindUserByIdAsync(string id)
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirstValue("id");
        return await _context.Characters.FindAsync(userId);
    }

    public void Add(Character character)
    {
        _context.Characters.Add(character);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    // Implementação de outros métodos
}
