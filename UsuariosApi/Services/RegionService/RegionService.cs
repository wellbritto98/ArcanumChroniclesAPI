using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos.RegionDto;

namespace UsuariosApi.Services;

public class RegionService
{
    private IMapper _mapper;
    private readonly ACDbContext _context;

    public RegionService(IMapper mapper, ACDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ApiResponse> CreatePolo(CreatePoloDto dto)
    {
        Polo polo = _mapper.Map<Polo>(dto);
        _context.Polos.Add(polo);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Polo criado com sucesso!" };
    }
    
    public async Task<List<Polo>> GetPolos()
    {
        return await _context.Polos.ToListAsync();
    }
}