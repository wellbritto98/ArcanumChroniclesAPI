using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos.BackgroundDto;
using UsuariosApi.Models;

namespace UsuariosApi.Services.BackgroundService;

public class CharBackgroundService
{
    private IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ACDbContext _context; // Substitua MeuDbContext pelo nome real do seu DbContext

    public CharBackgroundService(IMapper mapper, IHttpContextAccessor httpContextAccessor, ACDbContext context)
    {
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }

    public async Task<ApiResponse> CreateChildhoodBackground(CreateChildhoodBackgroundDto dto)
    {
        ChildhoodBackground childhoodBackground = _mapper.Map<ChildhoodBackground>(dto);
        _context.ChildhoodBackgrounds.Add(childhoodBackground);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Childhood Background criado com sucesso !" };
    }

    public async Task<ApiResponse> CreateFatherBackground(CreateFatherBackgroundDto dto)
    {
        FatherBackground fatherBackground = _mapper.Map<FatherBackground>(dto);

        _context.FatherBackgrounds.Add(fatherBackground);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Father Background criado com sucesso !" };
    }

    public async Task<ApiResponse> CreateMotherBackground(CreateMotherBackgroundDto dto)
    {
        MotherBackground motherBackground = _mapper.Map<MotherBackground>(dto);
        _context.MotherBackgrounds.Add(motherBackground);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Mother Background criado com sucesso !" };
    }

    public async Task<List<ChildhoodBackground>> GetChildhoodBackgrounds()
    {
        return await _context.ChildhoodBackgrounds.ToListAsync();
    }

    public async Task<List<FatherBackground>> GetFatherBackgrounds()
    {
        return await _context.FatherBackgrounds.ToListAsync();
    }

    public async Task<List<MotherBackground>> GetMotherBackgrounds()
    {
        return await _context.MotherBackgrounds.ToListAsync();
    }

    public async Task DeleteChildhoodBackground(int id)
    {
        ChildhoodBackground childhoodBackground = await _context.ChildhoodBackgrounds.FindAsync(id);
        _context.ChildhoodBackgrounds.Remove(childhoodBackground);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteFatherBackground(int id)
    {
        FatherBackground fatherBackground = await _context.FatherBackgrounds.FindAsync(id);
        _context.FatherBackgrounds.Remove(fatherBackground);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteMotherBackground(int id)
    {
        MotherBackground motherBackground = await _context.MotherBackgrounds.FindAsync(id);
        _context.MotherBackgrounds.Remove(motherBackground);
        await _context.SaveChangesAsync();
    }
    
    
}