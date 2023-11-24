using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos.CharacterDto;
using UsuariosApi.Models;

namespace UsuariosApi.Services.CharacterService;

public class NameService
{
    private IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ACDbContext _context;

    public NameService(IMapper mapper, IHttpContextAccessor httpContextAccessor, ACDbContext context)
    {
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }
    
    public async Task<ApiResponse> CreateName(CreateNameDto dto)
    {
        Name name = _mapper.Map<Name>(dto);
        _context.Names.Add(name);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Nome criado com sucesso!" };
    }

    public async Task<ApiResponse> CreateSurname(CreateSurnameDto dto)
    {
        Surname name = _mapper.Map<Surname>(dto);
        _context.Surnames.Add(name);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Sobrenome criado com sucesso!" };
        
    }
    public async Task<List<Name>> GetFemNames()
    {
        return await _context.Names
            .Where(nome => nome.Gender.Equals("f")) // Use aspas duplas para uma string
            .ToListAsync();
    }
    
    public async Task<List<Surname>> GetSurnames()
    {
        return await _context.Surnames.ToListAsync();
    }


    public async Task<List<Name>> GetMaleNames()
    {
        return await _context.Names.Where(nome => nome.Gender.Equals("m")).ToListAsync();
    }
    
    public async Task DeleteName(string nameChar)
    {
        Name name = await _context.Names.FindAsync(nameChar);
        _context.Names.Remove(name);
        await _context.SaveChangesAsync();
    }
    
    

}