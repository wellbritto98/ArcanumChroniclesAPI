using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos.TypeOfMagicDto;

namespace UsuariosApi.Services.TypeOfMagicService;

public class TypeOfMagicService
{
    private IMapper _mapper;
    private readonly ACDbContext _context;

    public TypeOfMagicService(IMapper mapper, ACDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ApiResponse> CreateTypeOfMagic(CreateTypeOfMagicDto dto)
    {
        TypeOfMagic typeOfMagic = _mapper.Map<TypeOfMagic>(dto);
        _context.TypesOfMagic.Add(typeOfMagic);
        await _context.SaveChangesAsync();
        return new ApiResponse { Success = true, Message = "Tipo de magia criado com sucesso!" };
    }
    
    public async Task<List<TypeOfMagic>> GetTypesOfMagic()
    {
        return await _context.TypesOfMagic.ToListAsync();
    }
    
    public async Task DeleteTypeOfMagic(string typeOfMagicName)
    {
        TypeOfMagic typeOfMagic = await _context.TypesOfMagic.FindAsync(typeOfMagicName);
        _context.TypesOfMagic.Remove(typeOfMagic);
        await _context.SaveChangesAsync();
    }
    
    public async Task<ApiResponse> UpdateTypeOfMagic(UpdateTypeOfMagicDto dto)
    {
        TypeOfMagic typeOfMagic = await _context.TypesOfMagic.FindAsync(dto.Name);
        if (typeOfMagic == null)
        {
            return new ApiResponse { Success = false, Message = "Tipo de magia não encontrado!" };
        }
        else
        {
            typeOfMagic.Description = dto.Description;
            await _context.SaveChangesAsync();
            return new ApiResponse { Success = true, Message = "Tipo de magia atualizado com sucesso!" };
        }
    }
    
    public async Task<TypeOfMagic> GetTypeOfMagic(int id)
    {
        return await _context.TypesOfMagic.FindAsync(id);
    }
    
    
}