using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos.RegionDto;

public class CreatePoloDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int RegionId { get; set; }
    
}